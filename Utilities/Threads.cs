using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SimpleRecoil.Utilities
{
    static  class Threads
    {
        [DllImport("user32.dll")]
        private static extern bool GetAsyncKeyState(Keys keys);

        private static Color _oldColor = Color.Empty;
        private static Color _newColor = Color.Empty;
        public static void HitThaQuan()
        {
            while (true)
            {
                bool _isHolding = GetAsyncKeyState((Keys)new KeysConverter().ConvertFromString(Settings.Trigger.Hotkey));
                if (Settings.Trigger.Enabled)
                {
                    Point crosshair = new Point(Screen.PrimaryScreen.Bounds.Width / 2 + Settings.Trigger.OffsetX, Screen.PrimaryScreen.Bounds.Height / 2 + Settings.Trigger.OffsetY);
                    if (_isHolding)
                    {
                        _oldColor = ColorManager.GetPixel(crosshair);
                        Thread.Sleep(1);
                        _newColor = ColorManager.GetPixel(crosshair);

                        switch((byte)Settings.Trigger.DetectionMethod)
                        {
                            case 0:
                                RunGlazTrigger();
                                break;
                            case 1:
                                RunPixelTrigger();
                                break;
                        }
                    }
                }


                if (Settings.Settings.bLowEnd || !Settings.Trigger.Enabled || !_isHolding)
                {
                    Thread.Sleep(1 * (int)Settings.Math.fMultiplier);
                }
                else
                {
                    Thread.Sleep(new TimeSpan(1 * (int)Settings.Math.fMultiplier));
                }
            }
        }

        public static void RunGlazTrigger()
        {
            float crosshairHue = ColorManager.RGBToHSL(_newColor).h;
            float glazHue = 0.95f;
            if (ColorManager.CloseEnoughForMe(crosshairHue, glazHue, Settings.Trigger.Tolerance / 10))
            {
                Thread.Sleep(Settings.Trigger.ShootDelay);
                if (Settings.Trigger.Continuous)
                {
                    while (GetAsyncKeyState((Keys)new KeysConverter().ConvertFromString(Settings.Trigger.Hotkey)))
                    {
                        VirtualInput.Keyboard.Down(VirtualInput.DirectInputKey.K);
                        Thread.Sleep(1);
                    }
                    VirtualInput.Keyboard.Up(VirtualInput.DirectInputKey.K);
                }
                else
                {
                    Thread.Sleep(Settings.Trigger.FireSpeed);
                    VirtualInput.Keyboard.Down(VirtualInput.DirectInputKey.K);
                    Thread.Sleep(1);
                    VirtualInput.Keyboard.Up(VirtualInput.DirectInputKey.K);
                }
            }
        }

        public static void RunPixelTrigger()
        {
            if (!ColorManager.AreColorsSimilar(_oldColor, _newColor, Settings.Trigger.Tolerance))
            {
                Thread.Sleep(Settings.Trigger.ShootDelay);
                if (Settings.Trigger.Continuous)
                {
                    while (GetAsyncKeyState((Keys)new KeysConverter().ConvertFromString(Settings.Trigger.Hotkey)))
                    {
                        VirtualInput.Keyboard.Down(VirtualInput.DirectInputKey.K);
                        Thread.Sleep(1);
                    }
                    VirtualInput.Keyboard.Up(VirtualInput.DirectInputKey.K);
                }
                else
                {
                    Thread.Sleep(Settings.Trigger.FireSpeed);
                    VirtualInput.Keyboard.Down(VirtualInput.DirectInputKey.K);
                    Thread.Sleep(1);
                    VirtualInput.Keyboard.Up(VirtualInput.DirectInputKey.K);
                }
            }
        }
    }
}
