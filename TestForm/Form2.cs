using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TestForm
{
    public partial class Form2 : Form
    {
        public bool isflag = false;
        public SoundPlayer Player = new SoundPlayer();

        [DllImport(@"User32", SetLastError = true, EntryPoint = "RegisterPowerSettingNotification",
    CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr RegisterPowerSettingNotification(IntPtr hRecipient, ref Guid PowerSettingGuid, Int32 Flags);

        static Guid GUID_LIDSWITCH_STATE_CHANGE = new Guid(0xBA3E0F4D, 0xB817, 0x4094, 0xA2, 0xD1, 0xD5, 0x63, 0x79, 0xE6, 0xA0, 0xF3);
        private const int DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000;
        private const int WM_POWERBROADCAST = 0x0218;
        const int PBT_POWERSETTINGCHANGE = 0x8013;

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        internal struct POWERBROADCAST_SETTING
        {
            public Guid PowerSetting;
            public uint DataLength;
            public byte Data;
        }


        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
             ES_SYSTEM_REQUIRED = 0x00000001,
            ES_DISPLAY_REQUIRED = 0x00000002,
        }

        internal class NativeMethods
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
        }


        private bool? _previousLidState = null;





        private void OnPoweModerChange(object s, PowerModeChangedEventArgs e)
        {

           

            //Debug.Write("aaaa");
            //Player.SoundLocation = "Alert.wav";
                //MessageBox.Show("Lid is now closed3");

            //Player.PlayLooping();

                

           
            
        }


        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_POWERBROADCAST:
                    //Debug.Write("WM_POWERBROADCAST");
                    OnPowerBroadcast(m.WParam, m.LParam);
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }


        private void RegisterForPowerNotifications()
        {
            IntPtr handle = this.Handle;
            Debug.WriteLine("Handle: " + handle.ToString()); //If this line is omitted, then lastError = 1008 which is ERROR_NO_TOKEN, otherwise, lastError = 0
            IntPtr hLIDSWITCHSTATECHANGE = RegisterPowerSettingNotification(handle,
                 ref GUID_LIDSWITCH_STATE_CHANGE,
                 DEVICE_NOTIFY_WINDOW_HANDLE);
            Debug.WriteLine("Registered: " + hLIDSWITCHSTATECHANGE.ToString());
            Debug.WriteLine("LastError:" + Marshal.GetLastWin32Error().ToString());
        }

        private void OnPowerBroadcast(IntPtr wParam, IntPtr lParam)
        {
            if ((int)wParam == PBT_POWERSETTINGCHANGE)
            {
                POWERBROADCAST_SETTING ps = (POWERBROADCAST_SETTING)Marshal.PtrToStructure(lParam, typeof(POWERBROADCAST_SETTING));
                IntPtr pData = (IntPtr)((int)lParam + Marshal.SizeOf(ps));
                Int32 iData = (Int32)Marshal.PtrToStructure(pData, typeof(Int32));
                if (ps.PowerSetting == GUID_LIDSWITCH_STATE_CHANGE)
                {
                    bool isLidOpen = ps.Data != 0;

                    if (!isLidOpen == _previousLidState)
                    {
                        LidStatusChanged(isLidOpen);
                    }

                    _previousLidState = isLidOpen;
                }
            }
        }

        private void LidStatusChanged(bool isLidOpen)
        {
            if (isLidOpen)
            {
                isflag = false;
                //Do some action on lid open event
                //MessageBox.Show("Lid is now open");
            }
            else
            {
      
                Console.Beep(15000, 5000);

                //   System.Media.SystemSounds.Beep.Play();
                //   System.Media.SystemSounds.Asterisk.Play();
                //   System.Media.SystemSounds.Exclamation.Play();
                //   System.Media.SystemSounds.Question.Play();
                //   System.Media.SystemSounds.Hand.Play();

                //Do some action on lid close event
                //MessageBox.Show("Lid is now closed");
            }
        }
   

    public Form2()
        {
            InitializeComponent();
             RegisterForPowerNotifications();

            SystemEvents.PowerModeChanged += OnPoweModerChange;

          
            NativeMethods.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED);

        }



        private void Form2_Load(object sender, EventArgs e)
        {
            UserControl1 uc = new UserControl1();
            this.Controls.Add(uc);
            timer1.Start();




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

            Debug.WriteLine(si.PowerLineStatus);

            if (isflag)
            {
               // Player.SoundLocation = "Alert.wav";
                //MessageBox.Show("Lid is now closed3");

                //Player.PlayLooping();
            }
        }



    }
}
