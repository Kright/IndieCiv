using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IndieCivCore.Resources;
using IndieCivCore.Map;

namespace IndieCivCore.Entities
{
    public class Civilization : Entity, IUpdateEndOfTurn {

        public List<City> CityList { get; set; }
        public List<Unit> UnitList { get; set; }

        public Unit ActiveUnit { get; set; }

        public EraData CurrentEra { get; set; }

        public GovernmentData GovernmentData { get; set; }

        public Civilization() {
            CityList = new List<City>();
            UnitList = new List<Unit>();
        }

        public override void Update() {
            foreach (var Item in UnitList) {
                Item.Update();
            }

        }

        public override void Render() {
            foreach (var Item in UnitList) {
                Item.Render();
            }
            foreach (var Item in CityList) {
                Item.Render();
            }

        }

        public override void UpdateEndOfTurn() {
            foreach (var Item in UnitList) {
                Item.UpdateEndOfTurn();
            }
            foreach (var Item in CityList) {
                Item.UpdateEndOfTurn();
            }

            ResetUnits();
            ActiveUnit = GetNextUnit();
        }

        public void ResetUnits() {

        }

        public Unit GetNextUnit() {
            return null;
        }

        public virtual Unit AddUnit(UnitData UnitData, MapTile MapTile) {
            foreach (var Item in UnitList) {
                Item.Active = false;
            }

            Unit Unit = new Unit(UnitData, MapTile);
            Unit.Init();
            Unit.ResetMoves();
            Unit.Owner = this;
            Unit.Active = true;

            MapTile.AddUnit(Unit);

            UnitList.Add(Unit);

            return Unit;
        }

        public bool ActiveUnitsLeft() {
            if ( UnitList.Find(u => u.Active == true) == null )
                return false;
            return true;
        }
    }
}
