using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;


namespace CanWeGetMuchHigher.Content.Tiles
{
    internal class WeedBench : ModTile
    {

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200), CreateMapEntryName());

            RegisterItemDrop(ModContent.ItemType<Items.Placeables.WeedBench>());
        }
    }
}