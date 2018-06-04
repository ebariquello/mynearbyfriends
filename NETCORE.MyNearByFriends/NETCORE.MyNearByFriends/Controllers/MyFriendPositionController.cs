using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCORE.MyNearByFriends.Models;
using NETCORE.MyNearByFriends.Services;

namespace NETCORE.MyNearByFriends.Controllers
{
    [Produces("application/json")]
    [Route("api/mfp")]
    public class MyFriendPositionController : Controller
    {
        private readonly IMyFriendPositionService _service;

        public MyFriendPositionController(IMyFriendPositionService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet, Route("ListMyFriendsPositions")]
        public async Task<List<MyFriendPosition>> ListMyFriendsPositions()
        {
            var result = await _service.GetAll();
            return result;
        }
        [Authorize("Bearer")]
        [HttpGet, Route("GetTop3FriendsNearByVisitedFriend/{id}")]
        public async Task<List<MyFriendPosition>> GetTop3FriendsNearByVisitedFriend(int id)
        {
            var result = await _service.GetTop3FriendsNearByVisitedFriend(id);
            return result;
        }

        
    }
}