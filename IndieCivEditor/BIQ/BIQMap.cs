using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Resources;
using IndieCivCore.Serialization;
using IndieCivCore.Entities;

namespace IndieCivEditor.BIQ
{
    static class BIQMap
    {
        public enum BIQMapSizes
        {
            Unknown4 = 124,
        };

        static int NumResources { get; set; }
        static List<int> ResourceOccurence { get; set; }

        static int NumContinents { get; set; }
        static int Height { get; set; }
        static int DistanceBetweenCivs { get; set; }
        static int NumCivs { get; set; }
        static int Unknown1 { get; set; }
        static int Unknown2 { get; set; }
        static int Width { get; set; }
        static int Unknown3 { get; set; }
        static string Unknown4 { get; set; }
        static int MapSeed { get; set; }
        static int Flags { get; set; }

        static public List<BIQTile> Tiles { get; set; }

        static public void Load( BinaryFormatter formatter )
        {
            NumResources = formatter.ReadInt32();

            ResourceOccurence = new List<int>();
            for ( int i = 0; i < NumResources; i++ )
                ResourceOccurence.Add( formatter.ReadInt32() );


            NumContinents = formatter.ReadInt32();
            Height = formatter.ReadInt32();
            DistanceBetweenCivs = formatter.ReadInt32();
            NumCivs = formatter.ReadInt32();
            Unknown1 = formatter.ReadInt32();
            Unknown2 = formatter.ReadInt32();
            Width = formatter.ReadInt32();
            Unknown3 = formatter.ReadInt32();
            Unknown4 = formatter.ReadChars( ( int ) BIQMapSizes.Unknown4 );
            MapSeed = formatter.ReadInt32();
            Flags = formatter.ReadInt32();

            formatter.ReadChars(4);


            Tiles = new List<BIQTile>();
            int iNumTiles = formatter.ReadInt32();

            for (int i = 0; i < iNumTiles; i++) {
                BIQTile tile = new BIQTile();

                // Read the size
                formatter.ReadInt32();
                tile.Load(formatter);
                Tiles.Add(tile);
            }

        }


        static public void Import() {
            IndieCivCore.Map.MapCiv3 worldMap = new IndieCivCore.Map.MapCiv3();
            worldMap.Init(Width / 2, Height);
            IndieCivCore.MapManager.Add(worldMap);


            //earth.MapTiles[0].Terrain = Terrain;
            //earth.MapTiles[0].TerrainArt = Art;

            //IndieCivCore.MapManager.Current = IndieCivCore.MapManager.Maps[0];

            List<IndieCivCore.Map.MapTile>.Enumerator enumerator = IndieCivCore.MapManager.Current.MapTiles.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < IndieCivCore.MapManager.Current.Count; i++) {
                IndieCivCore.Map.MapTile MapTile = enumerator.Current;

                MapTile.Region = Tiles[i].Continent;

                if (Tiles[i].Border > 0)
                    MapTile.Owner = PlayerManager.PlayerList[Tiles[i].Border - 1];

                if (Tiles[i].Resource != -1) {
                    //IndieCivCore.Resources.ResourceRef<IndieCivCore.Resources.ResourceData> Resource = IndieCivCore.Resources.ResourceProvider.RequestResource<IndieCivCore.Resources.ResourceData>(IndieCivCore.Resources.ResourceData.VirtualResourcePath + Tiles[i].Resource);

                    MapTile.ResourceType = ResourceInterface.ResourceData[Tiles[i].Resource];
                }

                MapTile.GfxIdx = Tiles[i].Image;
                MapTile.Variation = Tiles[i].File;

                char baseTerrain = (char)((Tiles[i].C3CBaseRealTerrain & 0xF0) >> 4); // 4 - Flood Plains, 5 - Hills, 6 - Mountains
                char real = (char)(Tiles[i].C3CBaseRealTerrain & 0x0F); // 0 - Desert, 1 - PLains, 2 - Grassland, 3 - Tundra, 4 - Plains

                // Set the real terrain type
                if (real == 0) // Desert
                    MapTile.TerrainType = ResourceInterface.TerrainData[4];
                else if (real == 1) // Plains
                    MapTile.TerrainType = ResourceInterface.TerrainData[5];
                else if (real == 2) // Grassland
                    MapTile.TerrainType = ResourceInterface.TerrainData[3];
                else if (real == 3) // Tundra
                    MapTile.TerrainType = ResourceInterface.TerrainData[6];
                

                else if (real == 11) // Coast
                    MapTile.TerrainType = ResourceInterface.TerrainData[0];
                else if (real == 12) // Sea
                    MapTile.TerrainType = ResourceInterface.TerrainData[1];
                else if (real == 13) // Ocean
                    MapTile.TerrainType = ResourceInterface.TerrainData[2];
                else {
                    int wirugwg = 0;
                }

                
                if ( baseTerrain == 4)
                    MapTile.ReliefType = ResourceInterface.ReliefData[6];
                else if ( baseTerrain == 5)
                    MapTile.ReliefType = ResourceInterface.ReliefData[baseTerrain];
                else if ( baseTerrain == 6)
                    MapTile.ReliefType = ResourceInterface.ReliefData[0];
                else if ( baseTerrain == 7) {
                    if ( real == 3)
                        MapTile.ReliefType = ResourceInterface.ReliefData[2];
                    else if ( real == 2)
                        MapTile.ReliefType = ResourceInterface.ReliefData[4];
                }

                enumerator.MoveNext();
            }
        }
    }
}
