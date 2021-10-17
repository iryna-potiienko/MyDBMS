using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBMSServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDBMS.Contexts;
using MyDBMS.Models;
using Attribute = MyDBMS.Models.Attribute;

namespace RESTWebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly AttributeService _attributeService;

        public AttributeController(AttributeService attributeService)
        {
            _attributeService = attributeService;
        }

        // GET: api/Attribute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attribute>>> GetAttributes()
        {
            return await _attributeService.GetAll();
        }

        // GET: api/Attribute/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attribute>> GetAttribute(int id)
        {
            var attribute = await _attributeService.Get(id);

            if (attribute == null)
            {
                return NotFound();
            }

            return attribute;
        }

        // PUT: api/Attribute/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttribute(int id, Attribute attribute)
        {
            if (id != attribute.Id)
            {
                return BadRequest();
            }

            var updated = await _attributeService.Edit(id, attribute);
            if (updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Attribute
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attribute>> PostAttribute(Attribute attribute)
        {
            var created = await _attributeService.Create(attribute);

            return CreatedAtAction("GetAttribute", new {id = created.Id}, created);
        }

        // DELETE: api/Attribute/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute(int id)
        {
            var deleted = await _attributeService.Delete(id);
            if (deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
