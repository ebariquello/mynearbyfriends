using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using NETCORE.MyNearByFriends.Models;

namespace NETCORE.MyNearByFriends.Repository
{
    public class CalcHistoryLogRepository : ICalcHistoryLogRepository
    {
        private readonly MyFriendsPositionContext _context;

        public CalcHistoryLogRepository(MyFriendsPositionContext context)
        {
            _context = context;
        }


        public async Task<List<CalcHistoryLog>> GetAll()
        {
            return await _context.CalcHistoryLogs
             .AsNoTracking()
             .ToListAsync();
        }

        public async Task<CalcHistoryLog> GetByID(int calcHistoryLogId)
        {

            var calcHistoryLogs = await _context.CalcHistoryLogs
            
             .AsNoTracking()
             .SingleOrDefaultAsync(m => m.CalcHistoryLogId == calcHistoryLogId);

            return calcHistoryLogs;

        }


        public async Task<int> Save(CalcHistoryLog calcHistoryLog)
        {
            if (calcHistoryLog.CalcHistoryLogId > 0)
            {
                _context.Update(calcHistoryLog);
                return await _context.SaveChangesAsync();
            }
            else
            {
                _context.Add(calcHistoryLog);
                return await _context.SaveChangesAsync();
            }
        }

    }
}
