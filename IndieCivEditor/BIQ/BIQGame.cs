using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;
using IndieCivCore.Entities;
using IndieCivCore.Resources;
using IndieCivCore;

namespace IndieCivEditor.BIQ
{
    public class BIQGame
    {
        public enum BIQGameSizes
        {
            ScenarioSearchFolders = 5200,
            Alliance0 = 256,
            Alliance1 = 256,
            Alliance2 = 256,
            Alliance3 = 256,
            Alliance4 = 256,
            PlaugeName = 260,
            Unknown4 = 260,
        };

        int UseDefaultRules { get; set; }
        int DefaultVictoryConditions { get; set; }
        int NumberOfPlayableCivs { get; set; }
        List<int> IdOfPlayableCivs { get; set; }
        int VictoryConditionsAndRules { get; set; }
        int PlaceCaptureUnits { get; set; }
        int AutoPlaceKings { get; set; }
        int AutoPlaceVictoryLocations { get; set; }
        int DebugMode { get; set; }
        int UseTimeLimit { get; set; }
        int BaseTimeUnit { get; set; }
        int StartMonth { get; set; }
        int StartWeek { get; set; }
        int StartYear { get; set; }
        int MinuteTimeLimit { get; set; }
        int TurnTimeLimit { get; set; }
        List<int> TurnsPerTimescalePart { get; set; }
        List<int> TimeUnitsPerTurn { get; set; }
        string ScenarioSearchFolders { get; set; }
        List<int> CivPartOfWhichAlliance { get; set; }

        int VictoryPointLimit { get; set; }
        int CityEliminationCount { get; set; }
        int OneCityCultureWinLimit { get; set; }
        int AllCitiesCultureWinLimit { get; set; }
        int DominationTerrainPercent { get; set; }
        int DominationPopulationPercent { get; set; }
        int WonderVP { get; set; }
        int DefeatingOpposingUnitVP { get; set; }
        int AdvancementVP { get; set; }
        int CityConquestVP { get; set; }
        int VictoryPointVP { get; set; }
        int CaptureSpecialUnitVP { get; set; }
        int Unknown1 { get; set; }
        byte Unknown2 { get; set; }
        string Alliance0 { get; set; }
        string Alliance1 { get; set; }
        string Alliance2 { get; set; }
        string Alliance3 { get; set; }
        string Alliance4 { get; set; }

        List<int> warWith0 { get; set; }
        List<int> warWith1 { get; set; }
        List<int> warWith2 { get; set; }
        List<int> warWith3 { get; set; }
        List<int> warWith4 { get; set; }

        int AllianceVictoryType { get; set; }
        string PlaugeName { get; set; }
        byte PermitPlagues { get; set; }
        int PlagueEarliestStart { get; set; }
        int PlagueVariation { get; set; }
        int PlagueDuration { get; set; }
        int PlagueStrength { get; set; }
        int PlagueGracePeriod { get; set; }
        int PlagueMaxOccurance { get; set; }
        int Unknown3 { get; set; }
        string Unknown4 { get; set; }
        int RespawnFlagUnits { get; set; }
        byte CaptureAnyFlag { get; set; }
        int GoldForCapture { get; set; }
        byte MapVisible { get; set; }
        byte RetainCulture { get; set; }
        int Unknown5 { get; set; }
        int EruptionPeriod { get; set; }

        int MpBaseTime { get; set; }
		int MpCityTime { get; set; }
		int MpUnitTime { get; set; }

