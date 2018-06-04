
using Microsoft.EntityFrameworkCore;
using NETCORE.MyNearByFriends.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE.MyNearByFriends.Repository
{
    public class MyFriendPositionRepository : IMyFriendPositionRepository
    { 
        private readonly MyFriendsPositionContext _context;

        public MyFriendPositionRepository(MyFriendsPositionContext context)
        {
            _context = context;
        }

        public async Task<List<MyFriendPosition>> GetAll()
        {
            var mfps = await _context.MyFriendsPositions
            .ToListAsync();

            return mfps;
        }

        public async Task<MyFriendPosition> GetByID(int myFriendsPositionID)
        {
            var mfps = await _context.MyFriendsPositions.Where(m => m.MyFriendPositionId == myFriendsPositionID)
            .SingleOrDefaultAsync();

            return mfps;
        }

        public async Task<int> Save(MyFriendPosition myFriendPosition)
        {
            if (myFriendPosition.MyFriendPositionId > 0)
            {
                _context.Update(myFriendPosition);
                return await _context.SaveChangesAsync();
            }
            else
            {
                _context.Add(myFriendPosition);
                return await _context.SaveChangesAsync();
            }
        }

       
    }
}
