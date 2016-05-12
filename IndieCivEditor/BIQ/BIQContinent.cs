using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQContinent
    {
        int Class { get; set; }
        int NumTiles { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            Class = formatter.ReadInt32();
            NumTiles = formatter.ReadInt32();
        }
    }
}
