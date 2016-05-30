using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

namespace IndieCivCore {
    class UnitAssetManager {
        static public Dictionary<string, Texture2D> unitTextureList = new Dictionary<string, Texture2D>();

        public UnitAssetManager() {
            //unitTextureList = new Dictionary<string, Texture2D>();
        }

        public static void AddTexture(string name, Texture2D texture) {
            if ( GetTexture(name) == null ) {
                unitTextureList.Add(name, texture);
            }
        }

        public static Texture2D GetTexture(string name) {
            Texture2D texture = null;
            unitTextureList.TryGetValue(name, out texture);
            return texture;
        }
    }
}
