namespace IndieCivEditor.Forms {
    partial class UnitViewer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.UnitViewer_UnitList = new System.Windows.Forms.ComboBox();
            this.unitViewerRender1 = new IndieCivEditor.UnitViewerRender();
            this.StartFrameSpinner = new System.Windows.Forms.NumericUpDown();
            this.EndFrameSpinner = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartFrameSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndFrameSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.EndFrameSpinner);
            this.panel1.Controls.Add(this.StartFrameSpinner);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.UnitViewer_UnitList);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 68);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unit:";
            // 
            // UnitViewer_UnitList
            // 
            this.UnitViewer_UnitList.FormattingEnabled = true;
            this.UnitViewer_UnitList.Location = new System.Drawing.Point(6, 16);
            this.UnitViewer_UnitList.Name = "UnitViewer_UnitList";
            this.UnitViewer_UnitList.Size = new System.Drawing.Size(188, 21);
            this.UnitViewer_UnitList.TabIndex = 0;
            this.UnitViewer_UnitList.SelectedIndexChanged += new System.EventHandler(this.UnitViewer_UnitList_SelectedIndexChanged);
            // 
            // unitViewerRender1
            // 
            this.unitViewerRender1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.unitViewerRender1.Location = new System.Drawing.Point(0, 86);
            this.unitViewerRender1.Name = "unitViewerRender1";
            this.unitViewerRender1.Size = new System.Drawing.Size(566, 315);
            this.unitViewerRender1.TabIndex = 0;
            this.unitViewerRender1.Text = "unitViewerRender1";
            // 
            // StartFrameSpinner
            // 
            this.StartFrameSpinner.Location = new System.Drawing.Point(200, 16);
            this.StartFrameSpinner.Name = "StartFrameSpinner";
            this.StartFrameSpinner.Size = new System.Drawing.Size(61, 20);
            this.StartFrameSpinner.TabIndex = 2;
            // 
            // EndFrameSpinner
            // 
            this.EndFrameSpinner.Location = new System.Drawing.Point(270, 16);
            this.EndFrameSpinner.Name = "EndFrameSpinner";
            this.EndFrameSpinner.Size = new System.Drawing.Size(58, 20);
            this.EndFrameSpinner.TabIndex = 3;
            this.EndFrameSpinner.ValueChanged += new System.EventHandler(this.EndFrameSpinner_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start Frame:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "End Frame:";
            // 
            // UnitViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 401);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.unitViewerRender1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitViewer";
            this.Text = "UnitViewer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartFrameSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndFrameSpinner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UnitViewerRender unitViewerRender1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UnitViewer_UnitList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown EndFrameSpinner;
        private System.Windows.Forms.NumericUpDown StartFrameSpinner;
        private System.Windows.Forms.Label label3;
    }
}