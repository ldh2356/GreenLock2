﻿namespace GreenLock
{
    partial class FormScreenSaver2
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
            this.pb_screenSaver = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_screenSaver)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_screenSaver
            // 
            this.pb_screenSaver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_screenSaver.Image = global::GreenLock.Properties.Resources.ScreenSaver_2018_06_30;
            this.pb_screenSaver.Location = new System.Drawing.Point(0, 0);
            this.pb_screenSaver.Name = "pb_screenSaver";
            this.pb_screenSaver.Size = new System.Drawing.Size(284, 261);
            this.pb_screenSaver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_screenSaver.TabIndex = 0;
            this.pb_screenSaver.TabStop = false;
            this.pb_screenSaver.Click += new System.EventHandler(this.pb_screenSaver_Click);
            // 
            // FormScreenSaver2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.pb_screenSaver);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormScreenSaver2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ScreenSaver2";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormScreenSaver2_FormClosing);
            this.Load += new System.EventHandler(this.FormScreenSaver2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_screenSaver)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pb_screenSaver;
    }
}