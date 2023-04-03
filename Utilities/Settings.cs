using System;
using System.Drawing;

namespace SimpleRecoil.Utilities
{
    namespace Settings
    {
        public enum DetectionMethods : byte
        {
            Pixel = 0,
            Glaz = 1,
            Color = 2
        }
        public static class DetectionMethodsExtensions
        {
            public static DetectionMethods FromInt(int val)
            {
                switch(val)
                {
                    case 0: return DetectionMethods.Pixel;
                    case 1: return DetectionMethods.Glaz;
                    case 2: return DetectionMethods.Color;
                    default: return DetectionMethods.Pixel;
                }
            }
        }
        public class Trigger
        {
            public static bool Enabled = false;
            public static bool Continuous = false;
            public static string Hotkey = "None";
            public static int OffsetX = 0;
            public static int OffsetY = 0;
            public static int ShootDelay = 0;
            public static int FireSpeed = 0;
            public static float Tolerance = 0;
            public static DetectionMethods DetectionMethod = DetectionMethods.Pixel;
        }

        public class Settings
        {
            public static bool bLowEnd = false;
            public static bool bPlaySounds = true;
        }
        public class Globals
        {
            public static bool ShenronsBlessing = true;
            public static bool DoYouEvenLiftBro = true;
            public static IntPtr WindowHandle = IntPtr.Zero;
            public static Color AccentColor = Color.Empty;
        }
        public class Math
        {
            public static float fMultiplier = 21.4f;
        }
    }
}
