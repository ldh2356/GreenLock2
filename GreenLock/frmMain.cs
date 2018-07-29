using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GreenLock.Repository;
using System.Data.Entity;
using GreenLock.Dispatcher;
using GreenLock.Common;

namespace GreenLock
{
    public enum MainType
    {
        Energy,
        Security,
        Config
    }

    public partial class frmMain : Form
    {
       

        #region "로컬 변수"

        /// <summary>
        ///  블루투스 통신 클래스 
        /// </summary>
        Bt32FeetDevice _bt32FeetDevice = new Bt32FeetDevice();

        CalcReduction _calcReduction = new CalcReduction();

        TimeSheetDispatcher _dispatcher = new TimeSheetDispatcher();

        public static Log _log = new Log();

        public bool _screensaverStatus = false;
        public bool _screensaverPasswordflag = false;

        private string _macAddress = string.Empty;

        FormScreenSaver _screenSaver1;
        FormScreenSaver _screenSaver2;

        Point _myPoint;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,

            /// <summary>
            /// Vertical height of entire desktop in pixels
            DESKTOPVERTRES = 117,
            /// <summary>
            /// Horizontal width of entire desktop in pixels
            /// </summary>
            DESKTOPHORZRES = 118,
            // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        }


        public enum SystemMetric
        {
            SM_CXSCREEN = 0,  // 0x00
            SM_CYSCREEN = 1,  // 0x01
            SM_CXVSCROLL = 2,  // 0x02
            SM_CYHSCROLL = 3,  // 0x03
            SM_CXVIRTUALSCREEN = 78,
            SM_CYVIRTUALSCREEN = 79
        }

        public Bt32FeetDevice Bt32FeetDevice
        {
            get
            {
                return _bt32FeetDevice;
            }
        }

        #endregion



        public frmMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.uc_MainEnergy1.Parent = this;

            Globals._language = Thread.CurrentThread.CurrentCulture.Name;

            if (Globals._language.CompareTo("ko-KR") == 0)
            {
                Font underLineFont = new Font(lblKorea.Font,  FontStyle.Underline);
                Font regularFont = new Font(lblEnglish.Font, FontStyle.Regular);

                lblKorea.Font = underLineFont;
                lblKorea.ForeColor = Color.White;

                lblEnglish.Font = regularFont;
                lblEnglish.ForeColor = ColorTranslator.FromHtml("#bad9ff");          
            }
            else
            {
                Font underLineFont = new Font(lblEnglish.Font, FontStyle.Underline);
                Font regularFont = new Font(lblKorea.Font, FontStyle.Regular);

                lblKorea.Font = regularFont;
                lblKorea.ForeColor = ColorTranslator.FromHtml("#bad9ff");  
               
                lblEnglish.Font = underLineFont;
                lblEnglish.ForeColor = Color.White;

            }
            lblDate.Text = DateTime.Now.Year +  "."  + DateTime.Now.Month +  "."   + DateTime.Now.Day + " (" + DateTime.Now.ToString("ddd", new CultureInfo(Globals._language)) +  ")";




            // 모니터 정확 해상도를 받기위한 DPI 세터 추가
            DpiManager.SetDpiAwareness();

