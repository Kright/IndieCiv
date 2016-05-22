using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Resources;
using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQResource
    {
        public enum BIQResourceSizes
        {
            Name = 24,
            Civlopedia = 32,
        };

        /*public static Dictionary<string, Tuple<DataType, Type, int>> propertyNames = new Dictionary<string, Tuple<DataType, Type, int>>()
	    {            
            {"Name", Tuple.Create(DataType.String, typeof(string),(int)BIQResourceSizes.Name)},
            {"CivilopediaEntry", Tuple.Create(DataType.String, typeof(string),(int)BIQResourceSizes.Civlopedia)},
            {"Type", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"AppearanceRatio", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"DisappearanceProbability", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"Icon", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"Prerequisite", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"FoodBonus", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"ShieldsBonus", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"CommerceBonus", Tuple.Create( DataType.Int, typeof(int), -1)},
	    };*/


        string Name { get; set; }
        string CivilopediaEntry { get; set; }
        int Type { get; set; }
        int AppearanceRatio { get; set; }
        int DisappearanceProbability { get; set; }
        int Icon { get; set; }
        int Prerequisite { get; set; }
        int FoodBonus { get; set; }
        int ShieldsBonus { get; set; }
        int CommerceBonus { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            Name = formatter.ReadString( ( int ) BIQResourceSizes.Name );
            CivilopediaEntry = formatter.ReadString( ( int ) BIQResourceSizes.Civlopedia );
            Type = formatter.ReadInt32();
            AppearanceRatio = formatter.ReadInt32();
            DisappearanceProbability = formatter.ReadInt32();
            Icon = formatter.ReadInt32();
            Prerequisite = formatter.ReadInt32();
            FoodBonus = formatter.ReadInt32();
            ShieldsBonus = formatter.ReadInt32();
            CommerceBonus = formatter.ReadInt32();
        }

        public void Import() {
            ResourceData data = ResourceInterface.AddResource();
            data.Icon = Icon;
            data.Description = "TXT_KEY_RESOURCE_" + Name.ToUpper();
        }

    }
}

