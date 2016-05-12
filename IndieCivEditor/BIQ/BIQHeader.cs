using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieCivEditor.BIQ
{
    struct BIQHeader
    {
        public enum BIQHeaderSizes
        {
            Description = 640,
            Title       = 64,
        };

        static private string mType;
        static private int iMajorVer;
        static private int iMinorVer;
		static private string sDescription;
		static private string sTitle;


        public static string Type
        {
            get { return BIQHeader.mType; }
            set { mType = value; }
        }
        public static int MajorVer
        {
            get { return BIQHeader.iMajorVer; }
            set { iMajorVer = value; }
        }
        public static int MinorVer
        {
            get { return BIQHeader.iMinorVer; }
            set { iMinorVer = value; }
        }
        public static string Description
        {
            get { return BIQHeader.sDescription; }
            set { sDescription = value; }
        }
        public static string Title
        {
            get { return BIQHeader.sTitle; }
            set { sTitle = value; }
        }

        public static bool IsValid ()
        {
            return ( BIQHeader.Type.Contains( "BICX" ) == true );
        }
    }
}
