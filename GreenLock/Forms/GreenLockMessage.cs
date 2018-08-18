using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenLock.Forms
{
    public partial class GreenLockMessage : System.Windows.Forms.Form
    {
        public GreenLockMessage()
        {
            InitializeComponent();
        }


        public void SetMessage(string text)
        {
            this.lblMessage.Text = text;
        }

        private void GreenLockMessage_Load(object sender, EventArgs e)
        {
            //btnOk.Text = GreenLock.languages.GreenLock.StringConfirm;
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
