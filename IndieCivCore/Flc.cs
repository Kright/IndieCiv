using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IndieCivCore.Resources;

namespace IndieCivCore {
    public class Flc {

        public string Path { get; set; }
        public UnitArt UnitArt { get; set; }

        public byte[] FileBuffer;

        public void BufferFile(string Path) {
            long length = new System.IO.FileInfo(Path).Length;
            FileBuffer = File.ReadAllBytes(Path);
        }
    }
}
