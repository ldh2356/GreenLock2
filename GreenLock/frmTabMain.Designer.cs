namespace GreenLock
{
    partial class frmTabMain
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
            this.lblEnergy = new System.Windows.Forms.Label();
            this.lblSecurity = new System.Windows.Forms.Label();
            this.lblConfig = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblKorea = new System.Windows.Forms.Label();
            this.lblEnglish = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.BackColor = System.Drawing.Color.Transparent;
            this.lblEnergy.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEnergy.ForeColor = System.Drawing.Color.White;
            this.lblEnergy.Location = new System.Drawing.Point(725, 40);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(99, 20);
            this.lblEnergy.TabIndex = 0;
            this.lblEnergy.Text = "에너지절감량";
            this.lblEnergy.Click += new System.EventHandler(this.lblEnergy_Click);
            // 
            // lblSecurity
            // 
            this.lblSecurity.AutoSize = true;
            this.lblSecurity.BackColor = System.Drawing.Color.Transparent;
            this.lblSecurity.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecurity.ForeColor = System.Drawing.Color.White;
            this.lblSecurity.Location = new System.Drawing.Point(846, 40);
            this.lblSecurity.Name = "lblSecurity";
            this.lblSecurity.Size = new System.Drawing.Size(39, 20);
            this.lblSecurity.TabIndex = 1;
            this.lblSecurity.Text = "보안";
            this.lblSecurity.Click += new System.EventHandler(this.lblSecurity_Click);
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.BackColor = System.Drawing.Color.Transparent;
            this.lblConfig.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblConfig.ForeColor = System.Drawing.Color.White;
            this.lblConfig.Location = new System.Drawing.Point(906, 40);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(69, 20);
            this.lblConfig.TabIndex = 2;
            this.lblConfig.Text = "환경설정";
            this.lblConfig.Click += new System.EventHandler(this.lblConfig_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::GreenLock.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(990, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 34);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblKorea
            // 
            this.lblKorea.AutoSize = true;
            this.lblKorea.BackColor = System.Drawing.Color.Transparent;
            this.lblKorea.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKorea.ForeColor = System.Drawing.Color.White;
            this.lblKorea.Location = new System.Drawing.Point(860, 12);
            this.lblKorea.Name = "lblKorea";
            this.lblKorea.Size = new System.Drawing.Size(48, 20);
            this.lblKorea.TabIndex = 4;
            this.lblKorea.Text = "Korea";
            this.lblKorea.Click += new System.EventHandler(this.lblKorea_Click);
            // 
            // lblEnglish
            // 
            this.lblEnglish.AutoSize = true;
            this.lblEnglish.BackColor = System.Drawing.Color.Transparent;
            this.lblEnglish.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEnglish.ForeColor = System.Drawing.Color.White;
            this.lblEnglish.Location = new System.Drawing.Point(912, 12);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(58, 20);
            this.lblEnglish.TabIndex = 5;
            this.lblEnglish.Text = "English";
            this.lblEnglish.Click += new System.EventHandler(this.lblEnglish_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(902, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "|";
            // 
            // frmTabMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::GreenLock.Properties.Resources.mainTabbg;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblEnglish);
            this.Controls.Add(this.lblKorea);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblConfig);
            this.Controls.Add(this.lblSecurity);
            this.Controls.Add(this.lblEnergy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTabMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTabMain";
            this.Load += new System.EventHandler(this.frmTabMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.Label lblSecurity;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblKorea;
        private System.Windows.Forms.Label lblEnglish;
        private System.Windows.Forms.Label label6;
    }
}