            //1. 자동 업데이트 추가 
            if (UpdateChecker.NeedUpdate(this))
            {
                if (MessageBox.Show(GreenLock.languages.GreenLock.ClientUpdatedCheck, GreenLock.languages.GreenLock.StringConfirm, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    UpdateChecker.RunClientUpdater();
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
            }

            //2. GreenLock 가동   
            AppConfig.Instance.LoadFromFile();
           
            _macAddress = AppConfig.Instance.DeviceAddress;
            _macAddress = "84:2E:27:6B:70:12";
           

            if (_macAddress != "00:00:00:00:00:00")
            {
                _bt32FeetDevice.GetBtAddr(_macAddress);
                _bt32FeetDevice.Start();
            }
            else
            {
                MessageBox.Show(GreenLock.languages.GreenLock.execution_caution_msg, GreenLock.languages.GreenLock.execution_caution);
            }

            //3. 에너지 세팅 
            _calcReduction.OnMainUpdate += _calcReduction_OnMainUpdate;

            //4. DB세팅
            DataBaseHelper helper = new DataBaseHelper();
            helper.EnsureSQLiteFileCreated();
        

        }

        private IDisposable greenlockEntities()
        {
            throw new NotImplementedException();
        }

        #region "에너지 절감량"
        private void _calcReduction_OnMainUpdate(object sender, EventArgs e)
        {

            //throw new NotImplementedException();
        }
        #endregion 

        #region "블루투스 통신 이벤트"

        /// <summary>
        /// UUID 로 발견한 장비기 있는 경우 1초에 한번 발생 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt32FeetDevice_OnIsSevrice(object sender, EventArgs e)
        {          
            // 언락 데이터 타임 기록
            _dispatcher.SetTimeTable(_macAddress, 0);


            Debug.WriteLine("Bt32FeetDevice_OnIsSevrice");
            Debug.WriteLine("_screensaverStatus== " + _screensaverStatus + " _screensaverPasswordflag  ==" + _screensaverPasswordflag);

            _screensaverPasswordflag = false;
            //스크린 종료
            if (_screensaverStatus == true)
            {
                // 언락 새로운 시작 기록
                _dispatcher.SetTimeTable(_macAddress, 0, true);


                // 종료시 end 타임 업데이트 후  새로 row 삽입
                _dispatcher.SetTimeTable(_macAddress, 0);
                _dispatcher.SetTimeTable(_macAddress, 1 , true);

                this.Invoke(new System.Windows.Forms.MethodInvoker(delegate ()
                {
                    //this.sendPCEnergy("3");

                    // 컴퓨터 절전해제
                    Service.mouse_event(Service.MOUSE_MOVE, 0, 1, 0, UIntPtr.Zero);
                    Thread.Sleep(40);
                    Service.mouse_event(Service.MOUSE_MOVE, 0, -1, 0, UIntPtr.Zero);

                    _calcReduction.OperationStartTime = DateTime.Now;
                    _calcReduction.ScreenEndTime = DateTime.Now;


                    //화면보호기 종료
                    screenSaverAllStop();
                    Service.AlertSoundStop();

                    _screensaverStatus = false;
                    Service.SendMessage(this.Handle.ToInt32(), Service.WM_SYSCOMMAND, Service.SC_MONITORPOWER, Service.MONITOR_ON);
                }));
            }
        }

        /// <summary>
        /// 서비스를 시작하지 못하는 경우 발생 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt32FeetDevice_OnNotService(object sender, EventArgs e)
        {
            // 락 데이터 타임 기록
            _dispatcher.SetTimeTable(_macAddress, 1);

            Debug.WriteLine("Bt32FeetDevice_OnNotService");
            Debug.WriteLine("_screensaverStatus== " + _screensaverStatus + " _screensaverPasswordflag  ==" + _screensaverPasswordflag);
            //화면보호기 시작
            if (_screensaverStatus == false && _screensaverPasswordflag == false)
            {
                // 락 새로운 시작 기록
                _dispatcher.SetTimeTable(_macAddress, 1, true);

                this.Invoke(new System.Windows.Forms.MethodInvoker(delegate ()
                {
                    _calcReduction.OperationEndTime = DateTime.Now;

                    //this.sendPCEnergy("2");

                    _screensaverStatus = true;
                    ScreenSaverSetting();
                    Thread.Sleep(100);
               

                    _calcReduction.ScreenStartTime = DateTime.Now;

                    //모니터 + 본체 절전
                    if (AppConfig.Instance.SleepMode == 1)
                    {
                        System.Windows.Forms.Application.SetSuspendState(System.Windows.Forms.PowerState.Suspend, false, false);
                    }
                    // 모니터 절전 진입
                    else
                    {
                        Service.SendMessage(this.Handle.ToInt32(), Service.WM_SYSCOMMAND, Service.SC_MONITORPOWER, Service.MONITOR_OFF);
                    }
                }));
            }
        }

       
        /// <summary>
        /// 블루투스 오류 이벤트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt32FeetDevice_OnErrorService(object sender, EventArgs e)
        {
            //Debug.WriteLine("오류로 ??? ==>  잠김 풀림");
        }


        #endregion 

        #region "이벤트"


        /// <summary>
        /// 메인 폼 로드시 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            lblDate.Left = this.Width / 2 - lblDate.Width / 2;
            lblCoypright.Left = this.Width / 2 - lblCoypright.Width / 2;
        }


