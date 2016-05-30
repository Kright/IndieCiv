namespace IndieCivEditor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TerrainDropDown = new System.Windows.Forms.ToolStripButton();
            this.ResourceDropDown = new System.Windows.Forms.ToolStripButton();
            this.ReliefDropDown = new System.Windows.Forms.ToolStripButton();
            this.TerritoryDropDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearMap = new System.Windows.Forms.ToolStripButton();
            this.MapWidth = new IndieCivEditor.ToolStripNumberControl();
            this.MapHeight = new IndieCivEditor.ToolStripNumberControl();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Play = new System.Windows.Forms.ToolStripButton();
            this.Pause = new System.Windows.Forms.ToolStripButton();
            this.Stop = new System.Windows.Forms.ToolStripButton();
            this.Step = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel1
            // 
            this.dockPanel1.BackColor = System.Drawing.Color.Transparent;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Location = new System.Drawing.Point(0, 50);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(992, 451);
            this.dockPanel1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "&Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 501);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(992, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStripStatusLabel1_Paint);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TerrainDropDown,
            this.ResourceDropDown,
            this.ReliefDropDown,
            this.TerritoryDropDown,
            this.toolStripSeparator1,
            this.ClearMap,
            this.MapWidth,
            this.MapHeight,
            this.toolStripSeparator2,
            this.Play,
            this.Pause,
            this.Stop,
            this.Step,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(992, 26);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TerrainDropDown
            // 
            this.TerrainDropDown.Checked = true;
            this.TerrainDropDown.CheckOnClick = true;
            this.TerrainDropDown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TerrainDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TerrainDropDown.Image = ((System.Drawing.Image)(resources.GetObject("TerrainDropDown.Image")));
            this.TerrainDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TerrainDropDown.Name = "TerrainDropDown";
            this.TerrainDropDown.Size = new System.Drawing.Size(23, 23);
            this.TerrainDropDown.Text = "toolStripButton1";
            this.TerrainDropDown.Click += new System.EventHandler(this.TerrainDropDown_Click);
            this.TerrainDropDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TerrainDropDown_MouseDown);
            // 
            // ResourceDropDown
            // 
            this.ResourceDropDown.CheckOnClick = true;
            this.ResourceDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ResourceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("ResourceDropDown.Image")));
            this.ResourceDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResourceDropDown.Name = "ResourceDropDown";
            this.ResourceDropDown.Size = new System.Drawing.Size(23, 23);
            this.ResourceDropDown.Text = "toolStripButton1";
            this.ResourceDropDown.Click += new System.EventHandler(this.ResourceDropDown_Click);
            this.ResourceDropDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResourceDropDown_MouseDown);
            // 
            // ReliefDropDown
            // 
            this.ReliefDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReliefDropDown.Image = ((System.Drawing.Image)(resources.GetObject("ReliefDropDown.Image")));
            this.ReliefDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReliefDropDown.Name = "ReliefDropDown";
            this.ReliefDropDown.Size = new System.Drawing.Size(23, 23);
            this.ReliefDropDown.Text = "toolStripButton1";
            this.ReliefDropDown.Click += new System.EventHandler(this.ReliefDropDown_Click);
            this.ReliefDropDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ReliefDropDown_MouseDown);
            // 
            // TerritoryDropDown
            // 
            this.TerritoryDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TerritoryDropDown.Image = ((System.Drawing.Image)(resources.GetObject("TerritoryDropDown.Image")));
            this.TerritoryDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TerritoryDropDown.Name = "TerritoryDropDown";
            this.TerritoryDropDown.Size = new System.Drawing.Size(23, 23);
            this.TerritoryDropDown.Text = "toolStripButton1";
            this.TerritoryDropDown.ToolTipText = "Territory - Right click to change the players";
            this.TerritoryDropDown.Click += new System.EventHandler(this.TerritoryDropDown_Click);
            this.TerritoryDropDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TerritoryDropDown_MouseDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // ClearMap
            // 
            this.ClearMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearMap.Image = ((System.Drawing.Image)(resources.GetObject("ClearMap.Image")));
            this.ClearMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearMap.Name = "ClearMap";
            this.ClearMap.Size = new System.Drawing.Size(23, 23);
            this.ClearMap.Text = "toolStripButton1";
            this.ClearMap.ToolTipText = "Clears the map with the currently selected terrain";
            this.ClearMap.Click += new System.EventHandler(this.ClearMap_Click);
            // 
            // MapWidth
            // 
            this.MapWidth.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.MapWidth.Name = "MapWidth";
            this.MapWidth.Size = new System.Drawing.Size(47, 23);
            this.MapWidth.Text = "20";
            this.MapWidth.ValueChanged += new System.EventHandler(this.MapWidth_ValueChanged);
            // 
            // MapHeight
            // 
            this.MapHeight.Name = "MapHeight";
            this.MapHeight.Size = new System.Drawing.Size(47, 23);
            this.MapHeight.Text = "20";
            this.MapHeight.ValueChanged += new System.EventHandler(this.MapHeight_ValueChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // Play
            // 
            this.Play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Play.Image = ((System.Drawing.Image)(resources.GetObject("Play.Image")));
            this.Play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(23, 23);
            this.Play.Text = "toolStripButton1";
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Pause
            // 
            this.Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Pause.Image = ((System.Drawing.Image)(resources.GetObject("Pause.Image")));
            this.Pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(23, 23);
            this.Pause.Text = "toolStripButton1";
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Stop
            // 
            this.Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Stop.Image = ((System.Drawing.Image)(resources.GetObject("Stop.Image")));
            this.Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(23, 23);
            this.Stop.Text = "toolStripButton2";
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Step
            // 
            this.Step.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Step.Image = ((System.Drawing.Image)(resources.GetObject("Step.Image")));
            this.Step.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(23, 23);
            this.Step.Text = "toolStripButton3";
            this.Step.Click += new System.EventHandler(this.Step_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unitViewerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // unitViewerToolStripMenuItem
            // 
            this.unitViewerToolStripMenuItem.Name = "unitViewerToolStripMenuItem";
            this.unitViewerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.unitViewerToolStripMenuItem.Text = "Unit Viewer";
            this.unitViewerToolStripMenuItem.Click += new System.EventHandler(this.unitViewerToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 523);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TerrainDropDown;
        private System.Windows.Forms.ToolStripButton ResourceDropDown;
        private System.Windows.Forms.ToolStripButton ReliefDropDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ClearMap;
        private ToolStripNumberControl MapWidth;
        private ToolStripNumberControl MapHeight;
        private System.Windows.Forms.ToolStripButton TerritoryDropDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Play;
        private System.Windows.Forms.ToolStripButton Pause;
        private System.Windows.Forms.ToolStripButton Stop;
        private System.Windows.Forms.ToolStripButton Step;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitViewerToolStripMenuItem;


    }
}

