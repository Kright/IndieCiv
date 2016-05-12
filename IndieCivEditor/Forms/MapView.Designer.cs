namespace IndieCivEditor.Forms
{
    partial class MapView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapViewRender1 = new IndieCivEditor.MapViewRender();
            this.SuspendLayout();
            // 
            // mapViewRender1
            // 
            this.mapViewRender1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewRender1.Location = new System.Drawing.Point(0, 0);
            this.mapViewRender1.Name = "mapViewRender1";
            this.mapViewRender1.Size = new System.Drawing.Size(487, 262);
            this.mapViewRender1.TabIndex = 0;
            this.mapViewRender1.Text = "mapViewRender1";
            this.mapViewRender1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapViewRender1_MouseDown);
            this.mapViewRender1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapViewRender1_MouseUp);
            this.mapViewRender1.Resize += new System.EventHandler(this.mapViewRender1_Resize);
            // 
            // MapView
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(487, 262);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.mapViewRender1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MapView";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.Text = "MapView";
            this.ResumeLayout(false);

        }

        #endregion

        public MapViewRender mapViewRender1;





    }
}