using GreenLock.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLock.Dispatcher
{
    public class TimeSheetDispatcher
    {
        /// <summary>
        /// 타임 테이블에 데이터를 추가하거나 업데이트한다
        /// </summary>
        /// <param name="clientMacAddress"></param>
        /// <param name="lockType"></param>
        public void SetTimeTable(string clientMacAddress, short lockType)
        {
            try
            {
                DateTime currentTime = DateTime.Now;

                using (greenlockEntities context = new greenlockEntities())
                {
                    // 가장 마지막의 행을 가져온다 
                    TimeTable currentTimeSheet = context.TimeTables.Where(x => x.MacAddress == clientMacAddress).OrderByDescending(x => x.RegDate).FirstOrDefault();

                    // null 인경우 new row 생성 
                    if (currentTimeSheet == null)
                    {
                        AddNewTimeTable(clientMacAddress, lockType, currentTime);
                    }
                    // null 이 아닌 경우 오늘 날짜의 데이터 인지 확인 
                    else
                    {
                        // 오늘 날짜의 데이터가 있다면 현재의 락타입과 일치 하는 경우 ( order by ) end time 업데이트 
                        if (currentTimeSheet.RegDate.ToString("yyyyMMdd").Equals(currentTime.ToString("yyyyMMdd")) && currentTimeSheet.LockType.Equals(lockType))
                        {
                            UpdateNewTimeTable(clientMacAddress, currentTime);
                        }
                        // 락타입과 일치하지 않는 경우 새로운 행 추가 
                        else
                        {
                            AddNewTimeTable(clientMacAddress, lockType, currentTime, true);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                frmMain._log.write(ex.Message + " - " + ex.StackTrace);
            }
        }


        /// <summary>
        /// 행의 종료시간을 업데이트한다
        /// </summary>
        /// <param name="clientMacAddress">사용자 맥어드레스</param>
        /// <param name="currentTime">기록될 시간</param>
        private void UpdateNewTimeTable(string clientMacAddress, DateTime currentTime)
        {
            using (greenlockEntities context = new greenlockEntities())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        TimeTable currentTimeSheet = context.TimeTables.Where(x => x.MacAddress == clientMacAddress).OrderByDescending(x => x.RegDate).FirstOrDefault();
                        
                        if (currentTimeSheet != null)
                        {
                            // 현재 타임시트와 업데이트하고자하는 타임시트의 날짜가 서로 다른경우
                            if (!Convert.ToDateTime(currentTimeSheet.StartDate).ToString("yyyyMMdd").Equals(currentTime.ToString("yyyyMMdd")))
                            {
                                AddNewTimeTable(clientMacAddress, currentTimeSheet.LockType, currentTime, true);
                            }
                            // 다르지 않은경우 EndTime 업데이트
                            else
                            {
                                currentTimeSheet.EndDate = currentTime;
                                context.SaveChanges();
                                transaction.Commit();
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


        /// <summary>
        /// 신규 타임 테이블 행을 추가시킨다
        /// </summary>
        /// <param name="clientMacAddress">사용자 맥어드레스</param>
        /// <param name="lockType">락 타입 0: 언락 1:락</param>
        /// <param name="currentTime">기록될 시간</param>
        /// <param name="isForce">강제 행추가 옵션</param>
        public void AddNewTimeTable(string clientMacAddress, short lockType, DateTime currentTime, bool isForce = false)
        {
            using (greenlockEntities context = new greenlockEntities())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    TimeTable currentTimeSheet = context.TimeTables.Where(x => x.MacAddress == clientMacAddress).OrderByDescending(x => x.RegDate).FirstOrDefault();

                    // 현재 행이 없거나 강제 생성인경우 로우생성
                    if (currentTimeSheet == null || isForce)
                    {
                        try
                        {
                            TimeTable addTimeSheet = new TimeTable
                            {
                                RegDate = currentTime,
                                StartDate = currentTime,
                                EndDate = currentTime,
                                Id = Guid.NewGuid().ToString(),
                                MacAddress = clientMacAddress,
                                LockType = lockType,
                            };

                            context.TimeTables.Add(addTimeSheet);
                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            frmMain._log.write(ex.StackTrace);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// 시간별 데이터를 가져온다
        /// </summary>
        /// <param name="clientMacAddress">사용자 맥어드레스</param>
        /// <param name="StartDate">시작 시간</param>
        /// <param name="EndDate">종료 시간</param>
        /// <returns></returns>
        public List<TimeTable> GetTimeTable(string clientMacAddress, DateTime startDate, DateTime endDate)
        {
            List<TimeTable> list = new List<TimeTable>();
            try
            {
                using (greenlockEntities context = new greenlockEntities())
                {
                    DateTime StartTimeParse = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                    DateTime EndTimeParse = new DateTime(endDate.Year, endDate.Month, endDate.Day, 0, 0, 0).AddDays(1);
                    list = context.TimeTables.Where(x => x.MacAddress == clientMacAddress &&
                                                       x.RegDate >= StartTimeParse &&
                                                       x.RegDate <= EndTimeParse)
                                                       .OrderBy(x => x.RegDate).ToList();
                }
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }

            return list;
        }

    }
}
