using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace IndieCivEditor
{
    public partial class Form1 : Form
    {
        private MapView MapView = null;

        public DockPanel MainDockPanel
        {
            get { return this.dockPanel1; }
        }

        public Form1()
        {
            InitializeComponent();
            InitMapView();
        }

        private void InitMapView()
        {
            MapView = new MapView();
            MapView.Show(this.dockPanel1);
            if (MapView.Pane != null)
            {
                MapView.Pane.Activate();
                MapView.Focus();
            }
        }
        
    }
}
