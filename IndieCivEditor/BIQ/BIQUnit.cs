using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore;
using IndieCivCore.Serialization;
using IndieCivCore.Resources;

namespace IndieCivEditor.BIQ
{
    public class BIQUnit
    {
        public enum BIQUnitSizes
        {
            Name = 32,
            Civlopedia = 32,
        };

		int ZoneOfControl { get; set; }
        string Name { get; set; }
        string Civlopedia { get; set; }
        int BombardStrength { get; set; }
        int BombardRange { get; set; }
        int Capacity { get; set; }
        int Cost { get; set; }
        int Defence { get; set; }
        int IconIndex { get; set; }
        int Attack { get; set; }
        int OperationalRange { get; set; }
        int PopulationCost { get; set; }
        int RateOfFire { get; set; }
        int Movement { get; set; }
        int Tech { get; set; }
        int UpgradeTo { get; set; }
        int Resource1 { get; set; }
        int Resource2 { get; set; }
        int Resource3 { get; set; }
        int UnitAbilities { get; set; }
        public long AIStrategy { get; set; }
        int AvailableTo { get; set; }
        int StandardOrdersSpecialActions { get; set; }
        int AirMissions { get; set; }
        int UnitClass { get; set; }
        public int OtherStrategy { get; set; }
        int HitPointBonus { get; set; }
        int PTWStandardOrders { get; set; }
        int PTWSpecialActions { get; set; }
        int PTWWorkerActions { get; set; }
        int PTWAirMissions { get; set; }
        short PTWActionsMix { get; set; }
        short Unknown1 { get; set; }
        int BombardEffects { get; set; }
        List<byte> IgnoreMovementCost { get; set; }
        int RequireSupport { get; set; }
        int UseExactCost { get; set; }
        int TelepadRange { get; set; }
        int Unknown4 { get; set; }
        int NumLegalUnitTelepads { get; set; }
        List<int> LegalUnitTelepads { get; set; }

        int EnslaveResults { get; set; }
        int Unknown6 { get; set; }
        int NumberOfStealthTargets { get; set; }
        List<int> StealthTargets { get; set; }
        int Unknown7 { get; set; }
        int NumLegalBuildingTelepads { get; set; }
        List<int> LegalBuildingTelepads { get; set; }

        byte CreateCraters { get; set; }
        int WorkerStrength1 { get; set; }
        int WorkerStrength2 { get; set; }
        int WorkerStrength3 { get; set; }
        int Unknown9 { get; set; }
        int AitDefense { get; set; }

