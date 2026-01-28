using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System.Collections.Generic;
using Terraria.DataStructures;
using System.Linq;
using System;


namespace CanWeGetMuchHigher.Content.MyPlayer
{
    internal class SummonChipUI : ModSystem
    {
        //private static bool showSummonDisplay = true;

        public bool showSummonDisplay = true;

        public override void SaveWorldData(TagCompound tag)
        {
            tag["showSummonDisplay"] = showSummonDisplay;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            if (tag.ContainsKey("showSummonDisplay"))
                showSummonDisplay = tag.GetBool("showSummonDisplay");
        }


        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            if (Main.playerInventory) return;
            if (!showSummonDisplay) return;

            Player player = Main.LocalPlayer;

            bool hasShellphone = false;

            int[] shellphoneIDs = new int[]
            {  
                ItemID.Shellphone,
                ItemID.ShellphoneDummy,
                ItemID.ShellphoneSpawn,
                ItemID.ShellphoneOcean,     
                ItemID.ShellphoneHell       
            };

            foreach (Item item in player.inventory)
            {
                if (shellphoneIDs.Contains(item.type))
                {
                    hasShellphone = true;
                    break;
                }
            }

            if (hasShellphone)
            {
                int minions = (int)Math.Round(player.slotsMinions);

                Texture2D summonIcon = ModContent.Request<Texture2D>("CanWeGetMuchHigher/Content/MyPlayer/ChipUI").Value;
                Vector2 iconPosition = new Vector2(1465, 618);
                Rectangle? iconRectangle = null;
                Color color = Color.White;
                float rotation = 0f;
                Vector2 origin = Vector2.Zero;
                float scale = 0.9f;
                spriteBatch.Draw(summonIcon, iconPosition, iconRectangle, color, rotation, origin, scale, SpriteEffects.None, 0f);

                string text = $"{minions} Summons";
                Vector2 position = new Vector2(1485, 615);
                Color textColor = Color.LightGreen;

                Utils.DrawBorderString(spriteBatch, text, position, textColor);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryIndex != -1)
            {
                layers.Insert(inventoryIndex + 1, new LegacyGameInterfaceLayer(
                    "CanWeGetMuchHigher: Summon Toggle Button",
                    DrawToggleButton,
                    InterfaceScaleType.UI)
                );
            }
        }

        private bool DrawToggleButton()
        {
            Player player = Main.LocalPlayer;
            bool hasShellphone = false;

            int[] shellphoneIDs = new int[]
            {
                ItemID.Shellphone,
                ItemID.ShellphoneDummy,
                ItemID.ShellphoneSpawn,
                ItemID.ShellphoneOcean,
                ItemID.ShellphoneHell
            };

            foreach (Item item in player.inventory)
            {
                if (shellphoneIDs.Contains(item.type))
                {
                    hasShellphone = true;
                    break;
                }
            }

            if (!hasShellphone) return true;
            
            if (!Main.playerInventory) return true;

            Vector2 position = new Vector2(1695, 355);
            Rectangle buttonRect = new Rectangle((int)position.X, (int)position.Y, 16, 16);

            bool hovering = buttonRect.Contains(Main.mouseX, Main.mouseY);

            if (hovering)
            {
                if (Main.mouseLeft && Main.mouseLeftRelease)
                {
                    showSummonDisplay = !showSummonDisplay;
                    SoundEngine.PlaySound(SoundID.MenuTick);
                }
            }

            Texture2D buttonTexture = ModContent.Request<Texture2D>("CanWeGetMuchHigher/Content/MyPlayer/ChipUIH").Value;
            float opacity = showSummonDisplay ? 1f : 0.35f;
            //Color drawColor = Color.Gray * opacity;
            Color drawColor = (hovering ? Color.White : Color.LightGreen) * opacity;
            
            Main.spriteBatch.Draw(buttonTexture, buttonRect, drawColor);

            return true;
        }

        public override void AddRecipes()
        {
            foreach (Recipe recipe in Main.recipe)
            {
                if (recipe.HasResult(ItemID.ShellphoneDummy))
                {
                    recipe.AddIngredient(ModContent.ItemType<Items.Materials.SummonChip>());
                }
            }
        }
    }
}