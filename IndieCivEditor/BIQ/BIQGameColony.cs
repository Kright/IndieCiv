using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQGameColony
    {
        public enum BIQGameColonySizes
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
        int ImprovementType { get; set; }

        public void Load ( BinaryFormatter formatter )
        {
            //Name = formatter.ReadChars( ( int ) BIQGameColonySizes.Name );
            OwnerType = formatter.ReadInt32();
            //ExperienceLevel = formatter.ReadInt32();
            Owner = formatter.ReadInt32();
            //PRTONumber = formatter.ReadInt32();
            //AIStrategy = formatter.ReadInt32();
            X = formatter.ReadInt32();
            Y = formatter.ReadInt32();
            //PTWCustomName = formatter.ReadChars( ( int ) BIQGameColonySizes.PTWCustomName );
            //UseCivilizationKing = formatter.ReadInt32();

            ImprovementType = formatter.ReadInt32();
        }
    }
}
