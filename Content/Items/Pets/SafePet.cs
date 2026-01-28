using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.Audio;

namespace CanWeGetMuchHigher.Content.Items.Pets
{
    internal class SafePet : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = new SoundStyle("CanWeGetMuchHigher/Content/Sounds/Safe");
            Item.value = Item.buyPrice(0, 4, 20, 0);

            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.SafePetProj>();
            Item.buffType = ModContent.BuffType<Buffs.SafePetBuff>();
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