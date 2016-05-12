using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using IndieCivCore.Resources;

namespace IndieCivCore
{
    public class BatchRendering
    {
        public Texture2D Texture { get; set; }
        SpriteBatch SpriteBatch { get; set; }

        List<Vector2> Positions { get; set; }
        List<Rectangle> TextureRects { get; set; }
        List<Color> Colors { get; set; }
        //List<IrrlichtLime.Core.Dimension2Di> DestSizes { get; set; }

		//IrrlichtLime.Core.Recti DestSize { get; set; }

        //SpriteBatch SpriteBatch { get; set; }
        //public ArtResource ArtResource { get; set; }

		public BatchRendering()
		{
            Colors = new List<Color>();

            Positions = new List<Vector2>();
            TextureRects = new List<Rectangle>();

            SpriteBatch = new SpriteBatch(Globals.GraphicsDevice);
		}

		public void Reset()
		{
			Positions.Clear();
			TextureRects.Clear();
            Colors.Clear();
		}

		public void AddBatch ( Vector2 dest, Rectangle source )
		{
			Positions.Add( dest );
			TextureRects.Add( source );
            Colors.Add(Color.White);
		}
        public void AddBatch(Vector2 dest, Rectangle source, Color Color) {
            Positions.Add(dest);
            TextureRects.Add(source);
            Colors.Add(Color);
        }

        public void Render ()
        {
            SpriteBatch.Begin();

            for (int i = 0; i < Positions.Count; i++) {
                SpriteBatch.Draw(this.Texture, Positions[i], TextureRects[i], Colors[i]);
            }

            SpriteBatch.End();
        }
    }
}
