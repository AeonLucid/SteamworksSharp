using System;
using Valve.Interop;

namespace SteamworksSharp
{
    // ReSharper disable InconsistentNaming
    internal static class CSteamAPIContext
    {
        internal static IntPtr m_pSteamClient;
        internal static IntPtr m_pSteamUser;
        internal static IntPtr m_pSteamFriends;
        internal static IntPtr m_pSteamUtils;
        internal static IntPtr m_pSteamMatchmaking;
        internal static IntPtr m_pSteamUserStats;
        internal static IntPtr m_pSteamApps;
        internal static IntPtr m_pSteamMatchmakingServers;
        internal static IntPtr m_pSteamNetworking;
        internal static IntPtr m_pSteamRemoteStorage;
        internal static IntPtr m_pSteamScreenshots;
        internal static IntPtr m_pSteamHTTP;
        internal static IntPtr m_pController;
        internal static IntPtr m_pSteamUGC;
        internal static IntPtr m_pSteamAppList;
        internal static IntPtr m_pSteamMusic;
        internal static IntPtr m_pSteamMusicRemote;
        internal static IntPtr m_pSteamHTMLSurface;
        internal static IntPtr m_pSteamInventory;
        internal static IntPtr m_pSteamVideo;
        internal static IntPtr m_pSteamParentalSettings;

        private const string SteamclientInterfaceVersion = "SteamClient017";
        private const string SteamuserInterfaceVersion = "SteamUser019";
        private const string SteamfriendsInterfaceVersion = "SteamFriends015";
        private const string SteamutilsInterfaceVersion = "SteamUtils009";
        private const string SteammatchmakingInterfaceVersion = "SteamMatchMaking009";
        private const string SteammatchmakingserversInterfaceVersion = "SteamMatchMakingServers002";
        private const string SteamuserstatsInterfaceVersion = "STEAMUSERSTATS_INTERFACE_VERSION011";
        private const string SteamappsInterfaceVersion = "STEAMAPPS_INTERFACE_VERSION008";
        private const string SteamnetworkingInterfaceVersion = "SteamNetworking005";
        private const string SteamremotestorageInterfaceVersion = "STEAMREMOTESTORAGE_INTERFACE_VERSION014";
        private const string SteamscreenshotsInterfaceVersion = "STEAMSCREENSHOTS_INTERFACE_VERSION003";
        private const string SteamhttpInterfaceVersion = "STEAMHTTP_INTERFACE_VERSION002";
        private const string SteamcontrollerInterfaceVersion = "SteamController006";
        private const string SteamugcInterfaceVersion = "STEAMUGC_INTERFACE_VERSION010";
        private const string SteamapplistInterfaceVersion = "STEAMAPPLIST_INTERFACE_VERSION001";
        private const string SteammusicInterfaceVersion = "STEAMMUSIC_INTERFACE_VERSION001";
        private const string SteammusicremoteInterfaceVersion = "STEAMMUSICREMOTE_INTERFACE_VERSION001";
        private const string SteamhtmlsurfaceInterfaceVersion = "STEAMHTMLSURFACE_INTERFACE_VERSION_004";
        private const string SteaminventoryInterfaceVersion = "STEAMINVENTORY_INTERFACE_V002";
        private const string SteamvideoInterfaceVersion = "STEAMVIDEO_INTERFACE_V002";
        private const string SteamparentalsettingsInterfaceVersion = "STEAMPARENTALSETTINGS_INTERFACE_VERSION001";

