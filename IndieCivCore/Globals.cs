using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace IndieCivCore
{
    public static class Globals
    {
        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }

        public static ContentManager ContentManager { get; set; }

        public static GraphicsDevice GraphicsDevice { get; set; }

        static Globals()
        {
            Globals.ScreenWidth = 1024;
            Globals.ScreenHeight = 768;
        }
    }
}
