using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GreenLock.UC_Controls
{
    public partial class Uc_TabMain : UserControl, ILanguage
    {
        private MainType _mainTabType; 
        private Uc_TabEnergy _tabEnergy = new Uc_TabEnergy();
        private Uc_TabSecurity _tabSecurity = new Uc_TabSecurity();
        private Uc_TabConfig _tabConfig = new Uc_TabConfig();

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
            localization();

           
        }

        public void localization()
        {
            lblEnegry.Text = GreenLock.languages.GreenLock.main_Energy1;
            lblSecurity.Text = GreenLock.languages.GreenLock.main_Security1;
            lblConfig.Text = GreenLock.languages.GreenLock.main_Config1;



            //lblEnegry.ForeColor = ColorTranslator.FromHtml("#3EE887");
            //lblSecurity.ForeColor = ColorTranslator.FromHtml("#3EE887");
            lblConfig.ForeColor = ColorTranslator.FromHtml("#3EE887");

            //throw new NotImplementedException();
        }

        private void Uc_TabMain_Load(object sender, EventArgs e)
        {

          

            this.pnlMain.Controls.Clear();
            if (_mainTabType == MainType.Energy)
            {
                _tabEnergy.Dock = DockStyle.Fill;
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

        }

        private void lblEnglish_Click(object sender, EventArgs e)
        {

        }
    }
}
