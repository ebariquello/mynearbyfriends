using NETCORE.MyNearByFriends.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NETCORE.MyNearByFriends.Repository
{
    public interface IUserRepository
    {
        User GetByID(int userID);

        User Register(User user);
        User Auth(string login, string pwd);
    }
}
