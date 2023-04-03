using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace SimpleRecoil.Utilities
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HSLColor
    {
        public float h;
        public float s;
        public float l;

        public HSLColor(float h, float s, float l) : this()
        {
            this.h = h;
            this.s = s;
            this.l = l;
        }
    }
    internal class ColorManager
    {
        public static HSLColor RGBToHSL(Color RGBColor)
        {
            float _R = (RGBColor.R / 255f);
            float _G = (RGBColor.G / 255f);
            float _B = (RGBColor.B / 255f);

            float _Min = Math.Min(Math.Min(_R, _G), _B);
            float _Max = Math.Max(Math.Max(_R, _G), _B);
            float _Delta = _Max - _Min;

            float H = 0;
            float S = 0;
            float L = (float)((_Max + _Min) / 2.0f);

            if (_Delta != 0)
            {
                if (L < 0.5f)
                {
                    S = (float)(_Delta / (_Max + _Min));
                }
                else
                {
                    S = (float)(_Delta / (2.0f - _Max - _Min));
                }


                if (_R == _Max)
                {
                    H = (_G - _B) / _Delta;
                }
                else if (_G == _Max)
                {
                    H = 2f + (_B - _R) / _Delta;
                }
                else if (_B == _Max)
                {
                    H = 4f + (_R - _G) / _Delta;
                }
            }

            return new HSLColor(H, S, L);
        }
        public static Color GetPixel(Point position)
        {
            using (var bitmap = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(position, new Point(0, 0), new Size(1, 1));
                }
                return bitmap.GetPixel(0, 0);
            }
        }
        public static bool AreColorsSimilar(Color c1, Color c2, float tolerance)
        {
            return Math.Abs(c1.R - c2.R) < tolerance &&
                   Math.Abs(c1.G - c2.G) < tolerance &&
                   Math.Abs(c1.B - c2.B) < tolerance;
        }
        public static bool CloseEnoughForMe(double value1, double value2, double acceptableDifference)
        {
            return Math.Abs(value1 - value2) <= acceptableDifference;
        }
    }

}
