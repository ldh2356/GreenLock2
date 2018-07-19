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
    public partial class Uc_TabConfig : UserControl, ILanguage
    {
        public Uc_TabConfig()
        {
            InitializeComponent();
        }

        public void localization()
        {
            lblConnet.Text = GreenLock.languages.GreenLock.pairing;
            lblSleepMode.Text = GreenLock.languages.GreenLock.mode;
            lblPassword.Text = GreenLock.languages.GreenLock.userPw;
            lblEnergy.Text = GreenLock.languages.GreenLock.energy;

            lblAddress.Text = GreenLock.languages.GreenLock.address;

            btnOK.Text = GreenLock.languages.GreenLock.StringConfirm;
            rbSleepModeMonitor.Text = GreenLock.languages.GreenLock.monitorMode;
            rbSleepModeAll.Text = GreenLock.languages.GreenLock.pcMode;

        }

        private void Uc_TabConfig_Load(object sender, EventArgs e)
        {
            btnOK.BackColor = ColorTranslator.FromHtml("#2C53CC");
            localization();
        }

     
    }
}
