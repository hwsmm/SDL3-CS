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
    public enum SDL_IOStatus
    {
        SDL_IO_STATUS_READY,
        SDL_IO_STATUS_ERROR,
        SDL_IO_STATUS_EOF,
        SDL_IO_STATUS_NOT_READY,
        SDL_IO_STATUS_READONLY,
        SDL_IO_STATUS_WRITEONLY,
    }

    public unsafe partial struct SDL_IOStreamInterface
    {
        [NativeTypeName("Sint64 (*)(void *)")]
        public delegate* unmanaged[Cdecl]<IntPtr, long> size;

        [NativeTypeName("Sint64 (*)(void *, Sint64, int)")]
        public delegate* unmanaged[Cdecl]<IntPtr, long, int, long> seek;

        [NativeTypeName("size_t (*)(void *, void *, size_t, SDL_IOStatus *)")]
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, nuint, SDL_IOStatus*, nuint> read;

        [NativeTypeName("size_t (*)(void *, const void *, size_t, SDL_IOStatus *)")]
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, nuint, SDL_IOStatus*, nuint> write;

        [NativeTypeName("int (*)(void *)")]
        public delegate* unmanaged[Cdecl]<IntPtr, int> close;
    }

    public partial struct SDL_IOStream
    {
    }

    public static unsafe partial class SDL3
    {
        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SDL_IOStream* SDL_IOFromFile([NativeTypeName("const char *")] byte* file, [NativeTypeName("const char *")] byte* mode);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SDL_IOStream* SDL_IOFromMem([NativeTypeName("void*")] IntPtr mem, [NativeTypeName("size_t")] nuint size);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SDL_IOStream* SDL_IOFromConstMem([NativeTypeName("const void *")] IntPtr mem, [NativeTypeName("size_t")] nuint size);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SDL_IOStream* SDL_IOFromDynamicMem();

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SDL_IOStream* SDL_OpenIO([NativeTypeName("const SDL_IOStreamInterface *")] SDL_IOStreamInterface* iface, [NativeTypeName("void*")] IntPtr userdata);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int SDL_CloseIO(SDL_IOStream* context);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_PropertiesID")]
        public static extern uint SDL_GetIOProperties(SDL_IOStream* context);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SDL_IOStatus SDL_GetIOStatus(SDL_IOStream* context);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Sint64")]
        public static extern long SDL_GetIOSize(SDL_IOStream* context);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Sint64")]
        public static extern long SDL_SeekIO(SDL_IOStream* context, [NativeTypeName("Sint64")] long offset, int whence);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Sint64")]
        public static extern long SDL_TellIO(SDL_IOStream* context);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint SDL_ReadIO(SDL_IOStream* context, [NativeTypeName("void*")] IntPtr ptr, [NativeTypeName("size_t")] nuint size);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint SDL_WriteIO(SDL_IOStream* context, [NativeTypeName("const void *")] IntPtr ptr, [NativeTypeName("size_t")] nuint size);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint SDL_IOprintf(SDL_IOStream* context, [NativeTypeName("const char *")] byte* fmt, __arglist);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint SDL_IOvprintf(SDL_IOStream* context, [NativeTypeName("const char *")] byte* fmt, [NativeTypeName("va_list")] byte* ap);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("void*")]
        public static extern IntPtr SDL_LoadFile_IO(SDL_IOStream* src, [NativeTypeName("size_t *")] nuint* datasize, [NativeTypeName("SDL_bool")] int closeio);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("void*")]
        public static extern IntPtr SDL_LoadFile([NativeTypeName("const char *")] byte* file, [NativeTypeName("size_t *")] nuint* datasize);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadU8(SDL_IOStream* src, [NativeTypeName("Uint8 *")] byte* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadU16LE(SDL_IOStream* src, [NativeTypeName("Uint16 *")] ushort* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadS16LE(SDL_IOStream* src, [NativeTypeName("Sint16 *")] short* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadU16BE(SDL_IOStream* src, [NativeTypeName("Uint16 *")] ushort* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadS16BE(SDL_IOStream* src, [NativeTypeName("Sint16 *")] short* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadU32LE(SDL_IOStream* src, [NativeTypeName("Uint32 *")] uint* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadS32LE(SDL_IOStream* src, [NativeTypeName("Sint32 *")] int* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadU32BE(SDL_IOStream* src, [NativeTypeName("Uint32 *")] uint* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadS32BE(SDL_IOStream* src, [NativeTypeName("Sint32 *")] int* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadU64LE(SDL_IOStream* src, [NativeTypeName("Uint64 *")] ulong* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadS64LE(SDL_IOStream* src, [NativeTypeName("Sint64 *")] long* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadU64BE(SDL_IOStream* src, [NativeTypeName("Uint64 *")] ulong* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_ReadS64BE(SDL_IOStream* src, [NativeTypeName("Sint64 *")] long* value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteU8(SDL_IOStream* dst, [NativeTypeName("Uint8")] byte value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteU16LE(SDL_IOStream* dst, [NativeTypeName("Uint16")] ushort value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteS16LE(SDL_IOStream* dst, [NativeTypeName("Sint16")] short value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteU16BE(SDL_IOStream* dst, [NativeTypeName("Uint16")] ushort value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteS16BE(SDL_IOStream* dst, [NativeTypeName("Sint16")] short value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteU32LE(SDL_IOStream* dst, [NativeTypeName("Uint32")] uint value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteS32LE(SDL_IOStream* dst, [NativeTypeName("Sint32")] int value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteU32BE(SDL_IOStream* dst, [NativeTypeName("Uint32")] uint value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteS32BE(SDL_IOStream* dst, [NativeTypeName("Sint32")] int value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteU64LE(SDL_IOStream* dst, [NativeTypeName("Uint64")] ulong value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteS64LE(SDL_IOStream* dst, [NativeTypeName("Sint64")] long value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteU64BE(SDL_IOStream* dst, [NativeTypeName("Uint64")] ulong value);

        [DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("SDL_bool")]
        public static extern int SDL_WriteS64BE(SDL_IOStream* dst, [NativeTypeName("Sint64")] long value);

        [NativeTypeName("#define SDL_PROP_IOSTREAM_WINDOWS_HANDLE_POINTER \"SDL.iostream.windows.handle\"")]
        public static ReadOnlySpan<byte> SDL_PROP_IOSTREAM_WINDOWS_HANDLE_POINTER => "SDL.iostream.windows.handle"u8;

        [NativeTypeName("#define SDL_PROP_IOSTREAM_STDIO_FILE_POINTER \"SDL.iostream.stdio.file\"")]
        public static ReadOnlySpan<byte> SDL_PROP_IOSTREAM_STDIO_FILE_POINTER => "SDL.iostream.stdio.file"u8;

        [NativeTypeName("#define SDL_PROP_IOSTREAM_ANDROID_AASSET_POINTER \"SDL.iostream.android.aasset\"")]
        public static ReadOnlySpan<byte> SDL_PROP_IOSTREAM_ANDROID_AASSET_POINTER => "SDL.iostream.android.aasset"u8;

        [NativeTypeName("#define SDL_PROP_IOSTREAM_DYNAMIC_MEMORY_POINTER \"SDL.iostream.dynamic.memory\"")]
        public static ReadOnlySpan<byte> SDL_PROP_IOSTREAM_DYNAMIC_MEMORY_POINTER => "SDL.iostream.dynamic.memory"u8;

        [NativeTypeName("#define SDL_PROP_IOSTREAM_DYNAMIC_CHUNKSIZE_NUMBER \"SDL.iostream.dynamic.chunksize\"")]
        public static ReadOnlySpan<byte> SDL_PROP_IOSTREAM_DYNAMIC_CHUNKSIZE_NUMBER => "SDL.iostream.dynamic.chunksize"u8;

        [NativeTypeName("#define SDL_IO_SEEK_SET 0")]
        public const int SDL_IO_SEEK_SET = 0;

        [NativeTypeName("#define SDL_IO_SEEK_CUR 1")]
        public const int SDL_IO_SEEK_CUR = 1;

        [NativeTypeName("#define SDL_IO_SEEK_END 2")]
        public const int SDL_IO_SEEK_END = 2;
    }
}
