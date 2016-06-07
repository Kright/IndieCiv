using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieCivCore.Entities.AI {
    static class AISettler {
        public static void AISettlerUpdate(Unit unit) {
            if (unit.UnitStates != Unit.EUnitStates.EUnitState_Idle)
                return;

            if (unit.Owner.CityList.Count == 0) {
                unit.UnitStates = Unit.EUnitStates.EUnitState_Building;
                unit.UnitAnimation.PlayAnimation(UnitAnimation.EAnimStates.EAnimState_Building, 
                    unit.UnitAnimation.AnimDirection, unit.UnitData);
            }
            else {
                if (AICityBuildRange(unit, 6))
                    return;

                if (AICityBuildRange(unit, 12))
                    return;
            }
        }

        public static bool AICityBuildRange(Unit unit, int range) {

            return false;
        }
    }
}
