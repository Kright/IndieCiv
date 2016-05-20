using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Flc CurrentFlc { get; set; }

        public MapTile.NeighbouringDirections AnimDirection { get; set; }

        public UnitAnimation.EAnimStates AnimState { get; set; }

        public void Start(MapTile.NeighbouringDirections Direction) {
            AnimDirection = Direction;
            CurrentFrame = StartFrame = AnimDirection * CurrentFlc.Civ3Header.animLength;

            EndFrame = (AnimDirection * CurrentFlc.Civ3Header.animLength) + CurrentFlc.Civ3Header.animLength - 1;

            Speed = (float)CurrentFlc.FlcHeader.speed;
        }

        public bool Update() {

            Speed -= IndieCivCoreApp.gameTime.TotalGameTime.Seconds * 1000.0f;

            if (Speed < 0.0f) {
                Speed = CurrentFlc.FlcHeader.speed;

                CurrentFrame++;
            }

            return false;
        }

        public void Render(Vector2 position) {
            if (this.CurrentFlc == null)
                return;

            x = (x) - (240 / 2) + this.CurrentFlc.Civ3Header.xOffset;
            y = (y) - (240 / 2) + this.CurrentFlc.Civ3Header.yOffset;

            int Width = this.CurrentFlc.FlcHeader.width;
            int Height = this.CurrentFlc.FlcHeader.height;

            if ( CurrentTexture == null )
                CurrentTexture = CurrentFlc.GetTexture(this->CurrentFrame);




        }

        public void PlayAnimation ( UnitAnimation.EAnimStates animState, MapTile.NeighbouringDirections direction, IndieCivCore.Resources.UnitData unitData ) {
            AnimState = animState;

            switch ( AnimState ) {
                case EAnimStates.EAnimState_Default:
                    this.CurrentFlc = unitData.GetUnitAnimation("UNIT_ART_DEFAULT");
                    break;

            }

            if (this.CurrentFlc)
                this.CurrentFlc.Start(direction);
        }
    }
}
