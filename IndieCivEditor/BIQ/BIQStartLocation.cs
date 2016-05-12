using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQStartLocation
    {
        int OwnerType { get; set; }
        int Owner { get; set; }
        int X { get; set; }
        int Y { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            OwnerType = formatter.ReadInt32();
            Owner = formatter.ReadInt32();
            X = formatter.ReadInt32();
            Y = formatter.ReadInt32();
        }
    }
}
