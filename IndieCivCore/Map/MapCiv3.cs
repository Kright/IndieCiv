using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using IndieCivCore.Map;
using IndieCivCore.Resources;

namespace IndieCivCore.Map
{
    public class MapCiv3 : MapTypeIsometric
    {
        public MapCiv3() : base()
        {
        }

        public override void Init ( int Width, int Height )
        {
            base.Init(Width, Height);
        }

        public override void AddMapTile(MapTile t) {
            Vector2 position = new Vector2(0, 0);

            //IrrlichtLime.Core.Recti  textureRect = new IrrlichtLime.Core.Recti(0, 0, 0, 0);
            Rectangle destSize = new Rectangle();

            int fX = t.ScreenXPos - (int)(MapRendering.TileWidthHalf * MapRendering.Scale);
            int fY = t.ScreenYPos - (int)(MapRendering.TileHeight * MapRendering.Scale);

            position.X = fX;
            position.Y = fY;

            destSize.Width = (int)(MapRendering.TileWidth * MapRendering.Scale);
            destSize.Height = (int)(MapRendering.TileHeight * MapRendering.Scale);

            int iGfxTile = t.GfxIdx;
            int iRow = (iGfxTile / 9);
            int iTile = iGfxTile - (9 * (iGfxTile / 9));

            int iStartU = 0 + (MapRendering.TileWidth * iTile);
            int iStartV = 0 + (MapRendering.TileHeight * iRow);

            MapRendering.AddTerrainBatch(t, position, new Rectangle(iStartU, iStartV, MapRendering.TileWidth, MapRendering.TileHeight));		
        }

        public override void AddResource(MapTile t) {
            Vector2 position = new Vector2(0, 0);

            //IrrlichtLime.Core.Recti  textureRect = new IrrlichtLime.Core.Recti(0, 0, 0, 0);
            Rectangle destSize = new Rectangle();

            int fX = t.ScreenXPos - (int)(25 * MapRendering.Scale);
            int fY = t.ScreenYPos - (int)(25 * MapRendering.Scale);

            position.X = fX;
            position.Y = fY;

            destSize.Width = (int)(50 * MapRendering.Scale);
            destSize.Height = (int)(50 * MapRendering.Scale);

            int iGfxTile = t.ResourceType.Icon;
            int iRow = (iGfxTile / 6);
            int iTile = iGfxTile - (6 * (iGfxTile / 6));

            int iStartU = 0 + (50 * iTile);
            int iStartV = 0 + (50 * iRow);

            MapRendering.AddResourceBatch(t, position, new Rectangle(iStartU, iStartV, 50, 50));
        }

        public override void AddStartLocation(StartLocation sl) {
            Vector2 position = new Vector2(0, 0);

            Rectangle destSize = new Rectangle();

            int fX = sl.MapTile.ScreenXPos - (int)(64 * MapRendering.Scale);
            int fY = sl.MapTile.ScreenYPos - (int)(32 * MapRendering.Scale);

            position.X = fX;
            position.Y = fY;

            destSize.Width = (int)(128 * MapRendering.Scale);
            destSize.Height = (int)(64 * MapRendering.Scale);

            MapRendering.AddStartLocationBatch(sl.MapTile, position, new Rectangle(0, 0, 128, 64));
        }

        public override void AddRelief(MapTile t) {
            ReliefArt ReliefArt = ResourceInterface.ReliefArtData.Find(x => x.Type == t.ReliefType.ReliefArt);

            Vector2 position = new Vector2(0, 0);

            Rectangle destSize = new Rectangle();

            int fX = t.ScreenXPos - (int)(MapRendering.TileWidthHalf * MapRendering.Scale);
            int fY = t.ScreenYPos - (int)(MapRendering.TileHeightHalf * MapRendering.Scale);
            fY -= ((ReliefArt.Height - 64));

            position.X = fX;
            position.Y = fY;

            destSize.Width = (int)(ReliefArt.Width * MapRendering.Scale);
            destSize.Height = (int)(ReliefArt.Height * MapRendering.Scale);

            if (t.ReliefType.Index == 6) {
                MapTile MapTileNorthEast = t.NeighbouringTiles[MapTile.NeighbouringDirections.Northeast];
                MapTile MapTileNorth = t.NeighbouringTiles[MapTile.NeighbouringDirections.North];
                MapTile MapTileNorthWest = t.NeighbouringTiles[MapTile.NeighbouringDirections.Northwest];

                int iStartCol = 1;
                int iStartRow = 1;

                //if (pMapTile->mRiverConnectionInfo & RIVER_CONNECTION_NORTH_WEST)
                    //iStartRow += 1;

                //if (pMapTile->mRiverConnectionInfo & RIVER_CONNECTION_NORTH_EAST)
                    //iStartRow += 2;

                //if (pMapTileNorthWest->mRiverConnectionInfo & RIVER_CONNECTION_NORTH_EAST)
                    //iStartCol += 1;

                //if (pMapTileNorthEast->mRiverConnectionInfo & RIVER_CONNECTION_NORTH_WEST)
                    //iStartCol += 2;

                if (iStartCol == 1 && iStartRow == 1)
                    return;

                t.ReliefGfxIdx = ((iStartRow - 1) * 4) + (iStartCol - 1);

                fX = t.ScreenXPos - (int)(MapRendering.TileWidthHalf * MapRendering.Scale);
                fY = t.ScreenYPos - (int)(MapRendering.TileHeight * MapRendering.Scale);

                position.X = fX;
                position.Y = fY;
            }


            int iGfxTile = t.ReliefGfxIdx;
            int iRow = (iGfxTile / 4);
            int iTile = iGfxTile - (4 * (iGfxTile / 4));

            int iStartU = 0 + (ReliefArt.Width * iTile);
            int iStartV = 0 + (ReliefArt.Height * iRow);

            MapRendering.AddReliefBatch(t, position, new Rectangle(iStartU, iStartV, ReliefArt.Width, ReliefArt.Height));
        }

