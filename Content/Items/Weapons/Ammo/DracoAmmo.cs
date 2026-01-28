using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using System;
using CanWeGetMuchHigher.Content.Projectiles.Weapons;


namespace CanWeGetMuchHigher.Content.Items.Weapons.Ammo
{
    internal class DracoAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 2.25f;

            Item.maxStack = 999;
            Item.consumable = true;

            Item.shoot = ModContent.ProjectileType<DracoProj>();
            Item.ammo = ModContent.ItemType<DracoAmmo>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(999);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
