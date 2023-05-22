using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleInsuranceClaimMSAPIConnect.LoginCredentials;
using VehicleInsuranceClaimMSAPIConnect.Service;

namespace VehicleInsuranceClaimMSAPIConnect.Models
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;
        private readonly ITokenGeneration _tokenGeneration;
         

        public LoginService(IUserService userService, ITokenGeneration tokenGeneration)
        {
            _userService = userService;
            _tokenGeneration = tokenGeneration;
        }
        public LoginCreds Login(LoginCreds userCreds)
        {
            var user = _userService.GetAllUsers().FirstOrDefault(u=>u.UserName == userCreds.UserName);
               
            if (user != null)
            {

                if (user.Password != userCreds.Password)
                {
                    return null;
                }
                userCreds.Password = user.Password;
                userCreds.Token = _tokenGeneration.GenerateToken(userCreds);
                return userCreds;
            }
            return null;
        }

        public LoginCreds Register(Users user)
        {

            Users userDetails = null;
            var users = _userService.GetAllUsers().FirstOrDefault(u => u.UserName == user.UserName);
            if (users == null)
            {
                userDetails = _userService.AddUser(user);
            }


            if (userDetails != null)
                return new LoginCreds
                {
                    UserName = user.UserName,
                    Token = _tokenGeneration.GenerateToken(new LoginCreds { UserName = user.UserName })
                };
            return null;
        }
    }
}
