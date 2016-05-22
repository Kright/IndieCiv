using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQCity
    {
        public enum BIQCitySizes
        {
            Name = 24,
        };

        byte HasWalls { get; set; }
        byte HasPalace { get; set; }
        string Name { get; set; }
        int OwnerType { get; set; }
        int NumBuildings { get; set; }
        List<int> Buildings { get; set; }

        int Culture { get; set; }
        int Owner { get; set; }
        int Size { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int CityLevel { get; set; }
        int BorderLevel { get; set; }
        int UseAutoName { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            HasWalls = formatter.ReadByte();
            HasPalace = formatter.ReadByte();
            Name = formatter.ReadString((int)BIQCitySizes.Name);
            OwnerType = formatter.ReadInt32();
            NumBuildings = formatter.ReadInt32();

            Buildings = new List<int>();
            for ( int i = 0; i < NumBuildings; i++ )
                Buildings.Add( formatter.ReadInt32() );

            Culture = formatter.ReadInt32();
            Owner = formatter.ReadInt32();
            Size = formatter.ReadInt32();
            X = formatter.ReadInt32();
            Y = formatter.ReadInt32();
            CityLevel = formatter.ReadInt32();
            BorderLevel = formatter.ReadInt32();
            UseAutoName = formatter.ReadInt32();

        }
    }
}
