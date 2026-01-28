using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;


namespace CanWeGetMuchHigher.Content.Items.Placeables
{
    internal class Seed1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;


            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useStyle = ItemUseStyleID.Swing;

            Item.autoReuse = true;
            Item.useTurn = true;

            Item.maxStack = 9999;
            Item.consumable = true;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;
            Item.createTile = ModContent.TileType<Tiles.Plant1>();
            Item.placeStyle = 0;

        }
    }
}