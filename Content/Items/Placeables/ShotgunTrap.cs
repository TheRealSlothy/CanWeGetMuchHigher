using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;


namespace CanWeGetMuchHigher.Content.Items.Placeables
{
    internal class ShotgunTrap : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;


            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.maxStack = 9999;
            Item.consumable = true;

            Item.createTile = ModContent.TileType<Tiles.ShotgunTrap>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.DirtBlock, 1)
               .Register();

        }
    }
}