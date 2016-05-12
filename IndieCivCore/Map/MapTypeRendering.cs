using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndieCivCore.Resources;

namespace IndieCivCore.Map
{
    public static class MapTypeRendering
    {
        public static int TileWidth { get; set; }
        public static int TileHeight { get; set; }

        public static int TileWidthHalf { get { return TileWidth / 2; } private set{} }
        public static int TileHeightHalf { get { return TileHeight / 2; } private set{} }

        public static int Scale { get; set; }

        public static MapTypeBase MapType { get; set; }

		public static Dictionary<string, BatchRendering> Terrain;

        //protected Dictionary<string, BatchRendering> ArtResources;

        static MapTypeRendering ()
        {
            TileWidth = 128;
            TileHeight = 64;

            Scale = 1;

            //Terrain = new List<BatchRendering>();

            //ArtResources = new Dictionary<string, BatchRendering>();
            Terrain = new Dictionary<string, BatchRendering>();
		}

        public static void staticRender()
        {

            //foreach ( BatchRendering br in Terrain )
			foreach ( KeyValuePair<string, BatchRendering> pair in Terrain )
                pair.Value.Render();
        }
		//public abstract void RenderGrid();

        public static void AddTerrainGraphic(string Path)
        {
            BatchRendering batch = new BatchRendering();
            batch.ArtResource = new ResourceRef<ArtResource>( r.Res );
			Terrain.Add( r.Path, batch );

        }
    }
}
