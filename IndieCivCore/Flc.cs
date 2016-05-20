using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IndieCivCore.Resources;

using Microsoft.Xna.Framework.Graphics;

namespace IndieCivCore {
    public class Flc {

        public class SFlcHeader {
            //long size;
            //public long speed;
            //public ushort width;
            //public ushort height;

            public long size;          /* Size of FLIC including this header */
            public short type;          /* File type 0xAF11, 0xAF12, 0xAF30, 0xAF44, ... */
            public short frames;        /* Number of frames in first segment */
            public short width;         /* FLIC width in pixels */
            public short height;        /* FLIC height in pixels */
            public short depth;         /* Bits per pixel (usually 8) */
            public short flags;         /* Set to zero or to three */
            public long speed;         /* Delay between frames */
            public short reserved1;     /* Set to zero */
            public long created;       /* Date of FLIC creation (FLC only) */
            public long creator;       /* Serial number or compiler id (FLC only) */
            public long updated;       /* Date of FLIC update (FLC only) */
            public long updater;       /* Serial number (FLC only), see creator */
            public short aspect_dx;     /* Width of square rectangle (FLC only) */
            public short aspect_dy;     /* Height of square rectangle (FLC only) */
            public char[] reserved2 = new char[36]; /* Set to zero */
            public long oframe1;       /* Offset to frame 1 (FLC only) */
            public long oframe2;       /* Offset to frame 2 (FLC only) */
            //BYTE												reserved3[40]; /* Set to zero */

            public void ReadData(byte[] data) {
                this.size = BitConverter.ToInt64(data, 0);
            }
        };

        public struct SCiv3Header {
            uint size;
            int flags;
            ushort numAnims;
            public ushort animLength;
            public ushort xOffset;
            public ushort yOffset;

        };

        public SFlcHeader FlcHeader;
        public SCiv3Header Civ3Header;

        public string Path { get; set; }
        public UnitArt UnitArt { get; set; }

        public byte[] FileBuffer;

        public void BufferFile(string Path) {
            long length = new System.IO.FileInfo(Path).Length;
            FileBuffer = File.ReadAllBytes(Path);

            this.GetBufferFrames();
        }

        public void GetBufferFrames() {
            //Array.Copy(FileBuffer.ToArray(), 0, FlcHeader, 0, sizeof(SFlcHeader));

            FlcHeader = new SFlcHeader();

            FlcHeader.ReadData(FileBuffer);
        }

        public Texture2D GetTexture(int Frame) {

            return null;

        }
    }
}
