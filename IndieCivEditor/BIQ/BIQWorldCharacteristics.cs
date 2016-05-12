using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQWorldCharacteristics
    {
        int SelectedClimate { get; set; }
        int ActualClimate { get; set; }
        int SelectedBarbarianActivity { get; set; }
        int ActualBarbarianActivity { get; set; }
        int SelectedLandform { get; set; }
        int ActualLandform { get; set; }
        int SelectedOceanCoverage { get; set; }
        int ActualOceanCoverage { get; set; }
        int SelectedTemperature { get; set; }
        int ActualTemperature { get; set; }
        int SelectedAge { get; set; }
        int ActualAge { get; set; }
        int WorldSize { get; set; }

        public void Load ( BinaryFormatter formatter )
        {
            SelectedClimate = formatter.ReadInt32();
            ActualClimate = formatter.ReadInt32();
            SelectedBarbarianActivity = formatter.ReadInt32();
            ActualBarbarianActivity = formatter.ReadInt32();
            SelectedLandform = formatter.ReadInt32();
            ActualLandform = formatter.ReadInt32();
            SelectedOceanCoverage = formatter.ReadInt32();
            ActualOceanCoverage = formatter.ReadInt32();
            SelectedTemperature = formatter.ReadInt32();
            ActualTemperature = formatter.ReadInt32();
            SelectedAge = formatter.ReadInt32();
            ActualAge = formatter.ReadInt32();
            WorldSize = formatter.ReadInt32();
        }
    }
}
