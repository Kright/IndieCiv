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

        //[StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct RGB {
            public byte red, green, blue;
        }


        public SFlcHeader FlcHeader = new SFlcHeader();
        public SCiv3Header Civ3Header = new SCiv3Header();

        byte[][] mBufferFrames;
        RGB[][] mColourMap;

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

            mBufferFrames = new byte[FlcHeader.frames + 8][];
            mColourMap = new RGB[FlcHeader.frames + 8][];

            for ( short frame = 0; frame < FlcHeader.frames; frame++ ) {

                mBufferFrames[frame] = new byte[FlcHeader.width * FlcHeader.height];
                //Array.Clear(mBufferFrames[frame], 0, FlcHeader.width * FlcHeader.height);                
                mColourMap[frame] = new RGB[256];
                //Array.Clear(mColourMap[frame], 0, 3 * 256);

                if (frame > 0) {
                    Array.Copy(mBufferFrames[frame - 1], mBufferFrames[frame], sizeof(byte) * (FlcHeader.width * FlcHeader.height));
                    Array.Copy(mColourMap[frame - 1], mColourMap[frame], 256);
                }

                frameHeader.ReadData(mFormatter);

                if (frameHeader.magic != 0xf1fa) {
                    continue;
                }

                for (int chunk = 0; chunk < frameHeader.chunks; chunk++) {
                    chunkHeader.ReadData(mFormatter);

                    switch (chunkHeader.type) {
                        case 4:
                            FlcColour256(mFormatter, frame);
                            break;
                        case 15:
                            FlcBitwiseRun(mFormatter, frame);
                            break;

                    }
                }

            }
        }

        void FlcColour256(BinaryFormatter formatter, int frame) {
            short packets, idx;
            byte skip, change;

            packets = formatter.ReadShort16();

            idx = 0;
            for (int i = 0; i < packets; i++) {

                skip = formatter.ReadByte();
                idx += skip;

                change = formatter.ReadByte();

                if (change == 0) {

                    for (idx = 0; idx < 256; idx++) {
                        mColourMap[frame][idx].red = formatter.ReadByte();
                        mColourMap[frame][idx].green = formatter.ReadByte();
                        mColourMap[frame][idx].blue = formatter.ReadByte();
                    }

                }
                else {
                    for (int j = 0; j < change; j++) {
                        mColourMap[frame][idx].red = formatter.ReadByte();
                        mColourMap[frame][idx].green = formatter.ReadByte();
                        mColourMap[frame][idx].blue = formatter.ReadByte();
                        idx++;

                    }
                }

            }
        }

        void FlcBitwiseRun(BinaryFormatter formatter, int frame) {
            int line = 0;
            int k, pos = 0;
            sbyte size;
            byte colour;

            while (line++ < FlcHeader.height) {
                formatter.ReadByte();
                k = 0;
                while (k < FlcHeader.width) {
                    size = (sbyte)formatter.ReadByte();

                    if (size > 0) {
                        colour = formatter.ReadByte();

                        k += size;
                        for (int j = 0; j < size; j++ )
                            mBufferFrames[frame][pos++] = colour;
                    }
                    else {
                        size = (sbyte)-size;
                        k += size;

				        for (int j = 0; j < size; j++) {
					        colour = formatter.ReadByte();
                            mBufferFrames[frame][pos++] = colour;
				        }


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
