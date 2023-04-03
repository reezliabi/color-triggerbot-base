namespace SimpleRecoil
{
    partial class HotkeyReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeyReader));
            this.lblKey = new NSLabel();
            this.SuspendLayout();
            // 
            // lblKey
            // 
            this.lblKey.Accent = System.Drawing.Color.MediumOrchid;
            this.lblKey.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblKey.Location = new System.Drawing.Point(95, 19);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(99, 23);
            this.lblKey.TabIndex = 1;
            this.lblKey.Text = "nsLabel1";
            this.lblKey.Value1 = "PRESS A";
            this.lblKey.Value2 = " KEY";
            this.lblKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HotkeyReader_MouseDown);
            // 
            // HotkeyReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(293, 64);
            this.Controls.Add(this.lblKey);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeyReader";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bind Hotkey";
            this.Load += new System.EventHandler(this.HotkeyReader_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyReader_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HotkeyReader_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
        private NSLabel lblKey;
    }
}