using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IndieCivCore.Resources;
using IndieCivCore.Entities.AI;

namespace IndieCivCore.Entities {
    static class UnitAI {

        public static void UpdateAI(Unit unit) {
            if (unit.UnitData.HasStrategy(EUnitData_AIStrategies.EUnitData_AIStrategy_Settle)) {
                AISettler.AISettlerUpdate(unit);
            }
        }
    }
}
