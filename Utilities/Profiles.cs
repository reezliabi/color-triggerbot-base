using Indigo.Utilities;
using System;
using System.IO;

namespace SimpleRecoil.Utilities
{
    public static class Profiles
    {
        public const string WORKING_FOLDER = "NECRUM";
        public static void CreateProfilesDirectory()
        {
            string profilesDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), WORKING_FOLDER, "profiles");
            string profileFolder = new FileInfo(profilesDir).FullName.ToString();
            if (!Directory.Exists(profileFolder))
                Directory.CreateDirectory(profileFolder);
        }
        public static void Load(string profileName)
        {
            if (profileName == null || profileName == "None") return;
            string profilesDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), WORKING_FOLDER, "profiles");
            string profileLong = Path.Combine(profilesDir, profileName + ".ini");
            IniFile profile = new IniFile(new FileInfo(profileLong).FullName.ToString());

            Settings.Trigger.Enabled = profile.KeyExists("Enabled", "NECRUM") && Convert.ToBoolean(profile.Read("Enabled", "NECRUM"));
            Settings.Trigger.Continuous = profile.KeyExists("Continuous", "NECRUM") && Convert.ToBoolean(profile.Read("Continuous", "NECRUM"));
            Settings.Trigger.Hotkey = profile.KeyExists("Hotkey", "NECRUM") ? profile.Read("Hotkey", "NECRUM") : "XButton2";
            Settings.Trigger.OffsetX = profile.KeyExists("OffsetX", "NECRUM") ? Convert.ToInt32(profile.Read("OffsetX", "NECRUM")) : 0;
            Settings.Trigger.OffsetY = profile.KeyExists("OffsetY", "NECRUM") ? Convert.ToInt32(profile.Read("OffsetY", "NECRUM")) : 0;
            Settings.Trigger.ShootDelay = profile.KeyExists("ShootDelay", "NECRUM") ? Convert.ToInt32(profile.Read("ShootDelay", "NECRUM")) : 0;
            Settings.Trigger.Tolerance = profile.KeyExists("Tolerance", "NECRUM") ? Convert.ToInt32(profile.Read("Tolerance", "NECRUM")) : 0;
            Settings.Trigger.FireSpeed = profile.KeyExists("FireSpeed", "NECRUM") ? Convert.ToInt32(profile.Read("FireSpeed", "NECRUM")) : 0;
            Settings.Trigger.DetectionMethod = Settings.DetectionMethodsExtensions.FromInt(profile.KeyExists("Detection", "NECRUM") ? Convert.ToInt32(profile.Read("Detection", "NECRUM")) : 0);
        }

        public static void Save(string profileName)
        {
            if (profileName == null || profileName == "None") return;
            string profilesDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), WORKING_FOLDER, "profiles");
            string profileLong = Path.Combine(profilesDir, profileName + ".ini");
            IniFile profile = new IniFile(profileLong);

            profile.Write("Enabled", Settings.Trigger.Enabled.ToString(), "NECRUM");
            profile.Write("Continuous", Settings.Trigger.Continuous.ToString(), "NECRUM");
            profile.Write("Hotkey", Settings.Trigger.Hotkey.ToString(), "NECRUM");
            profile.Write("OffsetX", Settings.Trigger.OffsetX.ToString(), "NECRUM");
            profile.Write("OffsetY", Settings.Trigger.OffsetY.ToString(), "NECRUM");
            profile.Write("ShootDelay", Settings.Trigger.ShootDelay.ToString(), "NECRUM");
            profile.Write("Tolerance", Settings.Trigger.Tolerance.ToString(), "NECRUM");
            profile.Write("FireSpeed", Settings.Trigger.FireSpeed.ToString(), "NECRUM");
            profile.Write("Detection", Convert.ToByte(Settings.Trigger.DetectionMethod).ToString(), "NECRUM");
        }
    }
}
