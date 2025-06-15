using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Utility;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace HighTide.SupercompactedItems.Items
{
    internal class DecompressedTitanium
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("DecompressedTitanium", "Titanium", "Ti. Basic building material.")
            .WithIcon(SpriteManager.Get(TechType.Titanium));

        public static void Register()
        {
            CustomPrefab prefab = new CustomPrefab(Info);
            CloneTemplate compactedTitaniumTemplate = new CloneTemplate(prefab.Info, TechType.Titanium);
            prefab.SetGameObject(compactedTitaniumTemplate);

            RecipeData recipeData = new RecipeData
            {
                craftAmount = 0,
                Ingredients =
                {
                    new Ingredient(SupercompactedTitanium.Info.TechType, 1)
                },
                LinkedItems = Enumerable.Repeat(TechType.TitaniumIngot, 10).ToList()
            };

            prefab.SetRecipe(recipeData)
                .WithCraftingTime(2.0f);

            prefab.SetUnlock(TechType.Titanium, fragmentsToScan: 0);

            prefab.Register();
        }
    }
}