        public void Load ( BinaryFormatter formatter )
        {
            UseDefaultRules = formatter.ReadInt32();
            DefaultVictoryConditions = formatter.ReadInt32();
            NumberOfPlayableCivs = formatter.ReadInt32();

            IdOfPlayableCivs = new List<int>();
            for ( int i = 0; i < NumberOfPlayableCivs; i++ )
                IdOfPlayableCivs.Add( formatter.ReadInt32() );

            VictoryConditionsAndRules = formatter.ReadInt32();
            PlaceCaptureUnits = formatter.ReadInt32();
            AutoPlaceKings = formatter.ReadInt32();
            AutoPlaceVictoryLocations = formatter.ReadInt32();
            DebugMode = formatter.ReadInt32();
            UseTimeLimit = formatter.ReadInt32();
            BaseTimeUnit = formatter.ReadInt32();
            StartMonth = formatter.ReadInt32();
            StartWeek = formatter.ReadInt32();
            StartYear = formatter.ReadInt32();
            MinuteTimeLimit = formatter.ReadInt32();
            TurnTimeLimit = formatter.ReadInt32();

            TurnsPerTimescalePart = new List<int>();
            for ( int i = 0; i < 7; i++ )
                TurnsPerTimescalePart.Add( formatter.ReadInt32() );

            TimeUnitsPerTurn = new List<int>();
            for ( int i = 0; i < 7; i++ )
                TimeUnitsPerTurn.Add( formatter.ReadInt32() );

            ScenarioSearchFolders = formatter.ReadString( ( int ) BIQGameSizes.ScenarioSearchFolders );

            CivPartOfWhichAlliance = new List<int>();
            for ( int i = 0; i < NumberOfPlayableCivs; i++ )
                CivPartOfWhichAlliance.Add( formatter.ReadInt32() );




            VictoryPointLimit = formatter.ReadInt32();
            CityEliminationCount  = formatter.ReadInt32();
            OneCityCultureWinLimit  = formatter.ReadInt32();
            AllCitiesCultureWinLimit = formatter.ReadInt32();
            DominationTerrainPercent = formatter.ReadInt32();
            DominationPopulationPercent = formatter.ReadInt32();
            WonderVP = formatter.ReadInt32();
            DefeatingOpposingUnitVP = formatter.ReadInt32();
            AdvancementVP = formatter.ReadInt32();
            CityConquestVP = formatter.ReadInt32();
            VictoryPointVP = formatter.ReadInt32();
            CaptureSpecialUnitVP = formatter.ReadInt32();
            Unknown1 = formatter.ReadInt32();
            Unknown2 = formatter.ReadByte();

            Alliance0 = formatter.ReadString( ( int ) BIQGameSizes.Alliance0 );
            Alliance1 = formatter.ReadString( ( int ) BIQGameSizes.Alliance1 );
            Alliance2 = formatter.ReadString( ( int ) BIQGameSizes.Alliance2 );
            Alliance3 = formatter.ReadString( ( int ) BIQGameSizes.Alliance3 );
            Alliance4 = formatter.ReadString( ( int ) BIQGameSizes.Alliance4 );


            warWith0 = new List<int>();
            warWith1 = new List<int>();
            warWith2 = new List<int>();
            warWith3 = new List<int>();
            warWith4 = new List<int>();
            for ( int i = 0; i < 5; i++ )
            {
                warWith0.Add( formatter.ReadInt32() );
                warWith1.Add( formatter.ReadInt32() );
                warWith2.Add( formatter.ReadInt32() );
                warWith3.Add( formatter.ReadInt32() );
                warWith4.Add( formatter.ReadInt32() );
            }

            AllianceVictoryType = formatter.ReadInt32();

            PlaugeName = formatter.ReadString( ( int ) BIQGameSizes.PlaugeName );
            PermitPlagues = formatter.ReadByte();
            PlagueEarliestStart = formatter.ReadInt32();
            PlagueVariation = formatter.ReadInt32();
            PlagueDuration = formatter.ReadInt32();
            PlagueStrength = formatter.ReadInt32();
            PlagueGracePeriod = formatter.ReadInt32();
            PlagueMaxOccurance = formatter.ReadInt32();
            Unknown3 = formatter.ReadInt32();
            Unknown4 = formatter.ReadString( ( int ) BIQGameSizes.Unknown4 );
            RespawnFlagUnits = formatter.ReadInt32();
            CaptureAnyFlag = formatter.ReadByte();
            GoldForCapture = formatter.ReadInt32();
            MapVisible = formatter.ReadByte();
            RetainCulture = formatter.ReadByte();
            Unknown5 = formatter.ReadInt32();
            EruptionPeriod = formatter.ReadInt32();


			if ( BIQHeader.MajorVer == 12 && BIQHeader.MinorVer >= 7 )
			{
				MpBaseTime = formatter.ReadInt32();
				MpCityTime = formatter.ReadInt32();
				MpUnitTime = formatter.ReadInt32();
			}
			else
			{
				MpBaseTime = 24;
				MpCityTime = 2;
				MpUnitTime = 3;
			}
        }

        public void Import(BIQLoader BIQLoader) {
            /*for (int i = 0; i < BIQLoader.NumPlayers; i++) {

                BIQLead Lead = BIQLoader.Lead[i];

                Player Player = PlayerManager.AddPlayer();

                Player.IsAI = true;

                //Player.CurrentEra = ResourceInterface.EraData[0];
                Player.CivilizationData = ResourceInterface.CivilizationData[i+1];
                //Player.Government = ResourceInterface.GovernmentData[Lead.Government];
            }*/

        }
    }
}
