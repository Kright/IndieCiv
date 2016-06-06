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

    public enum EUnitData_AIStrategies {
        EUnitData_AIStrategy_Offense = (1 << 0),
        EUnitData_AIStrategy_Defense = (1 << 1),
        EUnitData_AIStrategy_Artillery = (1 << 2),
        EUnitData_AIStrategy_Explore = (1 << 3),
        EUnitData_AIStrategy_Army = (1 << 4),
        EUnitData_AIStrategy_CruiseMissile = (1 << 5),
        EUnitData_AIStrategy_AirBombard = (1 << 6),
        EUnitData_AIStrategy_AirDefense = (1 << 7),
        EUnitData_AIStrategy_NavalPower = (1 << 8),
        EUnitData_AIStrategy_AirTransport = (1 << 9),
        EUnitData_AIStrategy_NavalTransport = (1 << 10),
        EUnitData_AIStrategy_NavalCarrier = (1 << 11),
        EUnitData_AIStrategy_Terraform = (1 << 12),
        EUnitData_AIStrategy_Settle = (1 << 13),
    }

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

        public bool HasStrategy(EUnitData_AIStrategies strategy) {
            if ((this.AIStrategies & (long)strategy) == (long)strategy)
                return true;

            return false;
        }

        public Flc GetUnitAnimation(string type) {

            if (UnitArt == null)
                return null;

            return UnitArt.GetUnitFlc(type);
        }
    }
}
