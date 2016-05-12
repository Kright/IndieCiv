using System;
using System.Runtime.InteropServices;
using System.Text;

namespace IndieCivEditor {
    static class INIFileHandler {
        public static string Path { get; set; }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static void WriteValue(string Section, string Key, string Value) {
            WritePrivateProfileString(Section, Key, Value, INIFileHandler.Path);
        }

        public static string ReadValue(string Section, string Key) {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, INIFileHandler.Path);
            return temp.ToString();

        }
    }
}
