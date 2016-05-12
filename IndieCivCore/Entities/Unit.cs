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
        public int NumMoves { get; set; }
        public bool Active { get; set; }

        public MapTile MapTile { get; set; }

        public Civilization Owner { get; set; }
        public UnitData UnitData { get; set; }
        public UnitAnimation UnitAnimation { get; set; }

        Vector2 Position { get; set; }

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

                FrameCount += Delta;
                if (FrameCount >= 1.0f)
                    FrameCount = 0;
            }

        }

        public override void Render() {
            if (UnitState & EUnitState_Moving) {
                UnitAnimation.Render(Position);
            }
            else {

                Position.X = MapTile.ScreenXPos;
                Position.Y = MapTile.ScreenYPos;

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
