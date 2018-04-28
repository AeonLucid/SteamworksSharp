using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using SteamworksSharp.Native.Libs;

namespace SteamworksSharp.Native
{
    public static class SteamNative
    {
        private static readonly List<string> NativeLibraryNames = new List<string> {
            "SteamworksSharp.Native.Linux_x86",
            "SteamworksSharp.Native.Linux_x64",
            "SteamworksSharp.Native.Windows_x86",
            "SteamworksSharp.Native.Windows_x64"
        };

        private static readonly List<INativeLibrary> NativeLibraries = new List<INativeLibrary>();

        private static string CurrentLocation { get; } = Path.GetDirectoryName(typeof(SteamNative).GetTypeInfo().Assembly.Location);

        public static void Initialize()
        {
            // Scan for libraries containing native libs in current directory.
            FindNativeLibraries();
            
            // Write needed native libraries to the disk.
            WriteNativeLibrary();
        }

        private static void FindNativeLibraries()
        {

            foreach (var nativeLibraryLocation in Directory.EnumerateFiles(CurrentLocation, "*.dll", SearchOption.TopDirectoryOnly))
            {
                var nativeLibraryName = Path.GetFileNameWithoutExtension(nativeLibraryLocation);

                // Check if dll name is valid.
                if (NativeLibraryNames.Contains(nativeLibraryName))
                {
                    // Load the assembly.
                    var loadedAssembly = Assembly.Load(new AssemblyName(nativeLibraryName));

                    // Find library type.
                    var libraryType = loadedAssembly.GetTypes().FirstOrDefault(x => typeof(INativeLibrary).GetTypeInfo().IsAssignableFrom(x));
                    if (libraryType != null)
                    {
                        NativeLibraries.Add((INativeLibrary)Activator.CreateInstance(libraryType));
                    }
                }
            }
        }

        private static void WriteNativeLibrary()
        {
            var currentArchitecture = RuntimeInformation.ProcessArchitecture;
            var currentPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? OSPlatform.Windows
                : (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                    ? OSPlatform.Linux
                    : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                        ? OSPlatform.OSX
                        : throw new Exception("Unknown OSPlatform."));
            
            var nativeLibrary = NativeLibraries.FirstOrDefault(x =>
                x.Architecture == currentArchitecture && 
                x.Platform == currentPlatform);

            if (nativeLibrary == null)
            {
                throw new Exception("SteamNative is unable to find native library " +
                                    $"for platform {currentPlatform} and architecture {currentArchitecture}, " +
                                    "have you installed the correct NuGet packages?");
            }

            var destination = Path.Combine(CurrentLocation, $"steam_api.{nativeLibrary.Extension}");

            File.WriteAllBytes(destination, nativeLibrary.LibraryBytes.Value);
        }
    }
}
