using SimpleRecoil.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRecoil
{
    public partial class TriggerForm : Form
    {
        public TriggerForm()
        {
            Profiles.CreateProfilesDirectory();
            InitializeComponent();

            Profiles.Load("NECRUM");
            UpdateInterface();

            StartThreads();
        }

        private void StartThreads()
        {
            new Thread(new ThreadStart(Threads.HitThaQuan))
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            }.Start();
        }

        private void UpdateInterface()
        {
            grpHotkey.SubTitle = Utilities.Settings.Trigger.Hotkey;
            chkEnable.Checked = Utilities.Settings.Trigger.Enabled;
            chkContinShot.Checked = Utilities.Settings.Trigger.Continuous;
            sOffsetX.Value = Utilities.Settings.Trigger.OffsetX;
            sOffsetY.Value = Utilities.Settings.Trigger.OffsetY;
            sShootDelay.Value = Utilities.Settings.Trigger.ShootDelay;
            sTolerance.Value = (int)Utilities.Settings.Trigger.Tolerance;
            sFireSpeed.Value = Utilities.Settings.Trigger.FireSpeed;

            switch((byte)Utilities.Settings.Trigger.DetectionMethod)
            {
                case 0:
                    rdPixel.Checked = true;
                    break;
                case 1:
                    rdGlaz.Checked = true;
                    break;
            }

            lblOffsetX.Text = String.Format("X Offset: [{0}px]", Utilities.Settings.Trigger.OffsetX);
            lblOffsetY.Text = String.Format("Y Offset: [{0}px]", Utilities.Settings.Trigger.OffsetY);
            lblShootDelay.Text = String.Format("Shoot Delay: [{0}ms]", Utilities.Settings.Trigger.ShootDelay);
            lblTolerance.Text = String.Format("Tolerance: [{0}]", Math.Round(Convert.ToDouble(Utilities.Settings.Trigger.Tolerance / 10.0f), 2, MidpointRounding.AwayFromZero).ToString());
            lblFireSpeed.Text = String.Format("Fire Speed: [{0}ms]", Utilities.Settings.Trigger.FireSpeed);

            grpContinShot.SubTitle = Utilities.Settings.Trigger.Continuous ? "Hold shoot button." : "Spam shoot button.";

            Profiles.Save("NECRUM");
        }

        private void btnHotkey_Click(object sender, EventArgs e)
        {
            HotkeyReader hr = new HotkeyReader();
            if (hr.ShowDialog() == DialogResult.OK)
            {
                if (hr.KeyName == "Del") hr.KeyName = "None";
                Utilities.Settings.Trigger.Hotkey = hr.KeyName;
                Profiles.Save("NECRUM");

                UpdateInterface();
            }
        }

        public static void DoWork()
        {
            if (Utilities.Settings.Trigger.Enabled)
            {

                Threads.HitThaQuan();
            }
        }
        private void chkEnable_CheckedChanged(object sender)
        {
            Utilities.Settings.Trigger.Enabled = chkEnable.Checked;
            Thread thread1 = new Thread(DoWork);
            thread1.Start();
        }


        private void chkContinShot_CheckedChanged(object sender)
        {
            Utilities.Settings.Trigger.Continuous = chkContinShot.Checked;
            grpContinShot.SubTitle = Utilities.Settings.Trigger.Continuous ? "Hold shoot button." : "Spam shoot button.";
            Profiles.Save("NECRUM");
        }

        private void sOffsetX_Scroll(object sender)
        {
            Utilities.Settings.Trigger.OffsetX = (int)sOffsetX.Value;
            UpdateInterface();
        }

        private void sOffsetY_Scroll(object sender)
        {
            Utilities.Settings.Trigger.OffsetY = (int)sOffsetY.Value;
            UpdateInterface();
        }

        private void sShootDelay_Scroll(object sender)
        {
            Utilities.Settings.Trigger.ShootDelay = (int)sShootDelay.Value;
            UpdateInterface();
        }

        private void sTolerance_Scroll(object sender)
        {
            Utilities.Settings.Trigger.Tolerance = (int)sTolerance.Value;
            UpdateInterface();
        }

        private void sFireSpeed_Scroll(object sender)
        {
            Utilities.Settings.Trigger.FireSpeed = (int)sFireSpeed.Value;
            UpdateInterface();
        }

        private void rdGlaz_CheckedChanged(object sender)
        {
            Utilities.Settings.Trigger.DetectionMethod = Utilities.Settings.DetectionMethods.Glaz;
            Profiles.Save("NECRUM");
        }

        private void rdPixel_CheckedChanged(object sender)
        {
            Utilities.Settings.Trigger.DetectionMethod = Utilities.Settings.DetectionMethods.Pixel;
            Profiles.Save("NECRUM");
        }

        private void grpHotkey_Click(object sender, EventArgs e)
        {

        }

        private void nsTheme1_Click(object sender, EventArgs e)
        {

        }

        private void grpEnable_Click(object sender, EventArgs e)
        {

        }
    }
}
