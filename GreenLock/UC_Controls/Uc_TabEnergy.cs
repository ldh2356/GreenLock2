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
            lblTreeAmt.Text = SaveEnergy.Instance.Tree.ToString();
        }

        private void Uc_TabEnergy_Load(object sender, EventArgs e)
        {
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

        private void pnlCost_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlEnergy_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
