﻿using System;
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
    public partial class Uc_MainEnergy : UserControl, ILanguage, IControlInit
    {
        public Uc_MainEnergy()
        {
            InitializeComponent();
            localization();

        }

        private void Uc_MainEnergy_Load(object sender, EventArgs e)
        {
            lblTilte.Left = this.Width / 2 - lblTilte.Width / 2;
           
        }

        private void lblTilte_TextChanged(object sender, EventArgs e)
        {
            lblTilte.Left = this.Width / 2 - lblTilte.Width / 2;
        }

      

        private void Uc_MainEnergy_MouseLeave(object sender, EventArgs e)
        {
            if (!RectangleToScreen(ClientRectangle).Contains(Cursor.Position))
            {
                this.BackColor = Color.Transparent;
                lblTilte.ForeColor = Color.White;
            }
        }

        public void InitControl()
        {
            this.BackColor = Color.Transparent;
            lblTilte.ForeColor = Color.White;
        }

        private void Uc_MainEnergy_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.ClientRectangle.Contains(new Point(e.X, e.Y)))
            {
                this.BackColor = Color.White;
                lblTilte.ForeColor = ColorTranslator.FromHtml("#1b3547");
            }
        }

        public void localization()
        {
            lblTilte.Text = GreenLock.languages.GreenLock.main_Energy;
            lblTilte.Left = this.Width / 2 - lblTilte.Width / 2;
            //throw new NotImplementedException();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
