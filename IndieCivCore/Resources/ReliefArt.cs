using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using Microsoft.Xna.Framework.Graphics;

using IndieCivCore.Map;

namespace IndieCivCore.Resources {
    [Serializable]
    [XmlType("ReliefArt")]
    public class ReliefArt : ArtResource {
        public string Path { get; set; }
        

        [XmlElement("iWidth")]
        public int Width { get; set; }
        [XmlElement("iHeight")]
        public int Height { get; set; }

        [XmlIgnore]
        public Texture2D Texture { get; set; }

        public ReliefArt()
        {
			Path = "xtgc.pcx";
        }

        public void Init() {
            MapRendering.AddReliefGraphic(this.Path);
        }

        public override void Load() {
            base.Load();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            if (string.IsNullOrEmpty(Path)) throw new ApplicationException("TerrainArt Path is null or empty");
            if (!System.IO.File.Exists(Path)) throw new ApplicationException("TerrainArt Path does not exist");

            Texture = Globals.ContentManager.Load<Texture2D>(Path);
        }
    }
}
