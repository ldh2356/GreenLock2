using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.Globalization;
using GreenLock.Repository;
using GreenLock.Dispatcher;

namespace GreenLock.UC_Controls
{
    public partial class Uc_TabSecurity : UserControl
    {
        /// <summary>
        /// DB 프로바이더
        /// </summary>
        private TimeSheetDispatcher _dispatcher = new TimeSheetDispatcher();

        /// <summary>
        /// 시작일 
        /// </summary>
        private static DateTime _startDate;

        /// <summary>
        /// 종료일
        /// </summary>
        private static DateTime _endDate;

        /// <summary>
        /// GanttView 언락 프라퍼티
        /// </summary>
        private static OverlappedGanttSeriesView _ganttView_Unlock { get; set; } = new OverlappedGanttSeriesView();

        /// <summary>
        /// GanttView 락 프라퍼티
        /// </summary>
        private static OverlappedGanttSeriesView _ganttView_Lock { get; set; } = new OverlappedGanttSeriesView();

        /// <summary>
        /// GanttView 더미 프라퍼티
        /// </summary>
        private static OverlappedGanttSeriesView _ganttView_Dummy { get; set; } = new OverlappedGanttSeriesView();

        /// <summary>
        /// Service 언락 바
        /// </summary>
        private static Series _series_Unlock { get; set; } = new Series();

        /// <summary>
        /// Service 락 바
        /// </summary>
        private static Series _series_Lock { get; set; } = new Series();

        /// <summary>
        /// Service 더미 바
        /// </summary>
        private static Series _series_Dummy { get; set; } = new Series();

        /// <summary>
        /// 다이어 그램
        /// </summary>
        private static GanttDiagram _ganttDigram_Custom = new GanttDiagram();


        /// <summary>
        /// 생성자
        /// </summary>
        public Uc_TabSecurity()
        {
            try
            {
                InitializeComponent();
                this.ChartControl = new DevExpress.XtraCharts.ChartControl();

                SetBaseSeries();
                SetBeginInit();
                this.SuspendLayout();

                SetChartInit();
                calendarControl1.DateTime = DateTime.Now;
                SetCalendarInit(DateTime.Now);

                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                this.Controls.Add(this.ChartControl);
                this.Margin = new System.Windows.Forms.Padding(0);
                this.Name = "Uc_TabSecurity";
                this.Size = new System.Drawing.Size(992, 672);

                SetEndBeginInit();
                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);                
            }
        }


        /// <summary>
        /// 시간을 설정한다
        /// </summary>
        /// <param name="targetTime"></param>
        private void SetCalendarInit(DateTime targetTime)
        {
            try
            {
                // 월요일이 아닌경우
                if (DateTime.Now.DayOfWeek != DayOfWeek.Monday)
                {
                    int gap = (targetTime.DayOfWeek - DayOfWeek.Monday);
                    _startDate = targetTime.AddDays((-1 * gap));
                }
                // 월요일 인 경우
                else
                {
                    _startDate = targetTime;
                }

                // 일요일이 아닌경우 
                if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
                {
                    int gap = (((int)targetTime.DayOfWeek - 7) * -1);
                    _endDate = targetTime.AddDays(gap);
                }
                // 일요일 인 경우
                else
                {
                    _endDate = targetTime;
                }

                // 라벨을 세팅한다
                Lable_StartDate.Text = _startDate.ToString("yyyy.MM.dd");
                Lable_EndDate.Text = _endDate.ToString("yyyy.MM.dd");
                this.calendarControl1.Visible = false;

                SetDateTimeData();

            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }

        /// <summary>
        /// 데이터를 셋팅한다
        /// </summary>
        private void SetDateTimeData()
        {
            try
            {
                List<TimeTable> timeSheetOfWeek = _dispatcher.GetTimeTable("84:2E:27:6B:70:12", _startDate, _endDate);

                _series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Tuesday)));

                // 초기화
                _series_Unlock.Points.Clear();
                _series_Lock.Points.Clear();

