using System.Globalization;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using UnityEngine;

namespace NOFrameLimiter
{
    [BepInPlugin("KopterBuzz.NOFrameLimiter", "NOFrameLimiter", "0.0.1")]
    [BepInProcess("NuclearOption.exe")]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource? Logger;
        static int internalTargetFramerate = -1;
        private void Awake()
        {
            // Plugin startup logic
            Configuration.InitSettings(Config);
            Logger = base.Logger;
            Logger.LogInfo($"Plugin NOFrameLimiter is loaded!");
            Logger.LogInfo($"FrameRateLimit: {Configuration.FrameRateLimit.Value}");
            Application.targetFrameRate = Configuration.FrameRateLimit.Value;
            internalTargetFramerate = Application.targetFrameRate;
            SetTargetFrameRate();
        }

        private void Update()
        {
            if (internalTargetFramerate != Configuration.FrameRateLimit.Value)
            {
                SetTargetFrameRate();
                Logger.LogInfo($"FrameRateLimit: {Application.targetFrameRate}");
            }

        }

        private static void SetTargetFrameRate()
        {
            if (Configuration.FrameRateLimit.Value < 1)
            {
                Application.targetFrameRate = -1;
                internalTargetFramerate = Application.targetFrameRate + 1;
                return;
            } else
            {
                Application.targetFrameRate = Configuration.FrameRateLimit.Value;
                internalTargetFramerate = Application.targetFrameRate;
                return;
            }
            
        }
    }

    public static class Configuration
    {
        internal const string GeneralSettings = "General Settings";
        internal const int DefaultFrameRateLimit = 60;
        internal static ConfigEntry<int> FrameRateLimit;
        internal static void InitSettings(ConfigFile config)
        {
            Plugin.Logger?.LogInfo("Loading Settings.");
            FrameRateLimit = config.Bind(GeneralSettings, "FrameRateLimit", DefaultFrameRateLimit, $"Maximum Desired Frame Rate. 0 = Unlimited. Default = {DefaultFrameRateLimit}");
        }
    }
}


