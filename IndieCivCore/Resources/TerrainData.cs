using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using IndieCivCore.Localization;

namespace IndieCivCore.Resources
{
    [XmlType("Terrain")]
    public class TerrainData : DataResource
    {
        //[XmlType("Blend")]
        public struct TerrainBlend {
            public string From { get; set; }
            public string To { get; set; }
        }

        [XmlArray("TerrainArts")]
        [XmlArrayItem("TerrainArt")]
        public List<string> TerrainArt { get; set; }

        [XmlArray("Blends")]
        [XmlArrayItem("Blend")]
        //[XmlArrayItem(typeof(TerrainBlend))]
        public List<TerrainBlend> Blend { get; set; }

        public TerrainData()
        {
            TerrainArt = new List<string>();
        }


    }
}
