using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.GameContent.Metadata;

namespace CanWeGetMuchHigher.Content.Tiles
{
    public enum PlantStage : byte
    {
        Planted,
        Growing1,
        Growing2,
        Grown
    }

    public class Plant1 : ModTile
    {
        private const int FrameHeight = 64;
        private const int FrameWidth = 32;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileNoFail[Type] = true;
            TileID.Sets.ReplaceTileBreakUp[Type] = true;
            TileID.Sets.IgnoredInHouseScore[Type] = true;
            TileID.Sets.IgnoredByGrowingSaplings[Type] = true;
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Plant"]);

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(128, 128, 128), name);

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(0, 3);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 32;
            TileObjectData.newTile.CoordinatePadding = 0;
            TileObjectData.newTile.AnchorValidTiles = [
                TileID.Grass,
                TileID.HallowedGrass,
                TileID.Dirt,
            ];
            TileObjectData.newTile.AnchorAlternateTiles = [
                TileID.ClayPot,
                TileID.PlanterBox
            ];
            TileObjectData.addTile(Type);

            HitSound = SoundID.Grass;
            DustType = DustID.Ambient_DarkBrown;
        }

        public override bool CanPlace(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.HasTile)
            {
                int tileType = tile.TileType;
                if (tileType == Type)
                {
                    PlantStage stage = GetStage(i, j);
                    return stage == PlantStage.Grown;
                }
                else
                {
                    if (Main.tileCut[tileType] || TileID.Sets.BreakableWhenPlacing[tileType] ||
                        tileType == TileID.WaterDrip || tileType == TileID.LavaDrip || tileType == TileID.HoneyDrip || tileType == TileID.SandDrip)
                    {
                        bool foliageGrass = tileType == TileID.Plants || tileType == TileID.Plants2;
                        bool moddedFoliage = tileType >= TileID.Count && (Main.tileCut[tileType] || TileID.Sets.BreakableWhenPlacing[tileType]);
                        bool harvestableVanillaHerb = Main.tileAlch[tileType] && WorldGen.IsHarvestableHerbWithSeed(tileType, tile.TileFrameX / 18);

                        if (foliageGrass || moddedFoliage || harvestableVanillaHerb)
                        {
                            WorldGen.KillTile(i, j);
                            if (!tile.HasTile && Main.netMode == NetmodeID.MultiplayerClient)
                            {
                                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
                            }

                            return true;
                        }
                    }

                    return false;
                }
            }

            return true;
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 0)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY = 0;
        }

        public override bool CanDrop(int i, int j)
        {
            PlantStage stage = GetStage(i, j);
            return stage != PlantStage.Planted;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            PlantStage stage = GetStage(i, j);
            Vector2 worldPosition = new Vector2(i, j).ToWorldCoordinates();
            Player nearestPlayer = Main.player[Player.FindClosest(worldPosition, 16, 16)];

            int herbItemType = ModContent.ItemType<Items.Materials.OGKush>();
            int seedItemType = ModContent.ItemType<Items.Placeables.Seed1>();

            int herbItemStack = 1;
            int seedItemStack = 1;

            if (nearestPlayer.active && (nearestPlayer.HeldItem.type == ItemID.StaffofRegrowth || nearestPlayer.HeldItem.type == ItemID.AcornAxe))
            {
                herbItemStack = Main.rand.Next(24, 81);
                seedItemStack = Main.rand.Next(1, 3);
            }
            else if (stage == PlantStage.Grown)
            {
                herbItemStack = Main.rand.Next(24, 81);
                seedItemStack = Main.rand.Next(1, 3);
            }

            if (herbItemType > 0 && herbItemStack > 0)
            {
                yield return new Item(herbItemType, herbItemStack);
            }

            if (seedItemType > 0 && seedItemStack > 0)
            {
                yield return new Item(seedItemType, seedItemStack);
            }
        }

        public override bool IsTileSpelunkable(int i, int j)
        {
            return GetStage(i, j) == PlantStage.Grown;
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            int originX = i - tile.TileFrameX / FrameWidth;
            int originY = j - tile.TileFrameY % FrameHeight / 16;

            PlantStage stage = GetStage(originX, originY);
            if ((int)stage >= (int)PlantStage.Grown)
                return;

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Tile t = Framing.GetTileSafely(originX + x, originY + y);
                    t.TileFrameY += (short)FrameHeight;
                }
            }

            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendTileSquare(-1, originX + 1, originY + 2, 4); 
            }
        }

        private static PlantStage GetStage(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            return (PlantStage)(tile.TileFrameY / FrameHeight);
        }
    }
}