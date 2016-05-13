using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using IndieCivCore.Resources;
using IndieCivCore.Map;

namespace IndieCivCore.Entities {
    public class Unit : Entity, IMapInterface {
        public enum EUnitStates {
            EUnitState_Idle             = 0,
            EUnitState_Automate         = (1 << 0),
            EUnitState_Explore          = (1 << 1),
            EUnitState_Building         = (1 << 2),
            EUnitState_TileImprovement  = (1 << 3),
            EUnitState_Moving           = (1 << 4),
        }

        public int NumMoves { get; set; }
        public bool Active { get; set; }
        private float FrameCount { get; set; }

        public MapTile MapTile { get; set; }

        public Civilization Owner { get; set; }
        public UnitData UnitData { get; set; }
        public UnitAnimation UnitAnimation { get; set; }

        public EUnitStates UnitStates { get; set; }

        Vector2 Position

        public Unit(UnitData UnitData, MapTile MapTile) {
            this.UnitData = UnitData;
            this.MapTile = MapTile;
        }

        public void Init() {
            UnitAnimation.PlayAnimation(UnitAnimation.EAnimStates.EAnimState_Default, MapTile.NeighbouringDirections.South, UnitData);
        }

        public override void Update() {
            if (UnitAnimation.Update()) {

            }

            if (Active == true) {

                FrameCount += (float)IndieCivCoreApp.gameTime.ElapsedGameTime.TotalSeconds;
                if (FrameCount >= 1.0f)
                    FrameCount = 0;
            }

        }

        public override void Render() {
            if ( ( UnitStates & EUnitStates.EUnitState_Moving ) == EUnitStates.EUnitState_Moving ) {
                UnitAnimation.Render(Position);
            }
            else {

                this.Position.X = MapTile.ScreenXPos;
                this.Position.Y = MapTile.ScreenYPos;

                if (Active == true) {
                    if (FrameCount >= 0 && FrameCount <= 0.8f) {
                        if (MapTile.OnScreen == true) {
                            UnitAnimation.Render(Position);
                        }
                    }
                }
                else {
                    if (MapTile.OnScreen == true) {
                        UnitAnimation.Render(Position);
                    }
                    else {
                        // DROP TEXTURE
                    }

                }

            }
        }

        public void ResetMoves() {
            this.NumMoves = UnitData.NumMoves;
        }

        public override void UpdateEndOfTurn() {

        }

        public void CenterOnMap() {
            throw new NotImplementedException();
        }
    }
}
