using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleInsuranceClaimMSAPIConnect.Models;

namespace VehicleInsuranceClaimMSAPIConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceCompaniesController : ControllerBase
    {
        private readonly VehicleClaimDb_81316Context _context;

        public InsuranceCompaniesController(VehicleClaimDb_81316Context context)
        {
            _context = context;
        }

        // GET: api/InsuranceCompanies
        [HttpGet]
        public IEnumerable<InsuranceCompanies> GetInsuranceCompanies()
        {
            return _context.InsuranceCompanies;
        }

        // GET: api/InsuranceCompanies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsuranceCompanies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insuranceCompanies = await _context.InsuranceCompanies.FindAsync(id);

            if (insuranceCompanies == null)
            {
                return NotFound();
            }

            return Ok(insuranceCompanies);
        }

        // PUT: api/InsuranceCompanies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceCompanies([FromRoute] int id, [FromBody] InsuranceCompanies insuranceCompanies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insuranceCompanies.CompanyIdentificationNo)
            {
                return BadRequest();
            }

            _context.Entry(insuranceCompanies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceCompaniesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InsuranceCompanies
        [HttpPost]
        public async Task<IActionResult> PostInsuranceCompanies([FromBody] InsuranceCompanies insuranceCompanies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InsuranceCompanies.Add(insuranceCompanies);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InsuranceCompaniesExists(insuranceCompanies.CompanyIdentificationNo))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInsuranceCompanies", new { id = insuranceCompanies.CompanyIdentificationNo }, insuranceCompanies);
        }

        // DELETE: api/InsuranceCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceCompanies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insuranceCompanies = await _context.InsuranceCompanies.FindAsync(id);
            if (insuranceCompanies == null)
            {
                return NotFound();
            }

            _context.InsuranceCompanies.Remove(insuranceCompanies);
            await _context.SaveChangesAsync();

            return Ok(insuranceCompanies);
        }

        private bool InsuranceCompaniesExists(int id)
        {
            return _context.InsuranceCompanies.Any(e => e.CompanyIdentificationNo == id);
        }
    }
}