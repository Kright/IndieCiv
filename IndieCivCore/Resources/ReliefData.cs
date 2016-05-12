using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IndieCivCore.Resources {
    [XmlType("Relief")]
    public class ReliefData : DataResource {

        public string ReliefArt { get; set; }
        public string Terrain { get; set; }

        public ReliefData() {

        }
    }
}
