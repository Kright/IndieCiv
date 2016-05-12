using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQBuilding
    {
        public enum BIQBuildingSizes
        {
            Description = 64,
            Name        = 32,
            Civlopedia  = 32,
        };

        string Description { get; set; }
        string Name { get; set; }
        string Civlopedia { get; set; }

        int DoublesHappinessOf { get; set; }
        int GainInEveryCity { get; set; }
        int GainInEveryCityOnContinent { get; set; }
        int RequiredBuilding { get; set; }
        int Cost { get; set; }
        int Culture { get; set; }
        int BombardmentDefense { get; set; }
        int NavalBombardmentDefense { get; set; }
        int DefenseBonus { get; set; }
        int NavalDefenseBonus { get; set; }
        int MaintenanceCost { get; set; }
        int HappyFacesAllCities { get; set; }
        int HappyFaces { get; set; }
        int UnhappyFacesAllCities { get; set; }
        int UnhappyFaces { get; set; }
        int NumberOfRequiredBuildings { get; set; }
        int AirPower { get; set; }
        int NavalPower { get; set; }
        int Pollution { get; set; }
        int Production { get; set; }
        int RequiredGovernment { get; set; }
        int SpaceshipPart { get; set; }
        int RequiredAdvance { get; set; }
        int RenderedObsoleteBy { get; set; }
        int RequiredResource1 { get; set; }
        int RequiredResource2 { get; set; }
        int Improvements { get; set; }
        int OtherCharacteristics { get; set; }
        int SmallWonders { get; set; }
        int Wonders { get; set; }
        int NumberOfArmiesRequired { get; set; }
        int Flavors { get; set; } // Binary
        int Unknown { get; set; }
        int UnitProduced { get; set; } // (PRTO ref)
        int UnitFrequency { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            Description = formatter.ReadChars( ( int ) BIQBuildingSizes.Description );
            Name = formatter.ReadChars( ( int ) BIQBuildingSizes.Name );
            Civlopedia = formatter.ReadChars( ( int ) BIQBuildingSizes.Civlopedia );

            DoublesHappinessOf = formatter.ReadInt32();
            GainInEveryCity = formatter.ReadInt32();
            GainInEveryCityOnContinent = formatter.ReadInt32();
            RequiredBuilding = formatter.ReadInt32();
            Cost = formatter.ReadInt32();
            Culture = formatter.ReadInt32();
            BombardmentDefense = formatter.ReadInt32();
            NavalBombardmentDefense = formatter.ReadInt32();
            DefenseBonus = formatter.ReadInt32();
            NavalDefenseBonus = formatter.ReadInt32();
            MaintenanceCost = formatter.ReadInt32();
            HappyFacesAllCities = formatter.ReadInt32();
            HappyFaces = formatter.ReadInt32();
            UnhappyFacesAllCities = formatter.ReadInt32();
            UnhappyFaces = formatter.ReadInt32();
            NumberOfRequiredBuildings = formatter.ReadInt32();
            AirPower = formatter.ReadInt32();
            NavalPower = formatter.ReadInt32();
            Pollution = formatter.ReadInt32();
            Production = formatter.ReadInt32();
            RequiredGovernment = formatter.ReadInt32();
            SpaceshipPart = formatter.ReadInt32();
            RequiredAdvance = formatter.ReadInt32();
            RenderedObsoleteBy = formatter.ReadInt32();
            RequiredResource1 = formatter.ReadInt32();
            RequiredResource2 = formatter.ReadInt32();
            Improvements = formatter.ReadInt32();
            OtherCharacteristics = formatter.ReadInt32();
            SmallWonders = formatter.ReadInt32();
            Wonders = formatter.ReadInt32();
            NumberOfArmiesRequired = formatter.ReadInt32();
            Flavors = formatter.ReadInt32(); // Binary
            Unknown = formatter.ReadInt32();
            UnitProduced = formatter.ReadInt32(); // (PRTO ref)
            UnitFrequency = formatter.ReadInt32();
        }

    }
}
