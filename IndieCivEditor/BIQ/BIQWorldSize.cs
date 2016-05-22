using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQWorldSize
    {
        public enum BIQWorldSizeSizes
        {
            Empty = 24,
            Name = 32,
        };


        int OptimalNumberOfCities { get; set; }
        int TechRate { get; set; }
        string Empty { get; set; }
        string Name { get; set; }
        int Height { get; set; }
        int DistanceBetweenCivs { get; set; }
        int NumberOfCivs { get; set; }
        int Width { get; set; }


        public void Load ( BinaryFormatter formatter )
        {
            OptimalNumberOfCities = formatter.ReadInt32();
            TechRate = formatter.ReadInt32();
            Empty = formatter.ReadString( ( int ) BIQWorldSizeSizes.Empty );
            Name = formatter.ReadString( ( int ) BIQWorldSizeSizes.Name );

            Height = formatter.ReadInt32();
            DistanceBetweenCivs = formatter.ReadInt32();
            NumberOfCivs = formatter.ReadInt32();
            Width = formatter.ReadInt32();
        }
    }
}
