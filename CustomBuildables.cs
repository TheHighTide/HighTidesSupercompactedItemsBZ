using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Utility;
using UnityEngine;

namespace HighTide.SupercompactedItems
{
    internal class CustomBuildables
    {
        public static void RegisterCustomBuildables()
        {
            Plugin.SendLog("Now attempting to register all custom buildables.", BepInEx.Logging.LogLevel.Warning);
            Plugin.SendLog("Registering \"Supercompactor\".");
            SupercompactorBuildable.Register();
            Plugin.SendLog("Registered \"Supercompactor\"!");
            Plugin.SendLog("All custom buildables should've been registered!");
        }
    }

    public static class SupercompactorBuildable
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("Supercompactor", "Supercompactor", "A device for supercompacting resources.")
            .WithIcon(SpriteManager.Get(TechType.Fabricator));

        public static void Register()
        {
            CustomPrefab prefab = new CustomPrefab(Info);

            prefab.CreateFabricator(out CraftTree.Type treeType)
                .AddTabNode("compact", "Compaction", SpriteManager.Get(TechType.TitaniumIngot))
                .AddTabNode("tier1compact", "Tier 1 Compaction", SpriteManager.Get(TechType.Titanium), parentTabId: "compact")
                .AddCraftNode(SupercompactedTitanium.Info.TechType, "tier1compact")
                .AddCraftNode(SupercompactedCopper.Info.TechType, "tier1compact")
                .AddCraftNode(SupercompactedQuartz.Info.TechType, "tier1compact")
                .AddTabNode("tier2compact", "Tier 2 Compaction", SpriteManager.Get(TechType.TitaniumIngot), parentTabId: "compact")
                .AddTabNode("tier3compact", "Tier 3 Compaction", SpriteManager.Get(TechType.DrillableTitanium), parentTabId: "compact")
                .AddTabNode("decompact", "Decompaction", SpriteManager.Get(TechType.Titanium))
                .AddTabNode("tier1decompact", "Tier 1 Decompaction", SpriteManager.Get(TechType.DrillableTitanium), parentTabId: "decompact")
                .AddTabNode("tier2decompact", "Tier 2 Decompaction", SpriteManager.Get(TechType.TitaniumIngot), parentTabId: "decompact")
                .AddTabNode("tier3decompact", "Tier 3 Decompaction", SpriteManager.Get(TechType.Titanium), parentTabId: "decompact");

            FabricatorTemplate template = new FabricatorTemplate(prefab.Info, treeType)
            {
                FabricatorModel = FabricatorTemplate.Model.Fabricator
            };
            prefab.SetGameObject(template);

            prefab.SetUnlock(TechType.Workbench)
                .WithPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

            prefab.Register();
        }
    }

    public static class SupercompactorBuildableOld
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("Supercompactor", "Supercompactor", "A device for supercompacting resources.")
            .WithIcon(SpriteManager.Get(TechType.Fabricator));

        public static void Register()
        {
            CustomPrefab prefab = new CustomPrefab(Info);
            CloneTemplate fabricatorClone = new CloneTemplate(Info, "9f16d82b-11f4-4eeb-aedf-f2fa2bfca8e3");

            fabricatorClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Wall;

                GameObject model = obj.transform.Find("submarine_fabricator_01").gameObject;

                PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, model);
            };

            prefab.SetGameObject(fabricatorClone);
            prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

            RecipeData recipeData = new RecipeData(
                new Ingredient(TechType.TitaniumIngot, 2),
                new Ingredient(TechType.CopperWire, 2),
                new Ingredient(TechType.ComputerChip, 1),
                new Ingredient(TechType.WiringKit, 1));

            prefab.SetRecipe(recipeData);

            prefab.Register();
        }
    }
}
