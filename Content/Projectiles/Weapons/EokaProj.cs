using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using System;

namespace CanWeGetMuchHigher.Content.Projectiles.Weapons
{
    internal class EokaProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 20;

            Projectile.aiStyle = 1;

            Projectile.friendly = true;
            Projectile.hostile = false;

            Projectile.penetrate = 1;

            Projectile.timeLeft = 420;

            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;

            Projectile.extraUpdates = 1;

            AIType = ProjectileID.Bullet;
        }

        public override bool? CanHitNPC(NPC target)
        {
            return true;
        }

    }
}