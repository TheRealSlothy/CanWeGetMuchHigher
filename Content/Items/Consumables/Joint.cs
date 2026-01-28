using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CanWeGetMuchHigher.Content.Items.Consumables
{
    public class Joint : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.EatFood;

            Item.UseSound = SoundID.Item3; // Potion sound
            Item.consumable = true;
            Item.maxStack = 9999;

            Item.buffType = ModContent.BuffType<Buffs.JointBuff>();
            Item.buffTime = 60 * 60 * 10; // 10 minutes in ticks
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 0, 75, 0); // 1 gold
        }

        public override bool CanUseItem(Player player)
        {
            // Optional: prevent use if already buffed
            return !player.HasBuff(Item.buffType);
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