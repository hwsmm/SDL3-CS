#!/bin/bash

set -e

pushd "$(dirname "$0")"

# Check if environment variables are defined
if [[ -z $1 || -z $NAME || -z $RUNNER_OS || -z $FLAGS || -z $BUILD_TYPE ]]; then
    echo "One or more required environment variables are not defined."
    exit 1
fi

BUILD_PLATFORM="$1"
SUDO=$(which sudo || exit 0)
export DEBIAN_FRONTEND=noninteractive

if [[ $BUILD_PLATFORM == 'android' ]]; then
    if [[ -z $ANDROID_HOME || -z $NDK_VER || -z $PLATFORM_VER || -z $ANDROID_ABI ]]; then
        echo "One or more required environment variables are not defined."
        exit 1
    fi

    export ANDROID_NDK_HOME="$ANDROID_HOME/ndk/$NDK_VER"

    export FLAGS="$FLAGS -DCMAKE_TOOLCHAIN_FILE=$ANDROID_NDK_HOME/build/cmake/android.toolchain.cmake \
                         -DANDROID_HOME=$ANDROID_HOME \
                         -DANDROID_PLATFORM=$PLATFORM_VER \
                         -DANDROID_ABI=$ANDROID_ABI \
                         -DCMAKE_POSITION_INDEPENDENT_CODE=ON \
                         -DCMAKE_FIND_ROOT_PATH_MODE_PACKAGE=BOTH \
                         -DCMAKE_INSTALL_INCLUDEDIR=include \
                         -DCMAKE_INSTALL_LIBDIR=lib \
                         -DCMAKE_INSTALL_DATAROOTDIR=share \
                         -DSDL_ANDROID_JAR=OFF"

    $SUDO apt-get install -y \
            git \
            cmake \
            ninja-build \
            meson
else
    if [[ $RUNNER_OS == 'Linux' ]]; then
        # Setup Linux dependencies
        if [[ $TARGET_APT_ARCH == :i386 ]]; then
            $SUDO dpkg --add-architecture i386
        fi

        $SUDO apt-get update -y -qq

        if [[ $NAME != 'linux-x86' && $NAME != 'linux-x64' ]]; then
            GCC="gcc"
            GPP="g++"
        else
            GCC="gcc-multilib"
            GPP="g++-multilib"
        fi

        $SUDO apt-get install -y \
            $GCC \
            $GPP \
            git \
            cmake \
            ninja-build \
            wayland-scanner++ \
            wayland-protocols \
            meson \
            pkg-config$TARGET_APT_ARCH \
            libasound2-dev$TARGET_APT_ARCH \
            libdbus-1-dev$TARGET_APT_ARCH \
            libegl1-mesa-dev$TARGET_APT_ARCH \
            libgl1-mesa-dev$TARGET_APT_ARCH \
            libgles2-mesa-dev$TARGET_APT_ARCH \
            libglu1-mesa-dev$TARGET_APT_ARCH \
            libgtk-3-dev$TARGET_APT_ARCH \
            libibus-1.0-dev$TARGET_APT_ARCH \
            libpango1.0-dev$TARGET_APT_ARCH \
            libpulse-dev$TARGET_APT_ARCH \
            libsndio-dev$TARGET_APT_ARCH \
            libudev-dev$TARGET_APT_ARCH \
            libwayland-dev$TARGET_APT_ARCH \
            libx11-dev$TARGET_APT_ARCH \
            libxcursor-dev$TARGET_APT_ARCH \
            libxext-dev$TARGET_APT_ARCH \
            libxi-dev$TARGET_APT_ARCH \
            libxinerama-dev$TARGET_APT_ARCH \
            libxkbcommon-dev$TARGET_APT_ARCH \
            libxrandr-dev$TARGET_APT_ARCH \
            libxss-dev$TARGET_APT_ARCH \
            libxt-dev$TARGET_APT_ARCH \
            libxv-dev$TARGET_APT_ARCH \
            libxxf86vm-dev$TARGET_APT_ARCH \
            libdrm-dev$TARGET_APT_ARCH \
            libgbm-dev$TARGET_APT_ARCH \
            libpulse-dev$TARGET_APT_ARCH \
            libpipewire-0.3-dev$TARGET_APT_ARCH \
            libdecor-0-dev$TARGET_APT_ARCH
    fi
fi

if [[ $RUNNER_OS == 'Linux' ]]; then
    git config --global --add safe.directory $PWD/SDL
    git config --global --add safe.directory $PWD/SDL_image
    git config --global --add safe.directory $PWD/SDL_ttf
fi

if [[ $RUNNER_OS == 'Windows' ]]; then
    export OUTPUT_PATTERN="bin/SDL3variant.dll"
elif [[ $RUNNER_OS == 'Linux' ]]; then
    export OUTPUT_PATTERN="lib/libSDL3variant.so"
elif [[ $RUNNER_OS == 'macOS' ]]; then
    export OUTPUT_PATTERN="lib/libSDL3variant.dylib"
fi

# Use the correct CMAKE_PREFIX_PATH for SDL_image and SDL_ttf, probably due differences in Cmake versions.
if [[ $BUILD_PLATFORM == 'android' ]]; then
    export CMAKE_PREFIX_PATH="$PWD/SDL/install_output/"
elif [[ $RUNNER_OS == 'Windows' ]]; then
    export CMAKE_PREFIX_PATH="$PWD/SDL/install_output/cmake/"
elif [[ $RUNNER_OS == 'Linux' ]]; then
    export CMAKE_PREFIX_PATH="$PWD/SDL/install_output/lib/cmake/"
elif [[ $RUNNER_OS == 'macOS' ]]; then
    export CMAKE_PREFIX_PATH="$PWD/SDL/install_output/lib/cmake/"
fi

run_cmake() {
    pushd $1

    git reset --hard HEAD || echo "Failed to clean up the repository"

    if [[ $RUNNER_OS == 'Windows' && $1 == 'SDL' ]]; then
        echo "Patching SDL to not include gameinput.h"
        sed -i 's/#include <gameinput.h>/#_include <gameinput.h>/g' CMakeLists.txt
    fi

    rm -rf build
    cmake -B build $FLAGS -DCMAKE_BUILD_TYPE=$BUILD_TYPE -DSDL_SHARED=ON -DSDL_STATIC=OFF "${@:3}"
    cmake --build build/ --config $BUILD_TYPE
    cmake --install build/ --prefix install_output --config $BUILD_TYPE

    # Move build lib into correct folders
    cp install_output/$2 ../../native/$NAME

    popd
}

run_cmake SDL ${OUTPUT_PATTERN/variant/}

run_cmake SDL_ttf ${OUTPUT_PATTERN/variant/_ttf} -DCMAKE_PREFIX_PATH=$CMAKE_PREFIX_PATH -DCMAKE_POLICY_VERSION_MINIMUM=3.5 -DSDLTTF_VENDORED=ON

run_cmake SDL_image ${OUTPUT_PATTERN/variant/_image} -DCMAKE_PREFIX_PATH=$CMAKE_PREFIX_PATH -DSDLIMAGE_AVIF=OFF -DSDLIMAGE_DEPS_SHARED=OFF -DSDLIMAGE_VENDORED=ON

popd