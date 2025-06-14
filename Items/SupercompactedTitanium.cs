using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Utility;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace HighTide.SupercompactedItems.Items
{
    internal class SupercompactedTitanium
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("SupercompactedTitanium", "Supercompacted Titanium", "Titanium that has been supercompacted one time.");

        public static void Register()
        {
            string executingPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string assetsPath = Path.Combine(executingPath, "Assets");
            string itemSpritePath = Path.Combine(assetsPath, "Sprites", "Items");
            Texture2D itemTexture = ImageUtils.LoadTextureFromFile(Path.Combine(itemSpritePath, "CompressedTitaniumIngot.png"));

            Sprite itemSprite = ImageUtils.LoadSpriteFromTexture(itemTexture);

            PrefabInfo compactedTitaniumInfo = Info
                .WithIcon(itemSprite);
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

            compactedTitanium.SetRecipe(recipeData)
                .WithCraftingTime(5.0f);

            compactedTitanium.SetUnlock(TechType.Titanium, fragmentsToScan: 0)
                .WithPdaGroupCategory(TechGroup.Resources, TechCategory.BasicMaterials);

            compactedTitanium.Register();
        }
    }
}
