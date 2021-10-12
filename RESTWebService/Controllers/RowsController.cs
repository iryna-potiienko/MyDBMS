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
    public class RowsController : ControllerBase
    {
        private readonly RowService _rowService;

        public RowsController(RowService rowService)
        {
            _rowService = rowService;
        }

        // GET: api/Rows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Row>>> GetRows()
        {
            return await _rowService.GetAll();
        }

        // GET: api/Rows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Row>> GetRow(int id)
        {
            var row = await _rowService.Get(id);

            if (row == null)
            {
                return NotFound();
            }

            return row;
        }

        // PUT: api/Rows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRow(int id, Row row)
        {
            if (id != row.Id)
            {
                return BadRequest();
            }

            var updated = await _rowService.Edit(id, row);
            if (updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Rows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Row>> PostRow(Row row)
        {
            var created = await _rowService.Create(row);

            return CreatedAtAction("GetRow", new { id = created.Id }, created);
        }

        // DELETE: api/Rows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRow(int id)
        {
            var deleted = await _rowService.Delete(id);
            if (deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        [HttpGet("GetByTableId/{tableId}")]
        public async Task<ActionResult<List<Row>>> GetRowsInTable(int tableId)
        {
            var row = await _rowService.GetByTableId(tableId);

            if (row == null)
            {
                return NotFound();
            }

            return row;
        }
    }
}
