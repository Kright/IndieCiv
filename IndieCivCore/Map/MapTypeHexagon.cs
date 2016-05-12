using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieCivCore.Map
{
    public class MapTypeHexagon : MapTypeBase
    {
        public override void AddMapTile(MapTile t) {
        }
        public override void AddResource(MapTile t) {
        }
        public override void AddRelief(MapTile t) {
        }
        public override void AddTerritory(MapTile t) {
        }

        public override bool PointInsideMapTile(MapTile t) {
            return true;
        }
        public override void Update()
        {
        }
    }
}
