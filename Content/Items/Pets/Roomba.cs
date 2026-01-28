using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;


namespace CanWeGetMuchHigher.Content.Items.Pets
{
    internal class Roomba : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item3;
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.buyPrice(0, 0, 75, 0);

            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.RoombaProj>();
            Item.buffType = ModContent.BuffType<Buffs.RoombaBuff>();
        }

        public override bool CanUseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.AddBuff(Item.buffType, 3600);
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient<Items.Materials.OGKush>()
                .AddTile<Tiles.WeedBench>()
                .Register();
        }
    }
}