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
    [Route("api/[controller]")]
    [ApiController]
    public class NewslettersController : ControllerBase
    {
        MailingContext _context = new MailingContext();
        
       
           
          
        
        // GET: api/Newsletters
       [HttpGet]
        public object GetNewsletter()
        {
            List<NewsletterDTO> list_newsletters = Mapper.Map<List<Newsletter>, List<NewsletterDTO>>(_context.Newsletter.ToList());
            List<NewsletterToParticipantDTO> list_newsletters_to_participants = Mapper.Map<List<NewsletterToParticipant>,
                List<NewsletterToParticipantDTO>>(_context.NewsletterToParticipant.ToList());
            var newsletter_to_participant_dto_groups = from c in list_newsletters_to_participants
                                                       group c by c.NewsletterId;
            
            var _newsletter_dto = list_newsletters.Join(newsletter_to_participant_dto_groups,
                p => p.Id,
                t => t.Key,
                (p, t) => new { Id = p.Id, EventId = p.EventId, SendDateTime = p.SendDateTime,
                    Message = p.Message, File = p.File, Participants = t.ToHashSet() }
                );
            
            return _newsletter_dto.ToList();
        }

        // GET: api/Newsletters/5
        [HttpGet("{id}")]
        public object GetNewsletter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<NewsletterDTO> list_newsletters = Mapper.Map<List<Newsletter>, List<NewsletterDTO>>(_context.Newsletter.ToList());
            List<NewsletterToParticipantDTO> list_newsletters_to_participants = Mapper.Map<List<NewsletterToParticipant>,
                List<NewsletterToParticipantDTO>>(_context.NewsletterToParticipant.ToList());
            var newsletter_to_participant_dto_groups = from c in list_newsletters_to_participants
                                                       group c by c.NewsletterId;

            var _newsletter_dto = list_newsletters.Join(newsletter_to_participant_dto_groups,
                p => p.Id,
                t => t.Key,
                (p, t) => new {
                    Id = p.Id,
                    EventId = p.EventId,
                    SendDateTime = p.SendDateTime,
                    Message = p.Message,
                    File = p.File,
                    Participants = t.ToHashSet()
                }
                );
            var newsletter = _newsletter_dto.SingleOrDefault(u => u.Id == id);

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