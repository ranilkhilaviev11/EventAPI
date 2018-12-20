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
    [Route("api/country")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        MailingContext _context = new MailingContext();
        private readonly List<Country> _countries;
        public CountriesController()
        {
            _countries = _context.Country.ToList();
        }

        [HttpGet]
        public IEnumerable<CountryDTO> GetCountry()
        {

            List<CountryDTO> list_obj = Mapper.Map(_countries, new List<CountryDTO>());

            return list_obj;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = await _context.Country.FindAsync(id);
            var model = Mapper.Map(country, new CountryDTO());

            if (country == null)
            {
                return NotFound();
            }

            return Ok(model);
        }


    }
}