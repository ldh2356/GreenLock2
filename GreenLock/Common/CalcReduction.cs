using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace GreenLock
{
  
    public class CalcReduction
    {
        public event EventHandler OnSaveChanged = null;

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


       // private _fileNmae = Path. + @"\HansCreative\nnv\GreenLock
        public static string logFileName
        { 
            get
            {
                string drivepath = Environment.ExpandEnvironmentVariables("%SystemDrive%") + @"\HansCreative\nnv\GreenLock";
                string fileName = @"\GreenLock_Energy.xml";
                return drivepath + fileName;
            }
        }

        #region filename

        #endregion

        public CalcReduction()
        {
            SaveEnergy.Instance.FileName = logFileName;
            SaveEnergy.Instance.LoadFromFile();

            _usedSec = TimeSpan.Parse(SaveEnergy.Instance.UsedSec);
            _usedOperation = TimeSpan.Parse(SaveEnergy.Instance.UsedOperation);

            _usedKwh = SaveEnergy.Instance.UsedKwh; // 전력량
            _usedCost = SaveEnergy.Instance.UsedCost; // 사용 전기요금
            _co2 = SaveEnergy.Instance.Co2; // Co2 양
            _tree = SaveEnergy.Instance.Tree; // 나무절약갯수
            _isSend = SaveEnergy.Instance.IsSend;      
        }

        public string IsSend
        {
            get
            {
                return _isSend;
            }
            set
            {
                SaveEnergy.Instance.IsSend = value;
            }
        }

        public CalcReduction(double devicePerKwh)
        {
            _devicePerKwh = devicePerKwh;
        }

       public DateTime _operationStartTime;

       public DateTime _operationEndTime;
       public DateTime OperationEndTime
       {
           get
           {
               return _operationEndTime;
           }

           set
           {
               _operationEndTime = value;
               TimeSpan t = _operationEndTime - _operationStartTime;
               _usedOperation += t;
               SaveEnergy.Instance.UsedOperation = _usedOperation.ToString();
             
               if (OnSaveChanged != null) OnSaveChanged(this, null);
           }
       }
      
        public void saveChanged()
        {
            if (OnSaveChanged != null) OnSaveChanged(this, null);
        }
        public DateTime StartTime;

        private DateTime _EndTime;
        public DateTime EndTime
        {
            get
            {
                return _EndTime;
            }

            set
            {
                _EndTime = value;
                TimeSpan t = _EndTime - StartTime;
                _usedSec += t;
                SaveEnergy.Instance.UsedSec = _usedSec.ToString();
                Calculate();
                if (OnSaveChanged != null) OnSaveChanged(this, null);
            }
        }



        public void Calculate()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            if (culture.Name.Equals("ko-KR"))
            {
                double deviceWatt = _devicePerKwh / 1000; //(kW)
                _usedKwh = deviceWatt * _usedSec.TotalHours;
                _usedCost = _usedKwh * _wonPerKwh;
                _co2 = _usedKwh * _co2Unit;
                _tree = _co2 / _treeUnit;
                SaveEnergy.Instance.UsedKwh = _usedKwh;
                SaveEnergy.Instance.UsedCost = _usedCost;
                SaveEnergy.Instance.Co2 = _co2;
                SaveEnergy.Instance.Tree = _tree;
            }
            else
            {
                double deviceWatt = _devicePerKwh / 1000; //(kW)
                _usedKwh = deviceWatt * _usedSec.TotalHours;
                _usedCost = (_usedKwh * _wonPerKwh)/1200;
                _co2 = _usedKwh * _co2Unit;
                _tree = _co2 / _treeUnit;
                SaveEnergy.Instance.UsedKwh = _usedKwh;
                SaveEnergy.Instance.UsedCost = _usedCost;
                SaveEnergy.Instance.Co2 = _co2;
                SaveEnergy.Instance.Tree = _tree;
            }
        }
    }
}
