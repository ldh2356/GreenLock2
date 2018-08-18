using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form2 : Form
    { 


        public static event Microsoft.Win32.PowerModeChangedEventHandler PowerModeChanged;

        public Form2()
        {
            InitializeComponent();

            ///this.label2.Text = "aaaabbbbccccddddeee";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UserControl1 uc = new UserControl1();
            this.Controls.Add(uc);
            timer1.Start();

            PowerModeChanged += Form2_PowerModeChanged;
        }

        private void Form2_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            Debug.Write(e.Mode.ToString());
            //throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PowerStatus si = SystemInformation.PowerStatus;

            //Debug.WriteLine(si.PowerLineStatus);

        }
    }


   
}
