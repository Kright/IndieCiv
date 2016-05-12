using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace IndieCivCore.Map
{
    public class MapCiv3Rendering : MapTypeIsometricRendering
    {
		public override void AddMapTile( MapTile t )
		{
            Vector2 position = new Vector2(0, 0);
            
			//IrrlichtLime.Core.Recti  textureRect = new IrrlichtLime.Core.Recti(0, 0, 0, 0);
            Rectangle destSize = new Rectangle();

			int fX = t.ScreenXPos - ( TileWidthHalf / Scale );
			int fY = t.ScreenYPos - ( TileHeightHalf / Scale );

            position.X = fX;
            position.Y = fY;

			destSize.Width = TileWidth / Scale;
			destSize.Height = TileHeight / Scale;

			int iGfxTile = t.GfxIdx;
			int iRow = (iGfxTile / 9);
			int iTile = iGfxTile - (9 * (iGfxTile / 9));

			int iStartU = 0 + ( TileWidth * iTile );
			int iStartV = 0 + ( TileHeight * iRow );

			if ( t.TerrainArt.Path != null )
				//Terrain [ t.TerrainArt.Path ].AddBatch( position, new IrrlichtLime.Core.Recti( iStartU, iStartV, iStartU + TileWidth, iStartV + TileHeight ), destSize );
                Terrain[t.TerrainArt.Path].AddBatch(new Rectangle((int)position.X, (int)position.Y, TileWidth, TileHeight), new Rectangle(iStartU, iStartV, iStartU + TileWidth, iStartV + TileHeight));
		}
    }
}
