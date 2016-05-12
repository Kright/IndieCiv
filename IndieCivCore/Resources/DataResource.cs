using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Localization;

namespace IndieCivCore.Resources
{
	public class DataResource : Resource
	{
		public enum ResourceType
		{
			Terrain,
			Unit,
			Resource,
			Civilization,
		};

        public string Type { get; set; }

        public string Description;

		public override void Load()
		{

		}


        public override String ToString() {
            return LocaleManager.GetLocale(Description);
        }
	}
}
