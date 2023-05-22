using VehicleInsuranceClaimMSAPIConnect.LoginCredentials;

namespace VehicleInsuranceClaimMSAPIConnect.Models
{
    public interface ITokenGeneration
    {
        string GenerateToken(LoginCreds userCreds);
    }
}