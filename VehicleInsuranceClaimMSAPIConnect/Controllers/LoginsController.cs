using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleInsuranceClaimMSAPIConnect.LoginCredentials;
using VehicleInsuranceClaimMSAPIConnect.Models;
using VehicleInsuranceClaimMSAPIConnect.Service;

namespace VehicleInsuranceClaimMSAPIConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly VehicleClaimDb_81316Context _vehicleClaimDb_81316Context;

        private readonly ILoginService _loginService;
        private readonly IUserService _userService;

        public LoginsController(VehicleClaimDb_81316Context vehicleClaimDb_81316Context, ILoginService loginService)
        {
            _vehicleClaimDb_81316Context = vehicleClaimDb_81316Context;
            _loginService = loginService;           
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginCreds user)
        {
            var result = _loginService.Login(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Invalid userName or Password");
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register(Users user)
        {
            var result = _userService.GetAllUsers().FirstOrDefault(u => u.UserName == user.UserName);

            if (result == null)
            {
                _vehicleClaimDb_81316Context.Users.Add(user);
                _vehicleClaimDb_81316Context.SaveChanges();
                return Ok(user);
            }
            else
            {
                return BadRequest("User is already exists");
            }
        }


    }
}