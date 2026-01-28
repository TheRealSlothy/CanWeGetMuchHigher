using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace CanWeGetMuchHigher.Content.Buffs
{
    internal class SafePetBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SafePetProj>()] <= 0)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position, player.velocity,
                    ModContent.ProjectileType<Projectiles.Pets.SafePetProj>(), 0, 0f, player.whoAmI);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams)
        {
            Texture2D texture = ModContent.Request<Texture2D>("CanWeGetMuchHigher/Content/Buffs/SafePetBuff").Value;

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