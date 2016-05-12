using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IndieCivCore.Map;
using IndieCivCore.Resources;

namespace IndieCivCore.Entities {
    public class Player : Civilization {
        public bool IsAI { get; set; }
        public CivilizationData CivilizationData { get; set; }

        public override void Update() {
            base.Update();
        }
        public override void Render() {
            base.Render();
        }

        public override void UpdateEndOfTurn() {
            base.UpdateEndOfTurn();
        }

        public override Unit AddUnit(UnitData UnitData, MapTile MapTile) {
            ActiveUnit = base.AddUnit(UnitData, MapTile);

            ActiveUnit.Owner = this;

            ActiveUnit.CenterOnMap();

            return ActiveUnit;

        }
    }
}
