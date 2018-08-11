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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_TabEnergy));
            this.pbPrint = new System.Windows.Forms.PictureBox();
            this.pbDown = new System.Windows.Forms.PictureBox();
            this.pnlEnergy = new System.Windows.Forms.Panel();
            this.lblEnergyAmt = new System.Windows.Forms.Label();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.pnlCost = new System.Windows.Forms.Panel();
            this.lblCostAmt = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.pnlCo2 = new System.Windows.Forms.Panel();
            this.lblCo2Amt = new System.Windows.Forms.Label();
            this.lblCo2 = new System.Windows.Forms.Label();
            this.pnlTree = new System.Windows.Forms.Panel();
            this.lblTreeAmt = new System.Windows.Forms.Label();
            this.lblTree = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDown)).BeginInit();
            this.pnlEnergy.SuspendLayout();
            this.pnlCost.SuspendLayout();
            this.pnlCo2.SuspendLayout();
            this.pnlTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPrint
            // 
            this.pbPrint.BackColor = System.Drawing.Color.Transparent;
            this.pbPrint.BackgroundImage = global::GreenLock.Properties.Resources.btn_print;
            this.pbPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbPrint.Location = new System.Drawing.Point(897, 32);
            this.pbPrint.Margin = new System.Windows.Forms.Padding(0);
            this.pbPrint.Name = "pbPrint";
            this.pbPrint.Size = new System.Drawing.Size(32, 32);
            this.pbPrint.TabIndex = 25;
            this.pbPrint.TabStop = false;
            this.pbPrint.Click += new System.EventHandler(this.pbPrint_Click);
            // 
            // pbDown
            // 
            this.pbDown.BackColor = System.Drawing.Color.Transparent;
            this.pbDown.BackgroundImage = global::GreenLock.Properties.Resources.btn_save;
            this.pbDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbDown.Location = new System.Drawing.Point(864, 32);
            this.pbDown.Margin = new System.Windows.Forms.Padding(0);
            this.pbDown.Name = "pbDown";
            this.pbDown.Size = new System.Drawing.Size(34, 32);
            this.pbDown.TabIndex = 24;
            this.pbDown.TabStop = false;
            this.pbDown.Click += new System.EventHandler(this.pbDown_Click);
            // 
            // pnlEnergy
            // 
            this.pnlEnergy.Controls.Add(this.lblEnergyAmt);
            this.pnlEnergy.Controls.Add(this.lblEnergy);
            this.pnlEnergy.Location = new System.Drawing.Point(42, 400);
            this.pnlEnergy.Name = "pnlEnergy";
            this.pnlEnergy.Size = new System.Drawing.Size(200, 192);
            this.pnlEnergy.TabIndex = 30;
            // 
            // lblEnergyAmt
            // 
            this.lblEnergyAmt.AutoSize = true;
            this.lblEnergyAmt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEnergyAmt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblEnergyAmt.Location = new System.Drawing.Point(56, 112);
            this.lblEnergyAmt.Name = "lblEnergyAmt";
            this.lblEnergyAmt.Size = new System.Drawing.Size(39, 45);
            this.lblEnergyAmt.TabIndex = 1;
            this.lblEnergyAmt.Text = "0";
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
            // pnlCost
            // 
            this.pnlCost.Controls.Add(this.lblCostAmt);
            this.pnlCost.Controls.Add(this.lblCost);
            this.pnlCost.Location = new System.Drawing.Point(264, 400);
            this.pnlCost.Name = "pnlCost";
            this.pnlCost.Size = new System.Drawing.Size(208, 192);
            this.pnlCost.TabIndex = 31;
            // 
            // lblCostAmt
            // 
            this.lblCostAmt.AutoSize = true;
            this.lblCostAmt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCostAmt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCostAmt.Location = new System.Drawing.Point(64, 112);
            this.lblCostAmt.Name = "lblCostAmt";
            this.lblCostAmt.Size = new System.Drawing.Size(39, 45);
            this.lblCostAmt.TabIndex = 2;
            this.lblCostAmt.Text = "0";
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
            // pnlCo2
            // 
            this.pnlCo2.Controls.Add(this.lblCo2Amt);
            this.pnlCo2.Controls.Add(this.lblCo2);
            this.pnlCo2.Location = new System.Drawing.Point(496, 400);
            this.pnlCo2.Name = "pnlCo2";
            this.pnlCo2.Size = new System.Drawing.Size(208, 192);
            this.pnlCo2.TabIndex = 31;
            // 
            // lblCo2Amt
            // 
            this.lblCo2Amt.AutoSize = true;
            this.lblCo2Amt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCo2Amt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCo2Amt.Location = new System.Drawing.Point(64, 112);
            this.lblCo2Amt.Name = "lblCo2Amt";
            this.lblCo2Amt.Size = new System.Drawing.Size(39, 45);
            this.lblCo2Amt.TabIndex = 3;
            this.lblCo2Amt.Text = "0";
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
            // pnlTree
            // 
            this.pnlTree.Controls.Add(this.lblTreeAmt);
            this.pnlTree.Controls.Add(this.lblTree);
            this.pnlTree.Location = new System.Drawing.Point(736, 400);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(208, 192);
            this.pnlTree.TabIndex = 32;
            // 
            // lblTreeAmt
            // 
            this.lblTreeAmt.AutoSize = true;
            this.lblTreeAmt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTreeAmt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTreeAmt.Location = new System.Drawing.Point(72, 112);
            this.lblTreeAmt.Name = "lblTreeAmt";
            this.lblTreeAmt.Size = new System.Drawing.Size(39, 45);
            this.lblTreeAmt.TabIndex = 4;
            this.lblTreeAmt.Text = "0";
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
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Uc_TabEnergy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GreenLock.Properties.Resources.tabEnergy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.pnlTree);
            this.Controls.Add(this.pnlCo2);
            this.Controls.Add(this.pnlCost);
            this.Controls.Add(this.pnlEnergy);
            this.Controls.Add(this.pbPrint);
            this.Controls.Add(this.pbDown);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Uc_TabEnergy";
            this.Size = new System.Drawing.Size(992, 672);
            this.Load += new System.EventHandler(this.Uc_TabEnergy_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Uc_TabEnergy_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDown)).EndInit();
            this.pnlEnergy.ResumeLayout(false);
            this.pnlEnergy.PerformLayout();
            this.pnlCost.ResumeLayout(false);
            this.pnlCost.PerformLayout();
            this.pnlCo2.ResumeLayout(false);
            this.pnlCo2.PerformLayout();
            this.pnlTree.ResumeLayout(false);
            this.pnlTree.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbPrint;
        private System.Windows.Forms.PictureBox pbDown;
        private System.Windows.Forms.Panel pnlEnergy;
        private System.Windows.Forms.Label lblEnergyAmt;
        private System.Windows.Forms.Panel pnlCost;
        private System.Windows.Forms.Label lblCostAmt;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Panel pnlCo2;
        private System.Windows.Forms.Label lblCo2Amt;
        private System.Windows.Forms.Label lblCo2;
        private System.Windows.Forms.Panel pnlTree;
        private System.Windows.Forms.Label lblTreeAmt;
        private System.Windows.Forms.Label lblTree;
        private System.Windows.Forms.Label lblEnergy;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}
