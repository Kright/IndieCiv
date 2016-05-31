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
        public UnitViewer() {
            InitializeComponent();

            foreach ( UnitData ud in ResourceInterface.UnitData ) {
                this.UnitViewer_UnitList.Items.Add(ud.ToString());

            }
        }
    }
}
