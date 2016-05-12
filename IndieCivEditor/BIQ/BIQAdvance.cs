using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Resources;
using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQAdvance
    {
        public enum BIQAdvanceSizes
        {
            AdvanceName = 32,
            CivilopediaEntry = 32,
        };

        string AdvanceName;
        string CivilopediaEntry;
        int Cost { get; set; }
        int Era { get; set; }
        int Icon { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Preq1 { get; set; }
        int Preq2 { get; set; }
        int Preq3 { get; set; }
        int Preq4 { get; set; }
        int Flags { get; set; }
        int Flavours { get; set; }
        int QuestionMark { get; set; }

        public int Id { get; set; }

        public void Load( BinaryFormatter formatter )
        {
		    AdvanceName = formatter.ReadChars((int)BIQAdvanceSizes.AdvanceName);
		    CivilopediaEntry = formatter.ReadChars((int)BIQAdvanceSizes.CivilopediaEntry);
		    Cost = formatter.ReadInt32();
		    Era = formatter.ReadInt32();
		    Icon = formatter.ReadInt32();
		    X = formatter.ReadInt32();
		    Y = formatter.ReadInt32();
		    Preq1 = formatter.ReadInt32();
		    Preq2 = formatter.ReadInt32();
		    Preq3 = formatter.ReadInt32();
		    Preq4 = formatter.ReadInt32();
		    Flags = formatter.ReadInt32();
		    Flavours = formatter.ReadInt32();
		    QuestionMark = formatter.ReadInt32();
        }

        public void Import() {
            AdvanceData data = ResourceInterface.AddAdvance();

            //IndieCivCore.Resources.ResourceProvider.RegisterResource(IndieCivCore.Resources.DataAdvance.VirtualResourcePath + Id, data);
        }
    }
}
