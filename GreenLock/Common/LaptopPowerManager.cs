using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenLock.Common
{
    public static class LaptopPowerManager
    {
        /// <summary>
        /// 파워연결 해제시 알람이 울리게 설정한다 , 모바일에서 설정한 알람 ON/OFF 가 OFF 상태이면 알람은 울리지 않는다
        /// </summary>
        public static void DoCheckPowerCableCheckAndAlarm()
        {
            try
            {
                PowerStatus powerStatus = SystemInformation.PowerStatus;

                if (!SoundService.isUsingSoundService)
                {
                    if (powerStatus.PowerLineStatus == PowerLineStatus.Offline || powerStatus.PowerLineStatus == PowerLineStatus.Unknown)
                    {
                        SoundService.AlertSoundStart();
                    }
                    else
                    {

                        SoundService.AlertSoundStop();
                    }


                    if (!SoundService.isAlramUseOn)
                    {
                        SoundService.AlertSoundStop();
                    }
                }

            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace); 
            }
        }


    }
}
