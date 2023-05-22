using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleInsuranceClaimMSAPIConnect.LoginCredentials;
using VehicleInsuranceClaimMSAPIConnect.Models;

namespace VehicleInsuranceClaimMSAPIConnect.Service
{
    public class UserService : IUserService
    {
        private readonly VehicleClaimDb_81316Context _context;

        public UserService(VehicleClaimDb_81316Context context)
        {
            context = _context;
        }


        Users IUserService.AddUser(Users user)
        {
            
            var u = _context.Users.Add(user);
            _context.SaveChanges();
            if (u != null)
                return user;
            else return null;
             
        }

        List<Users> IUserService.GetAllUsers()
        {
            return _context.Users.ToList<Users>();
        }
    }
}
