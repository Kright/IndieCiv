using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IndieCivEditor
{
    class IndieCivEditor : GraphicsDeviceControl
    {
        protected override void Initialize()
        {
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Black);
        }
    }
}
