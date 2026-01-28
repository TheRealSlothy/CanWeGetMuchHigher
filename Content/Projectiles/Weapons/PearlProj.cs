using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;


namespace CanWeGetMuchHigher.Content.Projectiles.Weapons
{
    internal class PearlProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;

            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            
            Projectile.DamageType = DamageClass.Ranged;
        }
        
        public override void AI()
        {
            Projectile.velocity.Y += 0.2f;

            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 150, default, 1.5f);
            Main.dust[dust].noGravity = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            HandleImpact();
            return true;
        }

        private Vector2 FindSafeTeleportPosition(Vector2 center, Player player)
        {
            Point tilePos = center.ToTileCoordinates();
            int searchRadius = 5;

            for (int x = -searchRadius; x <= searchRadius; x++)
            {
                for (int y = -searchRadius; y <= searchRadius; y++)
                {
                    int checkX = tilePos.X + x;
                    int checkY = tilePos.Y + y;

                    if (WorldGen.InWorld(checkX, checkY, 10) &&
                        !WorldGen.SolidTile(checkX, checkY) &&
                        !WorldGen.SolidTile(checkX, checkY - 1) &&
                        !WorldGen.SolidTile(checkX, checkY + 1))
                    {
                        return new Vector2(checkX * 16, (checkY + 1) * 16 - player.height);
                    }
                }
            }
            return center;
        }

        private void HandleImpact()
        {
            Player player = Main.player[Projectile.owner];

            int damage = (int)(player.statLife * 0.25f);
            damage = Math.Max(damage, 25);

            player.Hurt(PlayerDeathReason.ByCustomReason($"{player.name} got too high and crashed."), damage, 0);

            Vector2 teleportPosition = FindSafeTeleportPosition(Projectile.Center, player);

            player.Teleport(teleportPosition, 1);
            NetMessage.SendData(MessageID.TeleportEntity, -1, -1, null, player.whoAmI, teleportPosition.X, teleportPosition.Y, 1f);

            SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

            Projectile.Kill();
        }
    }
}