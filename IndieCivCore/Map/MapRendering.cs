using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using IndieCivCore.Resources;

namespace IndieCivCore.Map
{
    public static class MapRendering
    {
        public static int TileWidth { get; set; }
        public static int TileHeight { get; set; }

        public static int TileWidthHalf { get { return TileWidth / 2; } private set{} }
        public static int TileHeightHalf { get { return TileHeight / 2; } private set{} }

        public static float Scale { get; set; }

        public static MapTypeBase MapType { get; set; }

		public static List<BatchRendering> Terrain;
        public static BatchRendering Resource;
        public static List<BatchRendering> Relief;
        public static BatchRendering Territory;
        public static BatchRendering StartLocation;

        //protected Dictionary<string, BatchRendering> ArtResources;

        static MapRendering ()
        {
            TileWidth = 128;
            TileHeight = 64;

            Scale = 1f;

            Terrain = new List<BatchRendering>();
            Resource = new BatchRendering();
            Relief = new List<BatchRendering>();
            Territory = new BatchRendering();
            StartLocation = new BatchRendering();

            AddResourceGraphic("Assets/Art/Terrain/resources.png");
            AddTerritoryGraphic("Assets/Art/Terrain/territory.png");
            AddStartLocationGraphic("Assets/Art/Terrain/startloc.png");
		}

        public static void Reset() {
            Terrain.ForEach(r => r.Reset());
            Relief.ForEach(r => r.Reset());
            Territory.Reset();
            StartLocation.Reset();

            Resource.Reset();
        }

        public static void Render()
        {
            Terrain.ForEach(r => r.Render());
            Relief.ForEach(r => r.Render());

            Territory.Render();
            Resource.Render();
            StartLocation.Render();
        }

        public static void AddTerritoryGraphic(string Path) {
            Territory.Texture = Utils.LoadTexture(Path, new Color[] { new Color(128, 0, 128, 255), new Color(177, 177, 177, 255) });
        }

        public static void AddTerrainGraphic(string Path)
        {
            BatchRendering batch = new BatchRendering();
            batch.Texture = Utils.LoadTexture(Path, new Color(Color.Magenta, 255));
			Terrain.Add( batch );
        }

        public static void AddReliefGraphic(string Path) {
            BatchRendering batch = new BatchRendering();
            batch.Texture = Utils.LoadTexture(Path, new Color(Color.Magenta, 255));
            Relief.Add(batch);
        }

        public static void AddResourceGraphic(string Path) {
            Resource.Texture = Utils.LoadTexture(Path, new Color(Color.Magenta, 255));
        }
        public static void AddStartLocationGraphic(string Path) {
            StartLocation.Texture = Utils.LoadTexture(Path, new Color(Color.Magenta, 255));
        }



        public static void AddTerrainBatch(MapTile mapTile, Vector2 dest, Rectangle source ) {
            Terrain[mapTile.Variation].AddBatch( dest, source);
        }
        public static void AddReliefBatch(MapTile mapTile, Vector2 dest, Rectangle source ) {
            ReliefArt ReliefArt = ResourceInterface.ReliefArtData.Find(x => x.Type == mapTile.ReliefType.ReliefArt);
            Relief[ReliefArt.Index].AddBatch(dest, source);
        }
        public static void AddResourceBatch(MapTile mapTile, Vector2 dest, Rectangle source) {
            Resource.AddBatch(dest, source);
        }
        public static void AddTerritoryBatch(MapTile maptile, Vector2 dest, Rectangle source) {
            Territory.AddBatch(dest, source, maptile.Owner.CivilizationData.Color);
        }
        public static void AddStartLocationBatch(MapTile maptile, Vector2 dest, Rectangle source) {
            StartLocation.AddBatch(dest, source);
        }
    }
}
