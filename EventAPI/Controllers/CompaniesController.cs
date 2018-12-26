using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventAPI;
using AutoMapper;

namespace EventAPI.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        MailingContext _context = new MailingContext();
        

        // GET: api/Companies
        [HttpGet]
        public IEnumerable<CompanyDTO> GetCompany()
        { 
            List<CompanyDTO> list_obj = Mapper.Map(_context.Company.ToList(), new List<CompanyDTO>());
            return list_obj;
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _company = await _context.Company
             .SingleOrDefaultAsync(u => u.Id == id);
            var model = Mapper.Map<CompanyDTO>(_company);

            if (_company == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany([FromRoute] int id, [FromBody] CompanyDTO _company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != _company.Id)
            {
                return BadRequest();
            }
           

            try
            {
                Company company_map = Mapper.Map<Company>(_company);
                _context.Entry(company_map).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (!CompanyExists(id))
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

        // POST: api/Companies
        [HttpPost]
        public async Task<IActionResult> PostCompany([FromBody] CompanyDTO _company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
               
                Company company_map = Mapper.Map<Company>(_company);
                _context.Company.Add(company_map);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompanyExists(_company.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompany", new { id = _company.Id }, _company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _company = await _context.Company
           .SingleOrDefaultAsync(u => u.Id == id);
            var model = Mapper.Map<CompanyDTO>(_company);
            if (_company == null)
            {
                return NotFound();
            }

            _context.Company.Remove(_company);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.Id == id);
        }
    }
}