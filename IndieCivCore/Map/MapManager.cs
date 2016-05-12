using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IndieCivCore.Map;

namespace IndieCivCore
{
    public static class MapManager
    {
        public static List<MapTypeBase> Maps { get; set; }

        public static MapTypeBase Current { get; set; }

        static MapManager ()
        {
            Maps = new List<MapTypeBase>();
        }

        public static void Add ( MapTypeBase m )
        {
            Maps.Add( m );
            Current = m;
        }

        public static void Update ()
        {
            if ( Current != null )
                Current.Update();
            /*foreach ( MapTypeBase map in Maps )
            {
                map.Update();
            }*/
        }

        public static void Render ()
        {
            if (Current != null)
                Current.Render();
            /*foreach ( MapTypeBase map in Maps )
            {
                map.Render();
            }*/
        }
    }
}
