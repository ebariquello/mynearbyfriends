using NETCORE.MyNearByFriends.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NETCORE.MyNearByFriends.Services
{
    public interface IUserService
    {
        User GetbyID(int userID);

        User Auth(string login, string pwd);
        User Register(User user);
    }
}
