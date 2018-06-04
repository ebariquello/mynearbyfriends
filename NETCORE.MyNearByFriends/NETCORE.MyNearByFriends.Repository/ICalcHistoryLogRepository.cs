
using NETCORE.MyNearByFriends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETCORE.MyNearByFriends.Repository
{
    public interface ICalcHistoryLogRepository
    {
        Task<List<CalcHistoryLog>> GetAll();
        Task<CalcHistoryLog> GetByID(int logID);
        Task<int> Save(CalcHistoryLog log);
    

    }
}
