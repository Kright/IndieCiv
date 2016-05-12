using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace IndieCivCore.Serialization {
    public static class XmlFormatter {

        public static T Load<T>(string xml) {
            T instance;
            string Path = "";

            if (File.Exists(string.Format("Assets//XML//{0}.xml", xml))) {
                Path = string.Format("Assets//XML//{0}.xml", xml);
            }
            else if (File.Exists(string.Format("..//..//Assets//XML//{0}.xml", xml))) {
                Path = string.Format("..//..//Assets//XML//{0}.xml", xml);
            }

            using (TextReader reader = new StreamReader(Path)) {
                XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xml) );
                instance = (T)serializer.Deserialize(reader);
            }

            return instance;
        }

        public static T LoadToDictionary<T>(string xml) {
            T instance;
            string Path = "";

            if (File.Exists(string.Format("Assets//XML//{0}.xml", xml))) {
                Path = string.Format("Assets//XML//{0}.xml", xml);
            }
            else if (File.Exists(string.Format("..//..//Assets//XML//{0}.xml", xml))) {
                Path = string.Format("..//..//Assets//XML//{0}.xml", xml);
            }
            using (TextReader reader = new StreamReader(Path)) {
                XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xml));
                instance = ((T)serializer.Deserialize(reader));
            }

            return instance;
        }
    }
}
