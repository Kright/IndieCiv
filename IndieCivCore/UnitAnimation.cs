using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using IndieCivCore.Map;

namespace IndieCivCore {
    public class UnitAnimation {

        public enum EAnimStates {
            EAnimState_Default,
            EAnimState_Running,
            EAnimState_Building,
            EAnimState_Roading,
            EAnimState_Irrigating,
        }

        public int CurrentFrame { get; set; }
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        public float Speed { get; set; }

        public Texture2D CurrentTexture;

        public Flc CurrentFlc { get; set; }

        public MapTile.NeighbouringDirections AnimDirection { get; set; }

        public UnitAnimation.EAnimStates AnimState { get; set; }
        public SpriteBatch spriteBatch { get; set; }

        public UnitAnimation() {
            spriteBatch = new SpriteBatch(Globals.GraphicsDevice);
        }

        public void Start(MapTile.NeighbouringDirections Direction) {
            AnimDirection = Direction;
            CurrentFrame = StartFrame = (int)AnimDirection * (CurrentFlc.Civ3Header.animLength+1);
            //CurrentFrame = StartFrame = 0;
            //EndFrame = 14;
            EndFrame = StartFrame + CurrentFlc.Civ3Header.animLength;
            //EndFrame = ((int)AnimDirection * CurrentFlc.Civ3Header.animLength) + CurrentFlc.Civ3Header.animLength - 1;

            Speed = (float)CurrentFlc.FlcHeader.speed;
        }

        public bool Update() {

            if (CurrentFlc == null) return false;

            Speed -= (float)IndieCivCoreApp.gameTime.ElapsedGameTime.TotalMilliseconds;

            if (Speed < 0.0f) {
                Speed = CurrentFlc.FlcHeader.speed;

                CurrentFrame++;
                CurrentTexture = null;

                if (CurrentFrame > EndFrame)
                    CurrentFrame = StartFrame;
            }

            return false;
        }

        public void Render(Vector2 position) {
            if (this.CurrentFlc == null)
                return;

            int x = ((int)position.X) - (240 / 2) + this.CurrentFlc.Civ3Header.xOffset;
            int y = ((int)position.Y) - (240 / 2) + this.CurrentFlc.Civ3Header.yOffset;

            int Width = this.CurrentFlc.FlcHeader.width;
            int Height = this.CurrentFlc.FlcHeader.height;

            if ( CurrentTexture == null )
                CurrentTexture = CurrentFlc.GetTexture(this.CurrentFrame);
            
            spriteBatch.Begin();
            spriteBatch.Draw(CurrentTexture, new Vector2(x, y));
            spriteBatch.End();

        }

        public void PlayAnimation ( UnitAnimation.EAnimStates animState, MapTile.NeighbouringDirections direction, IndieCivCore.Resources.UnitData unitData ) {
            AnimState = animState;

            switch ( AnimState ) {
                case EAnimStates.EAnimState_Default:
                    this.CurrentFlc = unitData.GetUnitAnimation("UNIT_ART_DEFAULT");
                    break;

            }

            if ( this.CurrentFlc != null )
                this.Start(direction);
        }
    }
}
