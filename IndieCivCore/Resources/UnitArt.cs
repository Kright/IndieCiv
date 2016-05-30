using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IndieCivCore.Resources {
    [XmlType("UnitArt")]
    public class UnitArt : ArtResource {

        //[XmlType("Anim")]
        public struct UnitAnim {
            public string Type { get; set; }
            public string Path { get; set; }
        }

        [XmlArray("Anims")]
        [XmlArrayItem("Anim")]
        //[XmlArrayItem(typeof(UnitAnim))]
        public List<UnitAnim> Anims { get; set; }

        public List<Flc> UnitFlc { get; set; }

        public UnitArt()
        {
            this.UnitFlc = new List<Flc>();
        }

        public void Init() {
            foreach (var Item in Anims) {
                Flc UnitFlc = new Flc();
                UnitFlc.UnitArt = this;
                UnitFlc.Type = Item.Type;
                UnitFlc.BufferFile(Item.Path);
                this.UnitFlc.Add(UnitFlc);
            }
        }

        public Flc GetUnitFlc(string type) {
            return UnitFlc.Find(x => x.Type == type);
        }
    }
}
