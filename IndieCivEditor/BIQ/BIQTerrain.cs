using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQTerrain
    {
        public enum BIQTerrainSizes
        {
            Name = 32,
            CivilopediaEntry = 32,
            LandmarkName = 32,
            LandmarkCivlopedia = 32,
        };

		int NumTotalResources;
		List<byte> PossibleResources;
		string Name;
		string Civlopedia;
		int FoodBonus;
		int ShieldsBonus;
		int CommerceBonus;
		int DefenceBonus;
		int MovementCost;
		int Food;
		int Shields;
		int Commerce;
		int WorkerJob;
		int PollutionEffect;
		byte AllowCities;
		byte AllowColonies;
		byte Impassible;
		byte ImpassibleWheeled;
		byte AllowAirfields;
		byte AllowForts;
		byte AllowOutposts;
		byte AllowRadarTowers;
		int Unknown1;
		byte LandmarkEnabled;
		int LandmarkFood;
		int LandmarkShields;
		int LandmarkCommerce;
		int LandmarkFoodBonus;
		int LandmarkShieldBonus;
		int LandmarkCommerceBonus;
		int LandmarkMovementCost;
		int LandmarkDefenseBonus;
		string LandmarkName;
		string LandmarkCivlopedia;
		int Unknown2;
		int TerrainFlags;
		int DiseaseStrength;

        public void Load( BinaryFormatter formatter )
        {
            NumTotalResources = formatter.ReadInt32();


            int bytesOfAllowedResourceDataToInput = ( NumTotalResources + 7 ) / 8;
            PossibleResources = new List<byte>();
            for ( int j = 0; j < bytesOfAllowedResourceDataToInput; j++ )
                PossibleResources.Add ( formatter.ReadByte() );

            Name = formatter.ReadChars( ( int ) BIQTerrainSizes.Name );
            Civlopedia = formatter.ReadChars( ( int ) BIQTerrainSizes.CivilopediaEntry );

            FoodBonus = formatter.ReadInt32();

            ShieldsBonus = formatter.ReadInt32();
            CommerceBonus = formatter.ReadInt32();
            DefenceBonus = formatter.ReadInt32();
            MovementCost = formatter.ReadInt32();
            Food = formatter.ReadInt32();
            Shields = formatter.ReadInt32();
            Commerce = formatter.ReadInt32();
            WorkerJob = formatter.ReadInt32();
            PollutionEffect = formatter.ReadInt32();
            AllowCities = formatter.ReadByte();
            AllowColonies = formatter.ReadByte();
            Impassible = formatter.ReadByte();
            ImpassibleWheeled = formatter.ReadByte();
            AllowAirfields = formatter.ReadByte();
            AllowForts = formatter.ReadByte();
            AllowOutposts = formatter.ReadByte();
            AllowRadarTowers = formatter.ReadByte();

            Unknown1 = formatter.ReadInt32();
            LandmarkEnabled = formatter.ReadByte();
            LandmarkFood = formatter.ReadInt32();
            LandmarkShields = formatter.ReadInt32();
            LandmarkCommerce = formatter.ReadInt32();
            LandmarkFoodBonus = formatter.ReadInt32();
            LandmarkShieldBonus = formatter.ReadInt32();
            LandmarkCommerceBonus = formatter.ReadInt32();
            LandmarkMovementCost = formatter.ReadInt32();
            LandmarkDefenseBonus = formatter.ReadInt32();
            LandmarkName = formatter.ReadChars( ( int ) BIQTerrainSizes.LandmarkName );
            LandmarkCivlopedia = formatter.ReadChars( ( int ) BIQTerrainSizes.LandmarkCivlopedia);
            Unknown2 = formatter.ReadInt32();
            TerrainFlags = formatter.ReadInt32();
            DiseaseStrength = formatter.ReadInt32();
        }
    }
}
