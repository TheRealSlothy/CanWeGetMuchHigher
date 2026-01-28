using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;


namespace CanWeGetMuchHigher.Content.Tiles
{
    internal class ShotgunTrapEntity : ModTileEntity
    {
        public override bool IsTileValidForEntity(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            return tile.HasTile && tile.TileType == ModContent.TileType<Tiles.ShotgunTrap>();
        }

        public override void Update()
        {
            int i = Position.X;
            int j = Position.Y;

            Main.NewText("Jit");
            Tile tile = Main.tile[i, j];
            int style = tile.TileFrameY / 18;
            Vector2 spawnPosition;


            int horizontalDirection = (tile.TileFrameX == 0) ? -1 : ((tile.TileFrameX == 18) ? 1 : 0);
            int verticalDirection = (tile.TileFrameX < 36) ? 0 : ((tile.TileFrameX < 72) ? -1 : 1);


            spawnPosition = new Vector2(i * 16 + 8 + 0 * horizontalDirection, j * 16 + 9 + 0 * verticalDirection);
            Projectile.NewProjectile(Wiring.GetProjectileSource(i, j), spawnPosition, new Vector2(horizontalDirection, verticalDirection) * 6f, ProjectileID.IchorBullet, 20, 2f, Main.myPlayer);
        }
    }
}