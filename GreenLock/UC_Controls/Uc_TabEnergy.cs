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
    public partial class Uc_TabEnergy : UserControl, ILanguage
    {
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
            lblEnergyAmt.Text = SaveEnergy.Instance.UsedKwh.ToString();
            lblCostAmt.Text = SaveEnergy.Instance.UsedCost.ToString();
            lblCo2Amt.Text = SaveEnergy.Instance.Co2.ToString();
            lblTree.Text = SaveEnergy.Instance.Tree.ToString();
        }

        private void Uc_TabEnergy_Load(object sender, EventArgs e)
        {

        }
    }
}
