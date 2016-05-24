using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

namespace IndieCivCore {
    class UnitAssetManager {
        static public Dictionary<string, Texture2D> unitTextureList;

        public UnitAssetManager() {
            unitTextureList = new Dictionary<string, Texture2D>();
        }
    }
}
