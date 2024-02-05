using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;


namespace MaxStackTextRemover
{
    [BepInPlugin(Guid, Name, Vers)]
    public class Plugin : BaseUnityPlugin
    {
        public const string Guid = "dev.shinra.nostackmaxdisp";
        public const string Name = "Max Stack Text Remover";
        public const string Vers = "2024.205.2043";

        public static ManualLogSource UnityLogger;


        private void Awake()
        {
            UnityLogger = Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
            UnityLogger.LogMessage($"Running \"{Name}\" v{Vers}, thanks for using my mod! -Shinra.");
        }
    }
}
