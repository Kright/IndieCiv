using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using IndieCivCore.Serialization;

namespace IndieCivCore.Localization {
    public class Locale {

        [XmlType("String")]
        public class StringItem {
            [XmlAttribute("Name")]
            public string Key;

            [XmlText]
            public string Value;
        }

        Dictionary<string, string> Strings;

        public void Load(string lang) {
            Strings = XmlFormatter.Load<StringItem[]>(lang).ToDictionary(i => i.Key, i => i.Value);
        }

        public void AddString(string Key, string Value) {
            if (Strings.ContainsKey(Key)) {
            }
            else {
                Strings[Key] = Value;
            }
        }

        public string GetString(string Key) {
            try {
                return Strings[Key];
            }
            catch (Exception e) {
                //Console.WriteLine(e);
            }
            return "UNKNOWN LOCALE KEY";
        }

    }
}
