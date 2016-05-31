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

using IndieCivCore;

namespace IndieCivEditor {
    public class UnitViewerRender : GraphicsDeviceControl {
        public UnitAnimation unitAnimation = null;

        protected override void Initialize() {
            Application.Idle += delegate { Invalidate(); };

            unitAnimation = new UnitAnimation();
        }

        protected override void Draw() {
            GraphicsDevice.Clear(Color.Black);

            unitAnimation.Update();

            unitAnimation.Render(new Vector2(DefaultRenderTarget.Width / 2, DefaultRenderTarget.Height / 2));
        }
    }
}
