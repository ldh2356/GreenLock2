using GreenLockProvider.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLockProvider.Dispatcher
{
    public class TimeSheetProvider
    {
        /// <summary>
        /// 신규 타임테이블 데이터를 세팅한다
        /// </summary>
        /// <param name="clientMacAddress">전달 받을 맥주소</param>        
        public void SetTimeTable(string clientMacAddress, double usedTotalSecond = 0)
        {
            try
            {
                using (GreenLockEntites context = new GreenLockEntites())
                {
                    // 오늘 날짜로 기록된 데이터가 없는 경우 
                    if (context.TimeSheets.Where(x => x.MacAddress == clientMacAddress && x.StartTime <= DateTime.Now && x.EndTime >= DateTime.Now).Count() == 0)
                    {
                        // 신규로 데이터를 업데이트
                        using (DbContextTransaction transaction = context.Database.BeginTransaction())
                        {
                            TimeSheet addTimeSheet = new TimeSheet
                            {
                                RegDate = DateTime.Now,
                                StartTime = DateTime.Now,
                                EndTime = DateTime.Now,
                                Id = Guid.NewGuid().ToString(),
                                MacAddress = clientMacAddress,
                                UsedTotalSecond = usedTotalSecond,
                            };

                            context.TimeSheets.Add(addTimeSheet);
                            context.SaveChanges();
                            transaction.Commit();
                        }
                    }
                    // 오늘 날짜로 기록된 데이터가 있고 시간만 업데이트하는 경우
                    else
                    {
                        // 가장 마지막에 들어온 Row 를 가져온다
                        using (DbContextTransaction transaction = context.Database.BeginTransaction())
                        {
                            TimeSheet updateTimeSheet = context.TimeSheets.Where(x => x.MacAddress == clientMacAddress
                                                                    && x.StartTime <= DateTime.Now && x.EndTime >= DateTime.Now)
                                                                        .OrderByDescending(x => x.RegDate).FirstOrDefault();

                            updateTimeSheet.UsedTotalSecond = updateTimeSheet.UsedTotalSecond + usedTotalSecond;
                            context.SaveChanges();
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
