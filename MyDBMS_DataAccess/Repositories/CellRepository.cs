using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDBMS.Contexts;
using MyDBMS.Models;

namespace MyDBMS.Repositories
{
    public class CellRepository
    {
        private readonly MyDBMSContext _context;

        public CellRepository(MyDBMSContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        
        public async Task<Cell> Create(Cell cell)
        {
            var table = await _context.Rows.FindAsync(cell.RowId);
            if (table == null)
            {
                return null;
            }
            
            var attribute = await _context.Attributes.FindAsync(cell.AttributeName);
            if (attribute == null)
            {
                return null;
            }

            _context.Cells.Add(cell);
            await _context.SaveChangesAsync();

            return cell;
        }

        public Task<List<Cell>> FindAll()
        {
            return _context.Cells.ToListAsync();
        }
        
        public Cell FindById(int id)
        {
            return _context.Cells.Find(id);
        }

        public void Update(Cell cell)
        {
            _context.Cells.Update(cell);
            _context.SaveChanges();
        }

        public void Delete(Cell cell)
        {
            _context.Cells.Remove(cell);
            _context.SaveChanges();
        }
    }
}