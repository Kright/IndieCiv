using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace IndieCivEditor {
    public class UnitViewerRender : GraphicsDeviceControl {
        protected override void Initialize() {
            Application.Idle += delegate { Invalidate(); };
        }

        protected override void Draw() {
            GraphicsDevice.Clear(Color.Black);
        }
    }
}
