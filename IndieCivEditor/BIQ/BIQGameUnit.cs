using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQGameUnit
    {
        public enum BIQGameUnitSizes
        {
            Name = 32,
            PTWCustomName = 57,
        };

        string Name { get; set; }
        int OwnerType { get; set; }
        int ExperienceLevel { get; set; }
        int Owner { get; set; }
        int PRTONumber { get; set; }
        int AIStrategy { get; set; }
        int X { get; set; }
        int Y { get; set; }
        string PTWCustomName { get; set; }
        int UseCivilizationKing { get; set; }

        public void Load ( BinaryFormatter formatter )
        {
            Name = formatter.ReadString ( (int) BIQGameUnitSizes.Name );
            OwnerType = formatter.ReadInt32();
            ExperienceLevel = formatter.ReadInt32();
            Owner = formatter.ReadInt32();
            PRTONumber = formatter.ReadInt32();
            AIStrategy = formatter.ReadInt32();
            X = formatter.ReadInt32();
            Y = formatter.ReadInt32();
            PTWCustomName = formatter.ReadString( ( int ) BIQGameUnitSizes.PTWCustomName );
            UseCivilizationKing = formatter.ReadInt32();
        }
    }
}
