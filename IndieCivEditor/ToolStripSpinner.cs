using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IndieCivEditor {
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripNumberControl : ToolStripControlHost {
        public NumericUpDown spinner;
        public ToolStripNumberControl() : base(new NumericUpDown())
        {
            spinner = this.Control as NumericUpDown;
            spinner.Maximum = 9999;
            spinner.Minimum = 20;

        }

        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
            ((NumericUpDown)control).ValueChanged += new EventHandler(OnValueChanged);
        }

        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
            ((NumericUpDown)control).ValueChanged -= new EventHandler(OnValueChanged);
        }

        public event EventHandler ValueChanged;

        public Control NumericUpDownControl
        {
            get { return Control as NumericUpDown; }
        }

        public void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }
        }
    }
}
