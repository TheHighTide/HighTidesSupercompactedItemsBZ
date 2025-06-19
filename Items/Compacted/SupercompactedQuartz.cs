using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Utility;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace HighTide.SupercompactedItems.Items.Compacted
{
    internal class SupercompactedQuartz
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("SupercompactedQuartz", "Supercompacted Quartz", "Quartz that has been supercompacted one time.");

        public static void Register()
        {
            string executingPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string assetsPath = Path.Combine(executingPath, "Assets");
            string itemSpritePath = Path.Combine(assetsPath, "Sprites", "Items");
            Texture2D itemTexture = ImageUtils.LoadTextureFromFile(Path.Combine(itemSpritePath, "CompressedQuartz.png"));

            Sprite itemSprite = ImageUtils.LoadSpriteFromTexture(itemTexture);

            PrefabInfo prefabInfo = Info;
            prefabInfo.WithIcon(itemSprite);
            CustomPrefab prefab = new CustomPrefab(prefabInfo);

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

            prefab.SetRecipe(recipeData)
                .WithCraftingTime(3.5f);

            prefab.SetUnlock(TechType.Quartz, fragmentsToScan: 0)
                .WithPdaGroupCategory(TechGroup.Resources, TechCategory.BasicMaterials);

            prefab.Register();
        }
    }
}
