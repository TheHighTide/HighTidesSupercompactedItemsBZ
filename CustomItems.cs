﻿using HighTide.SupercompactedItems.Items;

namespace HighTide.SupercompactedItems
{
    internal class CustomItems
    {
        public static void RegisterCustomItems()
        {
            Plugin.SendLog("Now attempting to register all custom items...", BepInEx.Logging.LogLevel.Warning);

            SupercompactedTitanium.Register();
            SupercompactedCopper.Register();
            SupercompactedQuartz.Register();

            DecompressedTitanium.Register();

            Plugin.SendLog("All custom items should've been registered!");
        }
    }
}
