using SimpleRecoil.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleRecoil
{
    public partial class HotkeyReader : Form
    {
        string kName;
        public HotkeyReader()
        {
            InitializeComponent();
        }

        private void HotkeyReader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
            {
                string newKey = new KeysConverter().ConvertToString(e.KeyCode);
                kName = newKey;
                KeyName = newKey;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            kName = null;
            KeyName = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string KeyName
        {
            get { return kName; }
            set { kName = value; }
        }

        private void HotkeyReader_MouseDown(object sender, MouseEventArgs e)
        {
            string unformatted = e.Button.ToString();
            switch (unformatted)
            {
                case "Left":
                case "Right":
                    kName = null;
                    KeyName = null;
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                case "Middle":
                    unformatted = "MButton";
                    break;
            }
            string newKey = new KeysConverter().ConvertToString(unformatted);
            kName = newKey;
            KeyName = newKey;
            DialogResult = DialogResult.OK;
            Close();
            return;
        }

        private void HotkeyReader_Load_1(object sender, EventArgs e)
        {
            lblKey.Accent = Color.White;
        }
    }
}
