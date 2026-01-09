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
        private void Awake()
        {
            // Plugin startup logic
            Configuration.InitSettings(Config);
            Logger = base.Logger;
            Logger.LogInfo($"Plugin NOFrameLimiter is loaded!");
            Logger.LogInfo($"FrameRateLimit: {Configuration.FrameRateLimit.Value}");
            SetTargetFrameRate();
        }

        private void Update()
        {
            if (Application.targetFrameRate != Configuration.FrameRateLimit.Value)
            {
                SetTargetFrameRate();
                Logger.LogInfo($"FrameRateLimit: {Application.targetFrameRate}");
            }

        }

        private static void SetTargetFrameRate()
        {
            Application.targetFrameRate = Configuration.FrameRateLimit.Value;            
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
            FrameRateLimit = config.Bind(GeneralSettings, "FrameRateLimit", DefaultFrameRateLimit, $"Maximum Desired Frame Rate. -1 = Unlimited. Default = {DefaultFrameRateLimit}");
        }
    }
}


