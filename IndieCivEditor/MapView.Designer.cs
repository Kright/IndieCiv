namespace IndieCivEditor
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
            this.indieCivEditor1 = new IndieCivEditor();
            this.SuspendLayout();
            // 
            // indieCivEditor1
            // 
            this.indieCivEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indieCivEditor1.Location = new System.Drawing.Point(0, 0);
            this.indieCivEditor1.Name = "indieCivEditor1";
            this.indieCivEditor1.Size = new System.Drawing.Size(487, 262);
            this.indieCivEditor1.TabIndex = 0;
            this.indieCivEditor1.Text = "indieCivEditor1";
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 262);
            this.Controls.Add(this.indieCivEditor1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MapView";
            this.Text = "MapView";
            this.ResumeLayout(false);

        }

        #endregion

        private IndieCivEditor indieCivEditor1;
    }
}