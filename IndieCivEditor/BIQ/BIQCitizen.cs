using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQCitizen
    {
        public enum BIQCitizenSizes
        {
            Singular    = 32,
            Civlopedia  = 32,
            Plural      = 32,
        };

        /*public static Dictionary<string, Tuple<DataType, Type, int>> propertyNames = new Dictionary<string, Tuple<DataType, Type, int>>()
	    {            
            {"DefaultCitizen", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"SingularCitizens", Tuple.Create(DataType.String, typeof(string),(int)BIQCitizenSizes.Singular)},
            {"CivilopediaEntry", Tuple.Create(DataType.String, typeof(string),(int)BIQCitizenSizes.Civlopedia)},
            {"PluralName", Tuple.Create(DataType.String, typeof(string),(int)BIQCitizenSizes.Plural)},
	        {"Prerequisite", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"Luxuries", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"Research", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"Taxes", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"Corruption", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"Construction", Tuple.Create( DataType.Int, typeof(int), -1)},
	    };*/


        int DefaultCitizen { get; set; }
        string SingularCitizens { get; set; } // (singular) name
        string CivilopediaEntry { get; set; }
        string PluralName { get; set; }
        int Prerequisite { get; set; }
        int Luxuries { get; set; }
        int Research { get; set; }
        int Taxes { get; set; }
        int Corruption { get; set; }
        int Construction { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            DefaultCitizen      = formatter.ReadInt32();
            SingularCitizens    = formatter.ReadString( ( int ) BIQCitizenSizes.Singular );
            CivilopediaEntry    = formatter.ReadString( ( int ) BIQCitizenSizes.Civlopedia );
            PluralName = formatter.ReadString( ( int ) BIQCitizenSizes.Plural );
            Prerequisite = formatter.ReadInt32();
            Luxuries = formatter.ReadInt32();
            Research = formatter.ReadInt32();
            Taxes = formatter.ReadInt32();
            Corruption = formatter.ReadInt32();
            Construction = formatter.ReadInt32();

        }

    }
}

