using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CanWeGetMuchHigher.Content.Projectiles.NPCs.Enemies
{
    internal class SeedManProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.aiStyle = 1; // Arrow AI
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = true;
        }
    }
}