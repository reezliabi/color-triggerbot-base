using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Indigo.Utilities
{
    public class IniFile
    {
        private readonly string Path;
        private readonly string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(
          string Section,
          string Key,
          string Value,
          string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(
          string Section,
          string Key,
          string Default,
          StringBuilder RetVal,
          int Size,
          string FilePath);

        public IniFile(string IniPath = null) => this.Path = new FileInfo(IniPath ?? this.EXE + ".ini").FullName.ToString();

        public string Read(string Key, string Section = null)
        {
            StringBuilder RetVal = new StringBuilder((int)byte.MaxValue);
            IniFile.GetPrivateProfileString(Section ?? this.EXE, Key, "", RetVal, (int)byte.MaxValue, this.Path);
            return RetVal.ToString();
        }
        public int ReadInt(string Key, string Section = null)
        {
            return Convert.ToInt32(Read(Key, Section));
        }

        public float ReadFloat(string Key, string Section = null)
        {
            return Convert.ToSingle(Read(Key, Section));
        }

        public double ReadDouble(string Key, string Section = null)
        {
            return Convert.ToDouble(Read(Key, Section));
        }

        public bool ReadBoolean(string Key, string Section = null)
        {
            return Read(Key, Section) == "true";
        }

        public void Write(string Key, string Value, string Section = null) => IniFile.WritePrivateProfileString(Section ?? this.EXE, Key, Value, this.Path);

        public void DeleteKey(string Key, string Section = null) => this.Write(Key, (string)null, Section ?? this.EXE);

        public void DeleteSection(string Section = null) => this.Write((string)null, (string)null, Section ?? this.EXE);

        public bool KeyExists(string Key, string Section = null) => this.Read(Key, Section).Length > 0;
    }
}
