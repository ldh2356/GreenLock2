using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenLock
{
    public partial class CustomLabel : Label, ILanguage
    {
        public CustomLabel()
        {
            InitializeComponent();
        }

        public void localization()
        {
            //this.Text = ResourceManager.GetString("bluetoothOffMsg", GreenLock.languages.GreenLock.resourceCulture);
            //throw new NotImplementedException();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
