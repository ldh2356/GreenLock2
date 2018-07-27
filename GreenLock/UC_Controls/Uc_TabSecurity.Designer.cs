using DevExpress.XtraCharts;

namespace GreenLock.UC_Controls
{
    partial class Uc_TabSecurity
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
            this.Lable_StartDate = new System.Windows.Forms.Label();
            this.Cal_left = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Lable_EndDate = new System.Windows.Forms.Label();
            this.calendarControl1 = new DevExpress.XtraEditors.Controls.CalendarControl();
            ((System.ComponentModel.ISupportInitialize)(this.Cal_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarControl1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // Lable_StartDate
            // 
            this.Lable_StartDate.AccessibleName = "LabelStartDate";
            this.Lable_StartDate.AutoSize = true;
            this.Lable_StartDate.Font = new System.Drawing.Font("Malgun Gothic", 17F, System.Drawing.FontStyle.Bold);
            this.Lable_StartDate.Location = new System.Drawing.Point(28, 18);
            this.Lable_StartDate.Name = "Lable_StartDate";
            this.Lable_StartDate.Size = new System.Drawing.Size(198, 46);
            this.Lable_StartDate.TabIndex = 0;
            this.Lable_StartDate.Text = "2018.07.23";
            this.Lable_StartDate.Click += new System.EventHandler(this.label1_Click);
            // 
            // Cal_left
            // 
            this.Cal_left.AccessibleName = "CalStartDate";
            this.Cal_left.BackgroundImage = global::GreenLock.Properties.Resources.btn_calander;
            this.Cal_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Cal_left.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cal_left.Location = new System.Drawing.Point(452, 25);
            this.Cal_left.Name = "Cal_left";
            this.Cal_left.Size = new System.Drawing.Size(33, 32);
            this.Cal_left.TabIndex = 1;
            this.Cal_left.TabStop = false;
            this.Cal_left.Click += new System.EventHandler(this.Cal_left_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(218, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = "~";
            // 
            // Lable_EndDate
            // 
            this.Lable_EndDate.AccessibleName = "LabelEndDate";
            this.Lable_EndDate.AutoSize = true;
            this.Lable_EndDate.Font = new System.Drawing.Font("Malgun Gothic", 17F, System.Drawing.FontStyle.Bold);
            this.Lable_EndDate.Location = new System.Drawing.Point(253, 18);
            this.Lable_EndDate.Name = "Lable_EndDate";
            this.Lable_EndDate.Size = new System.Drawing.Size(198, 46);
            this.Lable_EndDate.TabIndex = 3;
            this.Lable_EndDate.Text = "2018.07.27";
            // 
            // calendarControl1
            // 
            this.calendarControl1.AccessibleName = "CalPicStartDate";
            this.calendarControl1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calendarControl1.DateTime = new System.DateTime(((long)(0)));
            this.calendarControl1.EditValue = new System.DateTime(((long)(0)));
            this.calendarControl1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calendarControl1.Location = new System.Drawing.Point(452, 63);
            this.calendarControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.calendarControl1.MaxValue = new System.DateTime(9999, 12, 31, 0, 0, 0, 0);
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.Size = new System.Drawing.Size(333, 360);
            this.calendarControl1.TabIndex = 5;
            this.calendarControl1.Visible = false;
            this.calendarControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.calendarControl1_MouseDoubleClick);
            // 
            // Uc_TabSecurity
            // 
            this.Controls.Add(this.calendarControl1);
            this.Controls.Add(this.Lable_EndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cal_left);
            this.Controls.Add(this.Lable_StartDate);
            this.Name = "Uc_TabSecurity";
            this.Size = new System.Drawing.Size(1021, 767);
            this.Load += new System.EventHandler(this.Uc_TabSecurity_Load);
            this.Click += new System.EventHandler(this.Uc_TabSecurity_Click);
            ((System.ComponentModel.ISupportInitialize)(this.Cal_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarControl1.CalendarTimeProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl ChartControl;
        private System.Windows.Forms.Label Lable_StartDate;
        private System.Windows.Forms.PictureBox Cal_left;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lable_EndDate;
        private DevExpress.XtraEditors.Controls.CalendarControl calendarControl1;
    }
}
