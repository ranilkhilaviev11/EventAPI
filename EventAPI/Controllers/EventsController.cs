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
    [Route("api/event")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        MailingContext _context = new MailingContext();
       
        // GET: api/Events
        [HttpGet]
        public IEnumerable<EventsDTO> GetEvent()
        {
            List<EventsDTO> list_obj = Mapper.Map<List<Events>, List<EventsDTO>>(_context.Event.ToList());
            return list_obj;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvents([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _events = await _context.Event.FindAsync(id);
            var model = Mapper.Map<EventsDTO>(_events);

            if (_events == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvents([FromRoute] int id, [FromBody] EventsDTO _events)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != _events.Id)
            {
                return BadRequest();
            }
            
            Events events_map = Mapper.Map<Events>(_events);
            _context.Entry(events_map).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventsExists(id))
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

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvents([FromBody] EventsDTO _events)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Events events_map = Mapper.Map<Events>(_events);
            _context.Event.Add(events_map);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventsExists(_events.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEvents", new { id = _events.Id }, _events);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvents([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _events = await _context.Event.FindAsync(id);
            var model = Mapper.Map<CompanyDTO>(_events);
            if (_events == null)
            {
                return NotFound();
            }

            _context.Event.Remove(_events);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        private bool EventsExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }
    }
}