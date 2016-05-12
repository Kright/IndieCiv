using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using IndieCivCore;
using IndieCivCore.Resources;
using IndieCivCore.Entities;

namespace IndieCivEditor
{
    public enum EEditorMode {
        EEditorMode_Terrain,
        EEditorMode_Resource,
        EEditorMode_Relief,
        EEditorMode_Territory,
    }

    public static class IndieCivEditorApp
    {
        private static MainForm mainForm = null;

        public static EEditorMode EditorMode = EEditorMode.EEditorMode_Resource;

        public static TerrainData SelectedTerrain;
        public static ResourceData SelectedResource;
        public static ReliefData SelectedRelief;
        public static Player Player;

        public static MainForm MainForm {
            get {
                return IndieCivEditorApp.mainForm;
            }

            private set{}
        }

        public static void Init(MainForm main_form)
        {
            IndieCivEditorApp.mainForm = main_form;
            IndieCivCore.IndieCivCoreApp.Init(EExecutionEnvironment.EExecutionEnvironment_Editor);

            IndieCivEditorApp.SelectedTerrain = ResourceInterface.TerrainData[3];
            IndieCivEditorApp.SelectedResource = null;
            IndieCivEditorApp.SelectedRelief = ResourceInterface.ReliefData[0];

            //IndieCivCore.Map.MapCiv3 worldMap = new IndieCivCore.Map.MapCiv3();
            //worldMap.Init(100, 100);
            //worldMap.RegisterTerrainArt(Art);
            //IndieCivCore.MapManager.Add(worldMap);
        }

        public static void Update(GameTime game_time) {

            KeyboardState state = ControlKeyboard.GetState();

            if (state.IsKeyDown(Keys.LeftControl) && IndieCivCore.MouseState.Left == IndieCivCore.ButtonState.Pressed && MapManager.Current.HighlightedMapTile != null) {

                if (EditorMode == EEditorMode.EEditorMode_Terrain) {
                    MapManager.Current.HighlightedMapTile.TerrainType = IndieCivEditorApp.SelectedTerrain;
                    MapManager.Current.SmoothTile(MapManager.Current.HighlightedMapTile);
                    MapManager.Current.SetTexturesTile(MapManager.Current.HighlightedMapTile, 2);
                    MapManager.Current.Dirty = true;
                }
                else if (EditorMode == EEditorMode.EEditorMode_Resource) {
                    MapManager.Current.HighlightedMapTile.ResourceType = IndieCivEditorApp.SelectedResource;
                    //MapManager.Current.SmoothTile(MapManager.Current.HighlightedMapTile);
                    //MapManager.Current.SetTexturesTile(MapManager.Current.HighlightedMapTile, 2);
                    MapManager.Current.Dirty = true;

                }
                else if (EditorMode == EEditorMode.EEditorMode_Relief) {
                    MapManager.Current.HighlightedMapTile.ReliefType = IndieCivEditorApp.SelectedRelief;
                    //MapManager.Current.SmoothTile(MapManager.Current.HighlightedMapTile);
                    MapManager.Current.SetTexturesTile(MapManager.Current.HighlightedMapTile, 2);
                    MapManager.Current.Dirty = true;

                }
            }
            else if (state.IsKeyDown(Keys.LeftControl) && IndieCivCore.MouseState.Left == IndieCivCore.ButtonState.Released && MapManager.Current.HighlightedMapTile != null) {
                MapManager.Current.HighlightedMapTile.Owner = IndieCivEditorApp.Player;
                MapManager.Current.Dirty = true;
            }

            IndieCivCore.IndieCivCoreApp.Update(game_time, state);
        }

        public static void Render(GameTime game_time) {
            IndieCivCore.IndieCivCoreApp.Render(game_time);
        }
    }
}
