using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ObjectData;


namespace CanWeGetMuchHigher.Content.Tiles
{
    internal class RGBpc : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200));

            AnimationFrameHeight = 36;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 6) // change to control speed; lower = faster
            {
                frameCounter = 0;
                frame++;
                if (frame >= 10)
                {
                    frame = 0;
                }
            }
        }
    }
}