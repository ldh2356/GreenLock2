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
                bool isTurnOnSound = false;

                if (!SoundService.isUsingSoundService)
                {
                    // 알람 사용이 아닐경우
                    if (!SoundService.isAlramUseOn)
                    {
                        SoundService.AlertSoundStop();
                    }
                    // 알람을 사용할경우
                    else
                    {
                        // 전원이 분리되었을때
                        if(powerStatus.PowerLineStatus == PowerLineStatus.Offline || powerStatus.PowerLineStatus == PowerLineStatus.Unknown)
                        {
                            isTurnOnSound = true;
                        }
                        // 키업이 일어났을때
                        else if (frmMain._isKeyArarm)
                        {
                            isTurnOnSound = true;

                            // 키업이 일어났지만 패스워드 팝업이 떠있는 경우 ( 유저가 패스워드 입력을 시도하는 경우 )
                            if (frmMain._isShowPasswordPopup)
                            {
                                isTurnOnSound = false;
                            }
                        }


                        // 사운드를 실행해야 하는경우
                        if (isTurnOnSound)
                        {
                            SoundService.AlertSoundStart();
                        }
                        // 사운드를 멈춰야 하는경우
                        else
                        {
                            SoundService.AlertSoundStop();
                        }
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