                foreach (TimeTable day in timeSheetOfWeek)
                {
                    // 언락인경우
                    if (day.LockType == 0)
                    {
                        _series_Unlock.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(day.RegDate.DayOfWeek), new double[] { GetDayOfMinute(day.StartDate), GetDayOfMinute(day.EndDate) }));
                    }
                    // 락인경우 
                    else
                    {
                        _series_Lock.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(day.RegDate.DayOfWeek), new double[] { GetDayOfMinute(day.StartDate), GetDayOfMinute(day.EndDate) }));
                    }
                }
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }

        /// <summary>
        /// 하루의 시간을 계산한다
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private double GetDayOfMinute(DateTime? startDate)
        {
            double result = 0.0;
            try
            {
                if(startDate != null)
                {
                    DateTime time = Convert.ToDateTime(startDate);
                    result = Convert.ToDouble(((time.Hour * 60) + (time.Minute)));
                }
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);                
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        private void SetLockPoint(TimeTable day)
        {
            // 언락인경우
            if (day.LockType == 0)
            {
                _series_Unlock.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Monday), new double[] { Convert.ToDateTime(day.StartDate).Minute, Convert.ToDateTime(day.EndDate).Minute }));
            }
            // 락인경우 
            else
            {
                _series_Lock.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Monday), new double[] { Convert.ToDateTime(day.StartDate).Minute, Convert.ToDateTime(day.EndDate).Minute }));
            }
        }


        /// <summary>
        /// Init 데이터를 초기화한다
        /// </summary>
        private void SetBeginInit()
        {
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_ganttDigram_Custom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_series_Unlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_series_Lock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_ganttView_Unlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_ganttView_Lock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(_ganttView_Dummy)).BeginInit();
            
        }

        /// <summary>
        /// Init 을 중지한다
        /// </summary>
        private void SetEndBeginInit()
        {
            ((System.ComponentModel.ISupportInitialize)(_ganttDigram_Custom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_ganttView_Unlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_ganttView_Lock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_series_Unlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_series_Lock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(_series_Dummy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl)).EndInit();
        }

        /// <summary>
        /// ChartControl 을 초기화한다
        /// </summary>
        private void SetChartInit()
        {
            this.ChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            _ganttDigram_Custom.AxisX.CrosshairAxisLabelOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            _ganttDigram_Custom.AxisX.GridLines.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            _ganttDigram_Custom.AxisX.InterlacedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            _ganttDigram_Custom.AxisX.Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            _ganttDigram_Custom.AxisX.Label.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            _ganttDigram_Custom.AxisX.MinorCount = 1;
            _ganttDigram_Custom.AxisX.NumericScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.None;
            _ganttDigram_Custom.AxisX.NumericScaleOptions.AutoGrid = false;
            _ganttDigram_Custom.AxisX.NumericScaleOptions.GridSpacing = 0.4D;
            _ganttDigram_Custom.AxisX.NumericScaleOptions.ProcessMissingPoints = DevExpress.XtraCharts.ProcessMissingPointsMode.InsertEmptyPoints;
            _ganttDigram_Custom.AxisX.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Automatic;
            _ganttDigram_Custom.AxisX.Thickness = 1;
            _ganttDigram_Custom.AxisX.Tickmarks.MinorVisible = false;
            _ganttDigram_Custom.AxisX.Tickmarks.Visible = false;
            _ganttDigram_Custom.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            _ganttDigram_Custom.AxisX.VisibleInPanesSerializable = "-1";
            _ganttDigram_Custom.AxisX.WholeRange.Auto = false;
            _ganttDigram_Custom.AxisX.WholeRange.AutoSideMargins = false;
            _ganttDigram_Custom.AxisX.WholeRange.MaxValueSerializable = "5.4";
            _ganttDigram_Custom.AxisX.WholeRange.MinValueSerializable = "0";
            _ganttDigram_Custom.AxisX.WholeRange.SideMarginsValue = 1D;
            _ganttDigram_Custom.AxisX.QualitativeScaleOptions.AutoGrid = false;
            _ganttDigram_Custom.AxisY.GridLines.LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped;
            _ganttDigram_Custom.AxisY.GridLines.Visible = false;
            _ganttDigram_Custom.AxisY.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            _ganttDigram_Custom.AxisY.Label.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            _ganttDigram_Custom.AxisY.Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _ganttDigram_Custom.AxisY.Label.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            _ganttDigram_Custom.AxisY.MinorCount = 1;
            _ganttDigram_Custom.AxisY.Thickness = 1;
            _ganttDigram_Custom.AxisY.Tickmarks.MinorVisible = false;
            _ganttDigram_Custom.AxisY.Tickmarks.Visible = false;
            _ganttDigram_Custom.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            _ganttDigram_Custom.AxisY.VisibleInPanesSerializable = "-1";
            _ganttDigram_Custom.AxisY.LabelVisibilityMode = AxisLabelVisibilityMode.Default;
            _ganttDigram_Custom.AxisY.Label.ResolveOverlappingOptions.AllowHide = false;
            _ganttDigram_Custom.DefaultPane.BorderVisible = false;

            // AsisY 시간 라벨링
            for (int i = 0; i < 25; i++)
            {
                int min_hour = i * 60;
                _ganttDigram_Custom.AxisY.CustomLabels.Add(new CustomAxisLabel(String.Format("{0:00}", i).ToString(), min_hour));
            }

            _ganttView_Unlock.BarWidth = 0.4D;
            _ganttView_Unlock.Color = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            _ganttView_Unlock.LinkOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            _ganttView_Unlock.LinkOptions.ColorSource = TaskLinkColorSource.OwnColor;
            _ganttView_Unlock.LinkOptions.Visible = false;
            _series_Unlock.View = _ganttView_Unlock;

            _ganttView_Lock.BarWidth = 0.4D;
            _ganttView_Lock.Color = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(77)))), ((int)(((byte)(82)))));
            _ganttView_Lock.LinkOptions.ColorSource = TaskLinkColorSource.OwnColor;
            _ganttView_Lock.LinkOptions.Visible = false;
            _series_Lock.View = _ganttView_Lock;

            _ganttView_Dummy.BarWidth = 0.1D;
            _ganttView_Dummy.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            _ganttView_Dummy.LinkOptions.ColorSource = TaskLinkColorSource.OwnColor;
            _ganttView_Dummy.LinkOptions.Visible = false;
            _ganttView_Dummy.Border.Color = Color.White;

            _series_Dummy.View = _ganttView_Dummy;
            _series_Dummy.View.Color = Color.White;

            this.ChartControl.Diagram = _ganttDigram_Custom;
            this.ChartControl.SeriesSerializable = new Series[] { _series_Dummy, _series_Unlock, _series_Lock };
            this.ChartControl.Size = new System.Drawing.Size(930, 310);
            this.ChartControl.TabIndex = 0;
            this.ChartControl.Legend.Font = new System.Drawing.Font("Gulim", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChartControl.Legend.Name = "Default Legend";
            this.ChartControl.Legend.TextVisible = false;
            this.ChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.ChartControl.Location = new System.Drawing.Point(20, 90);
            this.ChartControl.Name = "Weeks work Chart";
            this.ChartControl.CrosshairOptions.ShowCrosshairLabels = false;
            this.ChartControl.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
            this.ChartControl.Click += Uc_TabSecurity_Click;
        }


        /// <summary>
        /// Series 데이터를 세팅한다
        /// </summary>
        private static void SetBaseSeries()
        {
            // 언락 바            
            _series_Unlock.ValueScaleType = ScaleType.Numerical;
            _series_Unlock.Name = "Unlock";
            _series_Unlock.ShowInLegend = false;

            // 락 바
            _series_Lock.ValueScaleType = ScaleType.Numerical;
            _series_Lock.Name = "Lock";
            _series_Lock.ShowInLegend = false;

            // 데이터가 존재하지않아도 테이블을 유지시키기 위한 더미 바
            _series_Dummy.ValueScaleType = ScaleType.Numerical;
            _series_Dummy.ShowInLegend = false;

            // 더미 데이터 세팅
            _series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Monday), new double[] { 0, 1440 }));
            _series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Tuesday)));
            _series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Wednesday)));
            _series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Thursday)));
            _series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Friday)));
            _series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Saturday)));
            _series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Sunday)));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 캘린더 버튼 클릭시 Visible On/off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cal_left_Click(object sender, EventArgs e)
        {
            try
            {
                this.calendarControl1.Visible = !calendarControl1.Visible;
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Uc_TabSecurity_Load(object sender, EventArgs e)
        {
            try
            {
                this.calendarControl1.Visible = false;
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }

        /// <summary>
        /// 캘린더 더블클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calendarControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 월요일이 아닌경우
            DateTime currStartDate;
            if (DateTime.Now.DayOfWeek != DayOfWeek.Monday)
            {
                int gap = (calendarControl1.DateTime.DayOfWeek - DayOfWeek.Monday);
                currStartDate = calendarControl1.DateTime.AddDays((-1 * gap));
            }
            // 월요일 인 경우
            else
            {
                currStartDate = calendarControl1.DateTime;
            }

            // 시간 바운더리가 겹치지 않는다면 날짜를 새로 세팅한다
            if (currStartDate.ToString("yyyyMMdd") != _startDate.ToString("yyyyMMdd"))
            {
                SetCalendarInit(calendarControl1.DateTime);
                this.calendarControl1.Visible = false;
            }
        }


        /// <summary>
        /// 폼 전체 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Uc_TabSecurity_Click(object sender, EventArgs e)
        {
            try
            {
                this.calendarControl1.Visible = false;
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }
    }
}
