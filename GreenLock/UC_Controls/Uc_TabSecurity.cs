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

namespace GreenLock.UC_Controls
{
    public partial class Uc_TabSecurity : UserControl
    {
        /// <summary>
        /// GanttView 언락 프라퍼티
        /// </summary>
        private static OverlappedGanttSeriesView GanttView_Unlock { get; set; } = new OverlappedGanttSeriesView();

        /// <summary>
        /// GanttView 락 프라퍼티
        /// </summary>
        private static OverlappedGanttSeriesView GanttView_Lock { get; set; } = new OverlappedGanttSeriesView();

        /// <summary>
        /// GanttView 더미 프라퍼티
        /// </summary>
        private static OverlappedGanttSeriesView GanttView_Dummy { get; set; } = new OverlappedGanttSeriesView();

        /// <summary>
        /// Service 언락 바
        /// </summary>
        private static Series Series_Unlock { get; set; } = new Series();

        /// <summary>
        /// Service 락 바
        /// </summary>
        private static Series Series_Lock { get; set; } = new Series();

        /// <summary>
        /// Service 더미 바
        /// </summary>
        private static Series Series_Dummy { get; set; } = new Series();

        /// <summary>
        /// 다이어 그램
        /// </summary>
        private static GanttDiagram GanttDigram_Custom = new GanttDiagram();


        /// <summary>
        /// 생성자
        /// </summary>
        public Uc_TabSecurity()
        {
            InitializeComponent();
            this.ChartControl = new DevExpress.XtraCharts.ChartControl();

            SetBaseSeries();
            SetBeginInit();
            this.SuspendLayout();

            SetChartInit();
            
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


        /// <summary>
        /// Init 데이터를 초기화한다
        /// </summary>
        private void SetBeginInit()
        {
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GanttDigram_Custom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Series_Unlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Series_Lock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GanttView_Unlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GanttView_Lock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GanttView_Dummy)).BeginInit();
            
        }

        /// <summary>
        /// Init 을 중지한다
        /// </summary>
        private void SetEndBeginInit()
        {
            ((System.ComponentModel.ISupportInitialize)(GanttDigram_Custom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GanttView_Unlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GanttView_Lock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Series_Unlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Series_Lock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Series_Dummy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartControl)).EndInit();
        }

