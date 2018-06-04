using NETCORE.MyNearByFriends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETCORE.MyNearByFriends.Repository
{
    public interface IMyFriendPositionRepository
    {
        Task<List<MyFriendPosition>> GetAll();
        Task<MyFriendPosition> GetByID(int myFriendPositionID);
        Task<int> Save(MyFriendPosition myFriendPosition);
        
    }
}