        /// <summary>
        /// 한국어 클릭시 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblKorea_Click(object sender, EventArgs e)
        {
            if (Globals._language.CompareTo("ko-KR") != 0)
            {
                Font underLineFont = new Font(lblEnglish.Font, FontStyle.Underline);
                Font regularFont = new Font(lblKorea.Font, FontStyle.Regular);

                lblKorea.Font = underLineFont;
                lblKorea.ForeColor = Color.White;

                lblEnglish.Font = regularFont;
                lblEnglish.ForeColor = ColorTranslator.FromHtml("#bad9ff");

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ko-KR");
                Globals._language = "ko-KR";
                setLocalization();
            }   
        }


        /// <summary>
        /// 영어 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblEnglish_Click(object sender, EventArgs e)
        {
            if (Globals._language.CompareTo("en-US") != 0)
            {
                Font underLineFont = new Font(lblEnglish.Font, FontStyle.Underline);
                Font regularFont = new Font(lblKorea.Font, FontStyle.Regular);

                lblKorea.Font = regularFont;
                lblKorea.ForeColor = ColorTranslator.FromHtml("#bad9ff");

                lblEnglish.Font = underLineFont;
                lblEnglish.ForeColor = Color.White;

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                Globals._language = "en-US";
                setLocalization();
            }

        }


        /// <summary>
        /// 닫기 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 에너지 절감량 클릭시 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uc_MainEnergy_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
            this.Controls.Clear();
            this.BackgroundImage = null;
            GreenLock.UC_Controls.Uc_TabMain uc_TabMain = new UC_Controls.Uc_TabMain();
            uc_TabMain.Main = this;
            uc_TabMain.MainTabType = MainType.Energy;
            this.Controls.Add(uc_TabMain);
        }

