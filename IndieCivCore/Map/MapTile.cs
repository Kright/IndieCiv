using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using IndieCivCore;
using IndieCivCore.Resources;
using IndieCivCore.Entities;

namespace IndieCivCore.Map
{
    public class MapTile : GameObject
    {
        public enum NeighbouringDirections
        {
            Southwest,
	        South,
	        Southeast,
	        East,
	        Northeast,
	        North,
	        Northwest,
	        West,
        };

        [Category("Tile Properties"), Description("X")]
        public int X { get; set; }
        [Category("Tile Properties"), Description("Y")]
        public int Y { get; set; }

        public int WorldXPos { get; set; }
        public int WorldYPos { get; set; }

        public int ScreenXPos { get; set; }
        public int ScreenYPos { get; set; }

        public bool OnScreen { get; set; }

        public int Region { get; set; }
        public Player Owner { get; set; }

		public int GfxIdx { get; set; }
		public int Variation { get; set; }

        [TypeConverter(typeof(TerrainDataTypeConverter))]
        public TerrainData TerrainType { get; set; }
		public TerrainArt TerrainArt { get; set; }

        public ResourceData ResourceType { get; set; }
        public ReliefData ReliefType { get; set; }
        public int ReliefGfxIdx { get; set; }

        //spublic List<MapTile> NeighbouringTiles { get; set; }
        [Browsable(false)]
        public Dictionary<NeighbouringDirections, MapTile> NeighbouringTiles { get; set; }

        public MapTile ()
        {
            X = Y = 0;

            WorldXPos = 0;
            WorldYPos = 0;

            ScreenXPos = 0;
            ScreenYPos = 0;

			GfxIdx = 0;
			Variation = 0;

            OnScreen = false;
        }

        public void Init ( int x, int y )
        {
            X = x;
            Y = y;

            NeighbouringTiles = new Dictionary<NeighbouringDirections, MapTile>();
        }

        public void AddUnit(Unit Unit) {

        }
    }
}
