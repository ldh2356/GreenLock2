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
        /// 사용시간을 타임 테이블에 기록한다
        /// </summary>
        /// <param name="clientMacAddress"></param>
        /// <param name="usedTotalSeconds"></param>
        public void SetTimeTable(string clientMacAddress, double usedTotalSeconds = 0)
        {
            using (greenlockEntities context = new greenlockEntities())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        TimeSheet currentTimeSheet = context.TimeSheets.Where(x => x.MacAddress == clientMacAddress).OrderByDescending(x => x.RegDate).FirstOrDefault();

                        // 기록된 데이터가 아예없는 경우
                        if (currentTimeSheet == null)
                        {
                            Debug.WriteLine("1");
                            try
                            {
                                TimeSheet addTimeSheet = new TimeSheet
                                {
                                    RegDate = DateTime.Now,
                                    StartTime = DateTime.Now,
                                    EndTime = DateTime.Now,
                                    Id = Guid.NewGuid().ToString(),
                                    MacAddress = clientMacAddress,
                                    UsedTotalSecond = 0,
                                };

                                context.TimeSheets.Add(addTimeSheet);
                            }
                            catch (Exception ex)
                            {
                                frmMain._log.write(ex.StackTrace);
                            }
                        }
                        // 기록된 데이터가 있는경우
                        else
                        {
                            // 오늘날짜로 기록된 데이터가 있는경우
                            if (Convert.ToDateTime(currentTimeSheet.RegDate).ToString("yyyyMMdd").Equals(DateTime.Today.ToString("yyyyMMdd")))
                            {
                                Debug.WriteLine("2");
                                try
                                {
                                    // 총시간 업데이트
                                    currentTimeSheet.UsedTotalSecond = currentTimeSheet.UsedTotalSecond + usedTotalSeconds;
                                }
                                catch (Exception ex)
                                {
                                    frmMain._log.write(ex.StackTrace);
                                }
                            }
                            // 없는경우
                            else
                            {
                                Debug.WriteLine("3");
                                try
                                {
                                    TimeSheet addTimeSheet = new TimeSheet
                                    {
                                        RegDate = DateTime.Now,
                                        StartTime = DateTime.Now,
                                        EndTime = DateTime.Now,
                                        Id = Guid.NewGuid().ToString(),
                                        MacAddress = clientMacAddress,
                                        UsedTotalSecond = 0,
                                    };

                                    context.TimeSheets.Add(addTimeSheet);
                      
                                }
                                catch (Exception ex)
                                {
                                    frmMain._log.write(ex.StackTrace);
                                }
                            }
                        }

                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Debug.WriteLine(ex.StackTrace);
                        frmMain._log.write(ex.StackTrace);
                    }
                }
            }
        }

    }
}
