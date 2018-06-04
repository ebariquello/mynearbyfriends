using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NETCORE.MyNearByFriends.Auth;
using NETCORE.MyNearByFriends.Models;
using NETCORE.MyNearByFriends.Services;
using Newtonsoft.Json;

namespace NETCORE.MyNearByFriends.Controllers
{
    [Route("api/[controller]")]
    public class TokenAuthController : Controller
    {
        IUserService _service = null;
        public TokenAuthController( IUserService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]User user)
        {
            var existUser = _service.Auth(user.UserLogin, user.Password);

            if (existUser != null)
            {
                var requestAt = DateTime.Now;
                var expiresIn = requestAt + TokenAuthOption.ExpiresSpan;
                var token = GenerateToken(existUser, expiresIn);

                return JsonConvert.SerializeObject(new RequestResult
                {
                    State = RequestState.Success,
                    Data = new
                    {
                        requertAt = requestAt,
                        expiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds,
                        tokeyType = TokenAuthOption.TokenType,
                        accessToken = token
                    }
                });
            }
            else
            {
                return JsonConvert.SerializeObject(new RequestResult
                {
                    State = RequestState.Failed,
                    Msg = "Username or password is invalid"
                });
            }
        }

        [HttpGet]
        [Authorize("Bearer")]
        public string GetUserInfo()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            return JsonConvert.SerializeObject(new RequestResult
            {
                State = RequestState.Success,
                Data = new
                {
                    UserName = claimsIdentity.Name
                }
            });
        }

        private string GenerateToken(User user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserLogin, "TokenAuth"),
                new[] {
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserLogin.ToString())
                }
            );
            DateTime createDate = DateTime.Now;
            DateTime expiresDate = createDate +
               TokenAuthOption.ExpiresSpan;

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expiresDate
            });
            return handler.WriteToken(securityToken);
        }
    }

}