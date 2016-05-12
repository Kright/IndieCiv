using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using IndieCivCore;
using IndieCivCore.Entities;
using IndieCivCore.Resources;



namespace IndieCivCore.Map
{
    public abstract class MapTypeBase : GameObject
    {
        public int                  Width { get; set; }
        public int                  Height { get; set; }
        public int                  Count { get { return Width * Height; } } 

        public bool                 Dirty { get; set; }

        public MapTile              ViewTile { get; set; }
        public MapTile              HighlightedMapTile { get; set; }
        public MapTile              SelectedMapTile { get; set; }

        public Camera               Camera { get; set; }
        public List<MapTile>        VisibleMapTiles { get; set; }
        public List<MapTile>        MapTiles { get; set; }

        public bool                 Scrolling;

        public Player               Player { get; set; }

        public event EventHandler   MapTileSelectedEvent;

        public MapTypeBase()
        {
            Width   = 100;
            Height  = 100;
            Dirty   = true;

            ViewTile = null;

            VisibleMapTiles = new List<MapTile>();
            MapTiles = new List<MapTile>();
            Camera = new Camera();
        }

        public MapTile this [ int x, int y ]
        {
            get
            {
                int index = x + ( y * Width );
                return MapTiles [ index ];
            }
        }

        public IEnumerable<MapTile> AllMapTiles
        {
            get
            {
                return MapTiles;
            }
        }

        public virtual void Init (int Width, int Height)
        {
            this.Width   = Width;
            this.Height  = Height;

            for ( int c = 0; c < Count; c++ )
                MapTiles.Add( new MapTile() );

            ViewTile = MapTiles [ 0 ];
        }

        public abstract void AddMapTile(MapTile t);
        public abstract void AddResource(MapTile t);
        public abstract void AddRelief(MapTile t);
        public abstract void AddTerritory(MapTile t);
        public abstract bool PointInsideMapTile(MapTile MapTile);

        public virtual void Update ()
        {
            UpdateInput();

            if ( Dirty == true )
            {
                MapRendering.Reset();

                ResetVisibleTiles();

                BuildVisibleMapTileList();

                BuildMapForRendering();
            }


            foreach (MapTile t in VisibleMapTiles) {
                if (this.PointInsideMapTile(t) == true) {
                    this.HighlightedMapTile = t;
                }
            }



            Dirty = false;
        }

        public virtual void UpdateInput() {
            if (MouseState.Right == ButtonState.Pressed) {
                //if (MouseState.Moved.X != 0 || MouseState.Moved.Y != 0)
                {
                    Scrolling = true;

                    Vector2 dir = MouseState.Position - MouseState.MouseDownPosition;
                    float len = dir.Length();
                    dir.Normalize();
                    dir *= (-len * 0.05f);

                    if (!float.IsNaN(dir.X) && !float.IsNaN(dir.Y)) {

                        Camera.X = Camera.X - (int)dir.X;
                        Camera.Y = Camera.Y - (int)dir.Y;


                        if (Camera.X < 0) {
                            // Wraps the camera to the other side of the map
                            Camera.X = this.Width * MapRendering.TileWidth;

                            //ResetMapWorldPositions();
                        }
                        else if (Camera.X > this.Width * MapRendering.TileWidth) {

                            Camera.X = 0;
                            //ResetMapWorldPositions();
                        }
                    }

                    Dirty = true;
                }

            }
            else {
                Scrolling = false;
            }

            if ( MouseState.Left == ButtonState.Released && MapManager.Current.HighlightedMapTile != null ) {
                MapManager.Current.SelectedMapTile = MapManager.Current.HighlightedMapTile;
                FireMapTileSelected();
            }
        }

        public void FireMapTileSelected() {
            if (MapTileSelectedEvent != null) {
                MapTileSelectedEvent(this, EventArgs.Empty);
            }
        }

        public virtual void Render ()
        {
            MapRendering.Render();
        }

        protected void ResetVisibleTiles ()
        {
            foreach ( MapTile tile in VisibleMapTiles )
                tile.OnScreen = false;
            VisibleMapTiles.Clear();
        }

