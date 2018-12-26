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
    [Route("api/type")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        MailingContext _context = new MailingContext();

        // GET: api/type
        [HttpGet]
        public IEnumerable<TypeDTO> GetType()
        {
            Type type = new Type();
            var model = Mapper.Map<Type, TypeDTO>(type);
            var types = _context.Type.ToList();
            List<TypeDTO> list_obj = Mapper.Map<List<Type>, List<TypeDTO>>(types);
            return list_obj;
        }

        // GET: api/type/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var type = await _context.Type.FindAsync(id);
            var model = Mapper.Map<TypeDTO>(type);

            if (type == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

       
    }
}