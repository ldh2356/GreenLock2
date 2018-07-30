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
        /// <param name="isNew"></param>
        public void SetTimeTable(string clientMacAddress, short lockType, bool isNew = false)
        {
            try
            {
                using (greenlockEntities context = new greenlockEntities())
                {
                    using (DbContextTransaction transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            TimeTable currentTimeSheet = context.TimeTables.Where(x => x.MacAddress == clientMacAddress).OrderByDescending(x => x.RegDate).FirstOrDefault();

                            // 오늘날짜로 기록된 데이터가 아예없거나 신규로 행을 추가시 경우
                            if (currentTimeSheet == null || isNew)
                            {
                                try
                                {
                                    // 락 데이터가 들어왔을 경우 
                                    if (lockType == 1)
                                    {
                                        //마지막 행이 락이라면 new 로 들어왔다 하더라도 그에 상관없이 종료타임만 업데이트한다                                        
                                        if (currentTimeSheet.LockType == lockType)
                                        {
                                            // EndTime 을 업데이트한다 
                                            currentTimeSheet.EndDate = DateTime.Now;
                                        }
                                        // 신규 데이터라면 로우를 추가한다
                                        else if (isNew)
                                        {
                                            TimeTable addTimeSheet = new TimeTable
                                            {
                                                RegDate = DateTime.Now,
                                                StartDate = DateTime.Now,
                                                Id = Guid.NewGuid().ToString(),
                                                MacAddress = clientMacAddress,
                                                LockType = lockType,
                                            };

                                            context.TimeTables.Add(addTimeSheet);
                                        }
                                    }
                                    // 락 데이터가 아닌경우
                                    else
                                    {
                                        TimeTable addTimeSheet = new TimeTable
                                        {
                                            RegDate = DateTime.Now,
                                            StartDate = DateTime.Now,
                                            Id = Guid.NewGuid().ToString(),
                                            MacAddress = clientMacAddress,
                                            LockType = lockType,
                                        };

                                        context.TimeTables.Add(addTimeSheet);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    frmMain._log.write(ex.StackTrace);
                                }
                            }
                            // 기록된 데이터가 있는경우
                            else
                            {
                                try
                                {
                                    // 해당하는 락 타입 데이터의 마지막 행을 가져온다 
                                    TimeTable targetTable = context.TimeTables.Where(x => x.MacAddress == clientMacAddress && x.LockType == lockType).OrderBy(x => x.RegDate).FirstOrDefault();

                                    // 업데이트 할려는 시간이 다음날로 넘어 간다면
                                    DateTime updateEndTime = DateTime.Now;
                                    if (!targetTable.EndDate.ToString("yyyyMMdd").Equals(updateEndTime.ToString("yyyyMMdd")))
                                    {
                                        // 그날의 마지막시간으로 데이터를 업데이트하고 신규로 행을 추가한다
                                        targetTable.EndDate = Convert.ToDateTime($"{targetTable.EndDate.ToString("yyyy-MM-dd")} 23:59:59");

                                        TimeTable addTimeSheet = new TimeTable
                                        {
                                            RegDate = DateTime.Now,
                                            StartDate = DateTime.Now,
                                            Id = Guid.NewGuid().ToString(),
                                            MacAddress = clientMacAddress,
                                            LockType = lockType,
                                        };

                                        context.TimeTables.Add(addTimeSheet);
                                    }
                                    // 업데이트할려는 시작시간과 종료시간이 오늘 이내라면
                                    else
                                    {
                                        // EndTime 을 업데이트한다 
                                        targetTable.EndDate = updateEndTime;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    frmMain._log.write(ex.StackTrace);
                                }
                            }

                            context.SaveChanges();
                            transaction.Commit();
                            transaction.Dispose();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            transaction.Dispose();
                            Debug.WriteLine(ex.StackTrace);
                            frmMain._log.write(ex.StackTrace);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmMain._log.write(ex.StackTrace);
            }
        }



        /// <summary>
        /// 시간별 데이터를 가져온다
        /// </summary>
        /// <param name="clientMacAddress"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
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