        protected void BuildVisibleMapTileList ()
        {
            foreach ( MapTile t in MapTiles )
            {
                if ( t.WorldXPos >= Camera.X +  ( ( Width * 128 ) / 2 ) )
                    t.WorldXPos = t.WorldXPos - ( Width * 128 );

                if ( t.WorldXPos <= Camera.X - ( ( Width * 128 ) / 2 ) )
                    t.WorldXPos = t.WorldXPos + ( Width * 128 );

                if ( IsMapTileOnScreen( t ) == true )
                {
                    t.ScreenXPos = ( t.WorldXPos - Camera.X );
                    t.ScreenYPos = ( t.WorldYPos - Camera.Y );

                    t.OnScreen = true;

                    VisibleMapTiles.Add( t );
                }
            }
        }

        private void BuildMapForRendering ()
        {
            foreach ( MapTile t in VisibleMapTiles )
            {
                t.ScreenXPos = (int)( t.ScreenXPos * MapRendering.Scale ) + ( Globals.ScreenWidth / 2 );
                t.ScreenYPos = (int)(t.ScreenYPos * MapRendering.Scale) + (Globals.ScreenHeight / 2);

                this.AddMapTile(t);

                if (t.ResourceType != null) {
                    this.AddResource(t);
                }
                if (t.ReliefType != null) {
                    this.AddRelief(t);
                }
                if (t.Owner != null ) {
                    this.AddTerritory(t);
                }
            }
        }

        private bool IsMapTileOnScreen ( MapTile t )
        {
            int NewWidth = (int)(MapRendering.TileWidth * MapRendering.Scale);
            int NewHeight = (int)(MapRendering.TileHeight * MapRendering.Scale);

	        int NewPosX = t.WorldXPos;
	        int NewPosY = t.WorldYPos;

            if (NewPosX <= (Camera.X - ((Globals.ScreenWidth / 2) + 128) / MapRendering.Scale))
		        return false;
            if (NewPosX >= (Camera.X + ((Globals.ScreenWidth / 2) + 128) / MapRendering.Scale))
		        return false;

            if (NewPosY <= (Camera.Y - ((Globals.ScreenHeight / 2) + 128) / MapRendering.Scale))
		        return false;
            if (NewPosY >= (Camera.Y + ((Globals.ScreenHeight / 2) + 128) / MapRendering.Scale))
		        return false;

            return true;
        }

        public virtual bool SmoothTile(MapTile MapTile) {
            return false;
        }

        public virtual void SetTextures() {
            foreach (var MapTile in this.MapTiles) {
                SetTextures(MapTile);
            }

            SetReliefTextures();
        }

        public virtual void SetTextures(MapTile MapTile) {

        }

        public virtual void SetReliefTexture(MapTile MapTile) {
        }

        public virtual void SetReliefTextures() {
            foreach (var MapTile in this.MapTiles) {
                if (MapTile.ReliefType != null) {
                    SetReliefTexture(MapTile);
                }
            }
        }

        public void SetTexturesTile(MapTile MapTile, int Levels) {
            SetTextures(MapTile);

            if (Levels == 0) return;

            foreach ( var item in MapTile.NeighbouringTiles) {
                if (item.Value != null) {
                    SetTexturesTile(item.Value, Levels - 1);
                }
            }
        }

        public void ClearMap(TerrainData Terrain) {
            foreach (var MapTile in this.MapTiles) {
                MapTile.TerrainType = Terrain;
                MapTile.ResourceType = null;
                MapTile.ReliefType = null;
            }

            this.SetTextures();

            this.Dirty = true;
        }

        public virtual void InitMapTiles() {

        }

        public void Resize(int Width, int Height) {

            int OldWidth = this.Width;
            int OldHeight = this.Height;

            this.Width = Width;
            this.Height = Height;

            List<MapTile> newMapTiles = new List<MapTile>();

            for ( int y = 0; y < this.Height; y++ ) {
                for (int x = 0; x < this.Width; x++) {
                    if (x < OldWidth && y < OldHeight) {
                        newMapTiles.Add(this.MapTiles[x + (y * OldWidth)]);
                    }
                    else {

                        MapTile newMapTile = new MapTile();
                        newMapTile.TerrainType = ResourceInterface.TerrainData[0];

                        newMapTiles.Add(newMapTile);
                    }
                }
            }

            MapTiles = newMapTiles;
            InitMapTiles();

            this.SetTextures();
            this.Dirty = true;

        }

        public MapTile GetStartingLocation(Player Player) {
            MapTile MapTile = new MapTile();

            return MapTile;
        }

        public MapTile GetRandomLandTile() {
            MapTile MapTile = new MapTile();

            return MapTile;

        }

    }
}
