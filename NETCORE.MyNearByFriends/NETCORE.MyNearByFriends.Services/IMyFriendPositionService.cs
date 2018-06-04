using NETCORE.MyNearByFriends.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NETCORE.MyNearByFriends.Services
{
    public interface IMyFriendPositionService
    {
        Task<List<MyFriendPosition>> GetAll();
        Task<List<MyFriendPosition>> GetTop3FriendsNearByVisitedFriend(int id);
    }
}
