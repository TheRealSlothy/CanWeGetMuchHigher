using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;


namespace CanWeGetMuchHigher.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    
    internal class PimpWing : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(125, 4f, 1.25f);
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.accessory = true;

            Item.value = Item.sellPrice(silver: 420);
            Item.rare = ItemRarityID.Purple;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, 
            ref float maxCanAscendMultiplier, ref float maxAscendMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 1.55f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1.15f;
            maxAscendMultiplier = 2.2f;
            constantAscend = 0.1f;
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