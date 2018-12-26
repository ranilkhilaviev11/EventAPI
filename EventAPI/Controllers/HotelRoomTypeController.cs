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
    [Route("api/hotel_room_type")]
    [ApiController]
    public class HotelRoomTypeController : ControllerBase
    {
        MailingContext _context = new MailingContext();



        // GET: api/hotel_room_type
        [HttpGet]
        public IEnumerable<HotelRoomTypeDTO> GetHotelRoomType()
        {
            HotelRoomType hotel_room_type = new HotelRoomType();
            var model = Mapper.Map<HotelRoomType, HotelRoomTypeDTO>(hotel_room_type);
            var hotel_room_types = _context.HotelRoomType.ToList();
            List<HotelRoomTypeDTO> list_obj = Mapper.Map<List<HotelRoomType>, List<HotelRoomTypeDTO>>(hotel_room_types);
            return list_obj;
        }

        // GET: api/hotel_room_type/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gethotel_room_type([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotel_room_type = await _context.HotelRoomType
             .SingleOrDefaultAsync(u => u.Id == id);
            var model = Mapper.Map<HotelRoomTypeDTO>(hotel_room_type);

            if (hotel_room_type == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/hotel_room_type/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthotel_room_type([FromRoute] int id, [FromBody] HotelRoomTypeDTO hotel_room_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotel_room_type.Id)
            {
                return BadRequest();
            }


            HotelRoomType hotel_room_type_map = Mapper.Map<HotelRoomType>(hotel_room_type);

            _context.Entry(hotel_room_type_map).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hotel_room_typeExists(id))
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

        // POST: api/hotel_room_type
        [HttpPost]
        public async Task<IActionResult> Posthotel_room_type([FromBody] HotelRoomTypeDTO hotel_room_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {

                HotelRoomType hotel_room_type_map = Mapper.Map<HotelRoomType>(hotel_room_type);

                _context.HotelRoomType.Add(hotel_room_type_map);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (hotel_room_typeExists(hotel_room_type.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Gethotel_room_type", new { id = hotel_room_type.Id }, hotel_room_type);
        }

        // DELETE: api/hotel_room_type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehotel_room_type([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotel_room_type = await _context.HotelRoomType.FindAsync(id);
            var model = Mapper.Map<HotelRoomTypeDTO>(hotel_room_type);
            if (hotel_room_type == null)
            {
                return NotFound();
            }

            _context.HotelRoomType.Remove(hotel_room_type);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        private bool hotel_room_typeExists(int id)
        {
            return _context.HotelRoomType.Any(e => e.Id == id);
        }
    }
}