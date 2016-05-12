using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQExperience
    {
        public enum BIQExperienceSizes
        {
            ExperienceLevelName = 32,
        };

        /*public static Dictionary<string, Tuple<DataType, Type, int>> propertyNames = new Dictionary<string, Tuple<DataType, Type, int>>()
	    {            
            {"ExperienceLevelName", Tuple.Create(DataType.String, typeof(string),(int)BIQExperienceSizes.ExperienceLevelName)},
            {"BaseHitPoints", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"RetreatBonus", Tuple.Create( DataType.Int, typeof(int), -1)},
	    };*/


        string ExperienceLevelName { get; set; }
        int BaseHitPoints { get; set; }
        int RetreatBonus { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            ExperienceLevelName = formatter.ReadChars( ( int ) BIQExperienceSizes.ExperienceLevelName );
            BaseHitPoints = formatter.ReadInt32();
            RetreatBonus = formatter.ReadInt32();
        }
    }
}

