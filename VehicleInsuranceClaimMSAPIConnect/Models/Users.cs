using System;
using System.Collections.Generic;

namespace VehicleInsuranceClaimMSAPIConnect.Models
{
    public partial class Users
    {
        public Users()
        {
            Claims = new HashSet<Claims>();
            Vehicles = new HashSet<Vehicles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        
        public string PinCode { get; set; }
        public int? NoOfClaims { get; set; }
        public string Password { get; set; }

        public ICollection<Claims> Claims { get; set; }
        public ICollection<Vehicles> Vehicles { get; set; }
      
    }
}
