// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace SDL
{
    [Flags]
    [Typedef]
    public enum SDL_GPUTextureUsageFlags : uint
    {
        SDL_GPU_TEXTUREUSAGE_SAMPLER = SDL3.SDL_GPU_TEXTUREUSAGE_SAMPLER,
        SDL_GPU_TEXTUREUSAGE_COLOR_TARGET = SDL3.SDL_GPU_TEXTUREUSAGE_COLOR_TARGET,
        SDL_GPU_TEXTUREUSAGE_DEPTH_STENCIL_TARGET = SDL3.SDL_GPU_TEXTUREUSAGE_DEPTH_STENCIL_TARGET,
        SDL_GPU_TEXTUREUSAGE_GRAPHICS_STORAGE_READ = SDL3.SDL_GPU_TEXTUREUSAGE_GRAPHICS_STORAGE_READ,
        SDL_GPU_TEXTUREUSAGE_COMPUTE_STORAGE_READ = SDL3.SDL_GPU_TEXTUREUSAGE_COMPUTE_STORAGE_READ,
        SDL_GPU_TEXTUREUSAGE_COMPUTE_STORAGE_WRITE = SDL3.SDL_GPU_TEXTUREUSAGE_COMPUTE_STORAGE_WRITE,
    }

    [Flags]
    [Typedef]
    public enum SDL_GPUBufferUsageFlags : uint
    {
        SDL_GPU_BUFFERUSAGE_VERTEX = SDL3.SDL_GPU_BUFFERUSAGE_VERTEX,
        SDL_GPU_BUFFERUSAGE_INDEX = SDL3.SDL_GPU_BUFFERUSAGE_INDEX,
        SDL_GPU_BUFFERUSAGE_INDIRECT = SDL3.SDL_GPU_BUFFERUSAGE_INDIRECT,
        SDL_GPU_BUFFERUSAGE_GRAPHICS_STORAGE_READ = SDL3.SDL_GPU_BUFFERUSAGE_GRAPHICS_STORAGE_READ,
        SDL_GPU_BUFFERUSAGE_COMPUTE_STORAGE_READ = SDL3.SDL_GPU_BUFFERUSAGE_COMPUTE_STORAGE_READ,
        SDL_GPU_BUFFERUSAGE_COMPUTE_STORAGE_WRITE = SDL3.SDL_GPU_BUFFERUSAGE_COMPUTE_STORAGE_WRITE,
    }

    [Flags]
    [Typedef]
    public enum SDL_GPUShaderFormat : uint
    {
        SDL_GPU_SHADERFORMAT_SECRET = SDL3.SDL_GPU_SHADERFORMAT_SECRET,
        SDL_GPU_SHADERFORMAT_SPIRV = SDL3.SDL_GPU_SHADERFORMAT_SPIRV,
        SDL_GPU_SHADERFORMAT_DXBC = SDL3.SDL_GPU_SHADERFORMAT_DXBC,
        SDL_GPU_SHADERFORMAT_DXIL = SDL3.SDL_GPU_SHADERFORMAT_DXIL,
        SDL_GPU_SHADERFORMAT_MSL = SDL3.SDL_GPU_SHADERFORMAT_MSL,
        SDL_GPU_SHADERFORMAT_METALLIB = SDL3.SDL_GPU_SHADERFORMAT_METALLIB,
    }

    [Flags]
    [Typedef]
    public enum SDL_GPUColorComponentFlags : byte
    {
        SDL_GPU_COLORCOMPONENT_R = (byte)SDL3.SDL_GPU_COLORCOMPONENT_R,
        SDL_GPU_COLORCOMPONENT_G = (byte)SDL3.SDL_GPU_COLORCOMPONENT_G,
        SDL_GPU_COLORCOMPONENT_B = (byte)SDL3.SDL_GPU_COLORCOMPONENT_B,
        SDL_GPU_COLORCOMPONENT_A = (byte)SDL3.SDL_GPU_COLORCOMPONENT_A,
    }

}