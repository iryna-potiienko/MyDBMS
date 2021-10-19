using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDBMS.Contexts;
using MyDBMS.Models;

namespace MyDBMS.Repositories
{
    public class TableRepository
    {
        private readonly MyDBMSContext _context;

        public TableRepository(MyDBMSContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        
        public async Task<Table> Create(Table table)
        {
            var database = await _context.Databases.FindAsync(table.DatabaseId);

            if (database == null)
            {
                return null;
            }

            //table.Database = database;
            _context.Tables.Add(table);

            // database.Tables.Add(table);
            // _context.Databases.Update(database);
            await _context.SaveChangesAsync();

            return table;
        }

        public Task<List<Table>> FindAll()
        {
            return _context.Tables.ToListAsync();
        }
        
        public async Task<Table> FindById(int id)
        {
            return await _context.Tables.FindAsync(id);
        }

        public void Update(Table table)
        {
            _context.Tables.Update(table);
            _context.SaveChanges();
        }

        public void Delete(Table table)
        {
            _context.Tables.Remove(table);
            _context.SaveChanges();
        }
    }
}