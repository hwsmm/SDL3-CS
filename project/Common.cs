using SDL;
using System.Text;
using static SDL.SDL3;

namespace SDL3_CS.Tests
{
    public abstract unsafe class Common : IDisposable
    {
        protected SDL_Window* window;
        protected SDL_GPUDevice* device;
        private bool disposedValue;

        protected Common(string name, SDL_WindowFlags windowFlags)
        {
            // FIX FLAGS
            device = SDL_CreateGPUDevice(SDL_GPUShaderFormat.SDL_GPU_SHADERFORMAT_SPIRV, SDL_TRUE, (byte*)null);
            if (device == null)
            {
                throw new InvalidOperationException("GPUCreateDevice failed");
            }

            window = SDL_CreateWindow(name, 640, 480, windowFlags);
            if (window == null)
            {
                throw new InvalidOperationException("CreateWindow failed: " + SDL_GetError());
            }

            if (SDL_ClaimWindowForGPUDevice(device, window) == SDL_FALSE)
            {
                throw new InvalidOperationException("GPUClainWindow failed");
            }
        }

        public abstract void Init();

        public abstract void Update();

        public abstract void Draw();

        public abstract void Quit();

        private static readonly byte[] entryStr = Encoding.UTF8.GetBytes("main\0");

        protected SDL_GPUShader* LoadShader(SDL_GPUShaderStage stage, string code,
            uint samplerCount, uint uniformBufferCount, uint storageBufferCount, uint storageTextureCount)
        {
            byte[] codeStr = System.IO.File.ReadAllBytes(code);

            System.Console.WriteLine($"e {entryStr.Length}, c {codeStr.Length}");

            fixed (byte* codeptr = codeStr)
            fixed (byte* entptr = entryStr)
            {
                SDL_GPUShader* shader;
                SDL_GPUShaderCreateInfo shaderInfo = new SDL_GPUShaderCreateInfo()
                {
                    code = codeptr,
                    codeSize = (nuint)codeStr.Length,
                    entryPointName = entptr,
                    format = SDL_GPUShaderFormat.SDL_GPU_SHADERFORMAT_SPIRV,
                    stage = stage,
                    samplerCount = samplerCount,
                    uniformBufferCount = uniformBufferCount,
                    storageBufferCount = storageBufferCount,
                    storageTextureCount = storageTextureCount
                };

                if (SDL_GetGPUDriver(device) == SDL_GPUDriver.SDL_GPU_DRIVER_VULKAN)
                    shader = SDL_CreateGPUShader(device, &shaderInfo);
                else
                    throw new NotSupportedException("Can only use Vulkan with SPIR-V for now.");

                if (shader == null)
                {
                    throw new InvalidOperationException("Failed to create shader");
                }

                return shader;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;

                SDL_ReleaseWindowFromGPUDevice(device, window);
                SDL_DestroyWindow(window);
                SDL_DestroyGPUDevice(device);
            }
        }

        ~Common()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
