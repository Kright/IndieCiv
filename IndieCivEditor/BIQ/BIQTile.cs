using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Serialization;

namespace IndieCivEditor.BIQ
{
    public class BIQTile
    {
        public byte RiverConnectionInfo { get; set; }
        public byte Border { get; set; }
        public int Resource { get; set; }
        public byte Image { get; set; }
        public byte File { get; set; }
        public short Unknown1 { get; set; }
        public byte Overlays { get; set; }
        public byte BaseRealTerrain { get; set; }
        public byte Bonuses { get; set; }
        public byte RiverCrossingData { get; set; }
        public short BarbarianTribe { get; set; }
        public short City { get; set; }
        public short Colony { get; set; }
        public short Continent { get; set; }
        public byte Unknown2 { get; set; }
        public short VictoryPointLocation { get; set; }
        public int Ruin { get; set; }

        public int C3COverlays { get; set; }
        public byte Unknown3 { get; set; }
        public byte C3CBaseRealTerrain { get; set; }
        public short Unknown4 { get; set; }
        public short FogOfWar { get; set; }
        public int C3CBonuses { get; set; }
        public short Unknown5 { get; set; }

        public void Load( BinaryFormatter formatter )
        {
            RiverConnectionInfo = formatter.ReadByte();
            Border = formatter.ReadByte();
            Resource = formatter.ReadInt32();
            Image = formatter.ReadByte();
            File = formatter.ReadByte();
            Unknown1 = formatter.ReadShort16();
            Overlays = formatter.ReadByte();
            BaseRealTerrain = formatter.ReadByte();
            Bonuses = formatter.ReadByte();
            RiverCrossingData = formatter.ReadByte();
            BarbarianTribe = formatter.ReadShort16();
            City = formatter.ReadShort16();
            Colony = formatter.ReadShort16();
            Continent = formatter.ReadShort16();
            Unknown2 = formatter.ReadByte();
            VictoryPointLocation = formatter.ReadShort16();
            Ruin = formatter.ReadInt32();

            // Conquests
            C3COverlays = formatter.ReadInt32();
            Unknown3 = formatter.ReadByte();
            C3CBaseRealTerrain = formatter.ReadByte();
            Unknown4 = formatter.ReadShort16();
            FogOfWar = formatter.ReadShort16();
            C3CBonuses = formatter.ReadInt32();
            Unknown5 = formatter.ReadShort16();
        }
    }
}
