using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using UANGEL.Oam.Core.IO;
using System.Xml.Linq;
using System.IO;
//using UANGEL.Oam.Core.Database;
using System.Windows.Forms;
using System.Data;
//using UANGEL.Oam.Core;
using System.Diagnostics;
//using DevExpress.XtraEditors;
//using MySql.Data.MySqlClient;

//using MySql.Data.MySqlClient;

using MySql.Data.MySqlClient;


namespace GreenLock
{
    public static class UpdateChecker
    {
        public static frmMain main = null; 
        public static bool NeedUpdate(frmMain pmain)
        {
#if debug
            //UpdateInfoXmlUpdate();
#endif
            try
            {
                main = pmain;
                string connString = string.Empty;
                string currentVersion = string.Empty;
                //string updateConfigPath = PathManager.GetConfigPath(ConfigType.UpdateConfig);

                string startPath = Application.StartupPath;
                string updateConfigPath = Path.Combine(startPath, "UpdateInfo.xml");

                if (File.Exists(updateConfigPath) == false)
                    return false;

                XElement root = XElement.Load(updateConfigPath);
            
                string ipAddress = root.Element("Database").Element("IP").Value;
                string port = root.Element("Database").Element("Port").Value;
                string userId = root.Element("Database").Element("User").Value;
                string password = root.Element("Database").Element("Password").Value;
                string databaseName = root.Element("Database").Element("DatabaseName").Value;
                currentVersion = root.Element("CurrentVersion").Value;

                connString = string.Format("server={0};Port={1};User Id={2}; Password={3}; Database={4}; pooling=true;Charset=euckr;",
                    ipAddress, port, userId, password, databaseName);
                MySqlConnection conn = new MySqlConnection(connString);
         
                conn.Open();


                //NNV 와 NV 구분
                DataSet dataset = MySqlHelper.ExecuteDataset(conn, "SELECT Version FROM TBL_GREENLOCK_UPDATE_HITORY ORDER BY REGDATE DESC  LIMIT 1");

                if (dataset != null)
                {
                    if (dataset.Tables[0].Rows.Count > 0)
                    {
                        string version = dataset.Tables[0].Rows[0].Field<string>("Version");

                        if (currentVersion.CompareTo(version) < 0  )                            
                        {
                            //MessageBox.Show("현재 최신 버젼 날짜 :" + currentVersion + "서버 최신 버젼 날짜 : " + timeString);
                            return true;
                        }

                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                return false;
            }

            return false;
        }

        public static void RunClientUpdater()
        {
            //string clientUpdaterPath = PathManager.GetConfigPath(ConfigType.UpdaterFile);
            string startPath = Application.StartupPath;
            string clientUpdaterPath = Path.Combine(startPath, "ClientUpdater.exe");
            
            string currentPath = Application.StartupPath;

            currentPath = currentPath.Replace(' ', '+');    //설치된 경로에 space가 있으면 각각 parameters로 인식 하기때문에 replace함.
            string parameters =  " " + currentPath;
            
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(clientUpdaterPath);
                //startInfo.Arguments = currentPath;
                //startInfo.Arguments = siteName;
                startInfo.Arguments = parameters;
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Path.Combine(currentPath, "ClientUpdater");

                Process.Start(startInfo);

                if (main != null)
                {
                    main.Close();
                    Application.Exit();
                }
            }
            catch (Exception e)
            {
                //XtraMessageBox.Show(e.ToString());
            }
        }



        /// <summary>
        /// 
        /// </summary>
        private static void UpdateInfoXmlUpdate()
        {
            try
            {
                string connString = string.Empty;
                string currentVersion = string.Empty;
                //string updateConfigPath = PathManager.GetConfigPath(ConfigType.UpdateConfig);

                string startPath = Application.StartupPath;
                string updateConfigPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\GreenLock\\bin\\Debug\\", "\\ClientUpdater\\UpdateInfodummy.xml");
                string writeUpdateConfigPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\GreenLock\\bin\\Debug\\", "\\ClientUpdater\\UpdateInfo.xml");

                XElement root = XElement.Load(updateConfigPath);

                string ipAddress = root.Element("Database").Element("IP").Value;
                string port = root.Element("Database").Element("Port").Value;
                string userId = root.Element("Database").Element("User").Value;
                string password = root.Element("Database").Element("Password").Value;
                string databaseName = root.Element("Database").Element("DatabaseName").Value;
                currentVersion = root.Element("CurrentVersion").Value;

                connString = string.Format("server={0};Port={1};User Id={2}; Password={3}; Database={4}; pooling=true;Charset=euckr;",
                    ipAddress, port, userId, password, databaseName);
                MySqlConnection conn = new MySqlConnection(connString);

                conn.Open();
                DataSet dataset = MySqlHelper.ExecuteDataset(conn, "SELECT Version FROM TBL_GREENLOCK_UPDATE_HITORY ORDER BY REGDATE DESC  LIMIT 1");

                if (dataset != null)
                {
                    if (dataset.Tables[0].Rows.Count > 0)
                    {
                        string version = dataset.Tables[0].Rows[0].Field<string>("Version");

                        if (!version.Equals(currentVersion))
                        {
                            root.SetElementValue("CurrentVersion", version);
                            root.Save(writeUpdateConfigPath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
