using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleInsuranceClaimMSAPIConnect.LoginCredentials;
using VehicleInsuranceClaimMSAPIConnect.Models;

namespace VehicleInsuranceClaimMSAPIConnect.Service
{
    public interface IUserService
    {
        Users AddUser(Users user);
        List<Users> GetAllUsers();
    }
}
