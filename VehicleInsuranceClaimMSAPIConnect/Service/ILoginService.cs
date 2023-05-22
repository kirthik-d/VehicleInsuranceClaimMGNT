using VehicleInsuranceClaimMSAPIConnect.Models;
using VehicleInsuranceClaimMSAPIConnect.LoginCredentials;


namespace VehicleInsuranceClaimMSAPIConnect.Models
{
    public interface ILoginService
    {
        LoginCreds Login(LoginCreds userCreds);
        LoginCreds Register(Users user);

    }
}
