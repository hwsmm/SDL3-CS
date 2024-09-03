using SDL;
using static SDL.SDL3;

namespace SDL3_CS.Tests
{
    public unsafe class BasicTriangle : Common
    {
        public BasicTriangle(SDL_WindowFlags windowFlags = 0)
            : base("BasicTriangle", windowFlags)
        {
        }

        public override void Init()
        {
            SDL_GPUShader* vertexShader = LoadShader(SDL_GPUShaderStage.SDL_GPU_SHADERSTAGE_VERTEX, "RawTriangle.vert.spv", 0, 0, 0, 0);
            SDL_GPUShader* fragmentShader = LoadShader(SDL_GPUShaderStage.SDL_GPU_SHADERSTAGE_FRAGMENT, "SolidColor.frag.spv", 0, 0, 0, 0);

            SDL_GPUColorAttachmentDescription colorAttachmentDescription = new SDL_GPUColorAttachmentDescription()
            {
                format = SDL_GetGPUSwapchainTextureFormat(device, window),
                blendState = new SDL_GPUColorAttachmentBlendState()
                {
                    blendEnable = SDL_bool.SDL_TRUE,
                    alphaBlendOp = SDL_GPUBlendOp.SDL_GPU_BLENDOP_ADD,
                    colorBlendOp = SDL_GPUBlendOp.SDL_GPU_BLENDOP_ADD,
                    colorWriteMask = (SDL_GPUColorComponentFlags)0xF,
                    srcColorBlendFactor = SDL_GPUBlendFactor.SDL_GPU_BLENDFACTOR_ONE,
                    srcAlphaBlendFactor = SDL_GPUBlendFactor.SDL_GPU_BLENDFACTOR_ONE,
                    dstColorBlendFactor = SDL_GPUBlendFactor.SDL_GPU_BLENDFACTOR_ZERO,
                    dstAlphaBlendFactor = SDL_GPUBlendFactor.SDL_GPU_BLENDFACTOR_ZERO
                }
            };

            SDL_GPUGraphicsPipelineCreateInfo pipelineCreateInfo = new SDL_GPUGraphicsPipelineCreateInfo()
            {
                attachmentInfo = new SDL_GPUGraphicsPipelineAttachmentInfo()
                {
                    colorAttachmentCount = 1,
                    colorAttachmentDescriptions = &colorAttachmentDescription
                },
                multisampleState = new SDL_GPUMultisampleState()
                {
                    sampleMask = 0xFFFF
                },
                primitiveType = SDL_GPUPrimitiveType.SDL_GPU_PRIMITIVETYPE_TRIANGLELIST,
                vertexShader = vertexShader,
                fragmentShader = fragmentShader,
                rasterizerState = new SDL_GPURasterizerState()
            };

            pipelineCreateInfo.rasterizerState.fillMode = SDL_GPUFillMode.SDL_GPU_FILLMODE_FILL;
            FillPipeline = SDL_CreateGPUGraphicsPipeline(device, &pipelineCreateInfo);
            if (FillPipeline == null)
                throw new InvalidOperationException("Failed to create graphics pipeline!");

            SDL_ReleaseGPUShader(device, vertexShader);
            SDL_ReleaseGPUShader(device, fragmentShader);
        }

        protected SDL_GPUGraphicsPipeline* FillPipeline;

        public override void Quit()
        {
            SDL_ReleaseGPUGraphicsPipeline(device, FillPipeline);

            Dispose();
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
            SDL_GPUCommandBuffer* cmdbuf = SDL_AcquireGPUCommandBuffer(device);
            if (cmdbuf == null)
                throw new InvalidOperationException("Couldn't get command buffer");

            uint w, h;
            SDL_GPUTexture* swapchainTexture = SDL_AcquireGPUSwapchainTexture(cmdbuf, window, &w, &h);
            if (swapchainTexture != null)
            {
                SDL_GPUColorAttachmentInfo colorAttachmentInfo = new SDL_GPUColorAttachmentInfo()
                {
                    texture = swapchainTexture,
                    clearColor = new SDL_FColor()
                    {
                        r = 0, g = 0, b = 0, a = 1
                    },
                    loadOp = SDL_GPULoadOp.SDL_GPU_LOADOP_CLEAR,
                    storeOp = SDL_GPUStoreOp.SDL_GPU_STOREOP_STORE
                };

                SDL_GPURenderPass* renderPass = SDL_BeginGPURenderPass(cmdbuf, &colorAttachmentInfo, 1, null);
                SDL_BindGPUGraphicsPipeline(renderPass, FillPipeline);
                SDL_DrawGPUPrimitives(renderPass, 3, 1, 0, 0);
                SDL_EndGPURenderPass(renderPass);
            }

            SDL_SubmitGPUCommandBuffer(cmdbuf);
        }
    }
}
