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

        public string _LocalName;
        public int _TrackBar;
        public double _PcPower;
        public double _ElecRate; // 추가함
        public int _TotalTime;
        public string _UserPassword;
        public string _DeviceAddress;
        public int _SleepMode;
        public bool _MonitorSleepMode;
        public bool _PcSleepMode;
        private int _Model;

        public int Model
        {
            get { return _Model; }
            set { _Model = value; }
        }


        public double PcPower
        {
            get { return _PcPower; }
            set { _PcPower = value; }
        }
        
        public double ElecRate // 추가함
        {
            get { return _ElecRate; }
            set { _ElecRate = value;  }
        }

        public int TotalTime
        {
            get { return _TotalTime; }
            set { _TotalTime = value; }
        }

        public string UserPassword
        {
            get { return _UserPassword; }
            set { _UserPassword = value; }
        }

        public string DeviceAddress
        {
            get { return _DeviceAddress; }
            set { _DeviceAddress = value; }
        }

        public int SleepMode
        {
            get { return _SleepMode; }
            set { _SleepMode = value; }
        }


        public AppConfig()
        {        
            init();
        }

        void init()
        {
         
            _PcPower = 160; // PC 소비전력 기본값
            _ElecRate = 183; // 전기요금 기본값
            _TotalTime = 0;
            _UserPassword = "0000";
            _DeviceAddress = "00:00:00:00:00:00";
            _SleepMode = 0;
            _Model = 0;
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
            
           
            _PcPower = double.Parse(xe.Element("PcPower").Value);
            _TotalTime = int.Parse(xe.Element("TotalTime").Value);
            _UserPassword = xe.Element("UserPassword").Value;
            _DeviceAddress = xe.Element("DeviceAddress").Value;
            _SleepMode = int.Parse(xe.Element("SleepMode").Value);
            _Model = int.Parse(xe.Element("Model").Value);
            
            //_PcSleepMode = bool.Parse(xe.Element("PcSleepMode").Value);
            //_MonitorSleepMode = bool.Parse(xe.Element("MonitorSleepMode").Value);
            
            // 추가함
            try
            {
                _ElecRate = double.Parse(xe.Element("ElecRate").Value);
            }
            catch (Exception ex)
            {
                ex.ToString();
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
                xe.Add(new XElement("ElecRate", ElecRate));
                _ElecRate = double.Parse(xe.Element("ElecRate").Value);
            }
        }
    }

}
