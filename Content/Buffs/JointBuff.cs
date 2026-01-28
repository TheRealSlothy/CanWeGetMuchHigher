using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace CanWeGetMuchHigher.Content.Buffs
{
    internal class JointBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffNoSave[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.maxMinions += 1;
            player.GetDamage(DamageClass.Ranged) += 0.20f;
            player.statLifeMax2 += 100;

            Dust.NewDust(player.position, player.width, player.height, DustID.Smoke);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams)
        {
            Texture2D texture = ModContent.Request<Texture2D>("CanWeGetMuchHigher/Content/Buffs/JointBuff").Value;

            Vector2 position = drawParams.Position;
            Rectangle? sourceRectangle = null;
            Color color = Color.White;
            float rotation = 0f;
            Vector2 origin = Vector2.Zero;

            float scale = 0.9f;

            spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, SpriteEffects.None, 0f);

            return false;
        }
    }
}