        public void Load( BinaryFormatter formatter )
        {
		    ZoneOfControl = formatter.ReadInt32();
            Name = formatter.ReadChars( ( int ) BIQUnitSizes.Name );
            Civlopedia = formatter.ReadChars( ( int ) BIQUnitSizes.Civlopedia );
            BombardStrength = formatter.ReadInt32();
            BombardRange = formatter.ReadInt32();
            Capacity = formatter.ReadInt32();
            Cost = formatter.ReadInt32();
            Defence = formatter.ReadInt32();
            IconIndex = formatter.ReadInt32();
            Attack = formatter.ReadInt32();
            OperationalRange = formatter.ReadInt32();
            PopulationCost = formatter.ReadInt32();
            RateOfFire = formatter.ReadInt32();
            Movement = formatter.ReadInt32();
            Tech = formatter.ReadInt32();
            UpgradeTo = formatter.ReadInt32();
            Resource1 = formatter.ReadInt32();
            Resource2 = formatter.ReadInt32();
            Resource3 = formatter.ReadInt32();
            UnitAbilities = formatter.ReadInt32();
            AIStrategy = formatter.ReadInt32();
            AvailableTo = formatter.ReadInt32();
            StandardOrdersSpecialActions = formatter.ReadInt32();
            AirMissions = formatter.ReadInt32();
            UnitClass = formatter.ReadInt32();
            OtherStrategy = formatter.ReadInt32();
            HitPointBonus = formatter.ReadInt32();
            PTWStandardOrders = formatter.ReadInt32();
            PTWSpecialActions = formatter.ReadInt32();
            PTWWorkerActions = formatter.ReadInt32();
            PTWAirMissions = formatter.ReadInt32();


            PTWActionsMix = formatter.ReadShort16();
            Unknown1 = formatter.ReadShort16();
            BombardEffects = formatter.ReadInt32();
            IgnoreMovementCost = new List<byte>();
            for ( int i = 0; i < 14; i++ )
                IgnoreMovementCost.Add ( formatter.ReadByte() );
            RequireSupport = formatter.ReadInt32();
            UseExactCost = formatter.ReadInt32();
            TelepadRange = formatter.ReadInt32();
            Unknown4 = formatter.ReadInt32();
            NumLegalUnitTelepads = formatter.ReadInt32();

            LegalUnitTelepads = new List<int>();
            for ( int i = 0; i < NumLegalUnitTelepads; i++ )
                LegalUnitTelepads.Add( formatter.ReadInt32() );

            EnslaveResults = formatter.ReadInt32();
            Unknown6 = formatter.ReadInt32();
            NumberOfStealthTargets = formatter.ReadInt32();

            StealthTargets = new List<int>();
            for ( int i = 0; i < NumberOfStealthTargets; i++ )
                StealthTargets.Add ( formatter.ReadInt32() );

            Unknown7 = formatter.ReadInt32();
            NumLegalBuildingTelepads = formatter.ReadInt32();
            LegalBuildingTelepads = new List<int>();
            for ( int i = 0; i < NumLegalBuildingTelepads; i++ )
                LegalBuildingTelepads.Add( formatter.ReadInt32() );

            CreateCraters = formatter.ReadByte();
            WorkerStrength1 = formatter.ReadInt32();

            int temp = formatter.ReadInt32();
            if ( temp == 1 )
            {
                WorkerStrength2 = temp;
                WorkerStrength3 = formatter.ReadInt32();

                temp = formatter.ReadInt32();
            }

            Unknown9 = temp;
            AitDefense = formatter.ReadInt32();
        }

        public void Import(List<string> Paths) {
            UnitData data = ResourceInterface.AddUnit();
            data.NumMoves = this.Movement;
            data.Cost = this.Cost;
            data.PopulationCost = this.PopulationCost;
            data.AIStrategies = this.AIStrategy;
            data.Attack = this.Attack;
            data.Defense = this.Defence;
            data.BombardStr = this.BombardStrength;
            data.BombardRange = this.BombardRange;
            data.DomainType = (EUnitData_DomainType)this.UnitClass;

            bool found = false;
            string FoundPath = "";
            foreach(var Item in Paths) {

                if (System.IO.Directory.Exists(Item + "\\" + this.Name) == true) {
                    found = true;
                    FoundPath = Item + "\\" + this.Name;
                    break;
                }
            }

            if (found == true) {
                UnitArt UnitArt = new UnitArt();
                ResourceInterface.UnitArtData.Add(UnitArt);

                UnitArt.Type = "UNIT_ART_" + this.Name.ToUpper().Replace(" ", "_");
                data.UnitArt = UnitArt;

                System.IO.Directory.CreateDirectory(@"Assets\Art\Units\" + this.Name);

                INIFileHandler.Path = FoundPath + "\\" + this.Name + ".ini";
                string AnimName = INIFileHandler.ReadValue("Animations", "DEFAULT");

                GetUnitAnim(AnimName, UnitArt, FoundPath);


            }
            else {

            }

            data.Description = "TXT_KEY_UNIT_" + Name.ToUpper();
        }

        void GetUnitAnim(string AnimName, UnitArt UnitArt, string FoundPath) {
            Flc Flc = new Flc();

            Flc.UnitArt = UnitArt;
            UnitArt.UnitFlc.Add(Flc);

            if (System.IO.File.Exists(string.Format(@"Assets\Art\Units\{0}\{1}", this.Name, AnimName)) == false) 
                System.IO.File.Copy(string.Format(@"{0}\{1}", FoundPath, AnimName), string.Format(@"Assets\Art\Units\{0}\{1}", this.Name, AnimName));

            Flc.Path = string.Format(@"Assets\Art\Units\{0}\{1}", this.Name, AnimName);
            Flc.BufferFile(string.Format(@"Assets\Art\Units\{0}\{1}", this.Name, AnimName ) );
        }
    }
}
