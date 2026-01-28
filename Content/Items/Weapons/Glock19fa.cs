using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;

namespace CanWeGetMuchHigher.Content.Items.Weapons
{
    internal class Glock19fa : ModItem
    {

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 18;

            Item.useTime = 14;
            Item.useAnimation = 14;

            Item.useStyle = ItemUseStyleID.Shoot;

            Item.autoReuse = true;

            Item.UseSound = new SoundStyle("CanWeGetMuchHigher/Content/Sounds/GlockSound");

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 25;
            Item.knockBack = 3f;
            Item.noMelee = true;

            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 5f;

            Item.useAmmo = AmmoID.Bullet;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, 1f);
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