using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Security.Cryptography;

namespace GreenLock
{
    class SaveEnergy
    {
        private static SaveEnergy instance = new SaveEnergy();
        public static SaveEnergy Instance
        {
            get { return instance; }
        }

        public string FileName;

        public TimeSpan _usedSec; // 시간(second)
        public TimeSpan _usedOperation;
        public double _usedKwh; // 전력량
        public double _usedCost; // 사용 전기요금
        public double _co2; // Co2 양
        public double _tree; // 나무절약갯수
        public string _isSend;

        public string UsedSec
        {
            get { return _usedSec.ToString(); }
            set { _usedSec = TimeSpan.Parse(value); }
        }

        public string UsedOperation
        {
            get { return _usedOperation.ToString(); }
            set { _usedOperation = TimeSpan.Parse(value);}
        }

        public double UsedKwh
        {
            get { return _usedKwh; }
            set { _usedKwh = value; }
        }
        public double UsedCost
        {
            get { return _usedCost; }
            set { _usedCost = value; }
        }
        public double Co2
        {
            get { return _co2; }
            set { _co2 = value; }
        }
        public double Tree
        {
            get { return _tree; }
            set { _tree = value; }
        }

        public string IsSend
        {
            get { return _isSend; }
            set { _isSend = value; }
        }

        public SaveEnergy()
        {
            init();
        }

        void init()
        {
            _usedSec = TimeSpan.FromSeconds(0); // 시간(second)
            _usedOperation = TimeSpan.FromSeconds(0); // 시간(second)
            _usedKwh = 0.0; // 전력량
            _usedCost = 0.0; // 사용 전기요금
            _co2 = 0.0; // Co2 양
            _tree = 0.0; // 나무절약갯수
        }
    }

}

