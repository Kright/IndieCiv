using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQEspionage
    {
        public enum BIQEspionageSizes
        {
            Description = 128,
            DiplomatSpyMissionName = 64,
            CivilopediaEntry = 32,
        };

       /* public static Dictionary<string, Tuple<DataType, Type, int>> propertyNames = new Dictionary<string, Tuple<DataType, Type, int>>()
	    {            
            {"Description", Tuple.Create(DataType.String, typeof(string), (int)BIQEspionageSizes.Description)},
            {"DiplomatSpyMissionName", Tuple.Create(DataType.String, typeof(string),(int)BIQEspionageSizes.DiplomatSpyMissionName)},
            {"CivilopediaEntry", Tuple.Create(DataType.String, typeof(string),(int)BIQEspionageSizes.CivilopediaEntry)},
            {"MissionPerformedBy", Tuple.Create( DataType.Int, typeof(int),-1)},
	        {"BaseCost", Tuple.Create( DataType.Int, typeof(int), -1)},
	    };*/


        string Description { get; set; }
        string DiplomatSpyMissionName { get; set; }
        string CivilopediaEntry { get; set; }
        int MissionPerformedBy { get; set; }
        int BaseCost { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            Description = formatter.ReadString((int)BIQEspionageSizes.Description);
            DiplomatSpyMissionName = formatter.ReadString((int)BIQEspionageSizes.DiplomatSpyMissionName);
            CivilopediaEntry = formatter.ReadString((int)BIQEspionageSizes.CivilopediaEntry);
            MissionPerformedBy = formatter.ReadInt32();
            BaseCost = formatter.ReadInt32();
        }

    }
}

