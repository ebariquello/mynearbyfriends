using NETCORE.MyNearByFriends.Models;
using NETCORE.MyNearByFriends.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE.MyNearByFriends.Services
{
    public class MyFriendPositionService : IMyFriendPositionService
    {
        private IMyFriendPositionRepository _repository;
        private ICalcHistoryLogService _logService;
        public MyFriendPositionService(IMyFriendPositionRepository repository, ICalcHistoryLogService logService)
        {
            _repository = repository;
            _logService = logService;
            CheckIfFriendPositionsHasDuplication();
        }

        public async Task<List<MyFriendPosition>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<List<MyFriendPosition>> GetTop3FriendsNearByVisitedFriend(int id)
        {
            var myFriendsPositions = await _repository.GetAll();
            var myVisitedFriendPosition = myFriendsPositions.Where(mfp => mfp.MyFriendPositionId == id).FirstOrDefault();
            List<MyFriendPosition> myFriendPositionsFinalResult = CalcTop3FriendsNearMyCurrentPosition(myFriendsPositions, myVisitedFriendPosition);
            if (myFriendPositionsFinalResult != null && myFriendPositionsFinalResult.Count > 0)
            {
                var logObj = _logService.PreparaCalcHistoryLog(myFriendPositionsFinalResult, string.Empty);
                logObj.CalcHistoryLogId = await _logService.RegisterLog(logObj);
            }
            return myFriendPositionsFinalResult;
        }
        #region Private Methods
        private async void CheckIfFriendPositionsHasDuplication()
        {
            var myFriendsPositions = await _repository.GetAll();

            foreach (MyFriendPosition mfp in myFriendsPositions)
            {
                var result = myFriendsPositions.FindAll(mfpAux => mfpAux.Latitude == mfp.Latitude && mfpAux.Longitude == mfp.Longitude).ToList();
                if (result!=null &&  result.Count>1) throw new Exception("Already exists a friend of mine with this Localization!");
            }
        }

        private List<MyFriendPosition> CalcTop3FriendsNearMyCurrentPosition(List<MyFriendPosition> myFriendsPositions, MyFriendPosition myVisitedFriendPosition)
        {
            List<MyFriendPosition> myFriendPositionsFinalResult = new List<MyFriendPosition>();
            myFriendPositionsFinalResult.Add(myVisitedFriendPosition);
            foreach (var myFriendPosition in myFriendsPositions)
            {
                if (myFriendPosition == myVisitedFriendPosition)
                    continue;
                var aElevated2 = Math.Pow((myVisitedFriendPosition.Latitude - myFriendPosition.Latitude), 2);
                var bElevated2 = Math.Pow((myVisitedFriendPosition.Longitude - myFriendPosition.Longitude), 2);
                var sqrtA2B2 = Math.Sqrt(aElevated2 + bElevated2);
                myFriendPosition.Calc = sqrtA2B2;
                myFriendPositionsFinalResult.Add(myFriendPosition);
            }
            var friendNearMeOrderedByDistance = myFriendPositionsFinalResult.OrderBy(mfpKeyValue => mfpKeyValue.Calc).Take(3).ToList();
            return friendNearMeOrderedByDistance;
        }
        #endregion
    }
}
