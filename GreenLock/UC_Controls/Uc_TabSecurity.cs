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
using System.Data.Entity.SqlServer;
using System.Reflection;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;

namespace GreenLock.UC_Controls
{
    public partial class Uc_TabSecurity : UserControl, ILanguage
    {
        /// <summary>
        /// 캘린더 갱신 워커
        /// </summary>
        private static BackgroundWorker _calendarRenewWorker = new BackgroundWorker();

        /// <summary>
        /// 사용자 맥 어드레스
        /// </summary>
        private string _macAddress = AppConfig.Instance.DeviceAddress;

        /// <summary>
        /// 프린트 비트맵
        /// </summary>
        private static Bitmap PrintImage { get; set; }


        /// <summary>
        ///  캘린더 모드인지 도표 모드인지
        /// </summary>
        private bool IsGrapth { get; set; } = true;


        /// <summary>
        /// 현재 설정된 언어
        /// </summary>
        private static CultureInfo _currentCulture = new System.Globalization.CultureInfo(Globals._language);


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
        private static DevExpress.XtraCharts.Series _series_Unlock { get; set; } = new DevExpress.XtraCharts.Series();

        /// <summary>
        /// Service 락 바
        /// </summary>
        private static DevExpress.XtraCharts.Series _series_Lock { get; set; } = new DevExpress.XtraCharts.Series();

        /// <summary>
        /// Service 더미 바
        /// </summary>
        private static DevExpress.XtraCharts.Series _series_Dummy { get; set; } = new DevExpress.XtraCharts.Series();

        /// <summary>
        /// 다이어 그램
        /// </summary>
        private static GanttDiagram _ganttDigram_Custom = new GanttDiagram();

