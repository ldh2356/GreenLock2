namespace GreenLock
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblCoypright = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblKorea = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.lblEnglish = new System.Windows.Forms.Label();
            this.lblSeperator = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.uc_MainConfig = new GreenLock.UC_Controls.Uc_MainConfig();
            this.uc_MainEnergy = new GreenLock.UC_Controls.Uc_MainEnergy();
            this.uc_MainSecurity = new GreenLock.UC_Controls.Uc_MainSecurity();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCoypright
            // 
            resources.ApplyResources(this.lblCoypright, "lblCoypright");
            this.lblCoypright.BackColor = System.Drawing.Color.Transparent;
            this.lblCoypright.ForeColor = System.Drawing.Color.White;
            this.lblCoypright.Name = "lblCoypright";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Name = "lblDate";
            // 
            // lblKorea
            // 
            resources.ApplyResources(this.lblKorea, "lblKorea");
            this.lblKorea.BackColor = System.Drawing.Color.Transparent;
            this.lblKorea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKorea.ForeColor = System.Drawing.Color.White;
            this.lblKorea.Name = "lblKorea";
            this.lblKorea.Click += new System.EventHandler(this.lblKorea_Click);
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.BackgroundImage = global::GreenLock.Properties.Resources.close;
            resources.ApplyResources(this.pbClose, "pbClose");
            this.pbClose.Name = "pbClose";
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // lblEnglish
            // 
            resources.ApplyResources(this.lblEnglish, "lblEnglish");
            this.lblEnglish.BackColor = System.Drawing.Color.Transparent;
            this.lblEnglish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEnglish.ForeColor = System.Drawing.Color.White;
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Click += new System.EventHandler(this.lblEnglish_Click);
            // 
            // lblSeperator
            // 
            resources.ApplyResources(this.lblSeperator, "lblSeperator");
            this.lblSeperator.BackColor = System.Drawing.Color.Transparent;
            this.lblSeperator.ForeColor = System.Drawing.Color.White;
            this.lblSeperator.Name = "lblSeperator";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.BackgroundImage = global::GreenLock.Properties.Resources.KakaoTalk_20180709_130351591;
            this.pnlMain.Controls.Add(this.lblSeperator);
            this.pnlMain.Controls.Add(this.lblEnglish);
            this.pnlMain.Controls.Add(this.pbClose);
            this.pnlMain.Controls.Add(this.lblKorea);
            this.pnlMain.Controls.Add(this.lblDate);
            this.pnlMain.Controls.Add(this.lblCoypright);
            this.pnlMain.Controls.Add(this.uc_MainConfig);
            this.pnlMain.Controls.Add(this.uc_MainEnergy);
            this.pnlMain.Controls.Add(this.uc_MainSecurity);
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseMove);
            // 
            // uc_MainConfig
            // 
            this.uc_MainConfig.BackColor = System.Drawing.Color.Transparent;
            this.uc_MainConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uc_MainConfig, "uc_MainConfig");
            this.uc_MainConfig.Name = "uc_MainConfig";
            this.uc_MainConfig.Click += new System.EventHandler(this.uc_MainConfig_Click);
            // 
            // uc_MainEnergy
            // 
            this.uc_MainEnergy.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uc_MainEnergy, "uc_MainEnergy");
            this.uc_MainEnergy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uc_MainEnergy.Name = "uc_MainEnergy";
            this.uc_MainEnergy.Click += new System.EventHandler(this.uc_MainEnergy_Click);
            // 
            // uc_MainSecurity
            // 
            this.uc_MainSecurity.BackColor = System.Drawing.Color.Transparent;
            this.uc_MainSecurity.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uc_MainSecurity, "uc_MainSecurity");
            this.uc_MainSecurity.Name = "uc_MainSecurity";
            this.uc_MainSecurity.Click += new System.EventHandler(this.uc_MainSecurity_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImage = global::GreenLock.Properties.Resources.KakaoTalk_20180709_130351591;
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UC_Controls.Uc_MainSecurity uc_MainSecurity;
        private UC_Controls.Uc_MainEnergy uc_MainEnergy;
        private UC_Controls.Uc_MainConfig uc_MainConfig;


        private System.Windows.Forms.Label lblCoypright;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblKorea;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Label lblEnglish;
        private System.Windows.Forms.Label lblSeperator;
        private System.Windows.Forms.Panel pnlMain;
    }
}

