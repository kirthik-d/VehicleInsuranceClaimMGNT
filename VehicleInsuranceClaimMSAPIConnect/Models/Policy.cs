using System;
using System.Collections.Generic;

namespace VehicleInsuranceClaimMSAPIConnect.Models
{
    public partial class Policy
    {
        public Policy()
        {
            Claims = new HashSet<Claims>();
        }

        public int PolicyId { get; set; }
        public int VehicleId { get; set; }
        public string PolicyName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Vehicles Vehicle { get; set; }
        public ICollection<Claims> Claims { get; set; }
    }
}
