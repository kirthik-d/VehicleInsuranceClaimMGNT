using System;
using System.Collections.Generic;

namespace VehicleInsuranceClaimMSAPIConnect.Models
{
    public partial class InsuranceCompanies
    {
        public int CompanyIdentificationNo { get; set; }
        public string CompanyName { get; set; }
        public string CompanyContact { get; set; }
        public string CompanyAddress { get; set; }
    }
}