        /// <summary>
        /// ChartControl 을 초기화한다
        /// </summary>
        private void SetChartInit()
        {
            this.ChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            GanttDigram_Custom.AxisX.CrosshairAxisLabelOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            GanttDigram_Custom.AxisX.GridLines.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            GanttDigram_Custom.AxisX.InterlacedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            GanttDigram_Custom.AxisX.Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            GanttDigram_Custom.AxisX.Label.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            GanttDigram_Custom.AxisX.MinorCount = 1;
            GanttDigram_Custom.AxisX.NumericScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.None;
            GanttDigram_Custom.AxisX.NumericScaleOptions.AutoGrid = false;
            GanttDigram_Custom.AxisX.NumericScaleOptions.GridSpacing = 0.4D;
            GanttDigram_Custom.AxisX.NumericScaleOptions.ProcessMissingPoints = DevExpress.XtraCharts.ProcessMissingPointsMode.InsertEmptyPoints;
            GanttDigram_Custom.AxisX.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Automatic;
            GanttDigram_Custom.AxisX.Thickness = 1;
            GanttDigram_Custom.AxisX.Tickmarks.MinorVisible = false;
            GanttDigram_Custom.AxisX.Tickmarks.Visible = false;
            GanttDigram_Custom.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            GanttDigram_Custom.AxisX.VisibleInPanesSerializable = "-1";
            GanttDigram_Custom.AxisX.WholeRange.Auto = false;
            GanttDigram_Custom.AxisX.WholeRange.AutoSideMargins = false;
            GanttDigram_Custom.AxisX.WholeRange.MaxValueSerializable = "5.4";
            GanttDigram_Custom.AxisX.WholeRange.MinValueSerializable = "0";
            GanttDigram_Custom.AxisX.WholeRange.SideMarginsValue = 1D;
            GanttDigram_Custom.AxisX.QualitativeScaleOptions.AutoGrid = false;
            GanttDigram_Custom.AxisY.GridLines.LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped;
            GanttDigram_Custom.AxisY.GridLines.Visible = false;
            GanttDigram_Custom.AxisY.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            GanttDigram_Custom.AxisY.Label.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            GanttDigram_Custom.AxisY.Label.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GanttDigram_Custom.AxisY.Label.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            GanttDigram_Custom.AxisY.MinorCount = 1;
            GanttDigram_Custom.AxisY.Thickness = 1;
            GanttDigram_Custom.AxisY.Tickmarks.MinorVisible = false;
            GanttDigram_Custom.AxisY.Tickmarks.Visible = false;
            GanttDigram_Custom.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            GanttDigram_Custom.AxisY.VisibleInPanesSerializable = "-1";
            GanttDigram_Custom.AxisY.LabelVisibilityMode = AxisLabelVisibilityMode.Default;
            GanttDigram_Custom.AxisY.Label.ResolveOverlappingOptions.AllowHide = false;
            GanttDigram_Custom.DefaultPane.BorderVisible = false;

            // AsisY 시간 라벨링
            for (int i = 0; i < 25; i++)
            {
                int min_hour = i * 60;
                GanttDigram_Custom.AxisY.CustomLabels.Add(new CustomAxisLabel(String.Format("{0:00}", i).ToString(), min_hour));
            }

            GanttView_Unlock.BarWidth = 0.4D;
            GanttView_Unlock.Color = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            GanttView_Unlock.LinkOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            GanttView_Unlock.LinkOptions.ColorSource = TaskLinkColorSource.OwnColor;
            GanttView_Unlock.LinkOptions.Visible = false;
            Series_Unlock.View = GanttView_Unlock;

            GanttView_Lock.BarWidth = 0.4D;
            GanttView_Lock.Color = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(77)))), ((int)(((byte)(82)))));
            GanttView_Lock.LinkOptions.ColorSource = TaskLinkColorSource.OwnColor;
            GanttView_Lock.LinkOptions.Visible = false;
            Series_Lock.View = GanttView_Lock;

            GanttView_Dummy.BarWidth = 0.1D;
            GanttView_Dummy.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            GanttView_Dummy.LinkOptions.ColorSource = TaskLinkColorSource.OwnColor;
            GanttView_Dummy.LinkOptions.Visible = false;
            GanttView_Dummy.Border.Color = Color.White;

            Series_Dummy.View = GanttView_Dummy;
            Series_Dummy.View.Color = Color.White;

            this.ChartControl.Diagram = GanttDigram_Custom;
            this.ChartControl.SeriesSerializable = new Series[] { Series_Dummy, Series_Unlock, Series_Lock };
            this.ChartControl.Size = new System.Drawing.Size(930, 348);
            this.ChartControl.TabIndex = 0;
            this.ChartControl.Legend.Font = new System.Drawing.Font("Gulim", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChartControl.Legend.Name = "Default Legend";
            this.ChartControl.Legend.TextVisible = false;
            this.ChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.ChartControl.Location = new System.Drawing.Point(20, 24);
            this.ChartControl.Name = "Weeks work Chart";
            this.ChartControl.CrosshairOptions.ShowCrosshairLabels = false;
            this.ChartControl.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
        }


        /// <summary>
        /// Series 데이터를 세팅한다
        /// </summary>
        private static void SetBaseSeries()
        {
            // 언락 바            
            Series_Unlock.ValueScaleType = ScaleType.Numerical;
            Series_Unlock.Name = "Unlock";
            Series_Unlock.ShowInLegend = false;

            // 락 바
            Series_Lock.ValueScaleType = ScaleType.Numerical;
            Series_Lock.Name = "Lock";
            Series_Lock.ShowInLegend = false;

            // 데이터가 존재하지않아도 테이블을 유지시키기 위한 더미 바
            Series_Dummy.ValueScaleType = ScaleType.Numerical;
            Series_Dummy.ShowInLegend = false;

            // 더미 데이터 세팅
            Series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Monday), new double[] { 0, 1440 }));
            Series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Tuesday)));
            Series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Wednesday)));
            Series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Thursday)));
            Series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Friday)));
            Series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Saturday)));
            Series_Dummy.Points.Add(new SeriesPoint(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(DayOfWeek.Sunday)));
        }
    }
}
