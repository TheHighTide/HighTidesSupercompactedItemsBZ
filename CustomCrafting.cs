using HighTide.SupercompactedItems.Items.Compacted;
using HighTide.SupercompactedItems.Items.Decompacted;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;

namespace HighTide.SupercompactedItems
{
    internal class CustomCrafting
    {
        public static CraftTree.Type RegisterCompactionCraftingTree(CustomPrefab prefab)
        {
            prefab.CreateFabricator(out CraftTree.Type treeType)
                .AddTabNode("compact", "Compaction", SpriteManager.Get(TechType.TitaniumIngot))
                .AddTabNode("tier1compact", "Tier 1 Compaction", SpriteManager.Get(SupercompactedTitanium.Info.TechType), parentTabId: "compact")
                .AddCraftNode(SupercompactedTitanium.Info.TechType, "tier1compact")
                .AddCraftNode(SupercompactedCopper.Info.TechType, "tier1compact")
                .AddCraftNode(SupercompactedQuartz.Info.TechType, "tier1compact")
                .AddCraftNode(SupercompactedUranite.Info.TechType, "tier1compact")
                .AddCraftNode(SupercompactedNickel.Info.TechType, "tier1compact")
                .AddCraftNode(SupercompactedKyanite.Info.TechType, "tier1compact")
                .AddTabNode("tier2compact", "Tier 2 Compaction", SpriteManager.Get(TechType.TitaniumIngot), parentTabId: "compact")
                .AddTabNode("tier3compact", "Tier 3 Compaction", SpriteManager.Get(TechType.DrillableTitanium), parentTabId: "compact")
                .AddTabNode("decompact", "Decompaction", SpriteManager.Get(TechType.Titanium))
                .AddTabNode("tier1decompact", "Tier 1 Decompaction", SpriteManager.Get(TechType.Titanium), parentTabId: "decompact")
                .AddCraftNode(DecompressedTitanium.Info.TechType, "tier1decompact")
                .AddCraftNode(DecompactedCopper.Info.TechType, "tier1decompact")
                .AddCraftNode(DecompactedQuartz.Info.TechType, "tier1decompact")
                .AddCraftNode(DecompactedUraninite.Info.TechType, "tier1decompact")
                .AddCraftNode(DecompactedNickel.Info.TechType, "tier1decompact")
                .AddCraftNode(DecompactedKyanite.Info.TechType, "tier1decompact")
                .AddTabNode("tier2decompact", "Tier 2 Decompaction", SpriteManager.Get(TechType.TitaniumIngot), parentTabId: "decompact")
                .AddTabNode("tier3decompact", "Tier 3 Decompaction", SpriteManager.Get(TechType.Titanium), parentTabId: "decompact");

            return treeType;
        }
    }
}