        public override void AddTerritory(MapTile t) {

            Vector2 position = new Vector2(0, 0);
            Rectangle destSize = new Rectangle();

            int fX = t.ScreenXPos - (int)(MapRendering.TileWidthHalf * MapRendering.Scale);
            int fY = t.ScreenYPos - (int)(MapRendering.TileHeightHalf * MapRendering.Scale);
            fY -= ((72 - 64));

            position.X = fX;
            position.Y = fY;

            destSize.Width = (int)(MapRendering.TileWidth * MapRendering.Scale);
            destSize.Height = (int)(72 * MapRendering.Scale);

            MapTile NorthWest = t.NeighbouringTiles[MapTile.NeighbouringDirections.Northwest];
            MapTile NorthEast = t.NeighbouringTiles[MapTile.NeighbouringDirections.Northeast];
            MapTile SouthWest = t.NeighbouringTiles[MapTile.NeighbouringDirections.Southwest];
            MapTile SouthEast = t.NeighbouringTiles[MapTile.NeighbouringDirections.Southeast];

            int iRow = 0;
            int iTile = 0;

            if (NorthWest != null && ( NorthWest.Owner == null || NorthWest.Owner != t.Owner ) ){
                iRow = 0;
                iTile = 0;
                MapRendering.AddTerritoryBatch(t, position, new Rectangle(0 + (MapRendering.TileWidth * iTile), 0 + (72 * iRow), MapRendering.TileWidth, 72));
            }
            if (NorthEast != null && (NorthEast.Owner == null || NorthEast.Owner != t.Owner)) {
                iRow = 1;
                iTile = 0;
                MapRendering.AddTerritoryBatch(t, position, new Rectangle(0 + (MapRendering.TileWidth * iTile), 0 + (72 * iRow), MapRendering.TileWidth, 72));
            }
            if (SouthWest != null && (SouthWest.Owner == null || SouthWest.Owner != t.Owner)) {
                iRow = 2;
                iTile = 0;
                MapRendering.AddTerritoryBatch(t, position, new Rectangle(0 + (MapRendering.TileWidth * iTile), 0 + (72 * iRow), MapRendering.TileWidth, 72));
            }
            if (SouthEast != null && (SouthEast.Owner == null || SouthEast.Owner != t.Owner)) {
                iRow = 3;
                iTile = 0;
                MapRendering.AddTerritoryBatch(t, position, new Rectangle(0 + (MapRendering.TileWidth * iTile), 0 + (72 * iRow), MapRendering.TileWidth, 72));
            }
        }

        public override void Update ()
        {
            base.Update();
        }

        public override void Render ()
        {
            base.Render();
        }

        public override bool SmoothTile(MapTile MapTile) {
            bool Changed = false;

            foreach ( var item in MapTile.NeighbouringTiles ) {
                MapTile Direction = MapTile.NeighbouringTiles[item.Key];

                if (Direction != null) {
                    if (CanBlend(MapTile, Direction) == false) {

                        foreach ( var blend in MapTile.TerrainType.Blend ) {
                            TerrainData From = ResourceInterface.TerrainData.Find(x => x.Type == blend.From);
                            if (From == Direction.TerrainType) {
                                Direction.TerrainType = ResourceInterface.TerrainData.Find(x => x.Type == blend.To);
                                Changed = true;
                            }
                        }

                    }
                }
            }

            return Changed;

        }

        private bool CanBlend ( MapTile MapTile, MapTile Blend ) {
	        foreach ( string art in MapTile.TerrainType.TerrainArt ) {
                TerrainArt TerrainArt = ResourceInterface.TerrainArtData.Find(x => x.Type == art);

		        foreach ( string b in TerrainArt.Blend ) {
                    //TerrainData TerrainData = ResourceInterface.TerrainData.Find(x => x.Type == b);

			        if ( b == Blend.TerrainType.Type )
				        return true;
		        }
	        }
		
	        return false;
        }

