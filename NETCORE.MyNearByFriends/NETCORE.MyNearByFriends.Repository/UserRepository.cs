using NETCORE.MyNearByFriends.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NETCORE.MyNearByFriends.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyFriendsPositionContext _context;

        public UserRepository(MyFriendsPositionContext context)
        {
            _context = context;
        }

        public User Auth(string login, string pwd)
        {
            var user = _context.Users.Where(u => u.UserLogin == login && u.Password == pwd)
          .SingleOrDefault();

            return user;
        }

        public User GetByID(int userID)
        {
            var user =  _context.Users.Where(u => u.UserID  == userID)
           .SingleOrDefault();

            return user;
        }

        public User Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
