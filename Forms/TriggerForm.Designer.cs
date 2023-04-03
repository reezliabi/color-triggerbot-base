namespace SimpleRecoil
{
    partial class TriggerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriggerForm));
            this.nsTheme1 = new NSTheme();
            this.nsControlButton2 = new NSControlButton();
            this.nsControlButton1 = new NSControlButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdPixel = new NSRadioButton();
            this.rdGlaz = new NSRadioButton();
            this.grpContinShot = new NSGroupBox();
            this.chkContinShot = new NSOnOffBox();
            this.grpEnable = new NSGroupBox();
            this.chkEnable = new NSOnOffBox();
            this.lblOffsetX = new AALabel();
            this.grpHotkey = new NSGroupBox();
            this.btnHotkey = new NSButton();
            this.sFireSpeed = new NSTrackBar();
            this.sTolerance = new NSTrackBar();
            this.lblOffsetY = new AALabel();
            this.sShootDelay = new NSTrackBar();
            this.lblShootDelay = new AALabel();
            this.lblDetect = new AALabel();
            this.lblFireSpeed = new AALabel();
            this.sOffsetY = new NSTrackBar();
            this.lblTolerance = new AALabel();
            this.sOffsetX = new NSTrackBar();
            this.nsTheme1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpContinShot.SuspendLayout();
            this.grpEnable.SuspendLayout();
            this.grpHotkey.SuspendLayout();
            this.SuspendLayout();
            // 
            // nsTheme1
            // 
            this.nsTheme1.AccentOffset = 0;
            this.nsTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nsTheme1.Controls.Add(this.nsControlButton2);
            this.nsTheme1.Controls.Add(this.nsControlButton1);
            this.nsTheme1.Controls.Add(this.panel1);
            this.nsTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsTheme1.Location = new System.Drawing.Point(0, 0);
            this.nsTheme1.Name = "nsTheme1";
            this.nsTheme1.Size = new System.Drawing.Size(366, 458);
            this.nsTheme1.TabIndex = 0;
            this.nsTheme1.Text = "NECRUM.WIN COLOR TRIGGERBOT BASE";
            this.nsTheme1.Click += new System.EventHandler(this.nsTheme1_Click);
            // 
            // nsControlButton2
            // 
            this.nsControlButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsControlButton2.ControlButton = NSControlButton.Button.Minimize;
            this.nsControlButton2.Location = new System.Drawing.Point(324, 3);
            this.nsControlButton2.Margin = new System.Windows.Forms.Padding(0);
            this.nsControlButton2.MaximumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton2.MinimumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton2.Name = "nsControlButton2";
            this.nsControlButton2.Size = new System.Drawing.Size(18, 20);
            this.nsControlButton2.TabIndex = 30;
            this.nsControlButton2.Text = "nsControlButton2";
            // 
            // nsControlButton1
            // 
            this.nsControlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsControlButton1.ControlButton = NSControlButton.Button.Close;
            this.nsControlButton1.Location = new System.Drawing.Point(342, 3);
            this.nsControlButton1.Margin = new System.Windows.Forms.Padding(0);
            this.nsControlButton1.MaximumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.MinimumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.Name = "nsControlButton1";
            this.nsControlButton1.Size = new System.Drawing.Size(18, 20);
            this.nsControlButton1.TabIndex = 29;
            this.nsControlButton1.Text = "nsControlButton1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rdPixel);
            this.panel1.Controls.Add(this.rdGlaz);
            this.panel1.Controls.Add(this.grpContinShot);
            this.panel1.Controls.Add(this.grpEnable);
            this.panel1.Controls.Add(this.lblOffsetX);
            this.panel1.Controls.Add(this.grpHotkey);
            this.panel1.Controls.Add(this.sFireSpeed);
            this.panel1.Controls.Add(this.sTolerance);
            this.panel1.Controls.Add(this.lblOffsetY);
            this.panel1.Controls.Add(this.sShootDelay);
            this.panel1.Controls.Add(this.lblShootDelay);
            this.panel1.Controls.Add(this.lblDetect);
            this.panel1.Controls.Add(this.lblFireSpeed);
            this.panel1.Controls.Add(this.sOffsetY);
            this.panel1.Controls.Add(this.lblTolerance);
            this.panel1.Controls.Add(this.sOffsetX);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 401);
            this.panel1.TabIndex = 31;
            // 
            // rdPixel
            // 
            this.rdPixel.Checked = false;
            this.rdPixel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPixel.Location = new System.Drawing.Point(89, 285);
            this.rdPixel.Name = "rdPixel";
            this.rdPixel.Size = new System.Drawing.Size(73, 20);
            this.rdPixel.TabIndex = 29;
            this.rdPixel.Text = "Pixel";
            this.rdPixel.CheckedChanged += new NSRadioButton.CheckedChangedEventHandler(this.rdPixel_CheckedChanged);
            // 
            // rdGlaz
            // 
            this.rdGlaz.Checked = false;
            this.rdGlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdGlaz.Location = new System.Drawing.Point(10, 285);
            this.rdGlaz.Name = "rdGlaz";
            this.rdGlaz.Size = new System.Drawing.Size(73, 20);
            this.rdGlaz.TabIndex = 29;
            this.rdGlaz.Text = "Glaz";
            this.rdGlaz.CheckedChanged += new NSRadioButton.CheckedChangedEventHandler(this.rdGlaz_CheckedChanged);
            // 
            // grpContinShot
            // 
            this.grpContinShot.Accent = System.Drawing.Color.MediumOrchid;
            this.grpContinShot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpContinShot.Controls.Add(this.chkContinShot);
            this.grpContinShot.DrawSeperator = false;
            this.grpContinShot.Location = new System.Drawing.Point(0, 359);
            this.grpContinShot.Name = "grpContinShot";
            this.grpContinShot.Size = new System.Drawing.Size(342, 40);
            this.grpContinShot.SubTitle = "Hold shoot or spam fire.";
            this.grpContinShot.SubTitleFont = new System.Drawing.Font("Verdana", 6.5F);
            this.grpContinShot.TabIndex = 25;
            this.grpContinShot.Text = "nsGroupBox2";
            this.grpContinShot.Title = "Continuous Shot";
            this.grpContinShot.TitleFont = new System.Drawing.Font("Verdana", 10F);
            // 
            // chkContinShot
            // 
            this.chkContinShot.Accent = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(194)))), ((int)(((byte)(56)))));
            this.chkContinShot.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkContinShot.Checked = false;
            this.chkContinShot.Location = new System.Drawing.Point(278, 8);
            this.chkContinShot.MaximumSize = new System.Drawing.Size(56, 24);
            this.chkContinShot.MinimumSize = new System.Drawing.Size(56, 24);
            this.chkContinShot.Name = "chkContinShot";
            this.chkContinShot.Size = new System.Drawing.Size(56, 24);
            this.chkContinShot.TabIndex = 0;
            this.chkContinShot.Text = "nsOnOffBox1";
            this.chkContinShot.CheckedChanged += new NSOnOffBox.CheckedChangedEventHandler(this.chkContinShot_CheckedChanged);
            // 
            // grpEnable
            // 
            this.grpEnable.Accent = System.Drawing.Color.MediumOrchid;
            this.grpEnable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEnable.Controls.Add(this.chkEnable);
            this.grpEnable.DrawSeperator = false;
            this.grpEnable.Location = new System.Drawing.Point(0, 2);
            this.grpEnable.Name = "grpEnable";
            this.grpEnable.Size = new System.Drawing.Size(342, 40);
            this.grpEnable.SubTitle = "Toggle Triggerbot on/off";
            this.grpEnable.SubTitleFont = new System.Drawing.Font("Verdana", 6.5F);
            this.grpEnable.TabIndex = 25;
            this.grpEnable.Text = "nsGroupBox2";
            this.grpEnable.Title = "Enabled";
            this.grpEnable.TitleFont = new System.Drawing.Font("Verdana", 10F);
            this.grpEnable.Click += new System.EventHandler(this.grpEnable_Click);
            // 
            // chkEnable
            // 
            this.chkEnable.Accent = System.Drawing.Color.MediumOrchid;
            this.chkEnable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkEnable.Checked = false;
            this.chkEnable.Location = new System.Drawing.Point(278, 8);
            this.chkEnable.MaximumSize = new System.Drawing.Size(56, 24);
            this.chkEnable.MinimumSize = new System.Drawing.Size(56, 24);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(56, 24);
            this.chkEnable.TabIndex = 0;
            this.chkEnable.Text = "nsOnOffBox1";
            this.chkEnable.CheckedChanged += new NSOnOffBox.CheckedChangedEventHandler(this.chkEnable_CheckedChanged);
            // 
            // lblOffsetX
            // 
            this.lblOffsetX.ForeColor = System.Drawing.Color.White;
            this.lblOffsetX.Location = new System.Drawing.Point(7, 59);
            this.lblOffsetX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffsetX.Name = "lblOffsetX";
            this.lblOffsetX.Size = new System.Drawing.Size(88, 13);
            this.lblOffsetX.TabIndex = 27;
            this.lblOffsetX.Text = "X Offset [0]";
            // 
            // grpHotkey
            // 
            this.grpHotkey.Accent = System.Drawing.Color.MediumOrchid;
            this.grpHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHotkey.Controls.Add(this.btnHotkey);
            this.grpHotkey.DrawSeperator = false;
            this.grpHotkey.Location = new System.Drawing.Point(0, 313);
            this.grpHotkey.Name = "grpHotkey";
            this.grpHotkey.Size = new System.Drawing.Size(342, 40);
            this.grpHotkey.SubTitle = "Fire Key";
            this.grpHotkey.SubTitleFont = new System.Drawing.Font("Verdana", 6.5F);
            this.grpHotkey.TabIndex = 26;
            this.grpHotkey.Text = "nsGroupBox7";
            this.grpHotkey.Title = "Activation Key";
            this.grpHotkey.TitleFont = new System.Drawing.Font("Verdana", 10F);
            this.grpHotkey.Click += new System.EventHandler(this.grpHotkey_Click);
            // 
            // btnHotkey
            // 
            this.btnHotkey.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHotkey.ForeColor = System.Drawing.Color.White;
            this.btnHotkey.Location = new System.Drawing.Point(252, 8);
            this.btnHotkey.Name = "btnHotkey";
            this.btnHotkey.Size = new System.Drawing.Size(82, 24);
            this.btnHotkey.TabIndex = 17;
            this.btnHotkey.Text = "Change";
            this.btnHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHotkey.Click += new System.EventHandler(this.btnHotkey_Click);
            // 
            // sFireSpeed
            // 
            this.sFireSpeed.Accent = System.Drawing.Color.MediumOrchid;
            this.sFireSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sFireSpeed.Location = new System.Drawing.Point(10, 243);
            this.sFireSpeed.Maximum = 120;
            this.sFireSpeed.Minimum = 0;
            this.sFireSpeed.Name = "sFireSpeed";
            this.sFireSpeed.Size = new System.Drawing.Size(322, 23);
            this.sFireSpeed.TabIndex = 28;
            this.sFireSpeed.Text = "nsTrackBar1";
            this.sFireSpeed.Value = 0;
            this.sFireSpeed.Scroll += new NSTrackBar.ScrollEventHandler(this.sFireSpeed_Scroll);
            // 
            // sTolerance
            // 
            this.sTolerance.Accent = System.Drawing.Color.MediumOrchid;
            this.sTolerance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sTolerance.Location = new System.Drawing.Point(10, 201);
            this.sTolerance.Maximum = 50;
            this.sTolerance.Minimum = 0;
            this.sTolerance.Name = "sTolerance";
            this.sTolerance.Size = new System.Drawing.Size(322, 23);
            this.sTolerance.TabIndex = 28;
            this.sTolerance.Text = "nsTrackBar1";
            this.sTolerance.Value = 0;
            this.sTolerance.Scroll += new NSTrackBar.ScrollEventHandler(this.sTolerance_Scroll);
            // 
            // lblOffsetY
            // 
            this.lblOffsetY.ForeColor = System.Drawing.Color.White;
            this.lblOffsetY.Location = new System.Drawing.Point(7, 101);
            this.lblOffsetY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffsetY.Name = "lblOffsetY";
            this.lblOffsetY.Size = new System.Drawing.Size(88, 13);
            this.lblOffsetY.TabIndex = 27;
            this.lblOffsetY.Text = "Y Offset [0]";
            // 
            // sShootDelay
            // 
            this.sShootDelay.Accent = System.Drawing.Color.MediumOrchid;
            this.sShootDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sShootDelay.Location = new System.Drawing.Point(10, 159);
            this.sShootDelay.Maximum = 500;
            this.sShootDelay.Minimum = 0;
            this.sShootDelay.Name = "sShootDelay";
            this.sShootDelay.Size = new System.Drawing.Size(322, 23);
            this.sShootDelay.TabIndex = 28;
            this.sShootDelay.Text = "nsTrackBar1";
            this.sShootDelay.Value = 0;
            this.sShootDelay.Scroll += new NSTrackBar.ScrollEventHandler(this.sShootDelay_Scroll);
            // 
            // lblShootDelay
            // 
            this.lblShootDelay.ForeColor = System.Drawing.Color.White;
            this.lblShootDelay.Location = new System.Drawing.Point(7, 143);
            this.lblShootDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShootDelay.Name = "lblShootDelay";
            this.lblShootDelay.Size = new System.Drawing.Size(133, 13);
            this.lblShootDelay.TabIndex = 27;
            this.lblShootDelay.Text = "Shoot Delay [0]";
            // 
            // lblDetect
            // 
            this.lblDetect.ForeColor = System.Drawing.Color.White;
            this.lblDetect.Location = new System.Drawing.Point(7, 269);
            this.lblDetect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetect.Name = "lblDetect";
            this.lblDetect.Size = new System.Drawing.Size(133, 13);
            this.lblDetect.TabIndex = 27;
            this.lblDetect.Text = "Detection Method:";
            // 
            // lblFireSpeed
            // 
            this.lblFireSpeed.ForeColor = System.Drawing.Color.White;
            this.lblFireSpeed.Location = new System.Drawing.Point(7, 227);
            this.lblFireSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFireSpeed.Name = "lblFireSpeed";
            this.lblFireSpeed.Size = new System.Drawing.Size(133, 13);
            this.lblFireSpeed.TabIndex = 27;
            this.lblFireSpeed.Text = "Fire Speed [0]";
            // 
            // sOffsetY
            // 
            this.sOffsetY.Accent = System.Drawing.Color.MediumOrchid;
            this.sOffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sOffsetY.Location = new System.Drawing.Point(10, 117);
            this.sOffsetY.Maximum = 15;
            this.sOffsetY.Minimum = 0;
            this.sOffsetY.Name = "sOffsetY";
            this.sOffsetY.Size = new System.Drawing.Size(322, 23);
            this.sOffsetY.TabIndex = 28;
            this.sOffsetY.Text = "nsTrackBar1";
            this.sOffsetY.Value = 0;
            this.sOffsetY.Scroll += new NSTrackBar.ScrollEventHandler(this.sOffsetY_Scroll);
            // 
            // lblTolerance
            // 
            this.lblTolerance.ForeColor = System.Drawing.Color.White;
            this.lblTolerance.Location = new System.Drawing.Point(7, 185);
            this.lblTolerance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTolerance.Name = "lblTolerance";
            this.lblTolerance.Size = new System.Drawing.Size(133, 13);
            this.lblTolerance.TabIndex = 27;
            this.lblTolerance.Text = "Tolerance Level [0]";
            // 
            // sOffsetX
            // 
            this.sOffsetX.Accent = System.Drawing.Color.MediumOrchid;
            this.sOffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sOffsetX.Location = new System.Drawing.Point(10, 75);
            this.sOffsetX.Maximum = 15;
            this.sOffsetX.Minimum = 0;
            this.sOffsetX.Name = "sOffsetX";
            this.sOffsetX.Size = new System.Drawing.Size(322, 23);
            this.sOffsetX.TabIndex = 28;
            this.sOffsetX.Text = "nsTrackBar1";
            this.sOffsetX.Value = 0;
            this.sOffsetX.Scroll += new NSTrackBar.ScrollEventHandler(this.sOffsetX_Scroll);
            // 
            // TriggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 458);
            this.Controls.Add(this.nsTheme1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TriggerForm";
            this.Text = "NECRUM";
            this.nsTheme1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grpContinShot.ResumeLayout(false);
            this.grpEnable.ResumeLayout(false);
            this.grpHotkey.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme nsTheme1;
        private NSGroupBox grpEnable;
        private NSOnOffBox chkEnable;
        private NSGroupBox grpHotkey;
        private NSButton btnHotkey;
        public NSTrackBar sOffsetY;
        public NSTrackBar sOffsetX;
        private AALabel lblOffsetY;
        private AALabel lblOffsetX;
        public NSTrackBar sShootDelay;
        private AALabel lblShootDelay;
        private NSControlButton nsControlButton2;
        private NSControlButton nsControlButton1;
        public NSTrackBar sTolerance;
        private AALabel lblTolerance;
        private System.Windows.Forms.Panel panel1;
        private NSGroupBox grpContinShot;
        private NSOnOffBox chkContinShot;
        public NSTrackBar sFireSpeed;
        private AALabel lblFireSpeed;
        private NSRadioButton rdGlaz;
        private NSRadioButton rdPixel;
        private AALabel lblDetect;
    }
}