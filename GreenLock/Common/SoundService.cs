﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Media;
using System.IO;
using System.Windows.Forms;

namespace GreenLock
{
    public class SoundService
    {
      
        public static event EventHandler OnAlarmUseChange;
        /// <summary>
        /// 사운드 사용여부 
        /// </summary>
        public static bool isUsingSoundService { get; set; } = false;


        /// <summary>
        /// 알람 사용 여부
        /// </summary>
        /// 

        public static bool _isAlarmUseOn = true;
        public static bool isAlramUseOn
        {
            get
            {
                return _isAlarmUseOn;
            }
            set
            {
                _isAlarmUseOn = value;
                if (OnAlarmUseChange != null)
                    OnAlarmUseChange(null, null);
            }
        }

        /// <summary>
        /// 사운드 비프음 재생전 볼륨 퍼센트
        /// </summary>
        public static int lastVolumePercentage { get; set; } = 0;

        /// <summary>
        /// 사운드 재생중인지 여부
        /// </summary>
        public static bool isSoundPlaying { get; set; } = false;

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MONITORPOWER = 0xF170;

        public const int MONITOR_ON = -1;
        public const int MONITOR_OFF = 2;
        public const int MONITOR_STANBY = 1;

        public const int MOUSE_MOVE = 0x0001;

        public static SoundPlayer Player = new SoundPlayer();

        public static string drivepath = Application.StartupPath;
        public static string fileName = @"\Alert.wav";

        [DllImport("user32.dll")]
        public static extern void mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        /// <summary>
        /// Beep 사운드를 재생한다 
        /// </summary>
        public static void AlertSoundStart()
        {
            try
            {
                // 알람 사용을 할때만 알람 사용
                if (isAlramUseOn)
                {
                    // 사운드가 재생중이지 않은경우
                    if (!isSoundPlaying)
                    {
                        isSoundPlaying = true;

                        // 재생직전 볼륨을 저장한다
                        lastVolumePercentage = int.Parse(AudioManager.GetMasterVolume().ToString());

                        AudioManager.ToggleMasterVolumeUnMute();
                        AudioManager.SetMasterVolume(100);

                        Player.SoundLocation = drivepath + fileName;
                        Player.PlayLooping();
                    }
                }
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.Message);
            }
        }


        /// <summary>
        /// Beep 사운드를 재생한다 
        /// </summary>
        public static void AlertSoundStartForce()
        {
            try
            {
                // 사운드가 재생중이지 않은경우
                if (!isSoundPlaying)
                {
                    isSoundPlaying = true;

                    // 재생직전 볼륨을 저장한다
                    lastVolumePercentage = int.Parse(AudioManager.GetMasterVolume().ToString());

                    AudioManager.ToggleMasterVolumeUnMute();
                    AudioManager.SetMasterVolume(100);

                    Player.SoundLocation = drivepath + fileName;
                    Player.PlayLooping();
                }
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.Message);
            }
        }

        /// <summary>
        /// Beep 사운드 재생을 중지한다
        /// </summary>
        public static void AlertSoundStop()
        {
            try
            {
                if (isSoundPlaying)
                {
                    // 볼륨을 이전에 저장했던 볼륨으로 복원한다
                    AudioManager.SetMasterVolume(lastVolumePercentage);
                    isSoundPlaying = false;
                    Player.Stop();
                }
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.Message);
            }
        }
    }
}
