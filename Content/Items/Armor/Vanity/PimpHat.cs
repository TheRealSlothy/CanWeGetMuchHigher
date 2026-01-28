using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CanWeGetMuchHigher.Content.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    internal class PimpHat : ModItem
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

        public override void SetStaticDefaults()
        {
            //ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = true; // Enables drawing the head
            //ArmorIDs.Head.Sets.Animated[Item.headSlot] = true;
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
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