        public static bool Initialize()
        {
            var hSteamUser = (uint) NativeEntrypoints.SteamAPI_GetHSteamUser();
            var hSteamPipe = (uint) NativeEntrypoints.SteamAPI_GetHSteamPipe();

            if (hSteamPipe == 0)
                return false;

            m_pSteamClient = NativeEntrypoints.SteamInternal_CreateInterface(SteamclientInterfaceVersion);
            if (m_pSteamClient == IntPtr.Zero)
                return false;

            m_pSteamUser = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamUser(m_pSteamClient, hSteamUser, hSteamPipe, SteamuserInterfaceVersion);
            if (m_pSteamUser == IntPtr.Zero)
                return false;

            m_pSteamFriends = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamFriends(m_pSteamClient, hSteamUser, hSteamPipe, SteamfriendsInterfaceVersion);
            if (m_pSteamFriends == IntPtr.Zero)
                return false;

            m_pSteamUtils = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamUtils(m_pSteamClient, hSteamPipe, SteamutilsInterfaceVersion);
            if (m_pSteamUtils == IntPtr.Zero)
                return false;

            m_pSteamMatchmaking = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamMatchmaking(m_pSteamClient, hSteamUser, hSteamPipe, SteammatchmakingInterfaceVersion);
            if (m_pSteamMatchmaking == IntPtr.Zero)
                return false;

            m_pSteamMatchmakingServers = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamMatchmakingServers(m_pSteamClient, hSteamUser, hSteamPipe, SteammatchmakingserversInterfaceVersion);
            if (m_pSteamMatchmakingServers == IntPtr.Zero)
                return false;

            m_pSteamUserStats = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamUserStats(m_pSteamClient, hSteamUser, hSteamPipe, SteamuserstatsInterfaceVersion);
            if (m_pSteamUserStats == IntPtr.Zero)
                return false;

            m_pSteamApps = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamApps(m_pSteamClient, hSteamUser, hSteamPipe, SteamappsInterfaceVersion);
            if (m_pSteamApps == IntPtr.Zero)
                return false;

            m_pSteamNetworking = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamNetworking(m_pSteamClient, hSteamUser, hSteamPipe, SteamnetworkingInterfaceVersion);
            if (m_pSteamNetworking == IntPtr.Zero)
                return false;

            m_pSteamRemoteStorage = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamRemoteStorage(m_pSteamClient, hSteamUser, hSteamPipe, SteamremotestorageInterfaceVersion);
            if (m_pSteamRemoteStorage == IntPtr.Zero)
                return false;

            m_pSteamScreenshots = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamScreenshots(m_pSteamClient, hSteamUser, hSteamPipe, SteamscreenshotsInterfaceVersion);
            if (m_pSteamScreenshots == IntPtr.Zero)
                return false;

            m_pSteamHTTP = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamHTTP(m_pSteamClient, hSteamUser, hSteamPipe, SteamhttpInterfaceVersion);
            if (m_pSteamHTTP == IntPtr.Zero)
                return false;

            m_pController = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamController(m_pSteamClient, hSteamUser, hSteamPipe, SteamcontrollerInterfaceVersion);
            if (m_pController == IntPtr.Zero)
                return false;

            m_pSteamUGC = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamUGC(m_pSteamClient, hSteamUser, hSteamPipe, SteamugcInterfaceVersion);
            if (m_pSteamUGC == IntPtr.Zero)
                return false;

            m_pSteamAppList = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamAppList(m_pSteamClient, hSteamUser, hSteamPipe, SteamapplistInterfaceVersion);
            if (m_pSteamAppList == IntPtr.Zero)
                return false;

            m_pSteamMusic = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamMusic(m_pSteamClient, hSteamUser, hSteamPipe, SteammusicInterfaceVersion);
            if (m_pSteamMusic == IntPtr.Zero)
                return false;

            m_pSteamMusicRemote = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamMusicRemote(m_pSteamClient, hSteamUser, hSteamPipe, SteammusicremoteInterfaceVersion);
            if (m_pSteamMusicRemote == IntPtr.Zero)
                return false;

            m_pSteamHTMLSurface = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamHTMLSurface(m_pSteamClient, hSteamUser, hSteamPipe, SteamhtmlsurfaceInterfaceVersion);
            if (m_pSteamHTMLSurface == IntPtr.Zero)
                return false;

            m_pSteamInventory = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamInventory(m_pSteamClient, hSteamUser, hSteamPipe, SteaminventoryInterfaceVersion);
            if (m_pSteamInventory == IntPtr.Zero)
                return false;

            m_pSteamVideo = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamVideo(m_pSteamClient, hSteamUser, hSteamPipe, SteamvideoInterfaceVersion);
            if (m_pSteamVideo == IntPtr.Zero)
                return false;

            m_pSteamParentalSettings = NativeEntrypoints.SteamAPI_ISteamClient_GetISteamParentalSettings(m_pSteamClient, hSteamUser, hSteamPipe, SteamparentalsettingsInterfaceVersion);
            if (m_pSteamParentalSettings == IntPtr.Zero)
                return false;

            return true;
        }
    }
}