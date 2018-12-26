using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventAPI;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewslettersController : ControllerBase
    {
        MailingContext _context = new MailingContext();


        // GET: api/Newsletters
        [HttpGet]
        public object GetNewsletter()
        {
            var _newsletter = _context.Newsletter.GroupJoin(_context.NewsletterToParticipant,
                p => p.Id,
                t => t.NewsletterId,
                (p, t) => new
                {
                    Id = p.Id,
                    EventId = p.EventId,
                    SendDateTime = p.SendDateTime,
                    Message = p.Message,
                    File = p.File,
                    Participants = p.NewsletterToParticipant
                });
            return _newsletter;
        }

        // GET: api/Newsletters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsletter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newsletter = await _context.Newsletter.FindAsync(id);

            if (newsletter == null)
            {
                return NotFound();
            }

            return Ok(newsletter);
        }

        // PUT: api/Newsletters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsletter([FromRoute] int id, [FromBody] Newsletter newsletter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsletter.Id)
            {
                return BadRequest();
            }

            _context.Entry(newsletter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsletterExists(id))
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

        // POST: api/Newsletters
        [HttpPost]
        public async Task<IActionResult> PostNewsletter([FromBody] Newsletter newsletter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Newsletter.Add(newsletter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NewsletterExists(newsletter.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNewsletter", new { id = newsletter.Id }, newsletter);
        }

        // DELETE: api/Newsletters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsletter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newsletter = await _context.Newsletter.FindAsync(id);
            if (newsletter == null)
            {
                return NotFound();
            }

            _context.Newsletter.Remove(newsletter);
            await _context.SaveChangesAsync();

            return Ok(newsletter);
        }

        private bool NewsletterExists(int id)
        {
            return _context.Newsletter.Any(e => e.Id == id);
        }
    }
}