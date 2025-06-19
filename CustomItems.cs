using HighTide.SupercompactedItems.Items.Compacted;
using HighTide.SupercompactedItems.Items.Decompacted;

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
            SupercompactedUranite.Register();
            SupercompactedNickel.Register();

            Plugin.SendLog("Registered all supercompacted items!");

            DecompressedTitanium.Register();
            DecompactedCopper.Register();
            DecompactedQuartz.Register();
            DecompactedUraninite.Register();
            DecompactedNickel.Register();

            Plugin.SendLog("Registered all decompacted items!");

            Plugin.SendLog("All custom items should've been registered!");
        }
    }
}
