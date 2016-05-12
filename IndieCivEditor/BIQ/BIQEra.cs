using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQEra
    {
        public enum BIQEraSizes
        {
            EraName = 64,
            CivilopediaEntry = 32,
            Researcher1 = 32,
            Researcher2 = 32,
            Researcher3 = 32,
            Researcher4 = 32,
            Researcher5 = 32,
        };

        /*public static Dictionary<string, Tuple<DataType, Type, int>> propertyNames = new Dictionary<string, Tuple<DataType, Type, int>>()
	    {            
            {"EraName", Tuple.Create(DataType.String, typeof(string), (int)BIQEraSizes.EraName)},
            {"CivilopediaEntry", Tuple.Create(DataType.String, typeof(string),(int)BIQEraSizes.CivilopediaEntry)},
            {"Researcher1", Tuple.Create(DataType.String, typeof(string),(int)BIQEraSizes.Researcher1)},
            {"Researcher2", Tuple.Create(DataType.String, typeof(string),(int)BIQEraSizes.Researcher2)},
	        {"Researcher3", Tuple.Create(DataType.String, typeof(string), (int)BIQEraSizes.Researcher3)},
            {"Researcher4", Tuple.Create(DataType.String, typeof(string), (int)BIQEraSizes.Researcher4)},
            {"Researcher5", Tuple.Create(DataType.String, typeof(string), (int)BIQEraSizes.Researcher5)},
            {"NumberOfUsedResearcherNames", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"Unknown", Tuple.Create( DataType.Int, typeof(int), -1)},
	    };*/

        string EraName { get; set; }
        string CivilopediaEntry { get; set; }
        string Researcher1 { get; set; }
        string Researcher2 { get; set; }
        string Researcher3 { get; set; }
        string Researcher4 { get; set; }
        string Researcher5 { get; set; }
        int NumberOfUsedResearcherNames { get; set; }
        int Unknown { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            EraName = formatter.ReadChars((int)BIQEraSizes.EraName);
            CivilopediaEntry = formatter.ReadChars((int)BIQEraSizes.CivilopediaEntry);
            Researcher1 = formatter.ReadChars((int)BIQEraSizes.Researcher1);
            Researcher2 = formatter.ReadChars((int)BIQEraSizes.Researcher2);
            Researcher3 = formatter.ReadChars((int)BIQEraSizes.Researcher3);
            Researcher4 = formatter.ReadChars((int)BIQEraSizes.Researcher4);
            Researcher5 = formatter.ReadChars((int)BIQEraSizes.Researcher5);
            NumberOfUsedResearcherNames = formatter.ReadInt32();
            Unknown = formatter.ReadInt32();
        }
    }
}

