using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQDifficulty
    {
        public enum BIQDifficultySizes
        {
            DifficultyName = 64,
        };

        /*public static Dictionary<string, Tuple<DataType, Type, int>> propertyNames = new Dictionary<string, Tuple<DataType, Type, int>>()
	    {
            {"DifficultyLevelName", Tuple.Create ( DataType.String, typeof ( string ), ( int ) BIQDifficultySizes.DifficultyName ) },
            {"NumberOfCitizensBornContent", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"MaxGovernmentTransitionTime", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"NumberOfDefensiveLandUnitsAIStartsWith", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"NumberOfOffensiveLandUnitsAIStartsWith", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"ExtraStartUnit1", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"ExtraStartUnit2", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"AdditionalFreeSupport", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"BonusForEachCity", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"AttackBonusAgainstBarbarians", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"CostFactor", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"PercentageOfOptimalCities", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"AIToAITradeRate", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"CorruptionPercentage", Tuple.Create( DataType.Int, typeof(int), -1)},
            {"MilitaryLaw", Tuple.Create( DataType.Int, typeof(int), -1)},
	    };*/


        string DifficultyLevelName { get; set; }
        int NumberOfCitizensBornContent { get; set; }
        int MaxGovernmentTransitionTime { get; set; }
        int NumberOfDefensiveLandUnitsAIStartsWith { get; set; }
        int NumberOfOffensiveLandUnitsAIStartsWith { get; set; }
        int ExtraStartUnit1 { get; set; }
        int ExtraStartUnit2 { get; set; }
        int AdditionalFreeSupport { get; set; }
        int BonusForEachCity { get; set; }
        int AttackBonusAgainstBarbarians { get; set; }
        int CostFactor { get; set; }
        int PercentageOfOptimalCities { get; set; }
        int AIToAITradeRate { get; set; }
        int CorruptionPercentage { get; set; }
        int MilitaryLaw { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            DifficultyLevelName = formatter.ReadChars( ( int ) BIQDifficultySizes.DifficultyName );
            NumberOfCitizensBornContent = formatter.ReadInt32();
            MaxGovernmentTransitionTime = formatter.ReadInt32();
            NumberOfDefensiveLandUnitsAIStartsWith = formatter.ReadInt32();
            NumberOfOffensiveLandUnitsAIStartsWith = formatter.ReadInt32();
            ExtraStartUnit1 = formatter.ReadInt32();
            ExtraStartUnit2 = formatter.ReadInt32();
            AdditionalFreeSupport = formatter.ReadInt32();
            BonusForEachCity  = formatter.ReadInt32();
            AttackBonusAgainstBarbarians = formatter.ReadInt32();
            CostFactor = formatter.ReadInt32();
            PercentageOfOptimalCities = formatter.ReadInt32();
            AIToAITradeRate = formatter.ReadInt32();
            CorruptionPercentage = formatter.ReadInt32();
            MilitaryLaw = formatter.ReadInt32();
        }
    }
}

