using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    static class BIQGeneral
    {

        public enum BIQGeneralSizes
        {
		    CitySizeLevelName1 = 32,
            CitySizeLevelName2 = 32,
            CitySizeLevelName3 = 32,

        };

        static public string CitySizeLevelName1 { get; private set; }
        static public string CitySizeLevelName2 { get; private set; }
        static public string CitySizeLevelName3 { get; private set; }

        static public int NumSpaceShipParts { get; private set; }

        static public List<int> NumNeeded { get; private set; }

        static public int AdvancedBarbarian { get; private set; }
        static public int BasicBarbarian { get; private set; }
        static public int BarbarianSeaUnit { get; private set; }
        static public int NeededToSupportCity { get; private set; }
        static public int ChanceOfRioting { get; private set; }
        static public int DraftPenalty { get; private set; }
        static public int ShieldGoldCost { get; private set; }
        static public int FortressDefBonus { get; private set; }
        static public int CitizenHappyFace { get; private set; }
        static public int Unknown1 { get; private set; }
        static public int Unknown2 { get; private set; }
        static public int ForestShieldValue { get; private set; }
        static public int ShieldGoldValue { get; private set; }
        static public int CitizenShieldValue { get; private set; }
        static public int DefaultDiffLevel { get; private set; }
        static public int BattleCreatedUnit { get; private set; }
        static public int BuildArmyUnit { get; private set; }
        static public int BuildDefBonus { get; private set; }
        static public int CitizenDefBonus { get; private set; }
        static public int DefMoneyResource { get; private set; }
        static public int InterceptEnemyAir { get; private set; }
        static public int InterceptEnemyStealth { get; private set; }
        static public int StartingGold { get; private set; }
        static public int Unknown3 { get; private set; }
        static public int FoodPerCitizen { get; private set; }
        static public int RiverDefBonus { get; private set; }
        static public int TurnHurryPenalty { get; private set; }
        static public int Scout { get; private set; }
        static public int Slave { get; private set; }
        static public int RoadMovementRate { get; private set; }
        static public int StartUnit1 { get; private set; }
        static public int StartUnit2 { get; private set; }
        static public int WeLoveKingMinPop { get; private set; }
        static public int TownDefBonus { get; private set; }
        static public int CityDefBonus { get; private set; }
        static public int MetropolisDefBonus { get; private set; }
        static public int MinLevel1CitySize { get; private set; }
        static public int MinLevel2CitySize { get; private set; }
        static public int Unknown4 { get; private set; }
        static public int FortDefBonus { get; private set; }
        static public int NumCultureLevels { get; private set; }

        static public List<string> CultureNames { get; private set; }

        static public int BorderExpansionMultiplier { get; private set; }
        static public int BorderFactor { get; private set; }

        static public int FutureTechCost { get; private set; }
        static public int GoldenAgeDuration { get; private set; }
        static public int MaxResearchTime { get; private set; }
        static public int MinResearchTime { get; private set; }
        static public int FlagUnit { get; private set; }
        static public int UpgradeCost { get; private set; }

        static public void Load( BinaryFormatter formatter )
        {
            CitySizeLevelName1 = formatter.ReadChars((int)BIQGeneralSizes.CitySizeLevelName1);
            CitySizeLevelName2 = formatter.ReadChars((int)BIQGeneralSizes.CitySizeLevelName2);
            CitySizeLevelName3 = formatter.ReadChars((int)BIQGeneralSizes.CitySizeLevelName3);

            NumSpaceShipParts = formatter.ReadInt32();

            NumNeeded = new List<int>();

            for ( int o = 0; o < NumSpaceShipParts; o++ )
                NumNeeded.Add( formatter.ReadInt32() );

	        AdvancedBarbarian = formatter.ReadInt32();
	        BasicBarbarian = formatter.ReadInt32();
	        BarbarianSeaUnit = formatter.ReadInt32();
	        NeededToSupportCity = formatter.ReadInt32();
	        ChanceOfRioting = formatter.ReadInt32();
	        DraftPenalty = formatter.ReadInt32();
	        ShieldGoldCost = formatter.ReadInt32();
	        FortressDefBonus = formatter.ReadInt32();
            CitizenHappyFace = formatter.ReadInt32();

	        Unknown1 = formatter.ReadInt32();
	        Unknown2 = formatter.ReadInt32();
	        ForestShieldValue = formatter.ReadInt32();
	        ShieldGoldValue = formatter.ReadInt32();
	        CitizenShieldValue = formatter.ReadInt32();
	        DefaultDiffLevel = formatter.ReadInt32();
	        BattleCreatedUnit = formatter.ReadInt32();
	        BuildArmyUnit = formatter.ReadInt32();
	        BuildDefBonus = formatter.ReadInt32();
	        CitizenDefBonus = formatter.ReadInt32();
	        DefMoneyResource = formatter.ReadInt32();
	        InterceptEnemyAir = formatter.ReadInt32();
            InterceptEnemyStealth = formatter.ReadInt32();

	        StartingGold = formatter.ReadInt32();
	        Unknown3 = formatter.ReadInt32();
	        FoodPerCitizen = formatter.ReadInt32();
	        RiverDefBonus = formatter.ReadInt32();
	        TurnHurryPenalty = formatter.ReadInt32();
	        Scout = formatter.ReadInt32();
	        Slave = formatter.ReadInt32();
	        RoadMovementRate = formatter.ReadInt32();
	        StartUnit1 = formatter.ReadInt32();
	        StartUnit2 = formatter.ReadInt32();
	        WeLoveKingMinPop = formatter.ReadInt32();
	        TownDefBonus = formatter.ReadInt32();
	        CityDefBonus = formatter.ReadInt32();
	        MetropolisDefBonus = formatter.ReadInt32();
	        MinLevel1CitySize = formatter.ReadInt32();
	        MinLevel2CitySize = formatter.ReadInt32();
	        Unknown4 = formatter.ReadInt32();
            FortDefBonus = formatter.ReadInt32();

	        NumCultureLevels = formatter.ReadInt32();

	        CultureNames = new List<string>();
	        for ( int i = 0; i < NumCultureLevels; i++ )
                CultureNames.Add ( formatter.ReadChars(64));


	        BorderExpansionMultiplier = formatter.ReadInt32();
	        BorderFactor = formatter.ReadInt32();

	        FutureTechCost = formatter.ReadInt32();
	        GoldenAgeDuration = formatter.ReadInt32();
	        MaxResearchTime = formatter.ReadInt32();
	        MinResearchTime = formatter.ReadInt32();
	        FlagUnit = formatter.ReadInt32();
            UpgradeCost = formatter.ReadInt32();

        }
    }
}