        /// <summary>
        /// 라벨 리스트
        /// </summary>
        private static List<SheetLabel> _sheetLabels = new List<SheetLabel>();

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        /// <summary>
        /// 생성자
        /// </summary>
        public Uc_TabSecurity()
        {
            try
            {
                InitializeComponent();
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Globals._language);

                this.ChartControl = new DevExpress.XtraCharts.ChartControl();

                SetBaseSeries();
                SetBeginInit();
                
                this.SuspendLayout();

                SetChartInit();
                calendarControl1.DateTime = DateTime.Now;
                calendarControl1.BringToFront();
                SetCalendarInit(DateTime.Now);
                SetBaseInit();

                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                this.Controls.Add(this.ChartControl);
                this.Margin = new System.Windows.Forms.Padding(0);
                this.Name = "Uc_TabSecurity";
                this.Size = new System.Drawing.Size(992, 672);

                SetEndBeginInit();

                _sheetLabels.Add(new SheetLabel() { Date = label_Monday , Lock = label_Monday_Lock,  Unlock = label_Monday_Unlock , WeekType = DayOfWeek.Monday });
                _sheetLabels.Add(new SheetLabel() { Date = label_Tuesday, Lock = label_Tuesday_Lock, Unlock = label_Tuesday_Unlock, WeekType = DayOfWeek.Tuesday });
                _sheetLabels.Add(new SheetLabel() { Date = label_Wednesday, Lock = label_Wednesday_Lock, Unlock = label_Wednesday_Unlock, WeekType = DayOfWeek.Wednesday });
                _sheetLabels.Add(new SheetLabel() { Date = label_Thursday, Lock = label_Thursday_Lock, Unlock = label_Thursday_Unlock, WeekType = DayOfWeek.Thursday });
                _sheetLabels.Add(new SheetLabel() { Date = label_Friday, Lock = label_Friday_Lock, Unlock = label_Friday_Unlock, WeekType = DayOfWeek.Friday });
                _sheetLabels.Add(new SheetLabel() { Date = label_Saturday, Lock = label_Saturday_Lock, Unlock = label_Saturday_Unlock, WeekType = DayOfWeek.Saturday });
                _sheetLabels.Add(new SheetLabel() { Date = label_Sunday, Lock = label_Sunday_Lock, Unlock = label_Sunday_Unlock, WeekType = DayOfWeek.Sunday });

                this.LeftButtonLabel.Click += leftButton_Click;
                this.RightButtonLabel.Click += rightButton_Click;
                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);                
            }
        }


        /// <summary>
        /// 라벨 UI 세팅
        /// </summary>
        private void SetBaseLabel()
        {
            try
            {
                this.label_Monday_Lock.Text = "0"; this.label_Monday_Unlock.Text = "0";
                this.label_Tuesday_Lock.Text = "0"; this.label_Tuesday_Unlock.Text = "0";
                this.label_Wednesday_Lock.Text = "0"; this.label_Wednesday_Unlock.Text = "0";
                this.label_Thursday_Lock.Text = "0"; this.label_Thursday_Unlock.Text = "0";
                this.label_Friday_Lock.Text = "0"; this.label_Friday_Unlock.Text = "0";
                this.label_Saturday_Lock.Text = "0"; this.label_Saturday_Unlock.Text = "0";
                this.label_Sunday_Lock.Text = "0"; this.label_Sunday_Unlock.Text = "0";

                this.label_Monday_Lock.Tag = DayOfWeek.Monday; this.label_Monday_Unlock.Tag = DayOfWeek.Monday;
                this.label_Tuesday_Lock.Tag = DayOfWeek.Tuesday; this.label_Tuesday_Unlock.Tag = DayOfWeek.Tuesday; 
                this.label_Wednesday_Lock.Tag = DayOfWeek.Wednesday; this.label_Wednesday_Unlock.Tag = DayOfWeek.Wednesday;
                this.label_Thursday_Lock.Tag = DayOfWeek.Thursday; this.label_Thursday_Unlock.Tag = DayOfWeek.Thursday;
                this.label_Friday_Lock.Tag = DayOfWeek.Friday; this.label_Friday_Unlock.Tag = DayOfWeek.Friday;
                this.label_Saturday_Lock.Tag = DayOfWeek.Saturday; this.label_Saturday_Unlock.Tag = DayOfWeek.Saturday;
                this.label_Sunday_Lock.Tag = DayOfWeek.Sunday; this.label_Sunday_Unlock.Tag = DayOfWeek.Sunday;                
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }


        /// <summary>
        /// 기본 UI 세팅 
        /// </summary>
        private void SetBaseInit()
        {
            try
            {
                // 좌측 버튼 라벨                                
                LeftButtonLabel.Text = languages.GreenLock.Uc_TabSecurity_Graph;

                // 우측 버튼 라벨
                RightButtonLabel.Text = languages.GreenLock.Uc_TabSecurity_Sheet;

                SetModeChage();
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
                _startDate = Convert.ToDateTime(StartOfWeek(DateTime.Now, DayOfWeek.Monday).ToString("yyyy-MM-dd 00:00:00"));
                _endDate = Convert.ToDateTime(StartOfWeek(DateTime.Now, DayOfWeek.Monday).AddDays(6).ToString("yyyy-MM-dd 23:59:59"));

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
        public void SetDateTimeData()
        {
            try
            {
                SetBaseLabel();
                
                List<TimeTable> timeSheetOfWeek = _dispatcher.GetTimeTable(_macAddress, _startDate, _endDate);

                _series_Dummy.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Tuesday)));

                // 초기화
                _series_Unlock.Points.Clear();
                _series_Lock.Points.Clear();

                List<DayOfWeek> unLockDayOfWeeks = new List<DayOfWeek>();
                List<DayOfWeek> lockDayOfWeeks = new List<DayOfWeek>();

                double unlockTotalMinute = 0.0;
                double lockTotalMinute = 0.0;

                int avgUnlockStart = 0;
                int avgLockStart = 0;

                foreach (TimeTable day in timeSheetOfWeek)
                {
                    // 제대로 들어가지 않은 데이터에 대해선 무시
                    if (day.EndDate == DateTime.MinValue)
                        continue;

                    // 언락인경우
                    if (day.LockType == 0)
                    {
                        if(day.RegDate.DayOfWeek == (DayOfWeek)this.label_Monday_Unlock.Tag)
                        {
                            this.label_Monday_Unlock.Text = GetSheetElementData(this.label_Monday_Unlock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Tuesday_Unlock.Tag)
                        {
                            this.label_Tuesday_Unlock.Text = GetSheetElementData(this.label_Tuesday_Unlock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Wednesday_Unlock.Tag)
                        {
                            this.label_Wednesday_Unlock.Text = GetSheetElementData(this.label_Wednesday_Unlock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Thursday_Unlock.Tag)
                        {                            
                            this.label_Thursday_Unlock.Text = GetSheetElementData(this.label_Thursday_Unlock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Friday_Unlock.Tag)
                        {
                            this.label_Friday_Unlock.Text = GetSheetElementData(this.label_Friday_Unlock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Saturday_Unlock.Tag)
                        {
                            this.label_Saturday_Unlock.Text = GetSheetElementData(this.label_Saturday_Unlock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Sunday_Unlock.Tag)
                        {
                            this.label_Sunday_Unlock.Text = GetSheetElementData(this.label_Sunday_Unlock.Text, day.StartDate, day.EndDate);
                        }

                        // 평균값 계산을 위한 분할
                        if (!unLockDayOfWeeks.Contains(day.RegDate.DayOfWeek))
                        {
                            // 평균 시작시간계산을 위한..
                            avgUnlockStart = avgUnlockStart + Convert.ToInt32(GetDayOfMinute(day.StartDate));
                            unLockDayOfWeeks.Add(day.RegDate.DayOfWeek);
                        }

                        unlockTotalMinute = unlockTotalMinute + GetDayOfMinute(day.EndDate) - GetDayOfMinute(day.StartDate);
                        _series_Unlock.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(day.RegDate.DayOfWeek), new double[] { GetDayOfMinute(day.StartDate), GetDayOfMinute(day.EndDate) }));
                    }
                    // 락인경우 
                    else
                    {
                        if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Monday_Lock.Tag)
                        {
                            this.label_Monday_Lock.Text = GetSheetElementData(this.label_Monday_Lock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Tuesday_Lock.Tag)
                        {
                            this.label_Tuesday_Lock.Text = GetSheetElementData(this.label_Tuesday_Lock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Wednesday_Lock.Tag)
                        {
                            this.label_Wednesday_Lock.Text = GetSheetElementData(this.label_Wednesday_Lock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Thursday_Lock.Tag)
                        {                            
                            this.label_Thursday_Lock.Text = GetSheetElementData(this.label_Thursday_Lock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Friday_Lock.Tag)
                        {                            
                            this.label_Friday_Lock.Text = GetSheetElementData(this.label_Friday_Lock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Saturday_Lock.Tag)
                        {
                            this.label_Saturday_Lock.Text = GetSheetElementData(this.label_Saturday_Lock.Text, day.StartDate, day.EndDate);
                        }
                        else if (day.RegDate.DayOfWeek == (DayOfWeek)this.label_Sunday_Lock.Tag)
                        {
                            this.label_Sunday_Lock.Text = GetSheetElementData(this.label_Sunday_Lock.Text, day.StartDate, day.EndDate);
                        }

                        // 평균값 계산을 위한 분할
                        if (!lockDayOfWeeks.Contains(day.RegDate.DayOfWeek))
                        {
                            // 평균 시작시간계산을 위한..
                            avgLockStart = avgLockStart + Convert.ToInt32(GetDayOfMinute(day.StartDate));
                            lockDayOfWeeks.Add(day.RegDate.DayOfWeek);
                        }

                        lockTotalMinute = lockTotalMinute + GetDayOfMinute(day.EndDate) - GetDayOfMinute(day.StartDate);
                        _series_Lock.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(day.RegDate.DayOfWeek), new double[] { GetDayOfMinute(day.StartDate), GetDayOfMinute(day.EndDate) }));
                    }
                }


                this.label_Monday.Text = $"{_startDate.ToString("yyyy.MM.dd ")} ({_currentCulture.DateTimeFormat.GetShortestDayName(_startDate.DayOfWeek)})";
                this.label_Tuesday.Text = $"{_startDate.AddDays(1).ToString("yyyy.MM.dd ")} ({_currentCulture.DateTimeFormat.GetShortestDayName(_startDate.AddDays(1).DayOfWeek)})";
                this.label_Wednesday.Text = $"{_startDate.AddDays(2).ToString("yyyy.MM.dd ")} ({_currentCulture.DateTimeFormat.GetShortestDayName(_startDate.AddDays(2).DayOfWeek)})";
                this.label_Thursday.Text = $"{_startDate.AddDays(3).ToString("yyyy.MM.dd ")} ({_currentCulture.DateTimeFormat.GetShortestDayName(_startDate.AddDays(3).DayOfWeek)})";
                this.label_Friday.Text = $"{_startDate.AddDays(4).ToString("yyyy.MM.dd ")} ({_currentCulture.DateTimeFormat.GetShortestDayName(_startDate.AddDays(4).DayOfWeek)})";
                this.label_Saturday.Text = $"{_startDate.AddDays(5).ToString("yyyy.MM.dd ")} ({_currentCulture.DateTimeFormat.GetShortestDayName(_startDate.AddDays(5).DayOfWeek)})";
                this.label_Sunday.Text = $"{_startDate.AddDays(6).ToString("yyyy.MM.dd ")} ({_currentCulture.DateTimeFormat.GetShortestDayName(_startDate.AddDays(6).DayOfWeek)})";


                // 언락 평균값계산
                int resultUnlok = 0;
                if (unLockDayOfWeeks.Count == 0)
                {
                    labelUnlockAvg.Text = "0hr";
                }
                else
                {
                    resultUnlok = ((avgUnlockStart / unLockDayOfWeeks.Count) / 60);
                    labelUnlockAvg.Text = $"{ Math.Round(unlockTotalMinute / 60,1) }hr";
                }

                // 락 평균값 계산
                if (lockDayOfWeeks.Count == 0)
                {
                    labelockAvg.Text = "0hr";
                }
                else
                {
                    labelockAvg.Text = $"{ Math.Round((lockTotalMinute) / 60, 1) }hr";
                }

                string resultUnlockString = "";
                // 언락 시작 시간 평균 계산
                if (unLockDayOfWeeks.Count == 0)
                {
                    resultUnlockString = "-";
                }
                else
                {
                    int resultUnlock = ((avgUnlockStart / unLockDayOfWeeks.Count) / 60);
                    DateTime StartAvg = DateTime.Parse($"{string.Format("{0:00}", resultUnlock.ToString())}:00");
                    string AmPmUnlock = StartAvg.ToString("tt", CultureInfo.InvariantCulture).ToLower();
                    string StartAvgParse = StartAvg.ToString("hh");

                    if (StartAvgParse[0].Equals('0'))
                    {
                        resultUnlockString = $"{StartAvgParse[1]} {AmPmUnlock}";
                    }
                    else
                    {
                        resultUnlockString = $"{StartAvgParse} {AmPmUnlock}";
                    }
                }

                // 락 시작 시간 평균 계산
                string resultLockString = "";
                if (lockDayOfWeeks.Count == 0)
                {
                    resultLockString = "-";
                }
                else
                {
                    // 락 시작 시간 평균 계산
                    int resultlock = ((avgLockStart / lockDayOfWeeks.Count) / 60);
                    DateTime StartLockAvg = DateTime.Parse($"{string.Format("{0:00}", resultlock.ToString())}:00");
                    string AmPmLock = StartLockAvg.ToString("tt", CultureInfo.InvariantCulture).ToLower();
                    string StartAvgLockParse = StartLockAvg.ToString("hh");

                    if (StartAvgLockParse[0].Equals('0'))
                    {
                        resultLockString = $"{StartAvgLockParse[1]} {AmPmLock}";
                    }
                    else
                    {
                        resultLockString = $"{StartAvgLockParse} {AmPmLock}";
                    }
                }

                // 라벨에 평균데이터 삽입
                LabelAvgStartEnd.Text = $"Average Unlock Start: {resultUnlockString}  / Average Lock Start: {resultLockString}";
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }


        /// <summary>
        /// 시트 데이터 값을 계산한다 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private string GetSheetElementData(string text, DateTime? startDate, DateTime endDate)
        {
            string result = "";
            try
            {
                result = (Math.Round((double.Parse(text) + (GetDayOfMinute(endDate) - GetDayOfMinute(startDate)) / 60) , 2)).ToString();
            }
            catch (Exception ex)
            {
                result = "0";
                frmMain._log.write(ex.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// 하루의 시간을 계산한다
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private static double GetDayOfMinute(DateTime? startDate)
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
        /// 하루의 시간을 계산한다
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private double GetDayOfHour(DateTime? startDate)
        {
            double result = 0.0;
            try
            {
                if (startDate != null)
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
                _series_Unlock.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Monday), new double[] { Convert.ToDateTime(day.StartDate).Minute, Convert.ToDateTime(day.EndDate).Minute }));
            }
            // 락인경우 
            else
            {
                _series_Lock.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Monday), new double[] { Convert.ToDateTime(day.StartDate).Minute, Convert.ToDateTime(day.EndDate).Minute }));
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
            _ganttDigram_Custom.AxisX.Label.Font = new System.Drawing.Font("Malgun Gothic", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            _ganttDigram_Custom.AxisY.Label.Font = new System.Drawing.Font("Malgun Gothic", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            _ganttView_Unlock.Color = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(77)))), ((int)(((byte)(82)))));
            _ganttView_Unlock.LinkOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            _ganttView_Unlock.LinkOptions.ColorSource = TaskLinkColorSource.OwnColor;
            _ganttView_Unlock.LinkOptions.Visible = false;
            _series_Unlock.View = _ganttView_Unlock;

            _ganttView_Lock.BarWidth = 0.4D;
            _ganttView_Lock.Color = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
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
            this.ChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] { _series_Dummy, _series_Unlock, _series_Lock };
            this.ChartControl.Size = new System.Drawing.Size((this.Size.Width - 40), Convert.ToInt32((this.Size.Height / 1.7)));
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
            this.ChartControl.CrosshairOptions.ShowArgumentLine = true;
            this.ChartControl.CrosshairOptions.ShowValueLine = true;
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
            _series_Dummy.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Monday), new double[] { 0, 1440 }));
            _series_Dummy.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Tuesday)));
            _series_Dummy.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Wednesday)));
            _series_Dummy.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Thursday)));
            _series_Dummy.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Friday)));
            _series_Dummy.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Saturday)));
            _series_Dummy.Points.Add(new SeriesPoint(_currentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Sunday)));
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
            SetChoiceCalendar();
        }


        public static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetChoiceCalendar()
        {
            _startDate = Convert.ToDateTime(StartOfWeek(calendarControl1.DateTime, DayOfWeek.Monday).ToString("yyyy-MM-dd 00:00:00"));
            _endDate = Convert.ToDateTime(StartOfWeek(calendarControl1.DateTime, DayOfWeek.Monday).AddDays(6).ToString("yyyy-MM-dd 23:59:59"));

            this.calendarControl1.Visible = false;

            // 라벨을 세팅한다
            Lable_StartDate.Text = _startDate.ToString("yyyy.MM.dd");
            Lable_EndDate.Text = _endDate.ToString("yyyy.MM.dd");
            this.calendarControl1.Visible = false;

            SetDateTimeData();
        }


        void SetBackGroundRenew(object sender, DoWorkEventArgs e)
        {
            SetChoiceCalendar();
            Thread.Sleep(2 * 1000);
            SetBackGroundRenew(sender, e);
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 그래프보기 버튼 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftButton_Click(object sender, EventArgs e)
        {
            if (!IsGrapth)
            {
                IsGrapth = true;
            }

            SetModeChage();
        }



        /// <summary>
        /// 도표 버튼 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightButton_Click(object sender, EventArgs e)
        {
            if (IsGrapth)
            {
                IsGrapth = false;
            }

            SetModeChage();
        }


        /// <summary>
        /// 모드를 체인지한다
        /// </summary>
        private void SetModeChage()
        {
            try
            {
                // 그래프 모드일때
                if (IsGrapth)
                {
                    // 좌측 버튼 세팅
                    this.leftButton.BackgroundImage = global::GreenLock.Properties.Resources.blueButton;     
                    LeftButtonLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(81)))), ((int)(((byte)(203)))));
                    LeftButtonLabel.ForeColor = Color.White;    
                    
                    // 우측 버튼 세팅
                    this.rightButton.BackgroundImage = global::GreenLock.Properties.Resources.whiteButton;
                    RightButtonLabel.BackColor = Color.White;
                    RightButtonLabel.ForeColor = Color.Gray;

                    this.label_Monday.Visible = false; this.label_Monday_Lock.Visible = false; this.label_Monday_Unlock.Visible = false;
                    this.label_Tuesday.Visible = false; this.label_Tuesday_Lock.Visible = false; this.label_Tuesday_Unlock.Visible = false;
                    this.label_Wednesday.Visible = false; this.label_Wednesday_Lock.Visible = false; this.label_Wednesday_Unlock.Visible = false;
                    this.label_Thursday.Visible = false; this.label_Thursday_Lock.Visible = false; this.label_Thursday_Unlock.Visible = false;
                    this.label_Friday.Visible = false; this.label_Friday_Lock.Visible = false; this.label_Friday_Unlock.Visible = false;
                    this.label_Saturday.Visible = false; this.label_Saturday_Lock.Visible = false; this.label_Saturday_Unlock.Visible = false;
                    this.label_Sunday.Visible = false; this.label_Sunday_Lock.Visible = false; this.label_Sunday_Unlock.Visible = false;

                    // 시트 감춤
                    Sheet.Visible = false;
                }
                // 도표 모드일때
                else
                {
                    // 좌측 버튼 세팅
                    this.leftButton.BackgroundImage = global::GreenLock.Properties.Resources.whiteButton;
                    LeftButtonLabel.BackColor = Color.White;
                    LeftButtonLabel.ForeColor = Color.Gray;

                    // 우측 버튼 세팅
                    this.rightButton.BackgroundImage = global::GreenLock.Properties.Resources.blueButton;
                    RightButtonLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(81)))), ((int)(((byte)(203)))));
                    RightButtonLabel.ForeColor = Color.White;
                    
                    this.label_Monday.Visible = true; this.label_Monday_Lock.Visible = true; this.label_Monday_Unlock.Visible = true;
                    this.label_Tuesday.Visible = true; this.label_Tuesday_Lock.Visible = true; this.label_Tuesday_Unlock.Visible = true;
                    this.label_Wednesday.Visible = true; this.label_Wednesday_Lock.Visible = true; this.label_Wednesday_Unlock.Visible = true;
                    this.label_Thursday.Visible = true; this.label_Thursday_Lock.Visible = true; this.label_Thursday_Unlock.Visible = true;
                    this.label_Friday.Visible = true; this.label_Friday_Lock.Visible = true; this.label_Friday_Unlock.Visible = true;
                    this.label_Saturday.Visible = true; this.label_Saturday_Lock.Visible = true; this.label_Saturday_Unlock.Visible = true;
                    this.label_Sunday.Visible = true; this.label_Sunday_Lock.Visible = true; this.label_Sunday_Unlock.Visible = true;

                    // 시트 보임
                    Sheet.Visible = true;
                }

            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }

        private void LeftButtonLabel_Click(object sender, EventArgs e)
        {
            if (IsGrapth)
            {
                IsGrapth = false;
            }

            SetModeChage();
        }

        private void RightButtonLabel_Click(object sender, EventArgs e)
        {
            if (IsGrapth)
            {
                IsGrapth = false;
            }

            SetModeChage();
        }


        /// <summary>
        /// 엑셀 익스포트시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                List<TimeTable> timeTable = _dispatcher.GetTimeTable(_macAddress, _startDate, _endDate);

                // 디렉토리 체크
                DirectoryInfo excelDir = new DirectoryInfo(languages.GreenLock.Uc_TabSecurity_ExcelFilePath);
                if (!excelDir.Exists)
                    excelDir.Create();

                string fileName = Path.Combine(languages.GreenLock.Uc_TabSecurity_ExcelFilePath, $"{DateTime.Now.ToString("yyyy-MM-dd-hhmmss")}.xlsx");

                // 임시 파일 스트림 생성
                using (Stream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (ExcelPackage package = new ExcelPackage(fileStream))
                    {
                        // 워크시트 추가
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(languages.GreenLock.Uc_TabSecurity_Excel_WorkSheet_Total);

                        // Export
                        string[] backColors = { "#EFF3FB", "#FFFFFF" };
                        int columnCount = 5;

                        // 최상단 헤더 추가
                        worksheet.Cells["A1:E1"].Merge = true;
                        worksheet.Cells[1, 1].Value = languages.GreenLock.Uc_TabSecurity_Excel_Sheet_Title_1;
                        worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Row(1).Height = 40;

                        // 헤더 색상 및 테두리 설정
                        using (var cells = worksheet.Cells[1, 1, 1, columnCount])
                        {
                            cells.Style.Font.Bold = true;
                            cells.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cells.Style.Fill.BackgroundColor.SetColor(Color.White);
                        }

                        // 헤더 컬럼 추가
                        worksheet.Cells[2, 1].Value = languages.GreenLock.Uc_TabSecurity_Regdate;
                        worksheet.Cells[2, 2].Value = languages.GreenLock.Uc_TabSecurity_LockType;
                        worksheet.Cells[2, 3].Value = languages.GreenLock.Uc_TabSecurity_StartDate;
                        worksheet.Cells[2, 4].Value = languages.GreenLock.Uc_TabSecurity_EndDate;
                        worksheet.Cells[2, 5].Value = languages.GreenLock.Uc_TabSecurity_Sum;


                        // 헤더 색상 및 테두리 설정
                        using (var cells = worksheet.Cells["A2:E2"])
                        {
                            cells.Style.Font.Bold = true;
                            cells.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            cells.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#F3F3F3"));
                        }

                        int no = 1;
                        int rowIndex = 1;

                        var timeTableDictinct = timeTable.GroupBy(x => x.StartDate).Select(y => y.FirstOrDefault());

                        DateTime lastStartDate = DateTime.Now;

                        // 리스트 처리
                        foreach (TimeTable table in timeTableDictinct)
                        {
                            // 이전 데이터의 시작일과 기록된 시작일이 같을수가 없음으로 제외한다
                            if(lastStartDate.ToString("yyyy-MM-dd HH:mm:ss") == Convert.ToDateTime(table.StartDate).ToString("yyyy-MM-dd HH:mm:ss"))
                            {
                                continue;
                            }
                            // 아닌 경우 데이터를 보관한다
                            else
                            {
                                lastStartDate = Convert.ToDateTime(table.StartDate);
                            }
                                

                            if (table.EndDate == DateTime.MinValue)
                                continue;

                            no = no + 1;
                            rowIndex = rowIndex + 1;
                         
                            worksheet.Cells[rowIndex + 1, 1].Value = table.RegDate.ToString("yyyy-MM-dd HH:mm:ss");
                            worksheet.Cells[rowIndex + 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            worksheet.Cells[rowIndex + 1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowIndex + 1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                            worksheet.Cells[rowIndex + 1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                            worksheet.Cells[rowIndex + 1, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                            worksheet.Cells[rowIndex + 1, 2].Value = (table.LockType == 0) ? languages.GreenLock.Uc_TabSecurity_Unlock : languages.GreenLock.Uc_TabSecurity_Lock;
                            worksheet.Cells[rowIndex + 1, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowIndex + 1, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                            worksheet.Cells[rowIndex + 1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                            worksheet.Cells[rowIndex + 1, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                      
                            worksheet.Cells[rowIndex + 1, 3].Value = (table.StartDate != null ) ? Convert.ToDateTime(table.StartDate).ToString("yyyy-MM-dd HH:mm:ss") : "-";
                            worksheet.Cells[rowIndex + 1, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowIndex + 1, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                            worksheet.Cells[rowIndex + 1, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                            worksheet.Cells[rowIndex + 1, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                            worksheet.Cells[rowIndex + 1, 4].Value = (table.EndDate != null) ? Convert.ToDateTime(table.EndDate).ToString("yyyy-MM-dd HH:mm:ss") : "-";
                            worksheet.Cells[rowIndex + 1, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowIndex + 1, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                            worksheet.Cells[rowIndex + 1, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                            worksheet.Cells[rowIndex + 1, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                            worksheet.Cells[rowIndex + 1, 5].Value = Math.Round( ((GetDayOfMinute(table.EndDate) - GetDayOfMinute(table.StartDate)) / 60) ,2);
                            worksheet.Cells[rowIndex + 1, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[rowIndex + 1, 5].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                            worksheet.Cells[rowIndex + 1, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                            worksheet.Cells[rowIndex + 1, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }

                        // 모든 컬럼에 대해서 처리
                        for (int index = 0; index < columnCount; index++)
                        {
                            // 폰트 설정 (나눔 고딕)
                            worksheet.Cells[1, index + 1, worksheet.Cells.Rows, index + 1].Style.Font.Name = "NanumGothic";
                            // 컬럼 넓이를 자동 조정
                            worksheet.Column(index + 1).AutoFit();
                        }


                        // 워크시트 추가
                        ExcelWorksheet worksheet_sheet = package.Workbook.Worksheets.Add(languages.GreenLock.Uc_TabSecurity_Sheet);
                        columnCount = 8;

                        // 최상단 헤더 추가
                        worksheet_sheet.Cells["A1:C1"].Merge = true;
                        worksheet_sheet.Cells[1, 1].Value = languages.GreenLock.Uc_TabSecurity_Excel_Sheet_Title_2;
                        worksheet_sheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet_sheet.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet_sheet.Row(1).Height = 40;

                        // 최상단 헤더 색상 및 테두리 설정
                        using (var cells = worksheet_sheet.Cells[1, 1, 1, 3])
                        {
                            cells.Style.Font.Bold = true;
                            cells.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cells.Style.Fill.BackgroundColor.SetColor(Color.White);
                        }


                        // 헤더 추가
                        worksheet_sheet.Cells[2, 1].Value = "";
                        worksheet_sheet.Cells[2, 2].Value = languages.GreenLock.Uc_TabSecurity_Lock;
                        worksheet_sheet.Cells[2, 3].Value = languages.GreenLock.Uc_TabSecurity_Unlock;


                        // 헤더 색상 및 테두리 설정
                        using (var cells = worksheet_sheet.Cells["A2:C2"])
                        {
                            cells.Style.Font.Bold = true;
                            cells.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            cells.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#F3F3F3"));
                        }


                        worksheet_sheet.Cells[3, 1].Value = label_Monday.Text;
                        worksheet_sheet.Cells[3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[3, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[3, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[3, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[3, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[3, 2].Value = label_Monday_Lock.Text;
                        worksheet_sheet.Cells[3, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[3, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[3, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[3, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[3, 3].Value = label_Monday_Unlock.Text;
                        worksheet_sheet.Cells[3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[3, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[3, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[3, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[3, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);


                        worksheet_sheet.Cells[4, 1].Value = label_Tuesday.Text;
                        worksheet_sheet.Cells[4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[4, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[4, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[1]));
                        worksheet_sheet.Cells[4, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[4, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[4, 2].Value = label_Tuesday_Lock.Text;
                        worksheet_sheet.Cells[4, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[4, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[4, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[1]));
                        worksheet_sheet.Cells[4, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[4, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[4, 3].Value = label_Tuesday_Unlock.Text;
                        worksheet_sheet.Cells[4, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[4, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[4, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[1]));
                        worksheet_sheet.Cells[4, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[4, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);



                        worksheet_sheet.Cells[5, 1].Value = label_Wednesday.Text;
                        worksheet_sheet.Cells[5, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[5, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[5, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[5, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[5, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[5, 2].Value = label_Wednesday_Lock.Text;
                        worksheet_sheet.Cells[5, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[5, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[5, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[5, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[5, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[5, 3].Value = label_Wednesday_Unlock.Text;
                        worksheet_sheet.Cells[5, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[5, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[5, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[5, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[5, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);


                        worksheet_sheet.Cells[6, 1].Value = label_Thursday.Text;
                        worksheet_sheet.Cells[6, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[6, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[6, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[1]));
                        worksheet_sheet.Cells[6, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[6, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[6, 2].Value = label_Thursday_Lock.Text;
                        worksheet_sheet.Cells[6, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[6, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[6, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[1]));
                        worksheet_sheet.Cells[6, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[6, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[6, 3].Value = label_Thursday_Unlock.Text;
                        worksheet_sheet.Cells[6, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[6, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[6, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[1]));
                        worksheet_sheet.Cells[6, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[6, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);


                        worksheet_sheet.Cells[7, 1].Value = label_Friday.Text;
                        worksheet_sheet.Cells[7, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[7, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[7, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[7, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[7, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[7, 2].Value = label_Friday_Lock.Text;
                        worksheet_sheet.Cells[7, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[7, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[7, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[7, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[7, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[7, 3].Value = label_Friday_Unlock.Text;
                        worksheet_sheet.Cells[7, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[7, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[7, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[7, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[7, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);



                        worksheet_sheet.Cells[8, 1].Value = label_Saturday.Text;
                        worksheet_sheet.Cells[8, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[8, 1].Style.Font.Color.SetColor(Color.FromArgb(89, 157, 207));
                        worksheet_sheet.Cells[8, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[8, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[1]));
                        worksheet_sheet.Cells[8, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[8, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[8, 2].Value = label_Saturday_Lock.Text;
                        worksheet_sheet.Cells[8, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[8, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[8, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[1]));
                        worksheet_sheet.Cells[8, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[8, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[8, 3].Value = label_Saturday_Unlock.Text;
                        worksheet_sheet.Cells[8, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[8, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[8, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[1]));
                        worksheet_sheet.Cells[8, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[8, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);



                        worksheet_sheet.Cells[9, 1].Value = label_Sunday.Text;
                        worksheet_sheet.Cells[9, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[9, 1].Style.Font.Color.SetColor(Color.FromArgb(189, 89, 100));
                        worksheet_sheet.Cells[9, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[9, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[9, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[9, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[9, 2].Value = label_Sunday_Lock.Text;
                        worksheet_sheet.Cells[9, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[9, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[9, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[9, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[9, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet_sheet.Cells[9, 3].Value = label_Sunday_Unlock.Text;
                        worksheet_sheet.Cells[9, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet_sheet.Cells[9, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_sheet.Cells[9, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[0]));
                        worksheet_sheet.Cells[9, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet_sheet.Cells[9, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        // 모든 컬럼에 대해서 처리
                        for (int index = 0; index < 3; index++)
                        {
                            // 폰트 설정 (나눔 고딕)
                            worksheet_sheet.Cells[1, index + 1, worksheet.Cells.Rows, index + 1].Style.Font.Name = "NanumGothic";
                            // 컬럼 넓이를 자동 조정
                            worksheet_sheet.Column(index + 1).AutoFit();
                        }

                        // 내용 저장
                        package.Save();
                    }
                    fileStream.Dispose();

                    Process.Start(fileName);
                }
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);                
            }
        }


        /// <summary>
        /// 프린트 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics mygraphics = this.CreateGraphics();
                Size s = this.Size;
                PrintImage = new Bitmap(s.Width, s.Height, mygraphics);
                Graphics memoryGraphics = Graphics.FromImage(PrintImage);
                IntPtr dc1 = mygraphics.GetHdc();
                IntPtr dc2 = memoryGraphics.GetHdc();
                BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
               
                mygraphics.ReleaseHdc(dc1);
                memoryGraphics.ReleaseHdc(dc2);
                
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }


        /// <summary>
        /// 프린팅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap resize = (Bitmap)ResizeImage(PrintImage, new Size(700, 500));
            e.Graphics.DrawImage(resize, 50,150);
        }


        /// <summary>
        /// 이미지 리사이즈
        /// </summary>
        /// <param name="image"></param>
        /// <param name="size"></param>
        /// <param name="preserveAspectRatio"></param>
        /// <returns></returns>
        public static Image ResizeImage(Image image, Size size,bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        void ILanguage.localization()
        {

            LeftButtonLabel.Text = languages.GreenLock.Uc_TabSecurity_Graph;

            // 우측 버튼 라벨
            RightButtonLabel.Text = languages.GreenLock.Uc_TabSecurity_Sheet;
            //throw new NotImplementedException();
        }

        private void label_Monday_Unlock_Click(object sender, EventArgs e)
        {

        }

        private void Uc_TabSecurity_Paint(object sender, PaintEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Globals._language);
        }
    }


    /// <summary>
    /// 도표로 보기 라벨 관리 클래스
    /// </summary>
    public class SheetLabel
    {
        /// <summary>
        /// 요일 표시 라벨
        /// </summary>
        public Label Date { get; set; }

        /// <summary>
        /// 언락 라벨
        /// </summary>
        public Label Unlock { get; set; }

        /// <summary>
        /// 락 라벨
        /// </summary>
        public Label Lock { get; set; }

        /// <summary>
        /// 구분 을 위한 타입
        /// </summary>
        public DayOfWeek WeekType { get; set; }
    }

}
