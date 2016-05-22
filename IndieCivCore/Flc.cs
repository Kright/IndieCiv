using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using IndieCivCore.Resources;
using IndieCivCore.Serialization;

using Microsoft.Xna.Framework.Graphics;

namespace IndieCivCore {

    public class Flc {

        //[StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SFlcHeader {
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
            public char[] reserved2; /* Set to zero */
            public long oframe1;       /* Offset to frame 1 (FLC only) */
            public long oframe2;       /* Offset to frame 2 (FLC only) */
            //BYTE												reserved3[40]; /* Set to zero */

            public void ReadData(BinaryFormatter mFormatter) {
                this.size = mFormatter.ReadInt32();
                this.type = mFormatter.ReadShort16();
                this.frames = mFormatter.ReadShort16();
                this.width = mFormatter.ReadShort16();
                this.height = mFormatter.ReadShort16();
                this.depth = mFormatter.ReadShort16();
                this.flags = mFormatter.ReadShort16();
                this.speed = mFormatter.ReadInt32();
                this.reserved1 = mFormatter.ReadShort16();
                this.created = mFormatter.ReadInt32();
                this.creator = mFormatter.ReadInt32();
                this.updated = mFormatter.ReadInt32();
                this.updater = mFormatter.ReadInt32();
                this.aspect_dx = mFormatter.ReadShort16();
                this.aspect_dy = mFormatter.ReadShort16();
                this.reserved2 = mFormatter.ReadChars(38);
                this.oframe1 = mFormatter.ReadInt32();
                this.oframe2 = mFormatter.ReadInt32();
            }
        };


        public struct SCiv3Header {
            uint size;
            int flags;
            ushort numAnims;
            public ushort animLength;
            public ushort xOffset;
            public ushort yOffset;
            public ushort xs_orig;
            public ushort ys_orig;
            int animTime;
            int unknown12;
            public char[] stuff;

            public void ReadData(BinaryFormatter mFormatter) {
                this.size = mFormatter.ReadUInt32();
                this.flags = mFormatter.ReadInt32();
                this.numAnims = mFormatter.ReadUShort16();
                this.animLength = mFormatter.ReadUShort16();
                this.xOffset = mFormatter.ReadUShort16();
                this.yOffset = mFormatter.ReadUShort16();
                this.xs_orig = mFormatter.ReadUShort16();
                this.ys_orig = mFormatter.ReadUShort16();
                this.animTime = mFormatter.ReadInt32();
                this.unknown12 = mFormatter.ReadInt32();
                this.stuff = mFormatter.ReadChars(12);
            }
        };

        public struct SFliFrameHeader {
            ulong size;
            public ushort magic;
            public ushort chunks;
            public char[] expand;

            public void ReadData(BinaryFormatter mFormatter) {
                this.size = mFormatter.ReadUInt32();
                this.magic = mFormatter.ReadUShort16();
                this.chunks = mFormatter.ReadUShort16();
                this.expand = mFormatter.ReadChars(8);
            }
        };

        public struct SFliChunkHeader {
            ulong size;
            public ushort type;

            public void ReadData(BinaryFormatter mFormatter) {
                this.size = mFormatter.ReadUInt32();
                this.type = mFormatter.ReadUShort16();
            }
        };

        public SFlcHeader FlcHeader = new SFlcHeader();
        public SCiv3Header Civ3Header = new SCiv3Header();

        public string Path { get; set; }
        public UnitArt UnitArt { get; set; }

        public MemoryStream FileBuffer;

        public void BufferFile(string Path) {
            long length = new System.IO.FileInfo(Path).Length;
            FileBuffer = new MemoryStream(File.ReadAllBytes(Path));

            //this.GetBufferFrames();

            BinaryFormatter mFormatter = new BinaryFormatter(FileBuffer);
            FlcHeader.ReadData(mFormatter);
            Civ3Header.ReadData(mFormatter);

            SFliFrameHeader frameHeader = new SFliFrameHeader();
            SFliChunkHeader chunkHeader = new SFliChunkHeader();
            for ( short frame = 0; frame < FlcHeader.frames; frame++ ) {

                frameHeader.ReadData(mFormatter);

                if (frameHeader.magic != 0xf1fa) {
                    continue;
                }

                for (int chunk = 0; chunk < frameHeader.chunks; chunk++) {
                    chunkHeader.ReadData(mFormatter);

                    switch (chunkHeader.type) {
                        case 15:
                            break;

                    }
                }

            }
        }

        /*unsafe SFlcHeader GetFlcHeader() {
            fixed (byte* map = &FileBuffer[0]) {
                return *(SFlcHeader*)map;
            }
        }*/

        public void GetBufferFrames() {


            //Array.Copy(FileBuffer.ToArray(), 0, FlcHeader, 0, sizeof(SFlcHeader));

            //FlcHeader = GetFlcHeader();

            //FlcHeader.ReadData(FileBuffer);


        }


        public Texture2D GetTexture(int Frame) {

            return null;

        }
    }
}
