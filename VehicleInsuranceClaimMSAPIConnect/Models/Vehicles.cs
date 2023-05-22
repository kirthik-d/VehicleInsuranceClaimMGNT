using System;
using System.Collections.Generic;

namespace VehicleInsuranceClaimMSAPIConnect.Models
{
    public partial class Vehicles
    {
        public Vehicles()
        {
            Policy = new HashSet<Policy>();
        }

        public int VehicleNo { get; set; }
        public string VehicleName { get; set; }
        public string VehicleType { get; set; }
        public string VehicleModelMaker { get; set; }
        public string GrossVehicleWeight { get; set; }
        public string VehiclePower { get; set; }
        public string VehicleCapacity { get; set; }
        public string VehicleLength { get; set; }
        public string VehicleOwner { get; set; }
        public string VehicleEngineNo { get; set; }
        public string FuelType { get; set; }
        public string VehicleCompany { get; set; }
        public int? OwnerId { get; set; }

        public Users Owner { get; set; }
        public ICollection<Policy> Policy { get; set; }

    }
}
