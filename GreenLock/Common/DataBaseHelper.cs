using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLock.Common
{
    public class DataBaseHelper
    {
        /// <summary>
        /// Root 패스 설정 
        /// </summary>
        private readonly string SQLLITE_DIR_PATH = "C:\\GreenLock\\Data";

        /// <summary>
        /// 그린락 SQL 파일이름
        /// </summary>
        public string SQL_FILE_NAME { get; private set; } = "greenlock.sqlite";

        /// <summary>
        /// SQLite 파일 생성여부를 체크한다
        /// </summary>
        public void EnsureSQLiteFileCreated()
        {
            try
            {
                // SQL 파일 디렉토리 체크후 없다면 생성
                DirectoryInfo sqlDirectory = new DirectoryInfo(SQLLITE_DIR_PATH);
                if (!sqlDirectory.Exists)
                    Directory.CreateDirectory(SQLLITE_DIR_PATH);

                // SQL 라이트 생성파일이 존재하지 않는경우 복사한다                
                FileInfo sqliteFileInfo = new FileInfo(Path.Combine(SQLLITE_DIR_PATH, SQL_FILE_NAME));
                if (!sqliteFileInfo.Exists)
                {
                    string SQL_FILE_PATH = Path.Combine(System.IO.Directory.GetCurrentDirectory(),SQL_FILE_NAME);
                    FileInfo copyFile = new FileInfo(SQL_FILE_PATH);
                    copyFile.CopyTo(Path.Combine(SQLLITE_DIR_PATH, SQL_FILE_NAME));
                }
                
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }
    }
}
