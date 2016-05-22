using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQCulture
    {
        public enum BIQCultureSizes
        {
            CultureName = 64,
        };

        /*public static Dictionary<string, Tuple<DataType, Type, int>> propertyNames = new Dictionary<string, Tuple<DataType, Type, int>>()
	    {
            {"CultureOpinionName", Tuple.Create(DataType.String, typeof(string),(int)BIQCultureSizes.CultureName)},
	        {"ChanceOfSuccessfulPropaganda", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"CultureRatioPercentage", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"CultureRatioDenominator", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"CultureRatioNumerator", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"InitialResistanceChance", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"ContinuedResistanceChance", Tuple.Create( DataType.Int, typeof(int), -1)},
	    };*/

        string CultureOpinionName { get; set; }
        int ChanceOfSuccessfulPropaganda { get; set; }
        int CultureRatioPercentage { get; set; } //(3:1 = 300, 3:4 = 75)
        int CultureRatioDenominator { get; set; } //(e.g. the 1 in 3:1)
        int CultureRatioNumerator { get; set; } // (e.g. the 3 in 3:1)
        int InitialResistanceChance { get; set; }
        int ContinuedResistanceChance { get; set; }



        public void Load( BinaryFormatter formatter )
        {
            CultureOpinionName = formatter.ReadString( ( int ) BIQCultureSizes.CultureName );
            ChanceOfSuccessfulPropaganda = formatter.ReadInt32();
            CultureRatioPercentage = formatter.ReadInt32();
            CultureRatioDenominator = formatter.ReadInt32();
            CultureRatioNumerator = formatter.ReadInt32();
            InitialResistanceChance = formatter.ReadInt32();
            ContinuedResistanceChance = formatter.ReadInt32();

        }
    }
}

