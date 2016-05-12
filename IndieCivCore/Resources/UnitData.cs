using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieCivCore.Resources {
    public enum EUnitData_DomainType {
        EUnitData_DomainType_Land,
        EUnitData_DomainType_Sea,
        EUnitData_DomainType_Air,
    };

    public class UnitData : DataResource {
        public int NumMoves { get; set; }
        public int Cost { get; set; }
        public int PopulationCost { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int BombardStr { get; set; }
        public int BombardRange { get; set; }
        public EUnitData_DomainType DomainType { get; set; }
        public long AIStrategies { get; set; }

        public UnitArt UnitArt { get; set; }
    }
}
