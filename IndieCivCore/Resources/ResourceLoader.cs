using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IndieCivCore.Serialization;

namespace IndieCivCore.Resources {
    public static class ResourceLoader {
        public static void Load() {
            ResourceInterface.TerrainData = XmlFormatter.Load<List<TerrainData>>("TerrainData");
            ResourceInterface.ReliefData = XmlFormatter.Load<List<ReliefData>>("ReliefData");
            ResourceInterface.TurnData = XmlFormatter.Load<List<TurnData>>("TurnData");
        }

        public static void LoadArt() {
            ResourceInterface.TerrainArtData = XmlFormatter.Load<List<TerrainArt>>("TerrainArtData");
            ResourceInterface.ReliefArtData = XmlFormatter.Load<List<ReliefArt>>("ReliefArtData");
            ResourceInterface.UnitArtData = XmlFormatter.Load<List<UnitArt>>("UnitArtData");
        }
    }
}
