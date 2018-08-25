using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClientUpdater
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(params string[] parameters)
        {
            //Test
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string clientUpdateName = string.Empty;
            string mainPath = string.Empty;
            string clientFileName = string.Empty;
            mainPath = Application.StartupPath;
            mainPath = mainPath.Replace('+', ' ');
            Application.Run(new ClientUpdater(clientUpdateName, mainPath));


        }

       
    }
}
