using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GreenLock
{
    public class AppConfig
    {
       
        private static AppConfig instance = new AppConfig();
        public static AppConfig Instance
        {
            get { return instance; }
        }

        public string _fileName = Path.Combine(Application.StartupPath, "GreenLock_Config.xml"); 
  
        private double _pcPower;
        private double _elecRate; // 추가함
        private int _totalTime;
        private string _userPassword;
        private string _deviceAddress;
        private int _sleepMode;
        private string _elecUnit;
      
        private int _model;


        /// <summary>
        /// Model =0 은 안드로이드 Model = 1 IOS
        /// </summary>
        public int Model
        {
            get { return _model; }
            set { _model = value; }
        }


        public double PcPower
        {
            get { return _pcPower; }
            set { _pcPower = value; }
        }
    
        public double ElecRate // 추가함
        {
            get { return _elecRate; }
            set { _elecRate = value;  }
        }

        public string ElecUnit
        {
            get { return _elecUnit; }
            set { _elecUnit = value; }
        }

        public int TotalTime
        {
            get { return _totalTime; }
            set { _totalTime = value; }
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        public string DeviceAddress
        {
            get { return _deviceAddress; }
            set { _deviceAddress = value; }
        }


        /// <summary>
        /// SleepMode = 1 인경우 모니터 + 본체,  SleepMode = 0 모니터 절제 
        /// </summary>
        public int SleepMode
        {
            get { return _sleepMode; }
            set { _sleepMode = value; }
        }


        public AppConfig()
        {        
            init();
        }

        void init()
        {
         
            _pcPower = 160; // PC 소비전력 기본값
            _elecRate = 183; // 전기요금 기본값
            _totalTime = 0;
            _userPassword = "0000";
            _deviceAddress = "00:00:00:00:00:00";
            _sleepMode = 0;
            _model = 0;
        }

        //암호화 키.  8글자로 이루어짐.
        static byte[] Skey = ASCIIEncoding.ASCII.GetBytes("11111111");

        public void SaveToFile(string fileName = null)
        {
            if (fileName == null) fileName = _fileName;

            XElement xe = new XElement("AppConfig");
            
            xe.Add(new XElement("TotalTime", TotalTime));
            xe.Add(new XElement("UserPassword", UserPassword));
            xe.Add(new XElement("DeviceAddress", DeviceAddress));
            xe.Add(new XElement("SleepMode", SleepMode));     
            xe.Add(new XElement("Model", Model));
            xe.Add(new XElement("ElecRate", ElecRate)); // 추가함
            xe.Add(new XElement("EleUnit", ElecUnit)); // 추가함
            
            xe.Add(new XElement("PcPower", PcPower));

            xe.Save(fileName);
            Console.WriteLine("SSES_config.xml ==>" + xe.ToString());

           /* System.Windows.Forms.MessageBox.Show(xe.ToString()); //디버그용

            byte[] data = File.ReadAllBytes(fileName);
            //encrypt
            DESCryptoServiceProvider rc2 = new DESCryptoServiceProvider();
            rc2.Key = Skey;
            rc2.IV = Skey;

            MemoryStream ms = new MemoryStream();

            CryptoStream cryStream = new CryptoStream(ms, rc2.CreateEncryptor(), CryptoStreamMode.Write);
            cryStream.Write(data, 0, data.Length);
            cryStream.FlushFinalBlock();

            byte[] data1 = ms.ToArray();

            //Console.WriteLine("E + {0}", Convert.ToBase64String(ms.ToArray()));

            File.WriteAllBytes(fileName, data1);*/

        }

        public void LoadFromFile(string fileName = null)
        {
            if (fileName == null) fileName = _fileName;
            if (!File.Exists(fileName)) return;

            //byte[] data = File.ReadAllBytes(fileName);
            ////decrypt
            //DESCryptoServiceProvider rc2 = new DESCryptoServiceProvider();
            //rc2.Key = Skey;
            //rc2.IV = Skey;
            //MemoryStream ms = new MemoryStream();

            //CryptoStream cryStream = new CryptoStream(ms, rc2.CreateDecryptor(), CryptoStreamMode.Write);

            //cryStream.Write(data, 0, data.Length);
            //try
            //{
            //    cryStream.FlushFinalBlock();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("D + {0}", ex.Message);
            //}
            //Console.WriteLine("D + {0}", Encoding.UTF8.GetString(ms.GetBuffer()));

            //byte[] data1 = ms.ToArray();
            //File.WriteAllBytes(fileName, data1);

            XElement xe = XElement.Load(fileName);
            
           
            _pcPower = double.Parse(xe.Element("PcPower").Value);
            _totalTime = int.Parse(xe.Element("TotalTime").Value);
            _userPassword = xe.Element("UserPassword").Value;
            _deviceAddress = xe.Element("DeviceAddress").Value;
            _sleepMode = int.Parse(xe.Element("SleepMode").Value);
            _model = int.Parse(xe.Element("Model").Value);
            
            //_PcSleepMode = bool.Parse(xe.Element("PcSleepMode").Value);
            //_MonitorSleepMode = bool.Parse(xe.Element("MonitorSleepMode").Value);
            
            // 추가함
            try
            {
                _elecRate = double.Parse(xe.Element("ElecRate").Value);
                _elecUnit = xe.Element("EleUnit").Value;
            }
            catch (Exception ex)
            {
                ex.ToString();
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
                xe.Add(new XElement("ElecRate", ElecRate));
                _elecRate = double.Parse(xe.Element("ElecRate").Value);
            }
        }
    }

}
