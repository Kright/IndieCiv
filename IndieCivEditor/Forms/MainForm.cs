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

using Microsoft.Xna.Framework.Input;

using IndieCivEditor.Forms;

using IndieCivCore;
using IndieCivCore.Map;
using IndieCivCore.Resources;
using IndieCivCore.Localization;
using IndieCivCore.Entities;

namespace IndieCivEditor
{
    public partial class MainForm : Form
    {
        public MapView MapView = null;
        public IndieCivEditor.Forms.Properties Properties = null;

        public DockPanel MainDockPanel
        {
            get { return this.dockPanel1; }
        }

        public MainForm()
        {
            InitializeComponent();
            InitMapView();
            InitProperties();
            IndieCivEditorApp.Init(this);

            TerrainDropDown.ToolTipText = LocaleManager.GetLocale(IndieCivEditorApp.SelectedTerrain.Description);

            //toolStrip1.Renderer = new MyRenderer();
        }

        private void InitMapView()
        {
            MapView = new MapView();
            MapView.Show(this.dockPanel1);
            if (MapView.Pane != null)
            {
                //MapView.Pane.Activate();
                //MapView.Focus();
            }
        }

        private void InitProperties() {
            Properties = new IndieCivEditor.Forms.Properties();
            Properties.Show(this.dockPanel1);
            if (Properties.Pane != null) {
                Properties.Pane.Activate();
                Properties.Focus();
            }   
        }

        protected override bool ProcessKeyPreview(ref Message m) {
            MapView.mapViewRender1.ProcessKeyMessage(ref m);
            return base.ProcessKeyPreview(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, System.Windows.Forms.Keys keyData) {
            MapView.mapViewRender1.ProcessKeyMessage(ref msg);
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog importDialog = new OpenFileDialog();
            importDialog.CheckFileExists = true;
            importDialog.CheckPathExists = true;
            importDialog.Multiselect = false;
            importDialog.Title = "Select Civ3 Scenario File..";
            importDialog.RestoreDirectory = true;
            importDialog.InitialDirectory = Environment.CurrentDirectory;
            importDialog.AddExtension = true;
            importDialog.Filter = "Civ3 Scenario Files (*.bic;*.biq;*.bix)|*.bic;*.biq;*.bix";
            importDialog.FilterIndex = 2;
            importDialog.CustomPlaces.Add(Environment.CurrentDirectory);

            if (importDialog.ShowDialog(this) == DialogResult.OK)
            {
                using (var biqLoader = IndieCivEditor.BIQ.BIQLoader.Create())
                {
                    if (biqLoader.Load(importDialog.FileName) == false)
                    {
                        //Log.Core.WriteError("Error loading: {0}", importDialog.FileName);
                    }
                    biqLoader.Import();
                    //Game.Instance.Init();
                    MapManager.Current.MapTileSelectedEvent += OnMapTileSelectedEvent;
                }
            }
        }

        void OnMapTileSelectedEvent(object sender, EventArgs e) {
            this.Properties.UpdatePropertyGrid();
        }

        public void UpdateToolStrip() {
            this.toolStripStatusLabel1.Text = string.Format("X: {0}, Y: {1} - Moved X: {2}, Moved Y: {3} - Left: {4}, Right: {5}, Middle: {6}", IndieCivCore.MouseState.Position.X, IndieCivCore.MouseState.Position.Y, IndieCivCore.MouseState.Moved.X, IndieCivCore.MouseState.Moved.Y, IndieCivCore.MouseState.Left, IndieCivCore.MouseState.Right, IndieCivCore.MouseState.Middle);
            if (MapManager.Current != null && MapManager.Current.HighlightedMapTile != null) {
                MapTile MapTile = MapManager.Current.HighlightedMapTile;
                this.toolStripStatusLabel2.Text = string.Format("X: {0}, Y: {1}", MapTile.X, MapTile.Y );
            }
            this.statusStrip1.Refresh();
        }

        private void toolStripStatusLabel1_Paint(object sender, PaintEventArgs e) {

            //this.toolStripStatusLabel1.Text = string.Format("X: {0}, Y: {1}", Mouse.GetState().X, Mouse.GetState().Y);
            //this.statusStrip1.Refresh();
        }

        /*private class MyRenderer : ToolStripProfessionalRenderer {
            protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e) {
                var btn = e.Item as ToolStripSplitButton;
                if (btn != null) {
                    if (IndieCivEditorApp.EditorMode == EEditorMode.EEditorMode_Terrain && btn == this.TerrainDropDown) { }
                    Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.CadetBlue, bounds);
                }
                else base.OnRenderButtonBackground(e);
            }
        }*/

        private void TerrainDropDown_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {

                ContextMenuStrip _contextMenuStrip = new ContextMenuStrip();

                foreach (var Terrain in ResourceInterface.TerrainData) {
                    ToolStripItem item = _contextMenuStrip.Items.Add(LocaleManager.GetLocale(Terrain.Description));

                    item.Tag = Terrain;
                    item.Click += Terrain_Click;
                    ((ToolStripMenuItem)item).CheckOnClick = true;

                    if (IndieCivEditorApp.SelectedTerrain == Terrain)
                        ((ToolStripMenuItem)item).Checked = true;
                }

                if (_contextMenuStrip != null)
                    _contextMenuStrip.Show(Cursor.Position);
            }
        }

        void Terrain_Click(object sender, EventArgs e) {
            TerrainData Terrain = (TerrainData)((ToolStripItem)sender).Tag;

            IndieCivEditorApp.SelectedTerrain = Terrain;
            TerrainDropDown.ToolTipText = LocaleManager.GetLocale(IndieCivEditorApp.SelectedTerrain.Description);

        }

