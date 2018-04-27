using System;
using Valve.Interop;
using Valve.Steamworks;

namespace SteamworksSharp
{
    // ReSharper disable InconsistentNaming
    public static class SteamApi
    {
        /// <summary>
        ///     This method must be called before doing anything else.
        /// </summary>
        /// <returns>True if initialized successfully.</returns>
        public static bool Initialize()
        {
            var retVal = SteamAPIInterop.SteamAPI_Init();

            if (retVal)
            {
                retVal = CSteamAPIContext.Initialize();
            }

            return retVal;
        }

        public static CSteamClient SteamClient => new CSteamClient(CSteamAPIContext.m_pSteamClient);

        public static CSteamUser SteamUser => new CSteamUser(CSteamAPIContext.m_pSteamUser);

        public static CSteamFriends SteamFriends => new CSteamFriends(CSteamAPIContext.m_pSteamFriends);

        public static CSteamUtils SteamUtils => new CSteamUtils(CSteamAPIContext.m_pSteamUtils);

        public static CSteamMatchmaking SteamMatchmaking => new CSteamMatchmaking(CSteamAPIContext.m_pSteamMatchmaking);

        public static CSteamUserStats SteamUserStats => new CSteamUserStats(CSteamAPIContext.m_pSteamUserStats);

        public static CSteamApps SteamApps => new CSteamApps(CSteamAPIContext.m_pSteamUtils);

        public static CSteamMatchmakingServers SteamMatchmakingServers => new CSteamMatchmakingServers(CSteamAPIContext.m_pSteamMatchmakingServers);

        public static CSteamNetworking SteamNetworking => new CSteamNetworking(CSteamAPIContext.m_pSteamNetworking);

        public static CSteamRemoteStorage SteamRemoteStorage => new CSteamRemoteStorage(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamScreenshots SteamScreenshots => new CSteamScreenshots(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamHTTP SteamHTTP => new CSteamHTTP(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamController SteamController => new CSteamController(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamUGC SteamUGC => new CSteamUGC(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamAppList SteamAppList => new CSteamAppList(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamMusic SteamMusic => new CSteamMusic(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamMusicRemote SteamMusicRemote => new CSteamMusicRemote(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamHTMLSurface SteamHTMLSurface => new CSteamHTMLSurface(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamInventory SteamInventory => new CSteamInventory(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamVideo SteamVideo => new CSteamVideo(CSteamAPIContext.m_pSteamRemoteStorage);

        public static CSteamParentalSettings SteamParentalSettings => new CSteamParentalSettings(CSteamAPIContext.m_pSteamRemoteStorage);

        public static void RestartAppIfNecessary(uint appId)
        {
            SteamAPIInterop.SteamAPI_RestartAppIfNecessary(appId);
        }

        public static void RunCallbacks()
        {
            SteamAPIInterop.SteamAPI_RunCallbacks();
        }

        public static void RegisterCallback(IntPtr pCallback, int iCallback)
        {
            SteamAPIInterop.SteamAPI_RegisterCallback(pCallback, iCallback);
        }

        public static void UnregisterCallback(IntPtr pCallback)
        {
            SteamAPIInterop.SteamAPI_UnregisterCallback(pCallback);
        }

        public static bool IsSteamRunning()
        {
            return NativeEntrypoints.SteamAPI_IsSteamRunning();
        }
    }
}
