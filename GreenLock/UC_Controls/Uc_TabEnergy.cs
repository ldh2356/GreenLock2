using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Threading;
using System.Globalization;

namespace GreenLock.UC_Controls
{
    public partial class Uc_TabEnergy : UserControl, ILanguage
    {
        /// <summary>
        /// 프린트 비트맵
        /// </summary>
        /// 
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        private static Bitmap PrintImage { get; set; }

        public Uc_TabEnergy()
        {

            InitializeComponent();


           
            //Globals._language = "ko-KR";
            localization();
            UpdateUI();
        }


        public void localization()
        {
            lblEnergy.Text = GreenLock.languages.GreenLock.power;
            lblCost.Text = GreenLock.languages.GreenLock.cost;
            lblCo2.Text = GreenLock.languages.GreenLock.co2;
            lblTree.Text = GreenLock.languages.GreenLock.tree;
            //throw new NotImplementedException();
        }

        

        private void Uc_TabEnergy_Paint(object sender, PaintEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Globals._language);
            localization();
            UpdateUI();

            //String.Format("{0,10:N3}", calcReduction.UsedKwh)


        }

        private void Uc_TabEnergy_Load(object sender, EventArgs e)
        {
          
            

        }
        public void UpdateUI()
        {
            lblEnergyAmt.Text = String.Format("{0,10:N3}", SaveEnergy.Instance.UsedKwh).Trim();
            lblCostAmt.Text = String.Format("{0,10:N3}", SaveEnergy.Instance.UsedCost).Trim();
            lblCo2Amt.Text = String.Format("{0,10:N3}", SaveEnergy.Instance.Co2).Trim();
            lblTreeAmt.Text = String.Format("{0,10:N3}", SaveEnergy.Instance.Tree).Trim();

            //lblDate.Left = this.Width / 2 - lblDate.Width / 2;
            lblEnergy.Left = pnlEnergy.Width / 2 - lblEnergy.Width / 2;
            //lblEnergyAmt.Left = pnlEnergy.Width / 2 - lblEnergyAmt.Width / 2 - 20;

            lblCost.Left = pnlCost.Width / 2 - lblCost.Width / 2;
            //lblCostAmt.Left = pnlCost.Width / 2 - lblCostAmt.Width / 2 - 20;

            lblCo2.Left = pnlCo2.Width / 2 - lblCo2.Width / 2;
            //lblCo2Amt.Left = pnlCo2.Width / 2 - lblCo2Amt.Width / 2 - 20;

            lblTree.Left = pnlTree.Width / 2 - lblTree.Width / 2;
            //lblTreeAmt.Left = pnlTree.Width / 2 - lblTreeAmt.Width / 2 - 20;


            pictureBox1.Left = pnlEnergy.Width / 2 - pictureBox1.Width / 2;
            pictureBox2.Left = pnlCost.Width / 2 - pictureBox2.Width / 2;
            pictureBox3.Left = pnlCo2.Width / 2 - pictureBox3.Width / 2;
            pictureBox4.Left = pnlTree.Width / 2 - pictureBox4.Width / 2;
        }

        private void pbDown_Click(object sender, EventArgs e)
        {
            try
            {
                

                // 디렉토리 체크
                DirectoryInfo excelDir = new DirectoryInfo(languages.GreenLock.Uc_TabSecurity_ExcelFilePath);
                if (!excelDir.Exists)
                    excelDir.Create();

                string fileName = Path.Combine(languages.GreenLock.Uc_TabSecurity_ExcelFilePath, "Energy.xlsx");

                // 임시 파일 스트림 생성
                using (Stream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (ExcelPackage package = new ExcelPackage(fileStream))
                    {
                        // 워크시트 추가
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("에너지절감");

                        // Export
                        string[] backColors = { "#EFF3FB", "#FFFFFF" };
                        int columnCount = 1;

                        // 헤더 추가
                        worksheet.Cells[1, 1].Value = "항목";
                        worksheet.Cells[1, 2].Value = "절감량";
                   

                        // 헤더 색상 및 테두리 설정
                        using (var cells = worksheet.Cells[1, 1, 1, columnCount])
                        {
                            cells.Style.Font.Bold = true;
                            cells.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cells.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#F3F3F3"));
                        }

                        int no = 0;
                        int rowIndex = 0;

                        // 리스트 처리
                     
                         
                           

                            worksheet.Cells[2, 1].Value = "에너지절감량(kwh)";
                            worksheet.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            worksheet.Cells[2, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[2, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                            worksheet.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                            worksheet.Cells[2, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                            worksheet.Cells[2, 2].Value = SaveEnergy.Instance.UsedKwh;
                            worksheet.Cells[2, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[2, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                            worksheet.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                            worksheet.Cells[2, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);


                            worksheet.Cells[3, 1].Value = "전기료절감액(원)";
                            worksheet.Cells[3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            worksheet.Cells[3, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[3, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                            worksheet.Cells[3, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                            worksheet.Cells[3, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                            worksheet.Cells[3, 2].Value = SaveEnergy.Instance.UsedCost;
                            worksheet.Cells[3, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[3, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                            worksheet.Cells[3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                            worksheet.Cells[3, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);


                        worksheet.Cells[4, 1].Value = "C02절감(원)";
                        worksheet.Cells[4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet.Cells[4, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[4, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                        worksheet.Cells[4, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet.Cells[4, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet.Cells[4, 2].Value = SaveEnergy.Instance.Co2;
                        worksheet.Cells[4, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[4, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                        worksheet.Cells[4, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet.Cells[4, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);



                        worksheet.Cells[5, 1].Value = "환경보호(그루)";
                        worksheet.Cells[5, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        worksheet.Cells[5, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[5, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                        worksheet.Cells[5, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet.Cells[5, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet.Cells[5, 2].Value = SaveEnergy.Instance.Tree;
                        worksheet.Cells[5, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[5, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(backColors[no % 2]));
                        worksheet.Cells[5, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        worksheet.Cells[5, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);



                        for (int index = 0; index < 1; index++)
                        {
                            // 폰트 설정 (나눔 고딕)
                            worksheet.Cells[1, index + 1, worksheet.Cells.Rows, index + 1].Style.Font.Name = "NanumGothic";
                            // 컬럼 넓이를 자동 조정
                            worksheet.Column(index + 1).AutoFit();
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

        private void pbPrint_Click(object sender, EventArgs e)
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
                PrintImage.Save("aaa.jpg");
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
        /// 이미지 리사이즈
        /// </summary>
        /// <param name="image"></param>
        /// <param name="size"></param>
        /// <param name="preserveAspectRatio"></param>
        /// <returns></returns>
        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
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
  

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap resize = (Bitmap)ResizeImage(PrintImage, new Size(800, 600));
            //PrintImage.Save("a.jpg");
            e.Graphics.DrawImage(resize, 0, 0);
        }
    }
}
