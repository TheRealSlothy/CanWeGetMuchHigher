using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using System;


namespace CanWeGetMuchHigher.Content.Items.Weapons
{
    internal class Draco : ModItem
    {

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 47;
            Item.height = 22;

            Item.useTime = 10;
            Item.useAnimation = 10;

            Item.useStyle = ItemUseStyleID.Shoot;

            Item.autoReuse = true;

            Item.UseSound = new SoundStyle("CanWeGetMuchHigher/Content/Sounds/GlockSound");

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 69;
            Item.knockBack = 5f;
            Item.noMelee = true;

            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 16f;

            Item.useAmmo = ModContent.ItemType<Weapons.Ammo.DracoAmmo>();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3f, 1f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 40f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            position += new Vector2(0f, -6f);
            
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);

            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(position, 0, 0, DustID.Smoke, velocity.X * 0.1f, velocity.Y * 0.1f, 100, default, 1.2f);
                dust.velocity *= 0.3f;
                dust.noGravity = true;
            }

            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile<Tiles.WeedBench>();
            recipe.Register();
        }
    }
}