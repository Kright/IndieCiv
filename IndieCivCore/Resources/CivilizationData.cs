using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace IndieCivCore.Resources {
    public class CivilizationData : DataResource {
        public Color Color { get; set; }

        public List<string> CityNames { get; set; }
        public List<AdvanceData> FreeAdvances { get; set; }

        public CivilizationData() {
            CityNames = new List<string>();
            FreeAdvances = new List<AdvanceData>();
        }
    }
}
