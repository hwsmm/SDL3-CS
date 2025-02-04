/*
  <auto-generated/>
  C# bindings for Simple DirectMedia Layer.
  Original copyright notice of input files:

  Simple DirectMedia Layer
  Copyright (C) 1997-2024 Sam Lantinga <slouken@libsdl.org>

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.
*/

using System;
using System.Runtime.InteropServices;

namespace SDL
{
    public static unsafe partial class SDL3
    {
        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SDL_SetMainReady();

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int SDL_RunApp(int argc, [NativeTypeName("char *[]")] byte** argv, [NativeTypeName("SDL_main_func")] delegate* unmanaged[Cdecl]<int, byte**, int> mainFunction, [NativeTypeName("void*")] IntPtr reserved);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int SDL_EnterAppMainCallbacks(int argc, [NativeTypeName("char *[]")] byte** argv, [NativeTypeName("SDL_AppInit_func")] delegate* unmanaged[Cdecl]<IntPtr*, int, byte**, SDL_AppResult> appinit, [NativeTypeName("SDL_AppIterate_func")] delegate* unmanaged[Cdecl]<IntPtr, SDL_AppResult> appiter, [NativeTypeName("SDL_AppEvent_func")] delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDL_AppResult> appevent, [NativeTypeName("SDL_AppQuit_func")] delegate* unmanaged[Cdecl]<IntPtr, SDL_AppResult, void> appquit);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SDL_GDKSuspendComplete();
    }
}
