﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventAPI;
using AutoMapper;


namespace EventAPI.Models
{
    [Route("api/hotel")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        MailingContext _context = new MailingContext();
        private readonly IMapper _mapper;
        public HotelsController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // GET: api/Hotels
        [HttpGet]
        public IEnumerable<HotelDTO> GetHotel()
        {
            Hotel hotel_name = new Hotel();
            var model = _mapper.Map<Hotel, HotelDTO>(hotel_name);
            var hotels = _context.Hotel.ToList();
            List<HotelDTO> list_obj = _mapper.Map<List<Hotel>, List<HotelDTO>>(hotels);
            return list_obj;
            
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _hotel = await _context.Hotel
            .SingleOrDefaultAsync(u => u.Id == id);
            var model = _mapper.Map<HotelDTO>(_hotel);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel([FromRoute] int id, [FromBody] HotelDTO _hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != _hotel.Id)
            {
                return BadRequest();
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HotelDTO, Hotel>());
            var mapper = config.CreateMapper();
            Hotel hotel_map = mapper.Map<Hotel>(_hotel);

            _context.Entry(hotel_map).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        [HttpPost]
        public async Task<IActionResult> PostHotel([FromBody] HotelDTO _hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<HotelDTO, Hotel>());
                var mapper = config.CreateMapper();
                Hotel hotel_map = mapper.Map<Hotel>(_hotel);

                _context.Hotel.Add(hotel_map);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
               
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHotel", new { id = _hotel.Id }, _hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _hotel = await _context.Hotel
           .SingleOrDefaultAsync(u => u.Id == id);
            var model = _mapper.Map<HotelDTO>(_hotel);
            if (_hotel == null)
            {
                return NotFound();
            }

            _context.Hotel.Remove(_hotel);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.Id == id);
        }
    }
}
