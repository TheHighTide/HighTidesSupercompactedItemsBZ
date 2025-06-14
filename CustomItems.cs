using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Handlers;

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

            Plugin.SendLog("All custom items should've been registered!");
        }
    }

    public class SupercompactedTitanium
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("SupercompactedTitanium", "Supercompacted Titanium", "Titanium that has been supercompacted one time.")
            .WithIcon(SpriteManager.Get(TechType.TitaniumIngot));

        public static void Register()
        {
            PrefabInfo compactedTitaniumInfo = Info;
            CustomPrefab compactedTitanium = new CustomPrefab(compactedTitaniumInfo);

            CloneTemplate compactedTitaniumTemplate = new CloneTemplate(compactedTitaniumInfo, TechType.TitaniumIngot);
            compactedTitanium.SetGameObject(compactedTitaniumTemplate);

            RecipeData recipeData = new RecipeData
            {
                craftAmount = 1,
                Ingredients =
                {
                    new Ingredient(TechType.TitaniumIngot, 10)
                }
            };

            compactedTitanium.SetRecipe(recipeData);

            compactedTitanium.Register();
        }
    }

    public class SupercompactedCopper
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("SupercompactedCopper", "Supercompacted Copper", "Copper that has been supercompacted one time.")
            .WithIcon(SpriteManager.Get(TechType.Copper));

        public static void Register()
        {
            PrefabInfo compactedCopperInfo = Info;
            CustomPrefab compactedCopper = new CustomPrefab(compactedCopperInfo);

            CloneTemplate compactedCopperTemplate = new CloneTemplate(compactedCopperInfo, TechType.Copper);
            compactedCopper.SetGameObject(compactedCopperTemplate);

            RecipeData recipeData = new RecipeData
            {
                craftAmount = 1,
                Ingredients =
                {
                    new Ingredient(TechType.Copper, 10)
                }
            };

            compactedCopper.SetRecipe(recipeData);

            compactedCopper.Register();
        }
    }

    public class SupercompactedQuartz
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("SupercompactedQuartz", "Supercompacted Quartz", "Quartz that has been supercompacted one time.")
            .WithIcon(SpriteManager.Get(TechType.Quartz));

        public static void Register()
        {
            CustomPrefab prefab = new CustomPrefab(Info);

            CloneTemplate template = new CloneTemplate(prefab.Info, TechType.Quartz);
            prefab.SetGameObject(template);

            RecipeData recipeData = new RecipeData
            {
                craftAmount = 1,
                Ingredients =
                {
                    new Ingredient(TechType.Quartz, 10)
                }
            };

            prefab.SetRecipe(recipeData);

            prefab.Register();
        }
    }
}
