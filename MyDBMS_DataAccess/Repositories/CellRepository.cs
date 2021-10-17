using System.Collections.Generic;
using System.Linq;
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
            var row = await _context.Rows.FindAsync(cell.RowId);
            if (row == null)
            {
                return null;
            }
            
            var attribute = await _context.Attributes.FindAsync(cell.AttributeId);
            if (attribute == null)
            {
                return null;
            }

            if (row.TableId != attribute.TableId) return null;


            cell.Row = row;
            cell.Attribute = attribute;
            _context.Cells.Add(cell);
            
            // row.Cells.Add(cell);
            // _context.Rows.Update(row);
            await _context.SaveChangesAsync();

            return cell;
        }

        public Task<List<Cell>> FindAll()
        {
            return _context.Cells.ToListAsync();
        }
        
        public async Task<Cell> FindById(int id)
        {
            return await _context.Cells.FindAsync(id);
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

        public List<Cell> GetByRowId(int rowId)
        {
            return _context.Cells.Where(c => c.RowId == rowId).ToList();
        }
        public List<Cell> GetByAttributeId(int attributeId)
        {
            return _context.Cells.Where(c => c.AttributeId == attributeId).ToList();
        }
        public List<Cell> FindInTable(int rowId)
        {
            return _context.Cells.Where(c => c.RowId == rowId).Where(c => c.RowId == rowId).ToList();
        }
    }
}