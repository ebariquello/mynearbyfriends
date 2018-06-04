using NETCORE.MyNearByFriends.Models;
using NETCORE.MyNearByFriends.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE.MyNearByFriends.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
      
        }

        public User Auth(string login, string pwd)
        {
            return _repository.Auth(login, pwd);
        }

        public User GetbyID(int userID)
        {
            return _repository.GetByID(userID);
        }

        public User Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
