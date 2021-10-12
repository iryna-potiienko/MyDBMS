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

namespace RESTWebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public DatabaseController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // GET: api/Database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Database>>> GetDatabases()
        {
            return _databaseService.GetAll(); //await _context.Databases.ToListAsync();
        }

        // GET: api/Database/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Database>> GetDatabase(int id)
        {
            var database = _databaseService.Get(id);//await _context.Databases.FindAsync(id);

            if (database == null)
            {
                return NotFound();
            }

            return database;
        }

        // PUT: api/Database/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatabase(int id, Database database)
        {
            /*if (id != database.Id)
            {
                return BadRequest();
            }

            _context.Entry(database).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatabaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();*/

            var updated = _databaseService.Edit(id, database);
            if(updated)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        // POST: api/Database
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Database>> PostDatabase(Database database)
        {
            var created = _databaseService.Create(database);

            return CreatedAtAction("GetDatabase", new {id = created.Id}, created);
        }

        // DELETE: api/Database/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatabase(int id)
        {
            var deleted = _databaseService.Delete(id);
            if (deleted)
            {
                return NotFound();
            }
            
            return NoContent();

            // var database = _databaseService.Delete(id); //await _context.Databases.FindAsync(id);
            // if (database == null)
            // {
            //     return NotFound();
            // }
            //
            // _context.Databases.Remove(database);
            // await _context.SaveChangesAsync();
            //
            // return NoContent();
        }

        // private bool DatabaseExists(int id)
        // {
        //     return _context.Databases.Any(e => e.Id == id);
        // }
    }
}
