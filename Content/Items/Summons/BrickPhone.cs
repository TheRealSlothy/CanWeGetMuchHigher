using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace CanWeGetMuchHigher.Content.Items.Summons
{
    internal class BrickPhone : ModItem
    {

        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 10));
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 32;
            Item.maxStack = 20;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = new SoundStyle("CanWeGetMuchHigher/Content/Sounds/BrickPhone");
            Item.useAnimation = 245;
            Item.useTime = 245;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 0f;
            Item.consumable = true;

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10f, 0f);
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