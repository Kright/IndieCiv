using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace IndieCivCore.Map
{
    public class MapTypeIsometric : MapTypeBase
    {
        public MapTypeIsometric() : base()
        {
        }

        public override void Init(int Width, int Height)
        {
            base.Init(Width, Height);

            InitMapTiles();
        }

        public override void InitMapTiles() {

            int WorldXPos = 0;
            int WorldYPos = 0;

            List<MapTile>.Enumerator enumerator = MapTiles.GetEnumerator();
            enumerator.MoveNext();
            for ( int y = 0; y < Height; y++ )
            {
                WorldXPos = ( ( y % 2 ) != 0 ) ? MapRendering.TileWidthHalf : 0;
                for ( int x = 0; x < Width; x++ )
                {
                    MapTile t = enumerator.Current;

                    t.Init( x, y );
                    t.WorldXPos = WorldXPos;
                    t.WorldYPos = WorldYPos;

                    WorldXPos += MapRendering.TileWidth;

                    enumerator.MoveNext();


                    int DirX = x;
                    int DirY = y - 2;
                    if ( DirY < 0 )
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.North, null );
                    else
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.North, this [ DirX, DirY ] );

                    DirX = x;
                    DirY = y - 1;
                    DirX += ( DirY % 2 != 0 ) ? 0 : 1;
                    if ( DirX == Width )
                        DirX = 0;
                    if ( DirY < 0 )
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.Northeast, null );
                    else
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.Northeast, this [ DirX, DirY ] );

                    DirX = x + 1;
                    DirY = y;
                    if ( DirX == Width )
                        DirX = 0;
                    t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.East, this [ DirX, DirY ] );

                    DirX = x;
                    DirY = y + 1;
                    DirX += ( DirY % 2 != 0 ) ? 0 : 1;
                    if ( DirX == Width )
                        DirX = 0;
                    if ( DirY == Height )
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.Southeast, null );
                    else
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.Southeast, this [ DirX, DirY ] );

                    DirX = x;
                    DirY = y + 2;
                    if ( DirY >= Height )
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.South, null );
                    else
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.South, this [ DirX, DirY ] );

                    DirX = x;
                    DirY = y + 1;
                    DirX -= ( DirY % 2 != 0 ) ? 1 : 0;
                    if ( DirX == -1 )
                        DirX = Width - 1;
                    if ( DirY >= Height )
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.Southwest, null );
                    else
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.Southwest, this [ DirX, DirY ] );

                    DirX = x - 1;
                    DirY = y;
                    if ( DirX == -1 )
                        DirX = Width - 1;
                    t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.West, this [ DirX, DirY ] );

                    DirX = x;
                    DirY = y - 1;
                    DirX -= ( DirY % 2 != 0 ) ? 1 : 0;
                    if ( DirX == -1 )
                        DirX = Width - 1;
                    if ( DirY == -1 )
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.Northwest, null );
                    else
                        t.NeighbouringTiles.Add( MapTile.NeighbouringDirections.Northwest, this [ DirX, DirY ] );
                }

                WorldYPos += MapRendering.TileHeightHalf;
            }
        }

        public override bool PointInsideMapTile(MapTile MapTile) {
            Vector2[] points = new Vector2[4];
            Vector2 mouse;

            int xTile = MapTile.ScreenXPos;// +MapRendering.TileWidthHalf;
            int yTile = MapTile.ScreenYPos;// +MapRendering.TileHeightHalf;

	        points[0] = new Vector2(xTile - MapRendering.TileWidthHalf, yTile);
	        points[1] = new Vector2(xTile, yTile - MapRendering.TileHeightHalf);
	        points[2] = new Vector2(xTile + MapRendering.TileWidthHalf, yTile );
	        points[3] = new Vector2(xTile , yTile + MapRendering.TileHeightHalf);

	        int iMouseX = (int)MouseState.Position.X;
            int iMouseY = (int)MouseState.Position.Y;

	        mouse = new Vector2(iMouseX, iMouseY);

            float nx, ny, x, y;
            for (int i = 0; i < 4; i++) {
                nx = points[(i + 1) % 4].Y - points[i].Y;
                ny = points[i].X - points[(i + 1) % 4].X;

                x = mouse.X - points[i].X;
                y = mouse.Y - points[i].Y;

                if ((x * nx) + (y * ny) > 0)
                    return false;
            }

            return true;
        }

        public override void Update ()
        {
            base.Update();
        }

        public override void Render ()
        {
            base.Render();
        }

        public override void AddMapTile(MapTile t) {
        }
        public override void AddResource(MapTile t) {
        }
        public override void AddRelief(MapTile t) {
        }
        public override void AddTerritory(MapTile t) {
        }

        public override bool SmoothTile(MapTile MapTile) {
            return false;
        }

        public override void SetTextures(MapTile MapTile) {

        }
    }
}
