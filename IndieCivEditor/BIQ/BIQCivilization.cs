using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using IndieCivCore.Serialization;
using IndieCivCore.Resources;
using IndieCivCore.Localization;

namespace IndieCivEditor.BIQ
{

    struct CivColours {

        static public Color MakeColor(int Index) {
            return new Color(civColours[Index, 0], civColours[Index, 1], civColours[Index, 2]);
        }
        static int[,] civColours = new int[31,3]{
	        {231, 12, 12},
	        {255, 142, 5},
	        {235, 235, 5},
	        {11, 120, 10},
	        {31, 219, 219},
	        {57, 100, 252},
	        {255, 79, 242},
	        {125, 1, 156},
	        {144, 107, 11},
	        {121, 225, 3},
	        {152, 11, 10},
	        {151, 151, 151},
	        {3, 41, 148},
	        {18, 137, 154},
	        {248, 197, 255},
	        {64, 64, 64},
	        {195, 3, 255},
	        {210, 183, 0},
	        {131, 0, 255},
	        {175, 219, 237},
	        {118, 137, 57},
	        {255, 195, 0},
	        {255, 112, 0},
	        {198, 215, 153},
	        {119, 255, 176},
	        {194, 201, 72},
	        {178, 137, 82},
	        {111, 86, 10},
	        {73, 93, 48},
	        {255, 200, 255},
	        {199, 172, 237},
        };
    }
    public class BIQCivilization
    {
        public enum BIQCivilizationSizes
        {
            CityName = 24,
            LeaderNames = 32,
            LeaderName = 32,
            LeaderTitle = 24,
            CivilopediaEntry = 32,
            Adjective = 40,
            CivilizationName = 40,
            Noun = 40,
            Forward = 260,
            Reverse = 260,
            ScientificLeaderName = 32,
        };

		int	NumCityNames;
		List<string> CityNames;

		int	NumLeaders;
		List<string> LeaderNames;

		string	LeaderName { get; set; }
		string	LeaderTitle { get; set; }
		string	CivilopediaEntry { get; set; }
		string	Adjective { get; set; }
		string	CivilizationName { get; set; }
		string	Noun { get; set; }

		List<string>	Forward { get; set; }
		List<string>	Reverse { get; set; }

		int	CultureGroup { get; set; }
		int	LeaderGender { get; set; }
		int	CivilizationGender { get; set; }
		int	AggressionLevel { get; set; }
		int	UniqueCounter { get; set; }
		int	ShunnedGovernment { get; set; }
		int	FavoriteGovernment { get; set; }
		int	DefaultColor { get; set; }
		int	UniqueColor { get; set; }
		int	FreeTech1 { get; set; }
		int	FreeTech2 { get; set; }
		int	FreeTech3 { get; set; }
		int	FreeTech4 { get; set; }
		int	Bonuses { get; set; }
		int	GovernorSettings { get; set; }
		int	BuildNever { get; set; }
		int	BuildOften { get; set; }
		int	Plurality { get; set; }
		int	KingUnit { get; set; }
		int	Flavours { get; set; }
		int	Unknown { get; set; }
		int	DiplomacyTextIndex { get; set; }
		int	NumScientificLeaders { get; set; }

		List<string>	ScientificLeaderName;

        public void Load( BinaryFormatter formatter )
        {
            NumCityNames = formatter.ReadInt32();
            CityNames = new List<string>();
            for ( int i = 0; i < NumCityNames; i++ )
                CityNames.Add( formatter.ReadChars( ( int ) BIQCivilizationSizes.CityName ) );

            NumLeaders = formatter.ReadInt32();
            LeaderNames = new List<string>();
            for ( int i = 0; i < NumLeaders; i++ )
                LeaderNames.Add( formatter.ReadChars( ( int ) BIQCivilizationSizes.LeaderNames ) );

		    LeaderName = formatter.ReadChars( ( int ) BIQCivilizationSizes.LeaderName );
		    LeaderTitle = formatter.ReadChars( ( int ) BIQCivilizationSizes.LeaderTitle );
		    CivilopediaEntry = formatter.ReadChars( ( int ) BIQCivilizationSizes.CivilopediaEntry );
		    Adjective = formatter.ReadChars( ( int ) BIQCivilizationSizes.Adjective );
		    CivilizationName = formatter.ReadChars( ( int ) BIQCivilizationSizes.CivilizationName );
            Noun = formatter.ReadChars( ( int ) BIQCivilizationSizes.Noun );

            Forward = new List<string>();
            for ( int c = 0; c < 4; c++ )
                Forward.Add( formatter.ReadChars( ( int ) BIQCivilizationSizes.Forward ) );
            Reverse = new List<string>();
            for ( int c = 0; c < 4; c++ )
                Reverse.Add( formatter.ReadChars( ( int ) BIQCivilizationSizes.Reverse ) );

		    CultureGroup = formatter.ReadInt32();
		    LeaderGender = formatter.ReadInt32();
		    CivilizationGender = formatter.ReadInt32();
		    AggressionLevel = formatter.ReadInt32();
		    UniqueCounter = formatter.ReadInt32();
		    ShunnedGovernment = formatter.ReadInt32();
		    FavoriteGovernment = formatter.ReadInt32();
		    DefaultColor = formatter.ReadInt32();
		    UniqueColor = formatter.ReadInt32();
		    FreeTech1 = formatter.ReadInt32();
		    FreeTech2 = formatter.ReadInt32();
		    FreeTech3 = formatter.ReadInt32();
		    FreeTech4 = formatter.ReadInt32();
		    Bonuses = formatter.ReadInt32();
		    GovernorSettings = formatter.ReadInt32();
		    BuildNever = formatter.ReadInt32();
		    BuildOften = formatter.ReadInt32();
		    Plurality = formatter.ReadInt32();
		    KingUnit = formatter.ReadInt32();
		    Flavours = formatter.ReadInt32();
		    Unknown = formatter.ReadInt32();
            DiplomacyTextIndex = formatter.ReadInt32();

            NumScientificLeaders = formatter.ReadInt32();

            ScientificLeaderName = new List<string>();
            for ( int i = 0; i < NumScientificLeaders; i++ )
                ScientificLeaderName.Add( formatter.ReadChars( ( int ) BIQCivilizationSizes.ScientificLeaderName ) );
        }

        public void Import() {
            CivilizationData data = ResourceInterface.AddCivilization();
            if (this.DefaultColor > 0) {
                data.Color = CivColours.MakeColor(this.DefaultColor - 1);
                //Color col = data.Color;
                //col.A = 0;
                //data.Color = col;
            }
            data.CityNames = this.CityNames.ToList();
            data.Description = "TXT_KEY_CIVILIZATION_" + CivilizationName.ToUpper().Replace(" ", "_");
            LocaleManager.AddLocale(data.Description, CivilizationName);

            if (this.FreeTech1 != -1) {
                data.FreeAdvances.Add(ResourceInterface.AdvanceData[this.FreeTech1]);
            }
            if (this.FreeTech2 != -1) {
                data.FreeAdvances.Add(ResourceInterface.AdvanceData[this.FreeTech2]);
            }
            if (this.FreeTech3 != -1) {
                data.FreeAdvances.Add(ResourceInterface.AdvanceData[this.FreeTech3]);
            }
            if (this.FreeTech4 != -1) {
                data.FreeAdvances.Add(ResourceInterface.AdvanceData[this.FreeTech4]);
            }
        }
    }
}
