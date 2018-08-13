using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Threading;
using InTheHand.Net.Bluetooth.AttributeIds;

using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace GreenLock
{

    public enum EnumMobileModel
    {
        /// <summary>
        /// 안드로이드
        /// </summary>
        Android,

        /// <summary>
        /// 애플
        /// </summary>
        IOS,
    }

    /// <summary>
    /// 블루투스 컨트롤 클래스
    /// </summary>
    public class Bt32FeetDevice : IDisposable
    {

        public event EventHandler OnIsService;
        public event EventHandler OnNotService;
        public event EventHandler OnErrorService;

        ConnectLog _log = new ConnectLog();

        /// <summary>
        /// 에이전트로부터 받아올 맥 어드레스
        /// </summary>
        static string MacAddress { get; set; }


        /// <summary>
        /// 블루투스 어드레스 변수
        /// </summary>
        static BluetoothAddress bluetoothAddressString;


        /// <summary>
        /// 블루투스 디바이스 정보 클래스
        /// </summary>
        static BluetoothDeviceInfo bluetoothDeviceInfo;

        /// <summary>
        /// 워커 쓰레드
        /// </summary>
        protected Thread Worker = null;


        private int _lockcount;
        /// <summary>
        /// 락 카운트
        /// </summary>
        public int LockCount
        {
            get 
            {
                return _lockcount;
            }
            set
            {
                _lockcount = value;
            }
        }

        /// <summary>
        /// IOS / Android 모델
        /// </summary>
        public int _model;


        /// <summary>
        /// 모바일 모델
        /// </summary>
        public EnumMobileModel MobileModel
        {
            get
            {
                if (_model == 0)
                    return EnumMobileModel.Android;
                else
                    return EnumMobileModel.IOS;
            }
        }


        /// <summary>
        /// UUID
        /// </summary>
        static string uuidStr = "00002415-0000-1000-8000-00805F9B34FB";

        /// <summary>
        /// GUID
        /// </summary>
        Guid uuid = new Guid(uuidStr);
        

        /// <summary>
        /// 생성자
        /// </summary>
        public Bt32FeetDevice()
        {
        }

        /// <summary>
        /// 쓰레드를 시작한다
        /// </summary>
        public virtual void Start()
        {
            try
            {
                Worker = new Thread(DoWork);
                Worker.Start();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 서비스를 정지한다
        /// </summary>
        public virtual void Stop()
        {
            try
            {
                if (Worker == null)
                    return;

                Worker.Interrupt();
                Worker = null;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 주소를 져온다
        /// </summary>
        /// <param name="divAddr"></param>
        public void GetBtAddr(string divAddr)
        {
            MacAddress = divAddr;
        }


        /// <summary>
        /// Dispose 
        /// </summary>
        public void Dispose()
        {
            try
            {
                Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        /// <summary>
        /// 에이전트와 모바일 기기가 서로 통신이 되고있는지 여부 
        /// </summary>
        public bool IsServiced { get; set; } = true;



        /// <summary>
        /// 통신 체크
        /// </summary>
        protected void DoWork()
        {
            try
            {                 
                DoCheckBlueToothService();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



      

        /// <summary>
        /// 블루투스 서비스를 체크한다
        /// </summary>
        private void DoCheckBlueToothService()
        {
            try
            {
                // 파싱한 주소를 가져온다
                bluetoothAddressString = BluetoothAddress.Parse(MacAddress);

                // 컴퓨터에 블루투스가 연결되어있는지 여부를 확인 한다 
               // 블루투스 장치가 켜져있지 않다면 블루투스 설정 화면을 사용자에게 안내한다
                if (!BluetoothRadio.IsSupported)
                {
                   
                    MessageBox.Show(GreenLock.languages.GreenLock.bluetoothOffMsg, "GreenLock", MessageBoxButtons.OK);
                    Process.Start("bthprops.cpl");
                }
                // 블루투스 제어장치가 확인돈다면
                else
                {
                    // 블루투스 제어장비를 초기화한다
                    bluetoothDeviceInfo = new BluetoothDeviceInfo(bluetoothAddressString);                  
                }

                // 모바일 기기와 연결여부를 지속적으로 체크한다
                while (true)
                {                 
                    IAsyncResult iAsyncResult = bluetoothDeviceInfo.BeginGetServiceRecords(uuid, Service_AsyncCallback, bluetoothDeviceInfo);
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                if (OnErrorService != null)
                    OnErrorService(this, null);

                _log.write("==== 통신 예외 발생 ====");
                _log.write("BeginGetServiceRecords \n" + ex.Message);
                Console.WriteLine(ex.Message + " Thread Exception!!! 1");
            }
        }



        /// <summary>
        /// 블루투스 통신 부분
        /// </summary>
        /// <param name="result"></param>
        private void Service_AsyncCallback(IAsyncResult iAsyncResult)
        {
            try
            {
                bluetoothDeviceInfo = iAsyncResult.AsyncState as BluetoothDeviceInfo;

                ServiceRecord[] services = bluetoothDeviceInfo.EndGetServiceRecords(iAsyncResult);

                if (MobileModel == EnumMobileModel.Android)
                {
                    bool isService = false;
                    if (services.Count() > 0)
                    {
                        if (OnIsService != null)
                               OnIsService(this, null);

                        foreach (ServiceRecord r in services)
                        {
                            int port = ServiceRecordHelper.GetRfcommChannelNumber(r);
                            string curSvcName = r.GetPrimaryMultiLanguageStringAttributeById(UniversalAttributeId.ServiceName);

                            // 알람끄기
                            if (curSvcName.CompareTo("GreenLock0") == 0)
                            {
                                SoundService.isAlramUseOn = false;
                                break;
                            }
                            // 알람키기
                            else if (curSvcName.CompareTo("GreenLock1") == 0)
                            {
                                SoundService.isAlramUseOn = true;
                                break;
                            }
                        }

                        //if (isService)
                        //{

                        //    if (OnIsService != null)
                        //        OnIsService(this, null);
                        //}
                        //else
                        //{
                        //    if (OnNotService != null)
                        //        OnNotService(this, null);
                        //}
                    }
                    else
                    {
                        //서비스가 없는 경우 
                        if (OnNotService != null)
                            OnNotService(this, null);
                        _log.write("알림 off시 발생");
                    }
                }
                else
                {
                   
                    //if (OnNotService != null)
                    //    OnNotService(this, null);                   
                }
            }
            catch (Exception ea)
            {
                //통신을 못하는 경우 발생 - 모바일을 가지고 이동시 
                if (OnNotService != null)
                    OnNotService(this, null);

                _log.write("Service_AsyncCallback =>" + ea.Message);
            }
        }
    }
}
