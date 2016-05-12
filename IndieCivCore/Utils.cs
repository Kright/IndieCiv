using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IndieCivCore {
    public static class Utils {


        public static Texture2D LoadTexture(string Path, Color? ColorKey=null) {
            Texture2D Texture;

            using (FileStream fileStream = new FileStream(@Path, FileMode.Open)) {
                Texture = Texture2D.FromStream(Globals.GraphicsDevice, fileStream);
            }

            if (ColorKey != null) {
                int colorDataLength = Texture.Width * Texture.Height;
                Color[] colorData = new Color[colorDataLength];

                Texture.GetData<Color>(colorData);
                for (var i = 0; i < colorData.Length; i++) {
                    if (colorData[i].R == ColorKey.Value.R && colorData[i].G == ColorKey.Value.G && colorData[i].B == ColorKey.Value.B) {
                        colorData[i] = Color.Transparent;
                    }
                }
                Texture.SetData<Color>(colorData);
            }

            return Texture;
        }

        public static Texture2D LoadTexture(string Path, Color[] ColorKey = null) {
            Texture2D Texture;

            using (FileStream fileStream = new FileStream(@Path, FileMode.Open)) {
                Texture = Texture2D.FromStream(Globals.GraphicsDevice, fileStream);
            }

            if (ColorKey != null) {
                int colorDataLength = Texture.Width * Texture.Height;
                Color[] colorData = new Color[colorDataLength];

                Texture.GetData<Color>(colorData);
                for (var i = 0; i < colorData.Length; i++) {

                    foreach (var Item in ColorKey) {

                        if (colorData[i].R == Item.R && colorData[i].G == Item.G && colorData[i].B == Item.B) {
                            colorData[i] = Color.Transparent;
                        }

                    }
                }
                Texture.SetData<Color>(colorData);
            }

            return Texture;
        }


    }
}
