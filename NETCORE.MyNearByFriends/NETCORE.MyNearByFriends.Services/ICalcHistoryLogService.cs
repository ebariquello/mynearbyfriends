using NETCORE.MyNearByFriends.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NETCORE.MyNearByFriends.Services
{
    public interface ICalcHistoryLogService
    {
        Task<int> RegisterLog(CalcHistoryLog log);
        CalcHistoryLog PreparaCalcHistoryLog(List<MyFriendPosition> myFriendsPositions, string createdBy);
    }
}
