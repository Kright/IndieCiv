using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQGovernment
    {
        public enum BIQGovernmentSizes
        {
		    GovernmentName = 64,
            CivilopediaEntry = 32,
            MaleRulerTitle1 = 32,
            FemaleRulerTitle1 = 32,
            MaleRulerTitle2 = 32,
            FemaleRulerTitle2 = 32,
            MaleRulerTitle3 = 32,
            FemaleRulerTitle3 = 32,
            MaleRulerTitle4 = 32,
            FemaleRulerTitle4 = 32,
        };

        public struct SGovernmentPerformance
        {
            public int CanBribeThisGovernmentType { get; set; }//? (0 = no, 1 = yes)
            public int BriberyModifierVs { get; set; }
            public int ResistanceModifierVs { get; set; }
        };
        /*public static Dictionary<string, Tuple<DataType, Type, int>> governmentPerformance = new Dictionary<string, Tuple<DataType, Type, int>>()
	    {  
            {"CanBribeThisGovernmentType", Tuple.Create(DataType.Int, typeof(int), -1 ) },
            {"BriberyModifierVs", Tuple.Create(DataType.Int, typeof(int), -1 ) },
            {"ResistanceModifierVs", Tuple.Create(DataType.Int, typeof(int), -1 ) },
        };*/

        /*public static Dictionary<string, Tuple<DataType, Type, int>> propertyNames = new Dictionary<string, Tuple<DataType, Type, int>>()
	    {            
            {"DefaultType", Tuple.Create(DataType.Int, typeof(int), -1)},
            {"TransitionType", Tuple.Create(DataType.Int, typeof(int), -1)},
            {"RequiresMaintenance", Tuple.Create(DataType.Int, typeof(int), -1)},
            {"Unknown", Tuple.Create(DataType.Int, typeof(int), -1)},
            {"StandardTilePenalty", Tuple.Create(DataType.Int, typeof(int), -1)},
            {"StandardTradeBonus", Tuple.Create(DataType.Int, typeof(int), -1)},
            {"GovernmentName", Tuple.Create(DataType.String, typeof(string),(int)BIQGovernmentSizes.GovernmentName)},
            {"CivilopediaEntry", Tuple.Create(DataType.String,typeof(string),(int)BIQGovernmentSizes.CivilopediaEntry)},
            {"MaleRulerTitle1", Tuple.Create(DataType.String,typeof(string),(int)BIQGovernmentSizes.MaleRulerTitle1)},
            {"FemaleRulerTitle1", Tuple.Create(DataType.String,typeof(string),(int)BIQGovernmentSizes.FemaleRulerTitle1)},
            {"MaleRulerTitle2", Tuple.Create(DataType.String,typeof(string),(int)BIQGovernmentSizes.MaleRulerTitle2)},
            {"FemaleRulerTitle2", Tuple.Create(DataType.String,typeof(string),(int)BIQGovernmentSizes.FemaleRulerTitle2)},
            {"MaleRulerTitle3", Tuple.Create(DataType.String,typeof(string),(int)BIQGovernmentSizes.MaleRulerTitle3)},
            {"FemaleRulerTitle3", Tuple.Create(DataType.String,typeof(string),(int)BIQGovernmentSizes.FemaleRulerTitle3)},
            {"MaleRulerTitle4", Tuple.Create(DataType.String,typeof(string),(int)BIQGovernmentSizes.MaleRulerTitle4)},
            {"FemaleRulerTitle4", Tuple.Create(DataType.String,typeof(string),(int)BIQGovernmentSizes.FemaleRulerTitle4)},
            {"CorruptionAndWaste", Tuple.Create(DataType.Int,typeof(int), -1)},
            {"ImmuneTo", Tuple.Create(DataType.Int,typeof(int), -1)},
            {"DiplomatsAre", Tuple.Create(DataType.Int, typeof(int), -1)},
            {"SpiesAre", Tuple.Create(DataType.Int, typeof(int), -1)},
            {"NumberOfGovernments", Tuple.Create(DataType.LoopCounter, typeof(int), -1)},
            {"GovernmentsPerformance", Tuple.Create(DataType.List, typeof(SGovernmentsPerformance), -1)},


            //{"GovernmentsPerformance", Tuple.Create(typeof(SGovernmentPerformance), -1)},

            //{"GovernmentsPerformance", Tuple.Create ( typeof(List<SGovernmentPerformance>), -1, typeof(SGovernmentPerformance))},
	    };*/


        public int DefaultType { get; set; }
        public int TransitionType { get; set; }
        public int RequiresMaintenance { get; set; }
        public int Unknown { get; set; } //??? (0 for Rebublic/Democracy, 1 for rest);
        public int StandardTilePenalty { get; set; }
        public int StandardTradeBonus { get; set; }

		public string GovernmentName { get; set; }
        public string CivilopediaEntry { get; set; }
        public string MaleRulerTitle1 { get; set; }
        public string FemaleRulerTitle1 { get; set; }
        public string MaleRulerTitle2 { get; set; }
        public string FemaleRulerTitle2 { get; set; }
        public string MaleRulerTitle3 { get; set; }
        public string FemaleRulerTitle3 { get; set; }
        public string MaleRulerTitle4 { get; set; }
        public string FemaleRulerTitle4 { get; set; }

        public int CorruptionAndWaste { get; set; }
        public int ImmuneTo { get; set; }
        public int DiplomatsAre { get; set; }
        public int SpiesAre { get; set; }
        public int NumberOfGovernments { get; set; }

        public List<SGovernmentPerformance> GovernmentsPerformance { get; set; }

        public int Hurrying { get; set; }
        public int AssimilationChance { get; set; }
        public int DraftLimit { get; set; }
        public int MilitaryPoliceLimit { get; set; }
        public int RulerTitlePairsUsed { get; set; }// (max is 4);
        public int PrerequisiteTechnologyIndex { get; set; }// #;
        public int ScienceRateCap { get; set; }// (10 = 100% of gold can go to science);
        public int WorkerRate { get; set; }
        public int Unknown1 { get; set; } //??? (-1 for Despotism/Communism, 0 for Anarchy/Monarchy,  1 for Republic/Democracy)
        public int Unknown2 { get; set; } //		???; // (1 for Republic/Democracy, 0 for the rest)
        public int Unknown3 { get; set; } //???;
        public int FreeUnits { get; set; } //  (-1 = all, >=0 number of free units)
        public int FreeUnitsPerTown { get; set; }
        public int FreeUnitsPerCity { get; set; }
        public int FreeUnitsPerMetropolis { get; set; }
        public int CostUnit { get; set; }
        public int WarWeariness { get; set; }
        public int Xenophobic { get; set; }
        public int ForceResettle { get; set; }

        public void Load ( BinaryFormatter formatter )
        {
            DefaultType = formatter.ReadInt32();
            TransitionType = formatter.ReadInt32();
            RequiresMaintenance = formatter.ReadInt32();
            Unknown = formatter.ReadInt32();
            StandardTilePenalty = formatter.ReadInt32();
            StandardTradeBonus = formatter.ReadInt32();

		    GovernmentName = formatter.ReadString((int)BIQGovernmentSizes.GovernmentName);
            CivilopediaEntry = formatter.ReadString((int)BIQGovernmentSizes.CivilopediaEntry);
            MaleRulerTitle1 = formatter.ReadString((int)BIQGovernmentSizes.MaleRulerTitle1);
            FemaleRulerTitle1 = formatter.ReadString((int)BIQGovernmentSizes.FemaleRulerTitle1);
            MaleRulerTitle2 = formatter.ReadString((int)BIQGovernmentSizes.MaleRulerTitle2);
            FemaleRulerTitle2 = formatter.ReadString((int)BIQGovernmentSizes.FemaleRulerTitle2);
            MaleRulerTitle3 = formatter.ReadString((int)BIQGovernmentSizes.MaleRulerTitle3);
            FemaleRulerTitle3 = formatter.ReadString((int)BIQGovernmentSizes.FemaleRulerTitle3);
            MaleRulerTitle4 = formatter.ReadString((int)BIQGovernmentSizes.MaleRulerTitle4);
            FemaleRulerTitle4 = formatter.ReadString((int)BIQGovernmentSizes.FemaleRulerTitle4);

            CorruptionAndWaste = formatter.ReadInt32();
            ImmuneTo = formatter.ReadInt32();
            DiplomatsAre = formatter.ReadInt32();
            SpiesAre = formatter.ReadInt32();
            NumberOfGovernments = formatter.ReadInt32();

            GovernmentsPerformance = new List<BIQGovernment.SGovernmentPerformance>();
            for ( int o = 0; o < NumberOfGovernments; o++ )
            {
                SGovernmentPerformance governmentsPerformance = new SGovernmentPerformance();

                governmentsPerformance.CanBribeThisGovernmentType = formatter.ReadInt32();
                governmentsPerformance.BriberyModifierVs = formatter.ReadInt32();
                governmentsPerformance.ResistanceModifierVs = formatter.ReadInt32();

                GovernmentsPerformance.Add( governmentsPerformance );
            }

            Hurrying = formatter.ReadInt32();
            AssimilationChance = formatter.ReadInt32();
            DraftLimit = formatter.ReadInt32();
            MilitaryPoliceLimit = formatter.ReadInt32();
            RulerTitlePairsUsed = formatter.ReadInt32();// (max is 4);
            PrerequisiteTechnologyIndex = formatter.ReadInt32();// #;
            ScienceRateCap = formatter.ReadInt32();// (10 = 100% of gold can go to science);
            WorkerRate = formatter.ReadInt32();
            Unknown1 = formatter.ReadInt32(); //??? (-1 for Despotism/Communism, 0 for Anarchy/Monarchy,  1 for Republic/Democracy)
            Unknown2 = formatter.ReadInt32(); //		???; // (1 for Republic/Democracy, 0 for the rest)
            Unknown3 = formatter.ReadInt32(); //???;
            FreeUnits = formatter.ReadInt32(); //  (-1 = all, >=0 number of free units)
            FreeUnitsPerTown = formatter.ReadInt32();
            FreeUnitsPerCity = formatter.ReadInt32();
            FreeUnitsPerMetropolis = formatter.ReadInt32();
            CostUnit = formatter.ReadInt32();
            WarWeariness = formatter.ReadInt32();
            Xenophobic = formatter.ReadInt32();
            ForceResettle = formatter.ReadInt32();

        }
    }
}

