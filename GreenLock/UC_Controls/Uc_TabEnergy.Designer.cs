namespace GreenLock.UC_Controls
{
    partial class Uc_TabEnergy
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEnergyAmt = new System.Windows.Forms.Label();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCostAmt = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCo2Amt = new System.Windows.Forms.Label();
            this.lblCo2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTreeAmt = new System.Windows.Forms.Label();
            this.lblTree = new System.Windows.Forms.Label();
            this.lblCoypright = new System.Windows.Forms.Label();
            this.customLabel1 = new GreenLock.CustomLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::GreenLock.Properties.Resources.btn_print;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(896, 32);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::GreenLock.Properties.Resources.btn_save;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(864, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 32);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblEnergyAmt);
            this.panel1.Controls.Add(this.lblEnergy);
            this.panel1.Location = new System.Drawing.Point(40, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 192);
            this.panel1.TabIndex = 30;
            // 
            // lblEnergyAmt
            // 
            this.lblEnergyAmt.AutoSize = true;
            this.lblEnergyAmt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEnergyAmt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblEnergyAmt.Location = new System.Drawing.Point(64, 112);
            this.lblEnergyAmt.Name = "lblEnergyAmt";
            this.lblEnergyAmt.Size = new System.Drawing.Size(86, 45);
            this.lblEnergyAmt.TabIndex = 1;
            this.lblEnergyAmt.Text = "2.90";
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEnergy.Location = new System.Drawing.Point(32, 24);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(137, 20);
            this.lblEnergy.TabIndex = 0;
            this.lblEnergy.Text = "에너지절감량(kwh)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblCostAmt);
            this.panel2.Controls.Add(this.lblCost);
            this.panel2.Location = new System.Drawing.Point(256, 400);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 192);
            this.panel2.TabIndex = 31;
            // 
            // lblCostAmt
            // 
            this.lblCostAmt.AutoSize = true;
            this.lblCostAmt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCostAmt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCostAmt.Location = new System.Drawing.Point(64, 112);
            this.lblCostAmt.Name = "lblCostAmt";
            this.lblCostAmt.Size = new System.Drawing.Size(124, 45);
            this.lblCostAmt.TabIndex = 2;
            this.lblCostAmt.Text = "530.81";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCost.Location = new System.Drawing.Point(48, 24);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(124, 20);
            this.lblCost.TabIndex = 1;
            this.lblCost.Text = "전기료절감액(원)";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCo2Amt);
            this.panel3.Controls.Add(this.lblCo2);
            this.panel3.Location = new System.Drawing.Point(496, 400);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(208, 192);
            this.panel3.TabIndex = 31;
            // 
            // lblCo2Amt
            // 
            this.lblCo2Amt.AutoSize = true;
            this.lblCo2Amt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCo2Amt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCo2Amt.Location = new System.Drawing.Point(64, 112);
            this.lblCo2Amt.Name = "lblCo2Amt";
            this.lblCo2Amt.Size = new System.Drawing.Size(86, 45);
            this.lblCo2Amt.TabIndex = 3;
            this.lblCo2Amt.Text = "1.23";
            // 
            // lblCo2
            // 
            this.lblCo2.AutoSize = true;
            this.lblCo2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCo2.Location = new System.Drawing.Point(64, 24);
            this.lblCo2.Name = "lblCo2";
            this.lblCo2.Size = new System.Drawing.Size(90, 20);
            this.lblCo2.TabIndex = 2;
            this.lblCo2.Text = "C02절감(톤)";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblTreeAmt);
            this.panel4.Controls.Add(this.lblTree);
            this.panel4.Location = new System.Drawing.Point(730, 400);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(208, 192);
            this.panel4.TabIndex = 32;
            // 
            // lblTreeAmt
            // 
            this.lblTreeAmt.AutoSize = true;
            this.lblTreeAmt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTreeAmt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTreeAmt.Location = new System.Drawing.Point(72, 112);
            this.lblTreeAmt.Name = "lblTreeAmt";
            this.lblTreeAmt.Size = new System.Drawing.Size(86, 45);
            this.lblTreeAmt.TabIndex = 4;
            this.lblTreeAmt.Text = "0.43";
            // 
            // lblTree
            // 
            this.lblTree.AutoSize = true;
            this.lblTree.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTree.Location = new System.Drawing.Point(48, 24);
            this.lblTree.Name = "lblTree";
            this.lblTree.Size = new System.Drawing.Size(109, 20);
            this.lblTree.TabIndex = 3;
            this.lblTree.Text = "환경보호(그루)";
            // 
            // lblCoypright
            // 
            this.lblCoypright.AutoSize = true;
            this.lblCoypright.BackColor = System.Drawing.Color.Transparent;
            this.lblCoypright.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.lblCoypright.ForeColor = System.Drawing.Color.Black;
            this.lblCoypright.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCoypright.Location = new System.Drawing.Point(344, 32);
            this.lblCoypright.Name = "lblCoypright";
            this.lblCoypright.Size = new System.Drawing.Size(263, 22);
            this.lblCoypright.TabIndex = 33;
            this.lblCoypright.Text = "Copyrights hanscreative all rights reserved";
            this.lblCoypright.UseCompatibleTextRendering = true;
            // 
            // customLabel1
            // 
            this.customLabel1.AutoSize = true;
            this.customLabel1.Location = new System.Drawing.Point(152, 72);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(52, 15);
            this.customLabel1.TabIndex = 34;
            this.customLabel1.Tag = "절감량";
            this.customLabel1.Text = "에너지";
            // 
            // Uc_TabEnergy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GreenLock.Properties.Resources.tabEnergy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.customLabel1);
            this.Controls.Add(this.lblCoypright);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Uc_TabEnergy";
            this.Size = new System.Drawing.Size(992, 672);
            this.Load += new System.EventHandler(this.Uc_TabEnergy_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Uc_TabEnergy_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEnergyAmt;
        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCostAmt;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCo2Amt;
        private System.Windows.Forms.Label lblCo2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTreeAmt;
        private System.Windows.Forms.Label lblTree;
        private System.Windows.Forms.Label lblCoypright;
        private CustomLabel customLabel1;
    }
}
