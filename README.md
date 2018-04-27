SteamworksSharp
===================

Yet another C# steamworks interop library.

## Versions

| Project | NuGet | AppVeyor |
|-|-|-|
| SteamworksSharp | [![AppVeyor](https://img.shields.io/appveyor/ci/AeonLucid/SteamworksSharp/master.svg?maxAge=60)](https://ci.appveyor.com/project/AeonLucid/SteamworksSharp) | [![NuGet](https://img.shields.io/nuget/v/SteamworksSharp.svg?maxAge=60)](https://www.nuget.org/packages/SteamworksSharp) |
| SteamworksSharp.Native.Windows_x86 | [![AppVeyor](https://img.shields.io/appveyor/ci/AeonLucid/SteamworksSharp/master.svg?maxAge=60)](https://ci.appveyor.com/project/AeonLucid/SteamworksSharp) | [![NuGet](https://img.shields.io/nuget/v/SteamworksSharp.Native.Windows_x86.svg?maxAge=60)](https://www.nuget.org/packages/SteamworksSharp.Native.Windows_x86) |
| SteamworksSharp.Native.Windows_x64 | [![AppVeyor](https://img.shields.io/appveyor/ci/AeonLucid/SteamworksSharp/master.svg?maxAge=60)](https://ci.appveyor.com/project/AeonLucid/SteamworksSharp) | [![NuGet](https://img.shields.io/nuget/v/SteamworksSharp.Native.Windows_x64.svg?maxAge=60)](https://www.nuget.org/packages/SteamworksSharp.Native.Windows_x64) |
| SteamworksSharp.Native.Linux_x86 | [![AppVeyor](https://img.shields.io/appveyor/ci/AeonLucid/SteamworksSharp/master.svg?maxAge=60)](https://ci.appveyor.com/project/AeonLucid/SteamworksSharp) | [![NuGet](https://img.shields.io/nuget/v/SteamworksSharp.Native.Linux_x86.svg?maxAge=60)](https://www.nuget.org/packages/SteamworksSharp.Native.Linux_x86) |
| SteamworksSharp.Native.Linux_x64 | [![AppVeyor](https://img.shields.io/appveyor/ci/AeonLucid/SteamworksSharp/master.svg?maxAge=60)](https://ci.appveyor.com/project/AeonLucid/SteamworksSharp) | [![NuGet](https://img.shields.io/nuget/v/SteamworksSharp.Native.Linux_x64.svg?maxAge=60)](https://www.nuget.org/packages/SteamworksSharp.Native.Linux_x64) |

## How do I use this?

Check the example project [here](https://github.com/AeonLucid/SteamworksSharp/tree/master/SteamworksSharp.Example) or follow the steps below.

### Installation
First, install the base package `SteamworksSharp`.

If you are developing for a `x86` platform (most likely not), install;
- `SteamworksSharp.Native.Windows_x86`
- `SteamworksSharp.Native.Linux_x86`

If you are developing for a `x64` platform, install;
- `SteamworksSharp.Native.Windows_x64`
- `SteamworksSharp.Native.Linux_x64`

The native packages provide the necessary steam binaries to use the library.

### Configuration

Add a `steam_appid.txt` to your project, make sure "Copy to Output directory" is set to "Always" and put an appid in it. If you don't know how to find an appid, go to https://steamdb.info/ and search for a game.

### Using the library

First, you have to initialize `SteamApi`.

```csharp
var result = SteamApi.Initialize();
```

If the `result` is `false`, you can not use the library. Either you have not installed the native package for your platform, steam is not running or the `steam_appid.txt` is wrong.

> If you are sure that you have done everything correctly, open the `steam_appid.txt` in a hex editor. Make sure it does not contain a [byte order mark (BOM)](https://en.wikipedia.org/wiki/Byte_order_mark), which looks like `EF BB BF`. If it does, remove it and you are good to go.

You can also check if steam is open.

```csharp
var result = SteamApi.IsSteamRunning();
```

## Why?

Why not?

## License

Do whatever you want a.k.a. MIT. (Except for the steam binaries)