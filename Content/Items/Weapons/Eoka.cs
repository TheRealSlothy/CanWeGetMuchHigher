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
    internal class Eoka : ModItem
    {

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 19;
            Item.height = 8;

            Item.useTime = 10;
            Item.useAnimation = 10;

            Item.useStyle = ItemUseStyleID.Shoot;

            Item.autoReuse = false;

            Item.UseSound = new SoundStyle("CanWeGetMuchHigher/Content/Sounds/GlockSound");

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 99;
            Item.knockBack = 5f;
            Item.noMelee = true;

            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 16f;

            Item.useAmmo = ModContent.ItemType<Weapons.Ammo.EokaAmmo>();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3f, 1f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Misfire chance: 35%
            if (Main.rand.NextFloat() < 0.35f)
            {
                CombatText.NewText(player.Hitbox, Color.Gray, "Misfire!", true);
                SoundEngine.PlaySound(SoundID.Item16, player.position); // Optional misfire sound
                return false;
            }

            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 40f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            position += new Vector2(0f, -6f);

            int numberProjectiles = 3; // Shoot 3 bullets
            for (int i = 0; i < numberProjectiles; i++)
            {
                // Add some random spread (in radians)
                float spread = MathHelper.ToRadians(6); // 6-degree spread
                float randomRotation = MathHelper.Lerp(-spread, spread, Main.rand.NextFloat());
                Vector2 perturbedSpeed = velocity.RotatedBy(randomRotation) * (1f - Main.rand.NextFloat(0.05f)); // slight random speed reduction
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }

            // Smoke particles
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(position, 0, 0, DustID.Smoke, velocity.X * 0.1f, velocity.Y * 0.1f, 100, default, 1.2f);
                dust.velocity *= 0.3f;
                dust.noGravity = true;
            }

            return false; // Prevent default projectile
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