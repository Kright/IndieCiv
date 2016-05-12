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

using IndieCivCore;
using IndieCivCore.Resources;

namespace IndieCivEditor.Forms {
    public partial class Properties : DockContent {
        public Properties() {
            InitializeComponent();
        }

        public void UpdatePropertyGrid() {
            this.propertyGrid1.SelectedObjects = new object[] { MapManager.Current.SelectedMapTile };
        }

        private void propertyGrid1_PropertyValueChanged_1(object s, PropertyValueChangedEventArgs e) {
            Console.WriteLine(s);

            if (e.ChangedItem.Label == "TerrainType") {
                MapManager.Current.SelectedMapTile.TerrainType = (TerrainData)e.ChangedItem.Value;
                MapManager.Current.SmoothTile(MapManager.Current.SelectedMapTile);
                MapManager.Current.SetTexturesTile(MapManager.Current.SelectedMapTile, 2);
                MapManager.Current.Dirty = true;
            }
        }
    }
}
