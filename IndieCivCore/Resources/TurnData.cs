using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IndieCivCore.Resources {
    [XmlType("Turn")]
    public class TurnData : DataResource {
        [XmlElement("iNumTurns")]
        public int NumTurns { get; set; }
        [XmlElement("iStepValue")]
        public int StepValue { get; set; }
    }
}
