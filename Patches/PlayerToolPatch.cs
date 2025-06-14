using HarmonyLib;

namespace HighTide.SupercompactedItems.Patches
{
    [HarmonyPatch(typeof(PlayerTool))]
    internal class PlayerToolPatch
    {
        [HarmonyPatch(nameof(PlayerTool.Awake))]
        [HarmonyPostfix]
        public static void AwakePostfix(PlayerTool __instance)
        {
            if (__instance is Knife knife)
            {
                Plugin.Log.LogInfo("Attempting to set the knifes damage to 50000 times its original damage (" + (knife.damage * 50000f) + ")!");
                knife.damage *= 50000f;
                knife.drawTime = 0.01f;
                Plugin.Log.LogInfo("The knife should now deal a bit more damage...");
            }
        }
    }
}
