namespace GreenLock.UC_Controls
{
    partial class Uc_TabConfig
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
            this.lblConnet = new System.Windows.Forms.Label();
            this.lblSleepMode = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.rbAdroid = new System.Windows.Forms.RadioButton();
            this.lblAddress = new System.Windows.Forms.Label();
            this.rbSleepModeMonitor = new System.Windows.Forms.RadioButton();
            this.rbIOS = new System.Windows.Forms.RadioButton();
            this.rbSleepModeAll = new System.Windows.Forms.RadioButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress6 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConnet
            // 
            this.lblConnet.AutoSize = true;
            this.lblConnet.BackColor = System.Drawing.Color.Transparent;
            this.lblConnet.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblConnet.Location = new System.Drawing.Point(56, 112);
            this.lblConnet.Name = "lblConnet";
            this.lblConnet.Size = new System.Drawing.Size(39, 20);
            this.lblConnet.TabIndex = 0;
            this.lblConnet.Text = "연결";
            // 
            // lblSleepMode
            // 
            this.lblSleepMode.AutoSize = true;
            this.lblSleepMode.BackColor = System.Drawing.Color.Transparent;
            this.lblSleepMode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSleepMode.Location = new System.Drawing.Point(56, 176);
            this.lblSleepMode.Name = "lblSleepMode";
            this.lblSleepMode.Size = new System.Drawing.Size(69, 20);
            this.lblSleepMode.TabIndex = 1;
            this.lblSleepMode.Text = "절전모드";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPassword.Location = new System.Drawing.Point(56, 232);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 20);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "비밀번호";
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.BackColor = System.Drawing.Color.Transparent;
            this.lblEnergy.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEnergy.Location = new System.Drawing.Point(56, 280);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(86, 20);
            this.lblEnergy.TabIndex = 3;
            this.lblEnergy.Text = "절력값(kW)";
            // 
            // rbAdroid
            // 
            this.rbAdroid.AutoSize = true;
            this.rbAdroid.BackColor = System.Drawing.Color.Transparent;
            this.rbAdroid.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbAdroid.Location = new System.Drawing.Point(24, 16);
            this.rbAdroid.Name = "rbAdroid";
            this.rbAdroid.Size = new System.Drawing.Size(85, 24);
            this.rbAdroid.TabIndex = 4;
            this.rbAdroid.TabStop = true;
            this.rbAdroid.Text = "Android";
            this.rbAdroid.UseVisualStyleBackColor = false;
            this.rbAdroid.Click += new System.EventHandler(this.rbAdroid_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAddress.Location = new System.Drawing.Point(288, 138);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(69, 20);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "장치주소";
            // 
            // rbSleepModeMonitor
            // 
            this.rbSleepModeMonitor.AutoSize = true;
            this.rbSleepModeMonitor.BackColor = System.Drawing.Color.Transparent;
            this.rbSleepModeMonitor.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.rbSleepModeMonitor.Location = new System.Drawing.Point(280, 184);
            this.rbSleepModeMonitor.Name = "rbSleepModeMonitor";
            this.rbSleepModeMonitor.Size = new System.Drawing.Size(105, 24);
            this.rbSleepModeMonitor.TabIndex = 7;
            this.rbSleepModeMonitor.TabStop = true;
            this.rbSleepModeMonitor.Text = "모니터절전";
            this.rbSleepModeMonitor.UseVisualStyleBackColor = false;
            this.rbSleepModeMonitor.Click += new System.EventHandler(this.rbSleepModeMonitor_Click);
            // 
            // rbIOS
            // 
            this.rbIOS.AutoSize = true;
            this.rbIOS.BackColor = System.Drawing.Color.Transparent;
            this.rbIOS.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.rbIOS.Location = new System.Drawing.Point(168, 16);
            this.rbIOS.Name = "rbIOS";
            this.rbIOS.Size = new System.Drawing.Size(54, 24);
            this.rbIOS.TabIndex = 5;
            this.rbIOS.TabStop = true;
            this.rbIOS.Text = "IOS";
            this.rbIOS.UseVisualStyleBackColor = false;
            this.rbIOS.Click += new System.EventHandler(this.rbIOS_Click);
            // 
            // rbSleepModeAll
            // 
            this.rbSleepModeAll.AutoSize = true;
            this.rbSleepModeAll.BackColor = System.Drawing.Color.Transparent;
            this.rbSleepModeAll.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.rbSleepModeAll.Location = new System.Drawing.Point(424, 184);
            this.rbSleepModeAll.Name = "rbSleepModeAll";
            this.rbSleepModeAll.Size = new System.Drawing.Size(161, 24);
            this.rbSleepModeAll.TabIndex = 8;
            this.rbSleepModeAll.TabStop = true;
            this.rbSleepModeAll.Text = "모니터 + 본체 절전";
            this.rbSleepModeAll.UseVisualStyleBackColor = false;
            this.rbSleepModeAll.Click += new System.EventHandler(this.rbSleepModeAll_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPassword.Location = new System.Drawing.Point(280, 229);
            this.txtPassword.MaxLength = 4;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(136, 27);
            this.txtPassword.TabIndex = 9;
            // 
            // txtPower
            // 
            this.txtPower.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtPower.Location = new System.Drawing.Point(280, 275);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(136, 27);
            this.txtPower.TabIndex = 10;
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAddress1.Location = new System.Drawing.Point(376, 136);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(32, 27);
            this.txtAddress1.TabIndex = 11;
            this.txtAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddress1.TextChanged += new System.EventHandler(this.txtAddress1_TextChanged);
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAddress2.Location = new System.Drawing.Point(424, 136);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(32, 27);
            this.txtAddress2.TabIndex = 12;
            this.txtAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddress2.TextChanged += new System.EventHandler(this.txtAddress1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(410, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(458, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = ":";
            // 
            // txtAddress3
            // 
            this.txtAddress3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAddress3.Location = new System.Drawing.Point(472, 136);
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Size = new System.Drawing.Size(32, 27);
            this.txtAddress3.TabIndex = 14;
            this.txtAddress3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddress3.TextChanged += new System.EventHandler(this.txtAddress1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(506, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = ":";
            // 
            // txtAddress4
            // 
            this.txtAddress4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAddress4.Location = new System.Drawing.Point(520, 136);
            this.txtAddress4.Name = "txtAddress4";
            this.txtAddress4.Size = new System.Drawing.Size(32, 27);
            this.txtAddress4.TabIndex = 16;
            this.txtAddress4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(554, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = ":";
            // 
            // txtAddress5
            // 
            this.txtAddress5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAddress5.Location = new System.Drawing.Point(568, 136);
            this.txtAddress5.Name = "txtAddress5";
            this.txtAddress5.Size = new System.Drawing.Size(32, 27);
            this.txtAddress5.TabIndex = 18;
            this.txtAddress5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddress5.TextChanged += new System.EventHandler(this.txtAddress1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(602, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = ":";
            // 
            // txtAddress6
            // 
            this.txtAddress6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAddress6.Location = new System.Drawing.Point(616, 136);
            this.txtAddress6.Name = "txtAddress6";
            this.txtAddress6.Size = new System.Drawing.Size(32, 27);
            this.txtAddress6.TabIndex = 20;
            this.txtAddress6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddress6.TextAlignChanged += new System.EventHandler(this.txtAddress1_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(672, 336);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(130, 40);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(824, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.rbAdroid);
            this.panel1.Controls.Add(this.rbIOS);
            this.panel1.Location = new System.Drawing.Point(256, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 48);
            this.panel1.TabIndex = 25;
            // 
            // Uc_TabConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::GreenLock.Properties.Resources.tabConfig;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAddress6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddress3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.txtPower);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.rbSleepModeAll);
            this.Controls.Add(this.rbSleepModeMonitor);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblEnergy);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblSleepMode);
            this.Controls.Add(this.lblConnet);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Uc_TabConfig";
            this.Size = new System.Drawing.Size(992, 672);
            this.Load += new System.EventHandler(this.Uc_TabConfig_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnet;
        private System.Windows.Forms.Label lblSleepMode;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.RadioButton rbAdroid;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.RadioButton rbSleepModeMonitor;
        private System.Windows.Forms.RadioButton rbIOS;
        private System.Windows.Forms.RadioButton rbSleepModeAll;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddress5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddress6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
    }
}
