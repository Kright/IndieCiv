using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using Microsoft.Xna.Framework.Graphics;

using IndieCivCore.Map;

namespace IndieCivCore.Resources
{
    [Serializable]
    [XmlType("TerrainArt")]
    public class TerrainArt : ArtResource 
    {
		public string Path { get; set; }

        [XmlArray("Blends")]
        [XmlArrayItem("Blend")]
		public List<string> Blend { get; set; }

        [XmlIgnore]
		public Texture2D Texture { get; set; }

        public TerrainArt ()
        {
			Path = "xtgc.pcx";
            Blend = new List<string>();
        }

        public void Init() { 
            MapRendering.AddTerrainGraphic(this.Path);
        }

		public override void Load()
		{
			base.Load();

			string curDir = System.IO.Directory.GetCurrentDirectory();

			if ( string.IsNullOrEmpty( Path ) ) throw new ApplicationException( "TerrainArt Path is null or empty" );
			if ( !System.IO.File.Exists( Path ) ) throw new ApplicationException( "TerrainArt Path does not exist" );

			Texture = Globals.ContentManager.Load<Texture2D>( Path );
		}
    }
}
