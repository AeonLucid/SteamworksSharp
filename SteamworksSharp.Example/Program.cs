using System;
using SteamworksSharp.Native;

namespace SteamworksSharp.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int appId = 480;

            // Load native steam binaries.
            SteamNative.Initialize();

            // Use steam stuff.
            if (SteamApi.IsSteamRunning())
            {
                // Provide appId so it automatically creates a "steam_appid.txt" file.
                if (SteamApi.Initialize(appId))
                {
                    Console.WriteLine($"Logged in as: {SteamApi.SteamFriends.GetPersonaName()}");
                }
                else
                {
                    Console.WriteLine("SteamApi failed to initialize.");
                }
            }
            else
            {
                Console.WriteLine("Steam is not running.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
