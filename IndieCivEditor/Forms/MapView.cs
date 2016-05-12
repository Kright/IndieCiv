using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WeifenLuo.WinFormsUI.Docking;

using IndieCivCore;

namespace IndieCivEditor.Forms
{
    public partial class MapView : DockContent
    {
        public MapView()
        {
            InitializeComponent();
        }

        private void mapViewRender1_Resize(object sender, EventArgs e) {
            Globals.ScreenWidth = this.mapViewRender1.ClientSize.Width;
            Globals.ScreenHeight = this.mapViewRender1.ClientSize.Height;

            if (MapManager.Current != null) 
                MapManager.Current.Dirty = true;

            Invalidate();
        }

        private void mapViewRender1_MouseDown(object sender, MouseEventArgs e) {
            IndieCivCore.MouseState.MouseDownPosition.X = e.X;
            IndieCivCore.MouseState.MouseDownPosition.Y = e.Y;

            Console.WriteLine("Form Mouse Down");

            if (e.Button == MouseButtons.Left)
                IndieCivCore.MouseState.Left = IndieCivCore.ButtonState.Pressed;
            else if (e.Button == MouseButtons.Right)
                IndieCivCore.MouseState.Right = IndieCivCore.ButtonState.Pressed;
            else if (e.Button == MouseButtons.Middle)
                IndieCivCore.MouseState.Middle = IndieCivCore.ButtonState.Pressed;
        }

        private void mapViewRender1_MouseUp(object sender, MouseEventArgs e) {
            Console.WriteLine("Form Mouse Up");
            if (e.Button == MouseButtons.Left)
                IndieCivCore.MouseState.Left = IndieCivCore.ButtonState.Released;
            else if (e.Button == MouseButtons.Right)
                IndieCivCore.MouseState.Right = IndieCivCore.ButtonState.Released;
            else if (e.Button == MouseButtons.Middle)
                IndieCivCore.MouseState.Middle = IndieCivCore.ButtonState.Released;
        }

    }
}
