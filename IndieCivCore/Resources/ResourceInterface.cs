using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using IndieCivCore.Serialization;

namespace IndieCivCore.Resources {
    public static class ResourceInterface {

        [XmlElement("Terrain")]
        public static List<TerrainData> TerrainData;

        public static List<CivilizationData> CivilizationData = new List<CivilizationData>();
        public static List<ResourceData> ResourceData = new List<ResourceData>();
        public static List<ReliefData> ReliefData = new List<ReliefData>();
        public static List<AdvanceData> AdvanceData = new List<AdvanceData>();
        public static List<EraData> EraData = new List<EraData>();
        public static List<GovernmentData> GovernmentData = new List<GovernmentData>();

        [XmlElement("TerrainArt")]
        public static List<TerrainArt> TerrainArtData;

        [XmlElement("RelirtArt")]
        public static List<ReliefArt> ReliefArtData;

        [XmlElement("UnitArt")]
        public static List<UnitArt> UnitArtData = new List<UnitArt>();
        [XmlElement("Unit")]
        public static List<UnitData> UnitData = new List<UnitData>();

        public static List<TurnData> TurnData;

        public static void Init() {
            TerrainData.ForEach(item => {
                item.Index = TerrainData.IndexOf(item);
            });
            /*UnitData.ForEach(item => {
                item.Index = UnitData.IndexOf(item);
            });*/
            EraData.ForEach(item => {
                item.Index = EraData.IndexOf(item);
            });
            ReliefData.ForEach(item => {
                item.Index = ReliefData.IndexOf(item);
            });
            TerrainArtData.ForEach(item => {
                item.Index = TerrainArtData.IndexOf(item);
                item.Init();
            });
            ReliefArtData.ForEach(item => {
                item.Index = ReliefArtData.IndexOf(item);
                item.Init();
            });
            UnitArtData.ForEach(item => {
                item.Index = UnitArtData.IndexOf(item);
                item.Init();
            });
        }

        public static CivilizationData AddCivilization() {
            CivilizationData data = new CivilizationData();
            data.Index = ResourceInterface.CivilizationData.Count;
            ResourceInterface.CivilizationData.Add(data);
            return data;
        }

        public static ResourceData AddResource() {
            ResourceData data = new ResourceData();
            data.Index = ResourceInterface.ResourceData.Count;
            ResourceInterface.ResourceData.Add(data);
            return data;
        }

        public static ReliefData AddRelief() {
            ReliefData data = new ReliefData();
            data.Index = ResourceInterface.ReliefData.Count;
            ResourceInterface.ReliefData.Add(data);

            return data;
        }

        public static UnitData AddUnit() {
            UnitData data = new UnitData();
            data.Index = ResourceInterface.UnitData.Count;
            ResourceInterface.UnitData.Add(data);

            return data;
        }

        public static AdvanceData AddAdvance() {
            AdvanceData data = new AdvanceData();
            data.Index = ResourceInterface.AdvanceData.Count;
            ResourceInterface.AdvanceData.Add(data);

            return data;
        }
        
    }
}
