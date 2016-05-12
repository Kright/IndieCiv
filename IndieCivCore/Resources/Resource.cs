using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IndieCivCore.Resources
{
	public abstract class Resource
	{

        public int Index { get; set; }


		/*[XmlIgnore]
		protected string path = null;

        [XmlIgnore]
		public string Path
		{
			get { return this.path; }
			internal set { this.path = value; }
		}*/

		public abstract void Load();



	}
}
