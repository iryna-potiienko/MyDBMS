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
    public class CellController : ControllerBase
    {
        private readonly CellService _cellService;
        private readonly ValidateService _validateService;

        public CellController(CellService cellService, ValidateService validateService)
        {
            _cellService = cellService;
            _validateService = validateService;
        }

        // GET: api/Cell
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cell>>> GetCells()
        {
            return await _cellService.GetAll();
        }

        // GET: api/Cell/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cell>> GetCell(int id)
        {
            var cell = await _cellService.Get(id);

            if (cell == null)
            {
                return NotFound();
            }

            return cell;
        }

        // PUT: api/Cell/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCell(int id, Cell cell)
        {
            if (id != cell.Id)
            {
                return BadRequest();
            }

            var updated = await _cellService.Edit(id, cell);
            if (updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Cell
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cell>> PostCell(Cell cell)
        {
            var tryValidate = await _validateService.ValidateCell(cell);
            if (tryValidate)
            {
                var created = await _cellService.Create(cell);
                return CreatedAtAction("GetCell", new {id = created.Id}, created);
            }
            
            ModelState.AddModelError("Name", "Incorrect type");
            return BadRequest();
        }

        // DELETE: api/Cell/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCell(int id)
        {
            var deleted = await _cellService.Delete(id);
            if (deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
