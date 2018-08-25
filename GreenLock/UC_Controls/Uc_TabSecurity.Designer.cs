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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_TabSecurity));
            this.Lable_StartDate = new System.Windows.Forms.Label();
            this.Lable_EndDate = new System.Windows.Forms.Label();
            this.calendarControl1 = new DevExpress.XtraEditors.Controls.CalendarControl();
            this.labelUnlockAvg = new System.Windows.Forms.Label();
            this.labelockAvg = new System.Windows.Forms.Label();
            this.LabelAvgStartEnd = new System.Windows.Forms.Label();
            this.LeftButtonLabel = new System.Windows.Forms.Label();
            this.RightButtonLabel = new System.Windows.Forms.Label();
            this.label_Monday = new System.Windows.Forms.Label();
            this.label_Monday_Unlock = new System.Windows.Forms.Label();
            this.label_Monday_Lock = new System.Windows.Forms.Label();
            this.label_Tuesday_Lock = new System.Windows.Forms.Label();
            this.label_Tuesday_Unlock = new System.Windows.Forms.Label();
            this.label_Tuesday = new System.Windows.Forms.Label();
            this.label_Wednesday_Lock = new System.Windows.Forms.Label();
            this.label_Wednesday_Unlock = new System.Windows.Forms.Label();
            this.label_Wednesday = new System.Windows.Forms.Label();
            this.label_Thursday_Lock = new System.Windows.Forms.Label();
            this.label_Thursday_Unlock = new System.Windows.Forms.Label();
            this.label_Thursday = new System.Windows.Forms.Label();
            this.label_Friday_Lock = new System.Windows.Forms.Label();
            this.label_Friday_Unlock = new System.Windows.Forms.Label();
            this.label_Friday = new System.Windows.Forms.Label();
            this.label_Saturday_Lock = new System.Windows.Forms.Label();
            this.label_Saturday_Unlock = new System.Windows.Forms.Label();
            this.label_Saturday = new System.Windows.Forms.Label();
            this.label_Sunday_Lock = new System.Windows.Forms.Label();
            this.label_Sunday_Unlock = new System.Windows.Forms.Label();
            this.label_Sunday = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ButtonExcelExport = new System.Windows.Forms.PictureBox();
            this.leftButton = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Cal_left = new System.Windows.Forms.PictureBox();
            this.rightButton = new System.Windows.Forms.PictureBox();
            this.Sheet = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.calendarControl1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonExcelExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cal_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lable_StartDate
            // 
            this.Lable_StartDate.AccessibleName = "LabelStartDate";
            this.Lable_StartDate.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lable_StartDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lable_StartDate.Location = new System.Drawing.Point(3, 0);
            this.Lable_StartDate.Name = "Lable_StartDate";
            this.Lable_StartDate.Size = new System.Drawing.Size(144, 34);
            this.Lable_StartDate.TabIndex = 95;
            this.Lable_StartDate.Text = "2018.07.23";
            this.Lable_StartDate.Click += new System.EventHandler(this.label1_Click);
            // 
            // Lable_EndDate
            // 
            this.Lable_EndDate.AccessibleName = "LabelEndDate";
            this.Lable_EndDate.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lable_EndDate.Location = new System.Drawing.Point(189, 0);
            this.Lable_EndDate.Name = "Lable_EndDate";
            this.Lable_EndDate.Size = new System.Drawing.Size(157, 36);
            this.Lable_EndDate.TabIndex = 14;
            this.Lable_EndDate.Text = "2018.07.27";
            // 
            // calendarControl1
            // 
            this.calendarControl1.AccessibleName = "CalPicStartDate";
            this.calendarControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.calendarControl1.Appearance.Options.UseFont = true;
            this.calendarControl1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calendarControl1.DateTime = new System.DateTime(((long)(0)));
            this.calendarControl1.EditValue = new System.DateTime(((long)(0)));
            this.calendarControl1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calendarControl1.Location = new System.Drawing.Point(303, 66);
            this.calendarControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.calendarControl1.MaxValue = new System.DateTime(9999, 12, 31, 0, 0, 0, 0);
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.Size = new System.Drawing.Size(299, 290);
            this.calendarControl1.TabIndex = 999;
            this.calendarControl1.Visible = false;
            this.calendarControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.calendarControl1_MouseDoubleClick);
            // 
            // labelUnlockAvg
            // 
            this.labelUnlockAvg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelUnlockAvg.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.labelUnlockAvg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelUnlockAvg.Location = new System.Drawing.Point(715, 554);
            this.labelUnlockAvg.Name = "labelUnlockAvg";
            this.labelUnlockAvg.Size = new System.Drawing.Size(80, 53);
            this.labelUnlockAvg.TabIndex = 7;
            this.labelUnlockAvg.Text = "0hr";
            this.labelUnlockAvg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelockAvg
            // 
            this.labelockAvg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelockAvg.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.labelockAvg.Location = new System.Drawing.Point(875, 554);
            this.labelockAvg.Name = "labelockAvg";
            this.labelockAvg.Size = new System.Drawing.Size(80, 53);
            this.labelockAvg.TabIndex = 8;
            this.labelockAvg.Text = "0hr";
            this.labelockAvg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAvgStartEnd
            // 
            this.LabelAvgStartEnd.BackColor = System.Drawing.Color.Transparent;
            this.LabelAvgStartEnd.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold);
            this.LabelAvgStartEnd.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.LabelAvgStartEnd.Location = new System.Drawing.Point(560, 632);
            this.LabelAvgStartEnd.Name = "LabelAvgStartEnd";
            this.LabelAvgStartEnd.Size = new System.Drawing.Size(400, 26);
            this.LabelAvgStartEnd.TabIndex = 9;
            this.LabelAvgStartEnd.Text = "Average Unlock Start: {0}  / Average Lock Start: {1} ";
            this.LabelAvgStartEnd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LeftButtonLabel
            // 
            this.LeftButtonLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeftButtonLabel.Font = new System.Drawing.Font("맑은 고딕", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LeftButtonLabel.Location = new System.Drawing.Point(627, 28);
            this.LeftButtonLabel.Name = "LeftButtonLabel";
            this.LeftButtonLabel.Size = new System.Drawing.Size(109, 28);
            this.LeftButtonLabel.TabIndex = 11;
            this.LeftButtonLabel.Text = "label0";
            this.LeftButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LeftButtonLabel.Click += new System.EventHandler(this.LeftButtonLabel_Click);
            // 
            // RightButtonLabel
            // 
            this.RightButtonLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RightButtonLabel.Font = new System.Drawing.Font("맑은 고딕", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RightButtonLabel.Location = new System.Drawing.Point(744, 28);
            this.RightButtonLabel.Name = "RightButtonLabel";
            this.RightButtonLabel.Size = new System.Drawing.Size(109, 28);
            this.RightButtonLabel.TabIndex = 13;
            this.RightButtonLabel.Text = "label1";
            this.RightButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RightButtonLabel.Click += new System.EventHandler(this.RightButtonLabel_Click);
            // 
            // label_Monday
            // 
            this.label_Monday.BackColor = System.Drawing.Color.Transparent;
            this.label_Monday.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Monday.ForeColor = System.Drawing.Color.Gray;
            this.label_Monday.Location = new System.Drawing.Point(36, 135);
            this.label_Monday.Name = "label_Monday";
            this.label_Monday.Size = new System.Drawing.Size(201, 34);
            this.label_Monday.TabIndex = 15;
            this.label_Monday.Text = "2018.07.01 (월)";
            this.label_Monday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Monday_Unlock
            // 
            this.label_Monday_Unlock.BackColor = System.Drawing.Color.Transparent;
            this.label_Monday_Unlock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Monday_Unlock.ForeColor = System.Drawing.Color.Gray;
            this.label_Monday_Unlock.Location = new System.Drawing.Point(269, 146);
            this.label_Monday_Unlock.Name = "label_Monday_Unlock";
            this.label_Monday_Unlock.Size = new System.Drawing.Size(334, 23);
            this.label_Monday_Unlock.TabIndex = 16;
            this.label_Monday_Unlock.Text = "7.2";
            this.label_Monday_Unlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Monday_Unlock.Click += new System.EventHandler(this.label_Monday_Unlock_Click);
            // 
            // label_Monday_Lock
            // 
            this.label_Monday_Lock.BackColor = System.Drawing.Color.Transparent;
            this.label_Monday_Lock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Monday_Lock.ForeColor = System.Drawing.Color.Gray;
            this.label_Monday_Lock.Location = new System.Drawing.Point(632, 146);
            this.label_Monday_Lock.Name = "label_Monday_Lock";
            this.label_Monday_Lock.Size = new System.Drawing.Size(314, 23);
            this.label_Monday_Lock.TabIndex = 17;
            this.label_Monday_Lock.Text = "7.2";
            this.label_Monday_Lock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Tuesday_Lock
            // 
            this.label_Tuesday_Lock.BackColor = System.Drawing.Color.Transparent;
            this.label_Tuesday_Lock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Tuesday_Lock.ForeColor = System.Drawing.Color.Gray;
            this.label_Tuesday_Lock.Location = new System.Drawing.Point(632, 187);
            this.label_Tuesday_Lock.Name = "label_Tuesday_Lock";
            this.label_Tuesday_Lock.Size = new System.Drawing.Size(314, 24);
            this.label_Tuesday_Lock.TabIndex = 20;
            this.label_Tuesday_Lock.Text = "7.244";
            this.label_Tuesday_Lock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Tuesday_Unlock
            // 
            this.label_Tuesday_Unlock.BackColor = System.Drawing.Color.Transparent;
            this.label_Tuesday_Unlock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Tuesday_Unlock.ForeColor = System.Drawing.Color.Gray;
            this.label_Tuesday_Unlock.Location = new System.Drawing.Point(273, 190);
            this.label_Tuesday_Unlock.Name = "label_Tuesday_Unlock";
            this.label_Tuesday_Unlock.Size = new System.Drawing.Size(330, 19);
            this.label_Tuesday_Unlock.TabIndex = 19;
            this.label_Tuesday_Unlock.Text = "7.2";
            this.label_Tuesday_Unlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Tuesday
            // 
            this.label_Tuesday.BackColor = System.Drawing.Color.Transparent;
            this.label_Tuesday.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Tuesday.ForeColor = System.Drawing.Color.Gray;
            this.label_Tuesday.Location = new System.Drawing.Point(37, 181);
            this.label_Tuesday.Name = "label_Tuesday";
            this.label_Tuesday.Size = new System.Drawing.Size(200, 33);
            this.label_Tuesday.TabIndex = 18;
            this.label_Tuesday.Text = "2018.07.01 (월)";
            this.label_Tuesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Wednesday_Lock
            // 
            this.label_Wednesday_Lock.BackColor = System.Drawing.Color.Transparent;
            this.label_Wednesday_Lock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Wednesday_Lock.ForeColor = System.Drawing.Color.Gray;
            this.label_Wednesday_Lock.Location = new System.Drawing.Point(631, 234);
            this.label_Wednesday_Lock.Name = "label_Wednesday_Lock";
            this.label_Wednesday_Lock.Size = new System.Drawing.Size(308, 20);
            this.label_Wednesday_Lock.TabIndex = 23;
            this.label_Wednesday_Lock.Text = "7.2";
            this.label_Wednesday_Lock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Wednesday_Unlock
            // 
            this.label_Wednesday_Unlock.BackColor = System.Drawing.Color.Transparent;
            this.label_Wednesday_Unlock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Wednesday_Unlock.ForeColor = System.Drawing.Color.Gray;
            this.label_Wednesday_Unlock.Location = new System.Drawing.Point(273, 235);
            this.label_Wednesday_Unlock.Name = "label_Wednesday_Unlock";
            this.label_Wednesday_Unlock.Size = new System.Drawing.Size(330, 19);
            this.label_Wednesday_Unlock.TabIndex = 22;
            this.label_Wednesday_Unlock.Text = "7.2";
            this.label_Wednesday_Unlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Wednesday
            // 
            this.label_Wednesday.BackColor = System.Drawing.Color.Transparent;
            this.label_Wednesday.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Wednesday.ForeColor = System.Drawing.Color.Gray;
            this.label_Wednesday.Location = new System.Drawing.Point(39, 230);
            this.label_Wednesday.Name = "label_Wednesday";
            this.label_Wednesday.Size = new System.Drawing.Size(198, 32);
            this.label_Wednesday.TabIndex = 21;
            this.label_Wednesday.Text = "2018.07.01 (월)";
            this.label_Wednesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Thursday_Lock
            // 
            this.label_Thursday_Lock.BackColor = System.Drawing.Color.Transparent;
            this.label_Thursday_Lock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Thursday_Lock.ForeColor = System.Drawing.Color.Gray;
            this.label_Thursday_Lock.Location = new System.Drawing.Point(631, 280);
            this.label_Thursday_Lock.Name = "label_Thursday_Lock";
            this.label_Thursday_Lock.Size = new System.Drawing.Size(308, 26);
            this.label_Thursday_Lock.TabIndex = 26;
            this.label_Thursday_Lock.Text = "7.2";
            this.label_Thursday_Lock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Thursday_Unlock
            // 
            this.label_Thursday_Unlock.BackColor = System.Drawing.Color.Transparent;
            this.label_Thursday_Unlock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Thursday_Unlock.ForeColor = System.Drawing.Color.Gray;
            this.label_Thursday_Unlock.Location = new System.Drawing.Point(273, 280);
            this.label_Thursday_Unlock.Name = "label_Thursday_Unlock";
            this.label_Thursday_Unlock.Size = new System.Drawing.Size(330, 19);
            this.label_Thursday_Unlock.TabIndex = 25;
            this.label_Thursday_Unlock.Text = "7.2";
            this.label_Thursday_Unlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Thursday
            // 
            this.label_Thursday.BackColor = System.Drawing.Color.Transparent;
            this.label_Thursday.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Thursday.ForeColor = System.Drawing.Color.Gray;
            this.label_Thursday.Location = new System.Drawing.Point(39, 277);
            this.label_Thursday.Name = "label_Thursday";
            this.label_Thursday.Size = new System.Drawing.Size(198, 29);
            this.label_Thursday.TabIndex = 24;
            this.label_Thursday.Text = "2018.07.01 (월)";
            this.label_Thursday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Friday_Lock
            // 
            this.label_Friday_Lock.BackColor = System.Drawing.Color.Transparent;
            this.label_Friday_Lock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Friday_Lock.ForeColor = System.Drawing.Color.Gray;
            this.label_Friday_Lock.Location = new System.Drawing.Point(631, 330);
            this.label_Friday_Lock.Name = "label_Friday_Lock";
            this.label_Friday_Lock.Size = new System.Drawing.Size(308, 24);
            this.label_Friday_Lock.TabIndex = 29;
            this.label_Friday_Lock.Text = "7.2";
            this.label_Friday_Lock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Friday_Unlock
            // 
            this.label_Friday_Unlock.BackColor = System.Drawing.Color.Transparent;
            this.label_Friday_Unlock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Friday_Unlock.ForeColor = System.Drawing.Color.Gray;
            this.label_Friday_Unlock.Location = new System.Drawing.Point(273, 330);
            this.label_Friday_Unlock.Name = "label_Friday_Unlock";
            this.label_Friday_Unlock.Size = new System.Drawing.Size(330, 26);
            this.label_Friday_Unlock.TabIndex = 28;
            this.label_Friday_Unlock.Text = "7.2";
            this.label_Friday_Unlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Friday
            // 
            this.label_Friday.BackColor = System.Drawing.Color.Transparent;
            this.label_Friday.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Friday.ForeColor = System.Drawing.Color.Gray;
            this.label_Friday.Location = new System.Drawing.Point(39, 323);
            this.label_Friday.Name = "label_Friday";
            this.label_Friday.Size = new System.Drawing.Size(198, 32);
            this.label_Friday.TabIndex = 27;
            this.label_Friday.Text = "2018.07.01 (월)";
            this.label_Friday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Saturday_Lock
            // 
            this.label_Saturday_Lock.BackColor = System.Drawing.Color.Transparent;
            this.label_Saturday_Lock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Saturday_Lock.ForeColor = System.Drawing.Color.Gray;
            this.label_Saturday_Lock.Location = new System.Drawing.Point(631, 372);
            this.label_Saturday_Lock.Name = "label_Saturday_Lock";
            this.label_Saturday_Lock.Size = new System.Drawing.Size(313, 26);
            this.label_Saturday_Lock.TabIndex = 32;
            this.label_Saturday_Lock.Text = "7.2";
            this.label_Saturday_Lock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Saturday_Unlock
            // 
            this.label_Saturday_Unlock.BackColor = System.Drawing.Color.Transparent;
            this.label_Saturday_Unlock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Saturday_Unlock.ForeColor = System.Drawing.Color.Gray;
            this.label_Saturday_Unlock.Location = new System.Drawing.Point(273, 374);
            this.label_Saturday_Unlock.Name = "label_Saturday_Unlock";
            this.label_Saturday_Unlock.Size = new System.Drawing.Size(330, 26);
            this.label_Saturday_Unlock.TabIndex = 31;
            this.label_Saturday_Unlock.Text = "7.2";
            this.label_Saturday_Unlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Saturday
            // 
            this.label_Saturday.BackColor = System.Drawing.Color.Transparent;
            this.label_Saturday.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Saturday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(154)))), ((int)(((byte)(213)))));
            this.label_Saturday.Location = new System.Drawing.Point(39, 368);
            this.label_Saturday.Name = "label_Saturday";
            this.label_Saturday.Size = new System.Drawing.Size(198, 34);
            this.label_Saturday.TabIndex = 30;
            this.label_Saturday.Text = "2018.07.01 (월)";
            this.label_Saturday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Sunday_Lock
            // 
            this.label_Sunday_Lock.BackColor = System.Drawing.Color.Transparent;
            this.label_Sunday_Lock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Sunday_Lock.ForeColor = System.Drawing.Color.Gray;
            this.label_Sunday_Lock.Location = new System.Drawing.Point(636, 418);
            this.label_Sunday_Lock.Name = "label_Sunday_Lock";
            this.label_Sunday_Lock.Size = new System.Drawing.Size(308, 26);
            this.label_Sunday_Lock.TabIndex = 35;
            this.label_Sunday_Lock.Text = "7.2";
            this.label_Sunday_Lock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Sunday_Unlock
            // 
            this.label_Sunday_Unlock.BackColor = System.Drawing.Color.Transparent;
            this.label_Sunday_Unlock.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Sunday_Unlock.ForeColor = System.Drawing.Color.Gray;
            this.label_Sunday_Unlock.Location = new System.Drawing.Point(273, 422);
            this.label_Sunday_Unlock.Name = "label_Sunday_Unlock";
            this.label_Sunday_Unlock.Size = new System.Drawing.Size(330, 19);
            this.label_Sunday_Unlock.TabIndex = 34;
            this.label_Sunday_Unlock.Text = "7.2";
            this.label_Sunday_Unlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Sunday
            // 
            this.label_Sunday.BackColor = System.Drawing.Color.Transparent;
            this.label_Sunday.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Sunday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(77)))), ((int)(((byte)(81)))));
            this.label_Sunday.Location = new System.Drawing.Point(39, 415);
            this.label_Sunday.Name = "label_Sunday";
            this.label_Sunday.Size = new System.Drawing.Size(198, 33);
            this.label_Sunday.TabIndex = 33;
            this.label_Sunday.Text = "2018.07.01 (월)";
            this.label_Sunday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::GreenLock.Properties.Resources.btn_print;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(914, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 1001;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // ButtonExcelExport
            // 
            this.ButtonExcelExport.BackgroundImage = global::GreenLock.Properties.Resources.btn_save;
            this.ButtonExcelExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonExcelExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExcelExport.Location = new System.Drawing.Point(881, 26);
            this.ButtonExcelExport.Name = "ButtonExcelExport";
            this.ButtonExcelExport.Size = new System.Drawing.Size(34, 32);
            this.ButtonExcelExport.TabIndex = 1000;
            this.ButtonExcelExport.TabStop = false;
            this.ButtonExcelExport.Click += new System.EventHandler(this.ButtonExcelExport_Click);
            // 
            // leftButton
            // 
            this.leftButton.BackgroundImage = global::GreenLock.Properties.Resources.blueButton;
            this.leftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftButton.Location = new System.Drawing.Point(625, 26);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(115, 33);
            this.leftButton.TabIndex = 10;
            this.leftButton.TabStop = false;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GreenLock.Properties.Resources.WeeklyBar;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(24, 552);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(936, 64);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Cal_left
            // 
            this.Cal_left.AccessibleName = "CalStartDate";
            this.Cal_left.BackgroundImage = global::GreenLock.Properties.Resources.btn_calander;
            this.Cal_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cal_left.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cal_left.Location = new System.Drawing.Point(352, 3);
            this.Cal_left.Name = "Cal_left";
            this.Cal_left.Size = new System.Drawing.Size(33, 32);
            this.Cal_left.TabIndex = 1;
            this.Cal_left.TabStop = false;
            this.Cal_left.Click += new System.EventHandler(this.Cal_left_Click);
            // 
            // rightButton
            // 
            this.rightButton.BackgroundImage = global::GreenLock.Properties.Resources.whiteButton;
            this.rightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightButton.Location = new System.Drawing.Point(739, 26);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(119, 34);
            this.rightButton.TabIndex = 12;
            this.rightButton.TabStop = false;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // Sheet
            // 
            this.Sheet.BackgroundImage = global::GreenLock.Properties.Resources.sheet;
            this.Sheet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Sheet.Location = new System.Drawing.Point(28, 85);
            this.Sheet.Name = "Sheet";
            this.Sheet.Size = new System.Drawing.Size(942, 371);
            this.Sheet.TabIndex = 14;
            this.Sheet.TabStop = false;
            this.Sheet.Visible = false;
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
            // label1
            // 
            this.label1.AccessibleName = "LabelStartDate";
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(153, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 39);
            this.label1.TabIndex = 1002;
            this.label1.Text = "~";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.Lable_StartDate);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.Lable_EndDate);
            this.flowLayoutPanel2.Controls.Add(this.Cal_left);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(31, 26);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(571, 42);
            this.flowLayoutPanel2.TabIndex = 1004;
            // 
            // Uc_TabSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ButtonExcelExport);
            this.Controls.Add(this.label_Monday);
            this.Controls.Add(this.label_Tuesday);
            this.Controls.Add(this.label_Sunday_Lock);
            this.Controls.Add(this.label_Sunday_Unlock);
            this.Controls.Add(this.label_Sunday);
            this.Controls.Add(this.label_Saturday_Lock);
            this.Controls.Add(this.label_Saturday_Unlock);
            this.Controls.Add(this.label_Saturday);
            this.Controls.Add(this.label_Friday_Lock);
            this.Controls.Add(this.label_Friday_Unlock);
            this.Controls.Add(this.label_Friday);
            this.Controls.Add(this.label_Thursday_Lock);
            this.Controls.Add(this.label_Thursday_Unlock);
            this.Controls.Add(this.label_Thursday);
            this.Controls.Add(this.label_Wednesday_Lock);
            this.Controls.Add(this.label_Wednesday_Unlock);
            this.Controls.Add(this.label_Wednesday);
            this.Controls.Add(this.label_Tuesday_Lock);
            this.Controls.Add(this.label_Tuesday_Unlock);
            this.Controls.Add(this.label_Monday_Lock);
            this.Controls.Add(this.label_Monday_Unlock);
            this.Controls.Add(this.LeftButtonLabel);
            this.Controls.Add(this.RightButtonLabel);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.LabelAvgStartEnd);
            this.Controls.Add(this.labelockAvg);
            this.Controls.Add(this.labelUnlockAvg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.Sheet);
            this.Controls.Add(this.calendarControl1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Uc_TabSecurity";
            this.Size = new System.Drawing.Size(992, 672);
            this.Load += new System.EventHandler(this.Uc_TabSecurity_Load);
            this.Click += new System.EventHandler(this.Uc_TabSecurity_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Uc_TabSecurity_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.calendarControl1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonExcelExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cal_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl ChartControl;
        private System.Windows.Forms.Label Lable_StartDate;
        private System.Windows.Forms.PictureBox Cal_left;
        private System.Windows.Forms.Label Lable_EndDate;
        private DevExpress.XtraEditors.Controls.CalendarControl calendarControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelUnlockAvg;
        private System.Windows.Forms.Label labelockAvg;
        private System.Windows.Forms.Label LabelAvgStartEnd;
        private System.Windows.Forms.PictureBox leftButton;
        private System.Windows.Forms.Label LeftButtonLabel;
        private System.Windows.Forms.PictureBox rightButton;
        private System.Windows.Forms.Label RightButtonLabel;
        private System.Windows.Forms.PictureBox Sheet;
        private System.Windows.Forms.Label label_Monday;
        private System.Windows.Forms.Label label_Monday_Unlock;
        private System.Windows.Forms.Label label_Monday_Lock;
        private System.Windows.Forms.Label label_Tuesday_Lock;
        private System.Windows.Forms.Label label_Tuesday_Unlock;
        private System.Windows.Forms.Label label_Tuesday;
        private System.Windows.Forms.Label label_Wednesday_Lock;
        private System.Windows.Forms.Label label_Wednesday_Unlock;
        private System.Windows.Forms.Label label_Wednesday;
        private System.Windows.Forms.Label label_Thursday_Lock;
        private System.Windows.Forms.Label label_Thursday_Unlock;
        private System.Windows.Forms.Label label_Thursday;
        private System.Windows.Forms.Label label_Friday_Lock;
        private System.Windows.Forms.Label label_Friday_Unlock;
        private System.Windows.Forms.Label label_Friday;
        private System.Windows.Forms.Label label_Saturday_Lock;
        private System.Windows.Forms.Label label_Saturday_Unlock;
        private System.Windows.Forms.Label label_Saturday;
        private System.Windows.Forms.Label label_Sunday_Lock;
        private System.Windows.Forms.Label label_Sunday_Unlock;
        private System.Windows.Forms.Label label_Sunday;
        private System.Windows.Forms.PictureBox ButtonExcelExport;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}
