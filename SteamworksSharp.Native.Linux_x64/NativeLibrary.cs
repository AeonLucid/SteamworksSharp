using System;
using System.Reflection;
using System.Runtime.InteropServices;
using SteamworksSharp.Native.Libs;

namespace SteamworksSharp.Native.Linux_x64
{
    public class NativeLibrary : INativeLibrary
    {
        public OSPlatform Platform { get; } = OSPlatform.Linux;

        public Architecture Architecture { get; } = Architecture.X64;

        public Lazy<byte[]> LibraryBytes { get; } = new Lazy<byte[]>(() => 
            LibUtils.ReadResourceBytes(typeof(NativeLibrary).GetTypeInfo().Assembly, "SteamworksSharp.Native.Linux_x64.libsteam_api.so"));

        public string Extension { get; } = "so";
    }
}
