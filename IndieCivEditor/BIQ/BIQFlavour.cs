using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQFlavour
    {
        public enum BIQFlavourSizes
        {
            Name = 256,
        };


        int Unknown1 { get; set; }
        string Name { get; set; }
        int NumberOfFlavors { get; set; }
        List<int> RelationWithOtherFlavor { get; set; }


        public void Load ( BinaryFormatter formatter )
        {
            Unknown1 = formatter.ReadInt32();
            Name = formatter.ReadString( ( int ) BIQFlavourSizes.Name );

            RelationWithOtherFlavor = new List<int>();

            NumberOfFlavors = formatter.ReadInt32();
            for ( int i = 0; i < NumberOfFlavors; i++ )
                RelationWithOtherFlavor.Add( formatter.ReadInt32() );


        }
    }
}
