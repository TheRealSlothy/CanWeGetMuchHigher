using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using System;

namespace CanWeGetMuchHigher.Content.Items.MISC
{
    internal class Pearl : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;

            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useStyle = ItemUseStyleID.Shoot;

            Item.autoReuse = false;
            Item.consumable = true;
            Item.maxStack = 9999;
            Item.UseSound = new SoundStyle("CanWeGetMuchHigher/Content/Sounds/GlockSound");
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.buyPrice(0, 0, 75, 0);
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 69;
            Item.knockBack = 5f;
            Item.noMelee = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.PearlProj>();
            Item.shootSpeed = 16f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(5)
                .AddIngredient<Items.Materials.OGKush>()
                .AddTile<Tiles.WeedBench>()
                .Register();
        }
    }
}