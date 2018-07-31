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
            this.label2 = new System.Windows.Forms.Label();
            this.uc_MainConfig = new GreenLock.UC_Controls.Uc_MainConfig();
            this.uc_MainEnergy = new GreenLock.UC_Controls.Uc_MainEnergy();
            this.uc_MainSecurity = new GreenLock.UC_Controls.Uc_MainSecurity();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
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
            this.lblEnglish.ForeColor = System.Drawing.Color.White;
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Click += new System.EventHandler(this.lblEnglish_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // uc_MainConfig
            // 
            this.uc_MainConfig.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uc_MainConfig, "uc_MainConfig");
            this.uc_MainConfig.Name = "uc_MainConfig";
            this.uc_MainConfig.Click += new System.EventHandler(this.uc_MainConfig_Click);
            // 
            // uc_MainEnergy
            // 
            this.uc_MainEnergy.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uc_MainEnergy, "uc_MainEnergy");
            this.uc_MainEnergy.Name = "uc_MainEnergy";
            this.uc_MainEnergy.Click += new System.EventHandler(this.uc_MainEnergy_Click);
            // 
            // uc_MainSecurity
            // 
            this.uc_MainSecurity.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uc_MainSecurity, "uc_MainSecurity");
            this.uc_MainSecurity.Name = "uc_MainSecurity";
            this.uc_MainSecurity.Click += new System.EventHandler(this.uc_MainSecurity_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::GreenLock.Properties.Resources.KakaoTalk_20180709_130351591;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEnglish);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.lblKorea);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCoypright);
            this.Controls.Add(this.uc_MainConfig);
            this.Controls.Add(this.uc_MainEnergy);
            this.Controls.Add(this.uc_MainSecurity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label2;
       
    }
}

