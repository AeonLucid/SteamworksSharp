using System;
using System.Reflection;
using System.Runtime.InteropServices;
using SteamworksSharp.Native.Libs;

namespace SteamworksSharp.Native.Osx_x86
{
    public class NativeLibrary : INativeLibrary
    {
        public OSPlatform Platform { get; } = OSPlatform.OSX;

        public Architecture Architecture { get; } = Architecture.X86;

        public Lazy<byte[]> LibraryBytes { get; } = new Lazy<byte[]>(() => 
            LibUtils.ReadResourceBytes(typeof(NativeLibrary).GetTypeInfo().Assembly, "SteamworksSharp.Native.Linux_x86.libsteam_api.dylib"));

        public string Extension { get; } = "dylib";
    }
}
