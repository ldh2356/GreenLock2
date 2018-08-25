namespace GreenLock.UC_Controls
{
    partial class Uc_TabMain
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.lblEnglish = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.lblKorea = new System.Windows.Forms.Label();
            this.lblEnegry = new System.Windows.Forms.Label();
            this.lblSecurity = new System.Windows.Forms.Label();
            this.lblConfig = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHome = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(904, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "|";
            // 
            // lblEnglish
            // 
            this.lblEnglish.BackColor = System.Drawing.Color.Transparent;
            this.lblEnglish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEnglish.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblEnglish.ForeColor = System.Drawing.Color.White;
            this.lblEnglish.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEnglish.Location = new System.Drawing.Point(913, 16);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(58, 20);
            this.lblEnglish.TabIndex = 13;
            this.lblEnglish.Text = "English";
            this.lblEnglish.Click += new System.EventHandler(this.lblEnglish_Click);
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.BackgroundImage = global::GreenLock.Properties.Resources.close;
            this.pbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbClose.Location = new System.Drawing.Point(990, 0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(34, 34);
            this.pbClose.TabIndex = 12;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // lblKorea
            // 
            this.lblKorea.BackColor = System.Drawing.Color.Transparent;
            this.lblKorea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKorea.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKorea.ForeColor = System.Drawing.Color.White;
            this.lblKorea.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblKorea.Location = new System.Drawing.Point(845, 16);
            this.lblKorea.Name = "lblKorea";
            this.lblKorea.Size = new System.Drawing.Size(62, 24);
            this.lblKorea.TabIndex = 11;
            this.lblKorea.Text = "Korean ";
            this.lblKorea.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblKorea.Click += new System.EventHandler(this.lblKorea_Click);
            // 
            // lblEnegry
            // 
            this.lblEnegry.AutoSize = true;
            this.lblEnegry.BackColor = System.Drawing.Color.Transparent;
            this.lblEnegry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEnegry.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEnegry.ForeColor = System.Drawing.Color.White;
            this.lblEnegry.Location = new System.Drawing.Point(483, 0);
            this.lblEnegry.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblEnegry.Name = "lblEnegry";
            this.lblEnegry.Size = new System.Drawing.Size(118, 23);
            this.lblEnegry.TabIndex = 15;
            this.lblEnegry.Text = "에너지 절감량";
            this.lblEnegry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEnegry.Click += new System.EventHandler(this.lblEnegry_Click);
            // 
            // lblSecurity
            // 
            this.lblSecurity.AutoSize = true;
            this.lblSecurity.BackColor = System.Drawing.Color.Transparent;
            this.lblSecurity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSecurity.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecurity.ForeColor = System.Drawing.Color.White;
            this.lblSecurity.Location = new System.Drawing.Point(614, 0);
            this.lblSecurity.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblSecurity.Name = "lblSecurity";
            this.lblSecurity.Size = new System.Drawing.Size(44, 23);
            this.lblSecurity.TabIndex = 16;
            this.lblSecurity.Text = "보안";
            this.lblSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSecurity.Click += new System.EventHandler(this.lblSecurity_Click);
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.BackColor = System.Drawing.Color.Transparent;
            this.lblConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblConfig.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblConfig.ForeColor = System.Drawing.Color.White;
            this.lblConfig.Location = new System.Drawing.Point(671, 0);
            this.lblConfig.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(78, 23);
            this.lblConfig.TabIndex = 17;
            this.lblConfig.Text = "환경설정";
            this.lblConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblConfig.Click += new System.EventHandler(this.lblConfig_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlMain.Location = new System.Drawing.Point(16, 80);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(992, 672);
            this.pnlMain.TabIndex = 24;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.lblConfig);
            this.flowLayoutPanel1.Controls.Add(this.lblSecurity);
            this.flowLayoutPanel1.Controls.Add(this.lblEnegry);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(224, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(752, 37);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.Color.Transparent;
            this.pnlHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlHome.Location = new System.Drawing.Point(16, 24);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(200, 40);
            this.pnlHome.TabIndex = 26;
            this.pnlHome.Click += new System.EventHandler(this.pnlHome_Click);
            // 
            // Uc_TabMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Lavender;
            this.BackgroundImage = global::GreenLock.Properties.Resources.mainTabbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlHome);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEnglish);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.lblKorea);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Uc_TabMain";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.Uc_TabMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Uc_TabMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Uc_TabMain_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEnglish;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Label lblKorea;
        private System.Windows.Forms.Label lblEnegry;
        private System.Windows.Forms.Label lblSecurity;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlHome;
    }
}
