using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework.Graphics;

namespace IndieCivCore.Resources
{
	public abstract class ArtResource : Resource
	{
        public string Type { get; set; }

		public override void Load()
		{
		}

    }
}
