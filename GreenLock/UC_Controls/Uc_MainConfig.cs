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
    public partial class Uc_MainConfig : UserControl, ILanguage
    {
        public Uc_MainConfig()
        {
            InitializeComponent();
            localization();
        }

        private void Uc_MainConfig_Load(object sender, EventArgs e)
        {
            lblTilte.Left = this.Width / 2 - lblTilte.Width / 2;

        }

        private void lblTilte_TextChanged(object sender, EventArgs e)
        {
            lblTilte.Left = this.Width / 2 - lblTilte.Width / 2;
        }

       
        private void Uc_MainConfig_MouseLeave(object sender, EventArgs e)
        {
            if (!RectangleToScreen(ClientRectangle).Contains(Cursor.Position))
            {
                this.BackColor = Color.Transparent;
                lblTilte.ForeColor = Color.White;
            }
        }

        private void Uc_MainConfig_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.ClientRectangle.Contains(new Point(e.X, e.Y)))
            {
                this.BackColor = Color.White;
                lblTilte.ForeColor = ColorTranslator.FromHtml("#1b3547");
            }
        }

        public void localization()
        {
            lblTilte.Text = GreenLock.languages.GreenLock.main_Config;
            lblTilte.Left = this.Width / 2 - lblTilte.Width / 2;
        }

        private void Uc_MainConfig_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