        public override void SetTextures(MapTile MapTile) {
            int TerrainIdx = MapTile.TerrainType.Index;

            int[] Direction = {0, 0, 0};

            Direction[0] = MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Northeast] == null ? 0 : MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Northeast].TerrainType.Index;
            Direction[1] = MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.North] == null ? 0 : MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.North].TerrainType.Index;
            Direction[2] = MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Northwest] == null ? 0 : MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Northwest].TerrainType.Index;

            List<TerrainArt> possibleTerrainArt = new List<TerrainArt>();

            foreach ( string art in MapTile.TerrainType.TerrainArt ) {

                TerrainArt TerrainArt = ResourceInterface.TerrainArtData.Find(x => x.Type == art);

                TerrainData TerrainA = ResourceInterface.TerrainData.Find(x => x.Type == TerrainArt.Blend[0]);
                TerrainData TerrainB = ResourceInterface.TerrainData.Find(x => x.Type == TerrainArt.Blend[1]);
                TerrainData TerrainC = ResourceInterface.TerrainData.Find(x => x.Type == TerrainArt.Blend[2]);

                bool bFoundNorthWest = false;
                bool bFoundWest = false;
                bool bFoundSouthWest = false;

                if ( Direction[0] == TerrainA.Index || Direction[0] == TerrainB.Index || Direction[0] == TerrainC.Index )
                    bFoundNorthWest = true;
                if ( Direction[1] == TerrainA.Index || Direction[1] == TerrainB.Index || Direction[1] == TerrainC.Index )
                    bFoundWest = true;
                if ( Direction[2] == TerrainA.Index || Direction[2] == TerrainB.Index || Direction[2] == TerrainC.Index )
                    bFoundSouthWest = true;

                if (bFoundNorthWest == true && bFoundWest == true && bFoundSouthWest == true)
                    possibleTerrainArt.Add(TerrainArt);
            }

            if ( possibleTerrainArt.Count > 0 ) {
                int idx = ( (MapTile.X+1) * (MapTile.Y+1) ) % (int)possibleTerrainArt.Count;

                TerrainArt TerrainArt = possibleTerrainArt[idx];

                TerrainData TerrainA = ResourceInterface.TerrainData.Find(x => x.Type == TerrainArt.Blend[0]);
                TerrainData TerrainB = ResourceInterface.TerrainData.Find(x => x.Type == TerrainArt.Blend[1]);
                TerrainData TerrainC = ResourceInterface.TerrainData.Find(x => x.Type == TerrainArt.Blend[2]);

		        int iStartCol = 0;
		        int iStartRow = 0;

		        if ( Direction[2] == TerrainA.Index )
			        iStartCol = 1;
		        if ( Direction[2] == TerrainB.Index )
			        iStartCol = 4;
		        if ( Direction[2] == TerrainC.Index )
			        iStartCol = 7;

		        if ( TerrainIdx == TerrainA.Index )
			        iStartRow = 1;
		        if ( TerrainIdx == TerrainB.Index )
			        iStartRow = 4;
		        if ( TerrainIdx == TerrainC.Index )
			        iStartRow = 7;


		        if ( Direction[0] == TerrainA.Index )
			        iStartRow += 0;
		        if ( Direction[0] == TerrainB.Index )
			        iStartRow += 1;
		        if ( Direction[0] == TerrainC.Index )
			        iStartRow += 2;

		        if ( Direction[1] == TerrainA.Index )
			        iStartCol += 0;
		        if ( Direction[1] == TerrainB.Index )
			        iStartCol += 1;
		        if ( Direction[1] == TerrainC.Index )
			        iStartCol += 2;

                MapTile.GfxIdx = ((iStartRow - 1) * 9) + (iStartCol - 1);
		        MapTile.Variation = TerrainArt.Index;
            }

            if (MapTile.ReliefType != null) {

                SetReliefTexture(MapTile);
            }
        }

        public override void SetReliefTexture(MapTile MapTile) {
            bool[] bReliefDirectionIdx = { false, false, false, false };

            bReliefDirectionIdx[0] = MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Northwest] == null ? false : MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Northwest].ReliefType != null ? true : false;
            bReliefDirectionIdx[1] = MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Northeast] == null ? false : MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Northeast].ReliefType != null ? true : false;
            bReliefDirectionIdx[2] = MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Southwest] == null ? false : MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Southwest].ReliefType != null ? true : false;
            bReliefDirectionIdx[3] = MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Southeast] == null ? false : MapTile.NeighbouringTiles[Map.MapTile.NeighbouringDirections.Southeast].ReliefType != null ? true : false;

            int iStartRow = 1;
            int iStartCol = 1;

            if (bReliefDirectionIdx[2] == true)
                iStartRow = 2;
            if (bReliefDirectionIdx[3] == true)
                iStartRow = 3;
            if (bReliefDirectionIdx[2] == true && bReliefDirectionIdx[3] == true)
                iStartRow = 4;


            if (bReliefDirectionIdx[0] == true)
                iStartCol = 2;
            if (bReliefDirectionIdx[1] == true)
                iStartCol = 3;
            if (bReliefDirectionIdx[0] == true && bReliefDirectionIdx[1] == true)
                iStartCol = 4;

            MapTile.ReliefGfxIdx = ((iStartRow - 1) * 4) + (iStartCol - 1);
        }

    }
}
