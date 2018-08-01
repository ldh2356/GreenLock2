using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenLock
{
    public partial class CustomLabel : Label, ILanguage
    {
        public CustomLabel()
        {
            InitializeComponent();
        }

        public void localization()
        {
            //this.Text = ResourceManager.GetString("bluetoothOffMsg", GreenLock.languages.GreenLock.resourceCulture);
            //throw new NotImplementedException();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);


            pe.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            base.OnPaint(pe);
            // 부서 | 회사 
            
            //StringFormat drawFormat = new StringFormat();
            //drawFormat.Alignment = StringAlignment.Near;
            //drawFormat.LineAlignment = StringAlignment.Center;
            //.Trimming = StringTrimming.EllipsisCharacter;
            pe.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.ClientRectangle);
            //pe.Graphics.DrawRectangle(new Pen(Color.FromArgb(0xff, 0xd4, 0xd4, 0xd4), 1), _itemRect);
        }
    }
}
