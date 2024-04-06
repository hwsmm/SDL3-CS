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
        [return: NativeTypeName("Uint64")]
        public static extern ulong SDL_GetTicks();

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Uint64")]
        public static extern ulong SDL_GetTicksNS();

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Uint64")]
        public static extern ulong SDL_GetPerformanceCounter();

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Uint64")]
        public static extern ulong SDL_GetPerformanceFrequency();

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SDL_Delay([NativeTypeName("Uint32")] uint ms);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SDL_DelayNS([NativeTypeName("Uint64")] ulong ns);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_TimerID")]
        public static extern uint SDL_AddTimer([NativeTypeName("Uint32")] uint interval, [NativeTypeName("SDL_TimerCallback")] delegate* unmanaged[Cdecl]<uint, IntPtr, uint> callback, [NativeTypeName("void*")] IntPtr param2);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_RemoveTimer([NativeTypeName("SDL_TimerID")] uint id);

        [NativeTypeName("#define SDL_MS_PER_SECOND 1000")]
        public const int SDL_MS_PER_SECOND = 1000;

        [NativeTypeName("#define SDL_US_PER_SECOND 1000000")]
        public const int SDL_US_PER_SECOND = 1000000;

        [NativeTypeName("#define SDL_NS_PER_SECOND 1000000000LL")]
        public const long SDL_NS_PER_SECOND = 1000000000L;

        [NativeTypeName("#define SDL_NS_PER_MS 1000000")]
        public const int SDL_NS_PER_MS = 1000000;

        [NativeTypeName("#define SDL_NS_PER_US 1000")]
        public const int SDL_NS_PER_US = 1000;
    }
}