        private void ResourceDropDown_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {

                ContextMenuStrip _contextMenuStrip = new ContextMenuStrip();

                foreach (var Resource in ResourceInterface.ResourceData) {
                    ToolStripItem item = _contextMenuStrip.Items.Add(LocaleManager.GetLocale(Resource.Description));

                    item.Tag = Resource;
                    item.Click += Resource_Click;
                    ((ToolStripMenuItem)item).CheckOnClick = true;

                    if (IndieCivEditorApp.SelectedResource == Resource)
                        ((ToolStripMenuItem)item).Checked = true;
                }

                if (_contextMenuStrip != null)
                    _contextMenuStrip.Show(Cursor.Position);
            }
        }

        void Resource_Click(object sender, EventArgs e) {
            ResourceData Resource = (ResourceData)((ToolStripItem)sender).Tag;

            IndieCivEditorApp.SelectedResource = Resource;
            ResourceDropDown.ToolTipText = LocaleManager.GetLocale(IndieCivEditorApp.SelectedResource.Description);
        }

        void UpdateToolOptions(object sender) {
            ToolStripButton[] buttons = {TerrainDropDown, ResourceDropDown, ReliefDropDown, TerritoryDropDown};
            foreach (ToolStripButton item in buttons) {
                if (item == sender) item.Checked = true;
                if ((item != null) && (item != sender)) {
                    item.Checked = false;
                }
            }
        }

        private void TerrainDropDown_Click(object sender, EventArgs e) {
            IndieCivEditorApp.EditorMode = EEditorMode.EEditorMode_Terrain;
            UpdateToolOptions(sender);
        }
        private void ResourceDropDown_Click(object sender, EventArgs e) {
            IndieCivEditorApp.EditorMode = EEditorMode.EEditorMode_Resource;
            UpdateToolOptions(sender);
        }

        private void ReliefDropDown_Click(object sender, EventArgs e) {
            IndieCivEditorApp.EditorMode = EEditorMode.EEditorMode_Relief;
            UpdateToolOptions(sender);
        }

        private void ReliefDropDown_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {

                ContextMenuStrip _contextMenuStrip = new ContextMenuStrip();

                foreach (var Relief in ResourceInterface.ReliefData) {
                    ToolStripItem item = _contextMenuStrip.Items.Add(LocaleManager.GetLocale(Relief.Description));

                    item.Tag = Relief;
                    item.Click += Relief_Click;
                    ((ToolStripMenuItem)item).CheckOnClick = true;

                    if (IndieCivEditorApp.SelectedRelief == Relief)
                        ((ToolStripMenuItem)item).Checked = true;
                }

                if (_contextMenuStrip != null)
                    _contextMenuStrip.Show(Cursor.Position);
            }
        }

        void Relief_Click(object sender, EventArgs e) {
            ReliefData Relief = (ReliefData)((ToolStripItem)sender).Tag;

            IndieCivEditorApp.SelectedRelief = Relief;
            ReliefDropDown.ToolTipText = LocaleManager.GetLocale(IndieCivEditorApp.SelectedRelief.Description);
        }

        private void ClearMap_Click(object sender, EventArgs e) {
            MapManager.Current.ClearMap(IndieCivEditorApp.SelectedTerrain);
        }

        private void MapHeight_ValueChanged(object sender, EventArgs e) {
            ResizeMap();
        }

        private void MapWidth_ValueChanged(object sender, EventArgs e) {
            ResizeMap();
        }

        private void ResizeMap() {
            int x = 0, y = 0;
            if (MapManager.Current.SelectedMapTile != null) {
                x = MapManager.Current.SelectedMapTile.X;
                y = MapManager.Current.SelectedMapTile.Y;
            }
            MapManager.Current.Resize((int)this.MapWidth.spinner.Value, (int)this.MapHeight.spinner.Value);
            MapManager.Current.SelectedMapTile = MapManager.Current[x, y];
            MapManager.Current.FireMapTileSelected();
        }

        private void TerritoryDropDown_Click(object sender, EventArgs e) {
            IndieCivEditorApp.EditorMode = EEditorMode.EEditorMode_Territory;
            UpdateToolOptions(sender);
        }

        private void TerritoryDropDown_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {

                ContextMenuStrip _contextMenuStrip = new ContextMenuStrip();

                foreach (var Player in PlayerManager.PlayerList) {
                    ToolStripItem item = _contextMenuStrip.Items.Add(LocaleManager.GetLocale(Player.CivilizationData.Description));

                    item.Tag = Player;
                    item.Click += Territory_Click;
                    ((ToolStripMenuItem)item).CheckOnClick = true;

                    if (IndieCivEditorApp.Player == Player)
                        ((ToolStripMenuItem)item).Checked = true;
                }

                if (_contextMenuStrip != null)
                    _contextMenuStrip.Show(Cursor.Position);
            }
        }

        void Territory_Click(object sender, EventArgs e) {
            Player Player = (Player)((ToolStripItem)sender).Tag;

            IndieCivEditorApp.Player = Player;
            TerritoryDropDown.ToolTipText = LocaleManager.GetLocale(IndieCivEditorApp.Player.CivilizationData.Description);
        }

        private void Play_Click(object sender, EventArgs e) {
            IndieCivCoreApp.EExecutionState = EExecutionState.Playing;
        }

        private void Pause_Click(object sender, EventArgs e) {
            IndieCivCoreApp.EExecutionState = EExecutionState.Paused;
        }

        private void Stop_Click(object sender, EventArgs e) {
            IndieCivCoreApp.EExecutionState = EExecutionState.Stopped;

            Game.Instance.Reset();
        }

        private void Step_Click(object sender, EventArgs e) {

        }

        private void unitViewerToolStripMenuItem_Click(object sender, EventArgs e) {

        }
    }
}
