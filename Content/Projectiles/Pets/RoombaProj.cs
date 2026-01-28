using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;


namespace CanWeGetMuchHigher.Content.Projectiles.Pets
{
    internal class RoombaProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 10;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 40;
            Projectile.aiStyle = 26;
            Projectile.netImportant = true;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 5;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (!player.active || player.dead || !player.HasBuff(ModContent.BuffType<Buffs.RoombaBuff>()))
            {
                Projectile.Kill();
                return;
            }

            Projectile.timeLeft = 2; // Keep alive
        
        }
    } 
}