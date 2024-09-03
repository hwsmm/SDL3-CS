using SDL3_CS.Tests;
using SDL;
using static SDL.SDL3;

class Program
{
    public unsafe static void Main(string[] args)
    {
        SDL_SetHint(SDL_HINT_GPU_DRIVER, "vulkan"u8);

        if (SDL_Init(SDL.SDL_InitFlags.SDL_INIT_VIDEO) == SDL_FALSE)
        {
            Console.WriteLine("Failed initalizing SDL Video");
            return;
        }

        BasicTriangle triangle = new BasicTriangle();
        triangle.Init();

        while (true)
        {
            SDL_Event evt;
            while (SDL_PollEvent(&evt) == SDL_bool.SDL_TRUE)
            {
                if (evt.Type == SDL_EventType.SDL_EVENT_QUIT)
                {
                    triangle.Quit();
                    break;
                }
            }

            triangle.Update();
            triangle.Draw();
        }
    }
}
