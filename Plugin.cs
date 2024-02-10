using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using TMPro;


namespace MaxStackTextRemover
{
    [BepInPlugin(Guid, Name, Vers)]
    public class Plugin : BaseUnityPlugin
    {
        public const string Guid = "dev.shinra.nostackmaxdisp";
        public const string Name = "Max Stack Text Remover";
        public const string Vers = "2024.210.1413";

        public static ConfigEntry<string> TextAlignment;

        internal static ManualLogSource UnityLogger;
        internal static TextAlignmentOptions StackTextAlignment;
        internal static string Margin;


        private void Awake()
        {
            UnityLogger = Logger;

            TextAlignment = Config.Bind("Visuals", "Stack size text alignment", "Right",
                "Sets the alignment of the stack size text.\n" +
                "Valid values: Right, Center, Left");

            ParseTextAlignment(TextAlignment.Value);

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
            UnityLogger.LogMessage($"Running \"{Name}\" v{Vers}, thanks for using my mod! -Shinra.");
        }

        private static void ParseTextAlignment(string alignment)
        {
            switch (alignment.ToLower())
            {
                case "left":
                    StackTextAlignment = TextAlignmentOptions.Left;
                    Margin = "<margin-left=3px>";
                    break;

                case "center":
                    StackTextAlignment = TextAlignmentOptions.Center;
                    Margin = string.Empty;
                    break;

                default:
                    StackTextAlignment = TextAlignmentOptions.Right;
                    Margin = "<margin-right=3px>";
                    break;
            }
        }
    }
}
