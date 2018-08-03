using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GreenLock
{
  
    public class CalcReduction
    {
        public event EventHandler OnMainUpdate = null;

        // DevicePerKwh와 WonPerKwh는 MainForm의 생성자에서 AppConfig.xml파일에서 읽어온 값이 들어가게 됨. 저장되있는 값이 없을 경우 기본값으로 160과 183이 적용됨.
        public double _devicePerKwh = 160.0; // 전력값(kW)
        public double _wonPerKwh = 183; // won/kWh 전기요금 // MainForm에서 WonPerKwh의 값을 변경하기 위해 double에서 public double로 변경함
        double _co2Unit = 0.424;
        double _treeUnit = 2.77;
        public TimeSpan _usedSec = TimeSpan.FromSeconds(0); // 시간(second)
        public TimeSpan _usedOperation = TimeSpan.FromSeconds(0); // 시간(second)
    

        public double _usedKwh = 0.0; // 전력량
        public double _usedCost = 0.0; // 사용 전기요금
        public double _co2 = 0.0; // Co2 양
        public double _tree = 0.0; // 나무절약갯수
        public string _isSend;


        public string _fileName = Path.Combine(Application.StartupPath, "GreenLock_Energy.xml");

        public DateTime _operationStartTime;
        public DateTime _operationEndTime;

        public DateTime _screenStartTime;
        private DateTime _screenEndTime;



        public DateTime OperationStartTime
        {
            set
            {
                _operationStartTime = value;              
                if (OnMainUpdate != null) OnMainUpdate(this, null);                
            }
        }

        public DateTime OperationEndTime
        {
            set
            {
                _operationEndTime = value;
                TimeSpan t = _operationEndTime - _operationStartTime;
                _usedOperation += t;
                SaveEnergy.Instance.UsedOperation = _usedOperation.ToString();
            }
        }

        public DateTime ScreenStartTime
        {
            set
            {
                _screenStartTime = value;       
            }
        }

        /// <summary>
        /// ScreenSaver 가 끝나는 시점에 절감량 계산
        /// </summary>
        public DateTime ScreenEndTime
        {
            set
            {
                _screenEndTime = value;
                TimeSpan t = _screenEndTime - _screenStartTime;
                _usedSec += t;
                SaveEnergy.Instance.UsedSec = _usedSec.ToString();
                SaveToFile();
                Calculate();
                

                if (OnMainUpdate != null) OnMainUpdate(this, null);
            } 
        }

        public string IsSend
        {
            get
            {
                return _isSend;
            }
            set
            {
                _isSend = value;
            }
        }

        #region filename

        #endregion

        public CalcReduction()
        {
            _usedSec = TimeSpan.FromSeconds(0); // 시간(second)
            _usedOperation = TimeSpan.FromSeconds(0); // 시간(second)

            _usedKwh = 0.0;  // 전력량
            _usedCost = 0.0; // 사용 전기요금
            _co2 = 0.0; ; // Co2 양
            _tree = 0.0; ; // 나무절약갯수
        }



        public CalcReduction(double devicePerKwh)
        {
            _devicePerKwh = devicePerKwh;
        }

    
        public void Calculate()
        {
            LoadFromFile();
            CultureInfo culture = CultureInfo.CurrentCulture;
            if (culture.Name.Equals("ko-KR"))
            {
                double deviceWatt = _devicePerKwh / 1000; //(kW)
                _usedKwh = deviceWatt * _usedSec.TotalHours;
                _usedCost = _usedKwh * _wonPerKwh;
                _co2 = _usedKwh * _co2Unit;
                _tree = _co2 / _treeUnit;
  
            }
            else
            {
                double deviceWatt = _devicePerKwh / 1000; //(kW)
                _usedKwh = deviceWatt * _usedSec.TotalHours;
                _usedCost = (_usedKwh * _wonPerKwh)/1200;
                _co2 = _usedKwh * _co2Unit;
                _tree = _co2 / _treeUnit;
        
            }


            SaveEnergy.Instance.UsedKwh = _usedKwh;
            SaveEnergy.Instance.UsedCost = _usedCost;
            SaveEnergy.Instance.Co2 = _co2;
            SaveEnergy.Instance.Tree = _tree;
        }

        public void SaveToFile(string fileName = null)
        {
            if (fileName == null) fileName = _fileName;

            System.Xml.Linq.XElement xe = new XElement("SaveEnergy");

            xe.Add(new XElement("UsedSec", _usedSec.ToString()));
            xe.Add(new XElement("UsedOperation", _usedOperation.ToString()));
            xe.Add(new XElement("UsedKwh", _usedKwh));
            xe.Add(new XElement("UsedCost", _usedCost));
            xe.Add(new XElement("Co2", _co2));
            xe.Add(new XElement("Tree", _tree));
            xe.Add(new XElement("IsSend", _isSend));

            xe.Save(fileName);
        }

        public void LoadFromFile(string fileName = null)
        {
            try
            {
                if (fileName == null) fileName = _fileName;

                if (!File.Exists(fileName)) return;

                XElement xe = XElement.Load(fileName);

                _usedSec = TimeSpan.Parse(xe.Element("UsedSec").Value);
                _usedOperation = TimeSpan.Parse(xe.Element("UsedOperation").Value);
                _usedKwh = double.Parse(xe.Element("UsedKwh").Value);
                _usedCost = double.Parse(xe.Element("UsedCost").Value);
                _co2 = double.Parse(xe.Element("Co2").Value);
                _tree = double.Parse(xe.Element("Tree").Value);
                _isSend = xe.Element("IsSend").Value;


                SaveEnergy.Instance.UsedSec = _usedSec.ToString();
                SaveEnergy.Instance.UsedOperation = _usedOperation.ToString();
                SaveEnergy.Instance.UsedKwh = _usedKwh;
                SaveEnergy.Instance.UsedCost = _usedCost;
                SaveEnergy.Instance.Co2 = _co2;
                SaveEnergy.Instance.Tree = _tree;
                SaveEnergy.Instance.IsSend = _isSend;
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }
    }
}
