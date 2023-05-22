using System;
using System.Collections.Generic;

namespace VehicleInsuranceClaimMSAPIConnect.Models
{
    public partial class Claims
    {
        public int ClaimId { get; set; }
        public int PolicyId { get; set; }
        public string VehicleBill { get; set; }
        public string DriverLicenceNo { get; set; }
        public string VehicleCondition { get; set; }
        public string ClaimStatus { get; set; }
        public int UserId { get; set; }

        public Policy Policy { get; set; }
        public Users User { get; set; }
    }
}
