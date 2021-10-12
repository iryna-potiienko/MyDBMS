using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDBMS.Contexts;
using MyDBMS.Models;

namespace MyDBMS.Repositories
{
    public class RowRepository
    {
        private readonly MyDBMSContext _context;

        public RowRepository(MyDBMSContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        
        public async Task<Row> Create(Row row)
        {
            var table = await _context.Tables.FindAsync(row.TableId);

            if (table == null)
            {
                return null;
            }

            _context.Rows.Add(row);
            await _context.SaveChangesAsync();

            return row;
        }

        public Task<List<Row>> FindAll()
        {
            return _context.Rows.ToListAsync();
        }
        
        public async Task<Row> FindById(int id)
        {
            return await _context.Rows.FindAsync(id);
        }

        public void Update(Row row)
        {
            _context.Rows.Update(row);
            _context.SaveChanges();
        }

        public void Delete(Row row)
        {
            _context.Rows.Remove(row);
            _context.SaveChanges();
        }

        public Task<List<Row>> FindByTableId(int tableId)
        {
            return _context.Rows.Where(r => r.TableId == tableId).ToListAsync();
        }
    }
}