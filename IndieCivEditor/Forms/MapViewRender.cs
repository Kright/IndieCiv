using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using IndieCivCore;
using IndieCivCore.Map;
using IndieCivCore.Resources;

namespace IndieCivEditor
{
    public class MapViewRender : GraphicsDeviceControl
    {
        GameTime game_time;
        Stopwatch timer;
        TimeSpan elapsed;

        SpriteBatch sprite_batch;
        SpriteFont sprite_font;

        Texture2D MapTileFrame;

        ContentManager content_manager;

        int frame_rate       = 0;
        int frame_counter    = 0;

        TimeSpan elapsedTime = TimeSpan.Zero;

        protected override void Initialize()
        {
            timer = Stopwatch.StartNew();
            game_time = new GameTime();

            content_manager = new ContentManager(this.Services, "Content");
            Globals.ContentManager = content_manager;
            Globals.GraphicsDevice = this.GraphicsDevice;

            Globals.ScreenWidth = ClientSize.Width;
            Globals.ScreenHeight = ClientSize.Height;

            ResourceInterface.Init();

            sprite_font = content_manager.Load<SpriteFont>("TestFont");
            sprite_batch = new SpriteBatch(this.GraphicsDevice);

            MapTileFrame = Utils.LoadTexture("Assets/Art/UI/Frame.bmp", new Color(Color.Magenta, 255));

            Application.Idle += delegate { Invalidate(); };
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Black);

            game_time.TotalGameTime = timer.Elapsed;
            game_time.ElapsedGameTime = timer.Elapsed - elapsed;
            elapsed = timer.Elapsed;

            elapsedTime += game_time.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1)) {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frame_rate = frame_counter;
                frame_counter = 0;
            }

            string fps = string.Format("fps: {0} mem : {1}", frame_rate, GC.GetTotalMemory(false));

            frame_counter++;

            System.Drawing.Point p = this.PointToClient(Control.MousePosition);

            IndieCivCore.MouseState.Update(p.X, p.Y);

            IndieCivEditorApp.Update(game_time);

            IndieCivEditorApp.Render(game_time);

            sprite_batch.Begin();

            if (MapManager.Current != null && MapManager.Current.HighlightedMapTile != null) {

                int x = MapManager.Current.HighlightedMapTile.ScreenXPos - MapRendering.TileWidthHalf;
                int y = MapManager.Current.HighlightedMapTile.ScreenYPos - MapRendering.TileHeightHalf;

                sprite_batch.Draw(MapTileFrame, new Vector2(x, y), new Color(255, 255, 255, 100));
            }
            if (MapManager.Current != null && MapManager.Current.SelectedMapTile != null) {
                int x = MapManager.Current.SelectedMapTile.ScreenXPos - MapRendering.TileWidthHalf;
                int y = MapManager.Current.SelectedMapTile.ScreenYPos - MapRendering.TileHeightHalf;

                sprite_batch.Draw(MapTileFrame, new Vector2(x, y), new Color(255, 255, 255, 255));

            }


            sprite_batch.DrawString(sprite_font, fps, new Vector2(1, 1), Color.Black);
            sprite_batch.DrawString(sprite_font, fps, new Vector2(0, 0), Color.White);
            sprite_batch.End();

            IndieCivEditorApp.MainForm.UpdateToolStrip();

            IndieCivCore.MouseState.Reset();
        }
    }
}
