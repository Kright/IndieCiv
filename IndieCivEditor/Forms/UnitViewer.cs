using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IndieCivCore.Resources;
using IndieCivCore.Localization;

namespace IndieCivEditor.Forms {
    public partial class UnitViewer : Form {
        UnitData unitData = null;

        public UnitViewer() {
            InitializeComponent();

            foreach ( UnitData ud in ResourceInterface.UnitData ) {
                this.UnitViewer_UnitList.Items.Add(ud.ToString());
            }
        }

        private void UnitViewer_UnitList_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox comboBox = (ComboBox)sender;

            string selectedUnit = (string)comboBox.SelectedItem;

            unitData = ResourceInterface.UnitData.Find(u => u.Index == comboBox.SelectedIndex);

            this.unitViewerRender1.unitAnimation.PlayAnimation(IndieCivCore.UnitAnimation.EAnimStates.EAnimState_Default,
                                                                IndieCivCore.Map.MapTile.NeighbouringDirections.South, 
                                                                unitData);
        }

        private void EndFrameSpinner_ValueChanged(object sender, EventArgs e) {
            NumericUpDown spinner = (NumericUpDown)sender;
            this.unitViewerRender1.unitAnimation.EndFrame = (int)spinner.Value;
        }

        private void StartFrameSpinner_ValueChanged(object sender, EventArgs e) {
            NumericUpDown spinner = (NumericUpDown)sender;
            this.unitViewerRender1.unitAnimation.StartFrame = (int)spinner.Value;
        }
    }
}
