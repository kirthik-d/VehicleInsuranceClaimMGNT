using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleInsuranceClaimMSAPIConnect.Models;

namespace VehicleInsuranceClaimMSAPIConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleClaimDb_81316Context _context;

        public VehiclesController(VehicleClaimDb_81316Context context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("get-all-vehicles")]
        public IEnumerable<Vehicles> getAllVehicles()
        {
            return _context.Vehicles.ToList();
        }

        [HttpPost]
        [Route("post-new-vehicle")]
        public ActionResult postNewVehicle(Vehicles vehicle)
        {
            var result = _context.Vehicles.Add(vehicle);
            return Ok(result);
        }

    }
}