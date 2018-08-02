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

namespace GreenLock.UC_Controls
{
    public partial class Uc_TabEnergy : UserControl, ILanguage
    {    
        /// <summary>
        /// 프린트 비트맵
        /// </summary>
        private static Bitmap PrintImage { get; set; }

        public Uc_TabEnergy()
        {
            InitializeComponent();
            localization();
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
            //String.Format("{0,10:N3}", calcReduction.UsedKwh)

        
        }

        private void Uc_TabEnergy_Load(object sender, EventArgs e)
        {
          
            

        }
        public void UpdateUI()
        {
            lblEnergyAmt.Text = String.Format("{0,10:N3}", SaveEnergy.Instance.UsedKwh);
            lblCostAmt.Text = String.Format("{0,10:N3}", SaveEnergy.Instance.UsedCost);
            lblCo2Amt.Text = String.Format("{0,10:N3}", SaveEnergy.Instance.Co2);
            lblTreeAmt.Text = String.Format("{0,10:N3}", SaveEnergy.Instance.Tree);

            //lblDate.Left = this.Width / 2 - lblDate.Width / 2;
            lblEnergy.Left = pnlEnergy.Width / 2 - lblEnergy.Width / 2;
            lblEnergyAmt.Left = pnlEnergy.Width / 2 - lblEnergyAmt.Width / 2;

            lblCost.Left = pnlCost.Width / 2 - lblCost.Width / 2;
            lblCostAmt.Left = pnlCost.Width / 2 - lblCostAmt.Width / 2;

            lblCo2.Left = pnlCo2.Width / 2 - lblCo2.Width / 2;
            lblCo2Amt.Left = pnlCo2.Width / 2 - lblCo2Amt.Width / 2;

            lblTree.Left = pnlTree.Width / 2 - lblTree.Width / 2;
            lblTreeAmt.Left = pnlTree.Width / 2 - lblTreeAmt.Width / 2;

           
        }

        private void pbDown_Click(object sender, EventArgs e)
        {

        }

        private void pbPrint_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        Graphics graphics = this.CreateGraphics();
        //        PrintImage = new Bitmap(this.ParentForm.Size.Width, this.ParentForm.Size.Height, graphics);
        //        Graphics clone = Graphics.FromImage(PrintImage);
        //        clone.CopyFromScreen(this.ParentForm.Location.X, this.ParentForm.Location.Y, 0, 0, this.ParentForm.Size);
        //        printPreviewDialog1.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        frmMain._log.write(ex.StackTrace);
        //    }
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
            Bitmap resize = (Bitmap)ResizeImage(PrintImage, new Size(800, 550));
            e.Graphics.DrawImage(resize, 100, 150);
        }
    }
}