        /// <summary>
        /// 보안 클릭시 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uc_MainSecurity_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
            this.Controls.Clear();
            this.BackgroundImage = null;
            GreenLock.UC_Controls.Uc_TabMain uc_TabMain = new UC_Controls.Uc_TabMain();
            uc_TabMain.Main = this;
            uc_TabMain.MainTabType = MainType.Security;
            this.Controls.Add(uc_TabMain);
        }

        /// <summary>
        /// 환경 설정 클릭시 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uc_MainConfig_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
            this.Controls.Clear();
            this.BackgroundImage = null;
            GreenLock.UC_Controls.Uc_TabMain uc_TabMain = new UC_Controls.Uc_TabMain();
            uc_TabMain.Main = this;
            uc_TabMain.MainTabType = MainType.Config;
            
            this.Controls.Add((Control)uc_TabMain);
        } 
        #endregion

        #region "로컬 함수"
        private void setLocalization()
        {
            foreach (Control con in this.Controls)
            {
                ILanguage language = con as ILanguage;
                if (language != null)
                    language.localization();
            }
               
        }

        public void screenSaverAllStop()
        {
            try
            {
                if (_screenSaver1 != null)
                {
                    _screenSaver1.Close();
                    _screenSaver1 = null;

                    if (_screenSaver2 != null)
                    {
                        _screenSaver2.Close();
                        _screenSaver2 = null;
                    }
                }

                //MainForm.log.write("screenSaver != null" + (screenSaver != null));
                //MainForm.log.write("screenSaver2 != null" + (screenSaver2 != null));

                _screensaverStatus = false;
                Service.AlertSoundStop();
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.Message);
            }
        }

        void ScreenSaverSetting()
        {
            try
            {             
                Screen[] screen = Screen.AllScreens;

                // 듀얼모니터를 사용하지않는 경우
                if (screen.GetLength(0) != 2)
                {
                    DualMonitor(screen, 0);
                }
                else // 듀얼모니터를 사용하는 경우
                {
                    DualMonitor(screen, 0);
                    DualMonitor(screen, 1);
                }
              
            }
            catch (ObjectDisposedException ex)
            {
                frmMain._log.write(ex.Message);
            }    
        }

        public void SetFormScreenSaver(FormScreenSaver screenSaver)
        {
            try
            {
                this._screenSaver1 = screenSaver;
            }
            catch (Exception ex)
            {
                _log.write(ex.Message);
            }
        }
        void DualMonitor(Screen[] screen, int primaryNum)
        {
            try
            {
                Point point;

                int screen1 = 0;
                int screen2 = 1;

                if (screen[primaryNum] == screen[screen1])
                {
                    _screenSaver1 = new FormScreenSaver(this);

                    point = new Point(screen[screen1].Bounds.Location.X, screen[screen1].Bounds.Location.Y);
                    _screenSaver1.Location = point;

                    //GIF파일의 크기를 메인모니터 크기로 조정
                    //screenSaver.pb_screenSaver.Size = new Size(screen[screen1].WorkingArea.Width, screen[screen1].WorkingArea.Height);

                    _screenSaver1.Size = new Size(100,100);
                    //screenSaver.Size = new Size(screen[screen1].Bounds.Width, screen[screen1].Bounds.Height);
                    _screenSaver1.Show(this);
                    //KeyboardHooking.TaskBarHide();
                }
                else
                {
                    //전체 해상도를 가져온다. 
                    int nVirtualWidth = GetSystemMetrics((int)SystemMetric.SM_CXVIRTUALSCREEN);
                    int nVirtualHeight = GetSystemMetrics((int)SystemMetric.SM_CYVIRTUALSCREEN);

                    //Primary monitor 해상도만 가져온다. 
                    int nPrimaryWidth = GetSystemMetrics((int)SystemMetric.SM_CXSCREEN);
                    int nPrimaryHeight = GetSystemMetrics((int)SystemMetric.SM_CYSCREEN);

                    //서브모니터의 해상도는 
                    int nSubWidth = nVirtualWidth - nPrimaryWidth;
                    int nSubHeight = nVirtualHeight - nPrimaryHeight;

                    //Primary 를 기준으로 좌표 값이 오는듯합. 실제 해상도랑 틀려서 보정해줌. ??? 뭔지 모르겠다. 
                    int Scale = nSubWidth / nPrimaryWidth;

                    Graphics g = Graphics.FromHwnd(IntPtr.Zero);
                    IntPtr desktop = g.GetHdc();

                    int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);


                    //int a = GetSystemMetrics(SM_CXVIRTUALSCREEN);
                    _screenSaver2 = new FormScreenSaver(this);

                    point = new Point(screen[screen2].Bounds.Location.X, screen[screen2].Bounds.Location.Y);
                    _screenSaver2.Location = point;

                    //GIF파일의 크기를 서브모니터 크기로 조정
                    _screenSaver2.Size = new Size(screen[screen2].Bounds.Width, screen[screen2].Bounds.Height);
                    _screenSaver2.Show(this);
                }
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.Message);
            }
        }

        /// <summary>
        /// 블루투스 이벤트 등록
        /// </summary>
        public void AddEvent()
        {
            _bt32FeetDevice.OnErrorService += Bt32FeetDevice_OnErrorService;
            _bt32FeetDevice.OnIsSevrice += Bt32FeetDevice_OnIsSevrice;
            _bt32FeetDevice.OnNotService += Bt32FeetDevice_OnNotService;
        }

        /// <summary>
        /// 불루투스 이벤트 제거 
        /// </summary>
        public void RemoveEvent()
        {
            _bt32FeetDevice.OnErrorService -= Bt32FeetDevice_OnErrorService;
            _bt32FeetDevice.OnIsSevrice -= Bt32FeetDevice_OnIsSevrice;
            _bt32FeetDevice.OnNotService -= Bt32FeetDevice_OnNotService;
        }

        #endregion

        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;
            //const UInt32 WM_NCLBUTTONDBLCLK = 0x0203;

            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MAXIMIZE = 0xF030;
            const int SC_RESTORE = 0xF120;

            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;

            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;

            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>() {
                {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                {HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                {HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
                {HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                {HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                {HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                {HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) }
                };

                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }



            if (!handled)
                base.WndProc(ref m);
        }



        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //현재 마우스 좌표와 저장된 마우스 좌표의 차이만큼 이동 시킨다.
                this.Location = new Point(this.Location.X + (e.X - _myPoint.X)

                , this.Location.Y + (e.Y - _myPoint.Y));
            }
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //현재 마우스 좌표를 저장한다.
                _myPoint.X = e.X;
                _myPoint.Y = e.Y;
            }
        }
    }
}
