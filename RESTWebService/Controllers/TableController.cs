using System.Collections.Generic;
using System.Threading.Tasks;
using DBMSServices.Services;
using Microsoft.AspNetCore.Mvc;
using MyDBMS.Models;

namespace RESTWebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TableController: ControllerBase
    {
        private readonly TableService _tableService;

        public TableController(TableService tableService)
        {
            _tableService = tableService;
        }

        // GET: api/Database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            return await _tableService.GetAll();
        }

        // GET: api/Database/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _tableService.Get(id);//await _context.Databases.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            return table;
        }

        // PUT: api/Database/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(int id, Table table)
        {
            if (id != table.Id)
            {
                return BadRequest();
            }
            
            var updated = await _tableService.Edit(id, table);
            if(updated)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        // POST: api/Database
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Table>> PostTable(Table table)
        {
            var created = await _tableService.Create(table);

            return CreatedAtAction("GetTable", new {id = created.Id}, created);
        }

        // DELETE: api/Database/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var deleted = await _tableService.Delete(id);
            if (deleted)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
