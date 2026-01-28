using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Audio;


namespace CanWeGetMuchHigher.Content.Projectiles.Pets
{
    internal class SafePetProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 28;
            Projectile.aiStyle = 0;
            Projectile.netImportant = true;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 5;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (!player.active || player.dead || !player.HasBuff(ModContent.BuffType<Buffs.SafePetBuff>()))
            {
                Projectile.Kill();
                return;
            }

            Projectile.timeLeft = 2;

            Projectile.frameCounter++;
            if (Projectile.frameCounter >= 6)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }

            // Initial push — reduced to a short burst
            if (Projectile.localAI[0] == 0f)
            {
                Vector2 launchDirection = player.DirectionTo(Main.MouseWorld).SafeNormalize(Vector2.UnitX);
                Projectile.velocity = launchDirection * 3f; // Lower speed
                Projectile.localAI[0] = 1f;
            }

            // Dampen horizontal speed quickly
            Projectile.velocity.X *= 0.90f; // Stronger damping

            // Idle sine-wave hover (gentle up/down motion)
            float hoverAmplitude = 0.5f;
            float hoverSpeed = 0.12f;
            Projectile.velocity.Y = (float)Math.Sin(Main.GameUpdateCount * hoverSpeed + Projectile.whoAmI) * hoverAmplitude;

            // Face direction of horizontal movement (optional)
            if (Math.Abs(Projectile.velocity.X) > 0.1f)
                Projectile.spriteDirection = Projectile.velocity.X > 0 ? 1 : -1;
        }
    }
}