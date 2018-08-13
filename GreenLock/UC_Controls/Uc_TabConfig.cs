using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace GreenLock.UC_Controls
{
    public partial class Uc_TabConfig : UserControl, ILanguage
    {

        private frmMain _main;

        public frmMain Main
        {
            set
            {
                _main = value;
            }
        }
        public Uc_TabConfig()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Globals._language);

            localization();
        }

        public void localization()
        {
            lblConnet.Text = GreenLock.languages.GreenLock.pairing;
            lblSleepMode.Text = GreenLock.languages.GreenLock.mode;
            lblPassword.Text = GreenLock.languages.GreenLock.userPw;
            lblEnergy.Text = GreenLock.languages.GreenLock.energy;

            lblAddress.Text = GreenLock.languages.GreenLock.address;

            btnOK.Text = GreenLock.languages.GreenLock.StringConfirm;
            btnCancel.Text = GreenLock.languages.GreenLock.StringCancel;
            rbSleepModeMonitor.Text = GreenLock.languages.GreenLock.monitorMode;
            rbSleepModeAll.Text = GreenLock.languages.GreenLock.pcMode;

            lblNotice.Text = GreenLock.languages.GreenLock.notice;
            lblNotice1.Text = GreenLock.languages.GreenLock.notice1;
            lblNotice2.Text = GreenLock.languages.GreenLock.notice2;

            lblCharge.Text = GreenLock.languages.GreenLock.electric_Charge;
            
        }

        private void Uc_TabConfig_Load(object sender, EventArgs e)
        {
            btnOK.BackColor = ColorTranslator.FromHtml("#2C53CC");
            btnCancel.BackColor = ColorTranslator.FromHtml("#A6A6A6");

           

            initSetting();
        }

        private void initSetting()
        {
            AppConfig.Instance.LoadFromFile();
            if (AppConfig.Instance.Model == 0)
            {
                this.rbAdroid.Checked = true;
                this.rbIOS.Checked = false;
            }
            else
            {
                this.rbAdroid.Checked = false;
                this.rbIOS.Checked = true;
            }

            string[] textResult = AppConfig.Instance.DeviceAddress.Split(':');

            if (textResult != null)
            {
                txtAddress1.Text = textResult[0];
                txtAddress2.Text = textResult[1];
                txtAddress3.Text = textResult[2];
                txtAddress4.Text = textResult[3];
                txtAddress5.Text = textResult[4];
                txtAddress6.Text = textResult[5];
            }


            if (AppConfig.Instance.SleepMode == 0)
            {
                this.rbSleepModeMonitor.Checked = true;
                this.rbSleepModeAll.Checked = false;
            }
            else
            {
                this.rbSleepModeMonitor.Checked = false;
                this.rbSleepModeAll.Checked = true;
            }

            this.txtPassword.Text = AppConfig.Instance.UserPassword;

            this.txtPower.Text = AppConfig.Instance.PcPower.ToString(); 
            this.txtCost.Text = AppConfig.Instance.ElecRate.ToString();
         
            this.cbUnit.Text = AppConfig.Instance.ElecUnit.ToString();

            btnOK.Focus();
        }

        private void rbAdroid_Click(object sender, EventArgs e)
        {
            AppConfig.Instance.Model = 0;
        }

        private void rbIOS_Click(object sender, EventArgs e)
        {
            AppConfig.Instance.Model = 1;
        }

        private void txtAddress1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                if (txt.Text.Length == 2) // 이벤트 핸들러 설정된 컨트롤의 글자입력수가 3글자이면,
                {
                    SendKeys.Send("{tab}"); // Tab키를 실행하고 Focus를 설정. (Tab Order 기준으로 이동함)
                    txt.Focus();
                }
            }
            catch (Exception ex)
            {
             frmMain._log.write(ex.Message);
            }
        }

        private void rbSleepModeMonitor_Click(object sender, EventArgs e)
        {
            AppConfig.Instance.SleepMode = 0;
        }

        private void rbSleepModeAll_Click(object sender, EventArgs e)
        {
            AppConfig.Instance.SleepMode = 1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(txtAddress1.Text)) || (txtAddress1.TextLength < 2)) { MessageBox.Show(GreenLock.languages.GreenLock.bluetooth_setting_msg + "\n 1st text box"); return; }
            if ((String.IsNullOrEmpty(txtAddress2.Text)) || (txtAddress2.TextLength < 2)) { MessageBox.Show(GreenLock.languages.GreenLock.bluetooth_setting_msg + "\n 2nd text box"); return; }
            if ((String.IsNullOrEmpty(txtAddress3.Text)) || (txtAddress3.TextLength < 2)) { MessageBox.Show(GreenLock.languages.GreenLock.bluetooth_setting_msg + "\n 3rd text box"); return; }
            if ((String.IsNullOrEmpty(txtAddress4.Text)) || (txtAddress4.TextLength < 2)) { MessageBox.Show(GreenLock.languages.GreenLock.bluetooth_setting_msg + "\n 4th text box"); return; }
            if ((String.IsNullOrEmpty(txtAddress5.Text)) || (txtAddress5.TextLength < 2)) { MessageBox.Show(GreenLock.languages.GreenLock.bluetooth_setting_msg + "\n 5th text box"); return; }
            if ((String.IsNullOrEmpty(txtAddress6.Text)) || (txtAddress6.TextLength < 2)) { MessageBox.Show(GreenLock.languages.GreenLock.bluetooth_setting_msg + "\n 6th text box"); return; }


            _main.Bt32FeetDevice.Stop();

            _main.RemoveEvent();
           

            string[] AddArray = { txtAddress1.Text, txtAddress2.Text, txtAddress3.Text, txtAddress4.Text, txtAddress5.Text, txtAddress6.Text };
            string macAddr = String.Join(":", AddArray);
            AppConfig.Instance.DeviceAddress = macAddr;

            _main.Bt32FeetDevice.GetBtAddr(macAddr);
            _main.Bt32FeetDevice.Start();

            _main.AddEvent();

            if (this.rbAdroid.Checked == true)
                AppConfig.Instance.Model = 0;
            else
                AppConfig.Instance.Model = 1;


            if (this.rbSleepModeMonitor.Checked == true)
                AppConfig.Instance.SleepMode = 0;
            else
                AppConfig.Instance.SleepMode = 1;


            AppConfig.Instance.SaveToFile();

            MessageBox.Show(GreenLock.languages.GreenLock.ConfigChanged);

        }

        /// <summary>
        /// 환경 설정 취소 - 기본 저장된 정보로 다시 세팅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            initSetting();
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Instance.ElecUnit = this.cbUnit.Text;
        }

        private void Uc_TabConfig_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void Uc_TabConfig_Paint(object sender, PaintEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Globals._language);
            localization();
        }
    };
}
