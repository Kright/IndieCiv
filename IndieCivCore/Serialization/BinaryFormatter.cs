using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieCivCore.Serialization
{
    public class BinaryFormatter : Formatter
    {
        private BinaryReader reader = null;

        public BinaryFormatter ( Stream stream )
        {
            this.reader = (stream != null && stream.CanRead) ? new BinaryReader(stream, Encoding.ASCII) : null;
        }

        public bool EOF()
        {
            if (this.reader.BaseStream.Position == this.reader.BaseStream.Length)
                return true;
            if (this.reader.BaseStream.Position > this.reader.BaseStream.Length)
                throw new EndOfStreamException("Reader position is already past the end of the file.");

            return false;
        }

        public string ReadString(int iNum)
        {
            string t = new string(reader.ReadChars(iNum));
            t = t.Trim('\0');
            return t;
        }
        public char[] ReadChars(int iNum) {
            return reader.ReadChars(iNum);
        }
        public byte ReadByte()
        {
            return reader.ReadByte();
        }
        public short ReadShort16()
        {
            return reader.ReadInt16();
        }
        public ushort ReadUShort16() {
            return reader.ReadUInt16();
        }
        public int ReadInt32()
        {
            return reader.ReadInt32();
        }
        public uint ReadUInt32()
        {
            return reader.ReadUInt32();
        }
        public float ReadFloat()
        {
            // read 4 bytes
            byte[] floatBytes = reader.ReadBytes(4);
            // swap the bytes
            //floatBytes = Array.Reverse ( floatBytes );
            Array.Reverse(floatBytes);
            // get the float from the byte array
            float value = BitConverter.ToSingle(floatBytes, 0);

            return value;
        }
    }
}
