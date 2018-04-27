using System;

namespace SteamworksSharp.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (SteamApi.IsSteamRunning())
            {
                if (SteamApi.Initialize())
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
