namespace GreenLock.UC_Controls
{
    partial class Uc_MainSecurity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_MainSecurity));
            this.lblTilte = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTilte
            // 
            resources.ApplyResources(this.lblTilte, "lblTilte");
            this.lblTilte.BackColor = System.Drawing.Color.Transparent;
            this.lblTilte.ForeColor = System.Drawing.Color.White;
            this.lblTilte.Name = "lblTilte";
            this.lblTilte.TextChanged += new System.EventHandler(this.lblTilte_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GreenLock.Properties.Resources.icon_main02;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Uc_MainSecurity
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblTilte);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Uc_MainSecurity";
            this.Load += new System.EventHandler(this.Uc_MainSecurity_Load);
            this.MouseLeave += new System.EventHandler(this.Uc_MainSecurity_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Uc_MainSecurity_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTilte;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
