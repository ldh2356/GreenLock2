using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace GreenLock.UC_Controls
{
    public partial class Uc_TabMain : UserControl, ILanguage
    {
        private MainType _mainTabType; 
        private Uc_TabEnergy _tabEnergy = new Uc_TabEnergy();
        private Uc_TabSecurity _tabSecurity = new Uc_TabSecurity();
        private Uc_TabConfig _tabConfig = new Uc_TabConfig();

        private Point _myPoint;

        private frmMain _main;

        public frmMain Main
        {
            set
            {
                _main = value;
            }
        }

        public MainType MainTabType
        {
            set
            {
                _mainTabType = value;
            }
        }

        public Uc_TabMain()
        {
            InitializeComponent();
        }

        private void SetKorean()
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


        private void SetEnglish()
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

        public void localization()
        {
            lblEnegry.Text = GreenLock.languages.GreenLock.main_Energy1;
            lblSecurity.Text = GreenLock.languages.GreenLock.main_Security1;
            lblConfig.Text = GreenLock.languages.GreenLock.main_Config1;

            if (_mainTabType == MainType.Energy)
            {
                lblEnegry.ForeColor = ColorTranslator.FromHtml("#3EE887");
                lblSecurity.ForeColor = Color.White;
                lblConfig.ForeColor = Color.White;
            }
            else if (_mainTabType == MainType.Security)
            {
                lblEnegry.ForeColor = Color.White;
                lblSecurity.ForeColor = ColorTranslator.FromHtml("#3EE887");             
                lblConfig.ForeColor = Color.White;
            }
            else
            {
                lblEnegry.ForeColor = Color.White;
                lblSecurity.ForeColor = Color.White;
                lblConfig.ForeColor = ColorTranslator.FromHtml("#3EE887");
            }
            //throw new NotImplementedException();
        }

        private void setLocalization()
        {
            localization();
        }


        private void Uc_TabMain_Load(object sender, EventArgs e)
        {
            localization();


            if (Globals._language.CompareTo("ko-KR") == 0)
            {
                Font underLineFont = new Font(lblKorea.Font, FontStyle.Underline);
                Font regularFont = new Font(lblEnglish.Font, FontStyle.Regular);

                lblKorea.Font = underLineFont;
                lblKorea.ForeColor = Color.White;

                lblEnglish.Font = regularFont;
                lblEnglish.ForeColor = ColorTranslator.FromHtml("#bad9ff");
                SetKorean();
            }
            else
            {
                Font underLineFont = new Font(lblEnglish.Font, FontStyle.Regular);
                Font regularFont = new Font(lblKorea.Font, FontStyle.Regular);

                lblKorea.Font = regularFont;
                lblKorea.ForeColor = ColorTranslator.FromHtml("#bad9ff");

                lblEnglish.Font = underLineFont;
                lblEnglish.ForeColor = Color.White;
                SetEnglish();
            }

            this.pnlMain.Controls.Clear();
            if (_mainTabType == MainType.Energy)
            {
                this.pnlMain.Controls.Add(_tabEnergy);
            }
            else if (_mainTabType == MainType.Security)
                this.pnlMain.Controls.Add(_tabSecurity);
            else if (_mainTabType == MainType.Config)
            {
                _tabConfig.Main = _main;
                this.pnlMain.Controls.Add(_tabConfig);
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {

        }

        private void lblKorea_Click(object sender, EventArgs e)
        {
            if (Globals._language.CompareTo("ko-KR") != 0)
            {
                SetKorean();
            }
        }

        private void lblEnglish_Click(object sender, EventArgs e)
        {
            if (Globals._language.CompareTo("en-US") != 0)
            {
                SetEnglish();
            }
        }



        private void lblEnegry_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            UC_TestControl con = new UC_TestControl();
            //_tabEnergy.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(con);
            _mainTabType = MainType.Energy;

            localization();
        }

        private void lblSecurity_Click(object sender, EventArgs e)
        {
           this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(_tabSecurity);
           _mainTabType = MainType.Security;
           localization();

        }

        private void lblConfig_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            //_tabConfig.Dock = DockStyle.Fill;
            _tabConfig.Main = _main;
            this.pnlMain.Controls.Add(_tabConfig);
            _mainTabType = MainType.Config;
            localization();

        }

        private void Uc_TabMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //현재 마우스 좌표를 저장한다.
                _myPoint.X = e.X;
                _myPoint.Y = e.Y;
            }

        }

        private void Uc_TabMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //현재 마우스 좌표와 저장된 마우스 좌표의 차이만큼 이동 시킨다.
                this._main.Location = new Point(this._main.Location.X + (e.X - _myPoint.X)

                , this._main.Location.Y + (e.Y - _myPoint.Y));
            }
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // for perf cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED

                //cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                //2017.12.15 Modify by C.P.K (GMP-4716)
                cp.Style |= 0x20000; // WS_MINIMIZEBOX
                cp.ClassStyle |= 0x8; // CS_DBLCLKS

                return cp;
            }
        }

    }
}
