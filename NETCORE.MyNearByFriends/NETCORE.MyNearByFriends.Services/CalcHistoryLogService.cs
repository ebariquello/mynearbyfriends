using NETCORE.MyNearByFriends.Models;
using NETCORE.MyNearByFriends.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NETCORE.MyNearByFriends.Services
{
    public class CalcHistoryLogService : ICalcHistoryLogService
    {
        private ICalcHistoryLogRepository _repository;

        public CalcHistoryLogService(ICalcHistoryLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> RegisterLog(CalcHistoryLog log)
        {
           return await _repository.Save(log);
        }

        public CalcHistoryLog PreparaCalcHistoryLog(List<MyFriendPosition> myFriendsPositions, string createdBy)
        {
            CalcHistoryLog log = new CalcHistoryLog();
            log.LogCreated = DateTime.Now;
            log.LogCreatedBy = createdBy;
            log.FriendName = myFriendsPositions[0].FriendName;
            log.Longitude = myFriendsPositions[0].Longitude;
            log.Latitude = myFriendsPositions[0].Latitude;
            log.MyFriendPositionId = myFriendsPositions[0].MyFriendPositionId;
            try
            {
                log.FriendName1 = myFriendsPositions[1].FriendName;
                log.Longitude1 = myFriendsPositions[1].Longitude;
                log.Latitude1 = myFriendsPositions[1].Latitude;
                log.CalcNearFriend1 = myFriendsPositions[1].Calc;
            }
            catch
            {

            }
            try
            {
                log.FriendName2 = myFriendsPositions[2].FriendName;
                log.Longitude2 = myFriendsPositions[2].Longitude;
                log.Latitude2 = myFriendsPositions[2].Latitude;
                log.CalcNearFriend2 = myFriendsPositions[2].Calc;
            }
            catch
            {

            }
            try
            {
                log.FriendName3 = myFriendsPositions[3].FriendName;
                log.Longitude3 = myFriendsPositions[3].Longitude;
                log.Latitude3 = myFriendsPositions[3].Latitude;
                log.CalcNearFriend3 = myFriendsPositions[3].Calc;
            }
            catch
            {


            }
            return log; 
        }

    }
}
