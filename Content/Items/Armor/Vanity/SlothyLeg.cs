using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CanWeGetMuchHigher.Content.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Legs)]
    internal class SlothyLeg : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
            Item.defense = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }
}