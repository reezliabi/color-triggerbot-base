using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SimpleRecoil.Utilities
{
    internal class VirtualInput
    {
        public enum DirectInputKey : byte
        {
            ESCAPE = 0x01,
            ONE = 0x02,
            TWO = 0x03,
            THREE = 0x04,
            FOUR = 0x05,
            FIVE = 0x06,
            SIX = 0x07,
            SEVEN = 0x08,
            EIGHT = 0x09,
            NINE = 0x0A,
            ZERO = 0x0B,
            MINUS = 0x0C,
            EQUALS = 0x0D,
            BACK = 0x0E,
            TAB = 0x0F,
            Q = 0x10,
            W = 0x11,
            E = 0x12,
            R = 0x13,
            T = 0x14,
            Y = 0x15,
            U = 0x16,
            I = 0x17,
            O = 0x18,
            P = 0x19,
            LBRACKET = 0x1A,
            RBRACKET = 0x1B,
            RETURN = 0x1C,
            LCONTROL = 0x1D,
            A = 0x1E,
            S = 0x1F,
            D = 0x20,
            F = 0x21,
            G = 0x22,
            H = 0x23,
            J = 0x24,
            K = 0x25,
            L = 0x26,
            SEMICOLON = 0x27,
            APOSTROPHE = 0x28,
            GRAVE = 0x29,
            LSHIFT = 0x2A,
            BACKSLASH = 0x2B,
            Z = 0x2C,
            X = 0x2D,
            C = 0x2E,
            V = 0x2F,
            B = 0x30,
            N = 0x31,
            M = 0x32,
            COMMA = 0x33,
            PERIOD = 0x34,
            SLASH = 0x35,
            RSHIFT = 0x36,
            MULTIPLY = 0x37,
            LMENU = 0x38,
            SPACE = 0x39,
            CAPITAL = 0x3A,
            F1 = 0x3B,
            F2 = 0x3C,
            F3 = 0x3D,
            F4 = 0x3E,
            F5 = 0x3F,
            F6 = 0x40,
            F7 = 0x41,
            F8 = 0x42,
            F9 = 0x43,
            F10 = 0x44,
            NUMLOCK = 0x45,
            SCROLL = 0x46,
            NUMPAD7 = 0x47,
            NUMPAD8 = 0x48,
            NUMPAD9 = 0x49,
            SUBTRACT = 0x4A,
            NUMPAD4 = 0x4B,
            NUMPAD5 = 0x4C,
            NUMPAD6 = 0x4D,
            ADD = 0x4E,
            NUMPAD1 = 0x4F,
            NUMPAD2 = 0x50,
            NUMPAD3 = 0x51,
            NUMPAD0 = 0x52,
            DECIMAL = 0x53,
            F11 = 0x57,
            F12 = 0x58,
            F13 = 0x64,
            F14 = 0x65,
            F15 = 0x66,
            NUMPADEQUALS = 0x8D,
            AT = 0x91,
            COLON = 0x92,
            UNDERLINE = 0x93,
            NUMPADENTER = 0x9C,
            RCONTROL = 0x9D,
            NUMPADCOMMA = 0xB3,
            DIVIDE = 0xB5,
            SYSRQ = 0xB7,
            RMENU = 0xB8,
            PAUSE = 0xC5,
            HOME = 0xC7,
            UP = 0xC8,
            PRIOR = 0xC9,
            LEFT = 0xCB,
            RIGHT = 0xCD,
            END = 0xCF,
            DOWN = 0xD0,
            NEXT = 0xD1,
            INSERT = 0xD2,
            DELETE = 0xD3,
            LWIN = 0xDB,
            RWIN = 0xDC,
            APPS = 0xDD,
            POWER = 0xDE,
            SLEEP = 0xDF,
        }
        public enum MouseKey
        {
            LButton = 0,
            MButton = 1,
            RButton = 2,
            XButton1 = 3,
            XButton2 = 4,
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }
        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }
        private struct Input
        {
            public int type;
            public InputUnion u;
        }
        [Flags]
        private enum InputType
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }
        [Flags]
        private enum KeyEventF
        {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Unicode = 0x0004,
            Scancode = 0x0008
        }
        [Flags]
        private enum MouseEventF
        {
            Absolute = 0x8000,
            HWheel = 0x01000,
            Move = 0x0001,
            MoveNoCoalesce = 0x2000,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            VirtualDesk = 0x4000,
            Wheel = 0x0800,
            XDown = 0x0080,
            XUp = 0x0100
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);
        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        public static DirectInputKey VkToDik(Keys vK)
        {
            switch(vK)
            {
                case Keys.A: return DirectInputKey.A;
                case Keys.B: return DirectInputKey.B;
                case Keys.C: return DirectInputKey.C;
                case Keys.D: return DirectInputKey.D;
                case Keys.E: return DirectInputKey.E;
                case Keys.F: return DirectInputKey.F;
                case Keys.G: return DirectInputKey.G;
                case Keys.H: return DirectInputKey.H;
                case Keys.I: return DirectInputKey.I;
                case Keys.J: return DirectInputKey.J;
                case Keys.K: return DirectInputKey.K;
                case Keys.L: return DirectInputKey.L;
                case Keys.M: return DirectInputKey.M;
                case Keys.N: return DirectInputKey.N;
                case Keys.O: return DirectInputKey.O;
                case Keys.P: return DirectInputKey.P;
                case Keys.Q: return DirectInputKey.Q;
                case Keys.R: return DirectInputKey.R;
                case Keys.S: return DirectInputKey.S;
                case Keys.T: return DirectInputKey.T;
                case Keys.U: return DirectInputKey.U;
                case Keys.V: return DirectInputKey.V;
                case Keys.W: return DirectInputKey.W;
                case Keys.X: return DirectInputKey.X;
                case Keys.Y: return DirectInputKey.Y;
                case Keys.Z: return DirectInputKey.Z;
                case Keys.D0: return DirectInputKey.ZERO;
                case Keys.D1: return DirectInputKey.ONE;
                case Keys.D2: return DirectInputKey.TWO;
                case Keys.D3: return DirectInputKey.THREE;
                case Keys.D4: return DirectInputKey.FOUR;
                case Keys.D5: return DirectInputKey.FIVE;
                case Keys.D6: return DirectInputKey.SIX;
                case Keys.D7: return DirectInputKey.SEVEN;
                case Keys.D8: return DirectInputKey.EIGHT;
                case Keys.D9: return DirectInputKey.NINE;
                case Keys.OemMinus: return DirectInputKey.MINUS;
                case Keys.Oemplus: return DirectInputKey.EQUALS;
                case Keys.OemOpenBrackets: return DirectInputKey.LBRACKET;
                case Keys.Oem6: return DirectInputKey.RBRACKET;
                case Keys.Oemcomma: return DirectInputKey.COMMA;
                case Keys.OemPeriod: return DirectInputKey.PERIOD;
                case Keys.OemQuestion: return DirectInputKey.SLASH;
                case Keys.Oem1: return DirectInputKey.SEMICOLON;
                case Keys.Oem7: return DirectInputKey.APOSTROPHE;
                case Keys.LMenu: return DirectInputKey.LMENU;
                case Keys.RMenu: return DirectInputKey.RMENU;
                case Keys.LControlKey: return DirectInputKey.LCONTROL;
                case Keys.RControlKey: return DirectInputKey.RCONTROL;
                case Keys.LShiftKey: return DirectInputKey.LSHIFT;
                case Keys.RShiftKey: return DirectInputKey.RSHIFT;
                default: return DirectInputKey.G;
            }
        }

        internal class Mouse
        {
            public static uint Move(int x, int y)
            {
                Input[] inputs = new Input[]
                {
                    new Input
                    {
                        type = (int) InputType.Mouse,
                        u = new InputUnion
                        {
                            mi = new MouseInput
                            {
                                dx = x,
                                dy = y,
                                dwFlags = (uint)MouseEventF.Move,
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    }
                };

                return SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
            }
            public static uint Click(MouseKey mk)
            {
                MouseEventF mefd;
                MouseEventF mefu;
                switch (mk)
                {
                    case MouseKey.LButton:
                        mefd = MouseEventF.LeftDown;
                        mefu = MouseEventF.LeftUp;
                        break;
                    case MouseKey.RButton:
                        mefd = MouseEventF.RightDown;
                        mefu = MouseEventF.RightUp;
                        break;
                    case MouseKey.MButton:
                        mefd = MouseEventF.MiddleDown;
                        mefu = MouseEventF.MiddleUp;
                        break;
                    default:
                        mefd = MouseEventF.LeftDown;
                        mefu = MouseEventF.LeftUp;
                        break;
                }
                Input[] inputs = new Input[]
                {
                    new Input
                    {
                        type = (int) InputType.Mouse,
                        u = new InputUnion
                        {
                            mi = new MouseInput
                            {
                                dwFlags = (uint)mefd,
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    },
                    new Input
                    {
                        type = (int) InputType.Mouse,
                        u = new InputUnion
                        {
                            mi = new MouseInput
                            {
                                dwFlags = (uint)mefu,
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    }
                };
                return SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
            }
            public static uint Down(MouseKey mk)
            {
                MouseEventF mefd;
                switch (mk)
                {
                    case MouseKey.LButton:
                        mefd = MouseEventF.LeftDown;
                        break;
                    case MouseKey.RButton:
                        mefd = MouseEventF.RightDown;
                        break;
                    case MouseKey.MButton:
                        mefd = MouseEventF.MiddleDown;
                        break;
                    default:
                        mefd = MouseEventF.LeftDown;
                        break;
                }
                Input[] inputs = new Input[]
                {
                    new Input
                    {
                        type = (int) InputType.Mouse,
                        u = new InputUnion
                        {
                            mi = new MouseInput
                            {
                                dwFlags = (uint)mefd,
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    }
                };
                return SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
            }
            public static uint Up(MouseKey mk)
            {
                MouseEventF mefu;
                switch (mk)
                {
                    case MouseKey.LButton:
                        mefu = MouseEventF.LeftUp;
                        break;
                    case MouseKey.RButton:
                        mefu = MouseEventF.RightUp;
                        break;
                    case MouseKey.MButton:
                        mefu = MouseEventF.MiddleUp;
                        break;
                    default:
                        mefu = MouseEventF.LeftUp;
                        break;
                }
                Input[] inputs = new Input[]
                {
                    new Input
                    {
                        type = (int) InputType.Mouse,
                        u = new InputUnion
                        {
                            mi = new MouseInput
                            {
                                dwFlags = (uint)mefu,
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    }
                };
                return SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
            }
        }

        internal class Keyboard
        {
            public static uint Press(DirectInputKey dik)
            {
                Input[] inputs = new Input[]
                {
                    new Input
                    {
                        type = (int)InputType.Keyboard,
                        u = new InputUnion
                        {
                            ki = new KeyboardInput
                            {
                                wVk = 0,
                                wScan = (byte)dik,
                                dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    },
                    new Input
                    {
                        type = (int)InputType.Keyboard,
                        u = new InputUnion
                        {
                            ki = new KeyboardInput
                            {
                                wVk = 0,
                                wScan = (byte)dik,
                                dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    }
                };

                return SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
            }
            public static uint Down(DirectInputKey dik)
            {
                Input[] inputs = new Input[]
                {
                    new Input
                    {
                        type = (int)InputType.Keyboard,
                        u = new InputUnion
                        {
                            ki = new KeyboardInput
                            {
                                wVk = 0,
                                wScan = (byte)dik,
                                dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    }
                };

                return SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
            }
            public static uint Up(DirectInputKey dik)
            {
                Input[] inputs = new Input[]
                {
                    new Input
                    {
                        type = (int)InputType.Keyboard,
                        u = new InputUnion
                        {
                            ki = new KeyboardInput
                            {
                                wVk = 0,
                                wScan = (byte)dik,
                                dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    }
                };

                return SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
            }
        }
    }
}
