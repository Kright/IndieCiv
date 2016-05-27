using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore;
using IndieCivCore.Map;
using IndieCivCore.Entities;
using IndieCivCore.Serialization;
using IndieCivCore.Resources;

namespace IndieCivEditor.BIQ
{
    public class BIQLead
    {
        private const int ANY_CIV = -3;

        public enum BIQLeadSizes
        {
            LeaderName = 32,
        };

        struct StartUnits
        {
                public int UnitsOfThisType { get; set; }
                public int TypeOfStartingUnit { get; set; }
        };

        int CustomCivData { get; set; }
        int HumanPlayer { get; set; }
        string LeaderName { get; set; }
        int Unknown1 { get; set; }
        int Unknown2 { get; set; }
        int NumberOfDifferentStartUnits { get; set; }
        List<StartUnits> DifferentStartUnits { get; set; }
        int GenderOfLeaderName { get; set; }

        int NumberOfStartingTechnologies { get; set; }
        List<int> StartingTechnologies { get; set; }

        int Difficulty { get; set; }
        int InitialEra { get; set; }
        int StartCash { get; set; }
        public int Government { get; set; }
        int Civ { get; set; }
        int Color { get; set; }
        int SkipFirstTurn { get; set; }
        int Unknown3 { get; set; }
        byte StartEmbassies { get; set; }




        public void Load ( BinaryFormatter formatter )
        {
            CustomCivData = formatter.ReadInt32();
            HumanPlayer = formatter.ReadInt32();
            LeaderName = formatter.ReadString((int)BIQLeadSizes.LeaderName);
            Unknown1 = formatter.ReadInt32();
            Unknown2 = formatter.ReadInt32();

            NumberOfDifferentStartUnits = formatter.ReadInt32();
            DifferentStartUnits = new List<StartUnits>();
            for (int i = 0; i < NumberOfDifferentStartUnits; i++)
            {
                StartUnits startUnits = new StartUnits();
                startUnits.UnitsOfThisType = formatter.ReadInt32();
                startUnits.TypeOfStartingUnit = formatter.ReadInt32();

                DifferentStartUnits.Add(startUnits);
            }

            GenderOfLeaderName = formatter.ReadInt32();

            NumberOfStartingTechnologies = formatter.ReadInt32();
            StartingTechnologies = new List<int>();
            for (int i = 0; i < NumberOfStartingTechnologies; i++)
                StartingTechnologies.Add(formatter.ReadInt32());

            Difficulty = formatter.ReadInt32();
            InitialEra = formatter.ReadInt32();
            StartCash = formatter.ReadInt32();
            Government = formatter.ReadInt32();
            Civ = formatter.ReadInt32();
            Color = formatter.ReadInt32();
            SkipFirstTurn = formatter.ReadInt32();

            Unknown3 = formatter.ReadInt32();
            StartEmbassies = formatter.ReadByte();

        }

        public void Import() {

            Player player = PlayerManager.AddPlayer();
            player.IsAI = true;

            if (this.Civ == ANY_CIV) {
                player.CivilizationData = ResourceInterface.CivilizationData[player.Index];
            }

            MapTile mapTile = MapManager.Current.GetStartingLocation(player);
            if (mapTile == null) {
                mapTile = MapManager.Current.GetRandomLandTile();
            }

            foreach (StartUnits ss in DifferentStartUnits) {
                for (int i = 0; i < ss.UnitsOfThisType; i++) {
                    player.AddUnit ( ResourceInterface.UnitData[ss.TypeOfStartingUnit], mapTile);
                }

            }

            //Player.CurrentEra = ResourceInterface.EraData[0];
            //Player.CivilizationData = ResourceInterface.CivilizationData[i + 1];
            //Player.Government = ResourceInterface.GovernmentData[Lead.Government];
        }
    }
}
