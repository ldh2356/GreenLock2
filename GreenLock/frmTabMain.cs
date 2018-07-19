using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenLock
{
    public partial class frmTabMain : Form
    {
        public frmTabMain()
        {
            InitializeComponent();
           
        }
        private void setLocalization()
        {
            foreach (Control con in this.Controls)
            {
                ILanguage language = con as ILanguage;
                if (language != null)
                    language.localization();
            }

        }

        private void frmTabMain_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            if (Globals._language.CompareTo("ko-KR") == 0)
            {
                Font underLineFont = new Font(lblKorea.Font, FontStyle.Underline);
                Font regularFont = new Font(lblEnglish.Font, FontStyle.Regular);

                lblKorea.Font = underLineFont;
                lblKorea.ForeColor = Color.White;

                lblEnglish.Font = regularFont;
                lblEnglish.ForeColor = ColorTranslator.FromHtml("#bad9ff");
            }
            else
            {
                Font underLineFont = new Font(lblEnglish.Font, FontStyle.Underline);
                Font regularFont = new Font(lblKorea.Font, FontStyle.Regular);

                lblKorea.Font = regularFont;
                lblKorea.ForeColor = ColorTranslator.FromHtml("#bad9ff");

                lblEnglish.Font = underLineFont;
                lblEnglish.ForeColor = Color.White;
            }

            lblEnergy.Text = GreenLock.languages.GreenLock.main_Energy;
        }

        private void lblKorea_Click(object sender, EventArgs e)
        {
            if (Globals._language.CompareTo("ko-KR") != 0)
            {
                Font underLineFont = new Font(lblEnglish.Font, FontStyle.Underline);
                Font regularFont = new Font(lblKorea.Font, FontStyle.Regular);

                lblKorea.Font = underLineFont;
                lblKorea.ForeColor = Color.White;

                lblEnglish.Font = regularFont;
                lblEnglish.ForeColor = ColorTranslator.FromHtml("#bad9ff");

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ko-KR");
                Globals._language = "ko-KR";
                setLocalization();
            }
        }

        private void lblEnglish_Click(object sender, EventArgs e)
        {
            if (Globals._language.CompareTo("en-US") != 0)
            {
                Font underLineFont = new Font(lblEnglish.Font, FontStyle.Underline);
                Font regularFont = new Font(lblKorea.Font, FontStyle.Regular);

                lblKorea.Font = regularFont;
                lblKorea.ForeColor = ColorTranslator.FromHtml("#bad9ff");

                lblEnglish.Font = underLineFont;
                lblEnglish.ForeColor = Color.White;

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                Globals._language = "en-US";
                setLocalization();
            }
        }

        private void lblEnergy_Click(object sender, EventArgs e)
        {

        }

        private void lblSecurity_Click(object sender, EventArgs e)
        {

        }

        private void lblConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
