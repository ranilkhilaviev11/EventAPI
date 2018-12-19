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
        private readonly IMapper _mapper;
        public CountriesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CountryDTO> GetCountry()
        {
            Country country = new Country();
            var model = _mapper.Map<Country, CountryDTO>(country);
            var countries = _context.Country.ToList();
            List<CountryDTO> list_obj = _mapper.Map<List<Country>, List<CountryDTO>>(countries);
            
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
            var model = _mapper.Map<CountryDTO>(country);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        
    }
}