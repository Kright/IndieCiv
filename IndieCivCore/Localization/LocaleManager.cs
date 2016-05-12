using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


using IndieCivCore.Serialization;

namespace IndieCivCore.Localization {
    public static class LocaleManager {

        public class LocaleItem {
            [XmlAttribute]
            public string Name;
            [XmlAttribute]
            public string FileName;

        }
        public static Dictionary<string, string> Locales;
        public static Locale Locale = new Locale();

        public static void Load() {
            Locales = XmlFormatter.Load<LocaleItem[]>("LocaleManager").ToDictionary(i => i.Name, i => i.FileName);

            LoadLocale("English");
        }

        public static void LoadLocale(string lang) {
            LocaleManager.Locale.Load(lang);
        }

        public static void AddLocale(string Key, string Value) {
            LocaleManager.Locale.AddString(Key, Value);
        }

        public static string GetLocale(string Key) {
            return LocaleManager.Locale.GetString(Key);
        }
    }
}
