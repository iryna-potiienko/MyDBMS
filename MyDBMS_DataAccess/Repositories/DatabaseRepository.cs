using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDBMS.Contexts;
using MyDBMS.Models;

namespace MyDBMS.Repositories
{
    public class DatabaseRepository
    {
        private readonly MyDBMSContext _context;

        public DatabaseRepository(MyDBMSContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        
        public async Task<Database> Create(Database database)
        {
            _context.Databases.Add(database);
            await _context.SaveChangesAsync();

            return database;
        }

        public Task<List<Database>> FindAll()
        {
            return _context.Databases.ToListAsync();
        }
        
        public async Task<Database> FindById(int id)
        {
            return await _context.Databases.FindAsync(id);
        }

        public void Update(Database database)
        {
            _context.Databases.Update(database);
            _context.SaveChanges();
        }

        public void Delete(Database database)
        {
            _context.Databases.Remove(database);
            _context.SaveChanges();
        }

        public async Task<Database> GetFullDatabase(int id)
        {
            var tables = await _context.Tables
                     .Include(t => t.Attributes)
                     .Include(t => t.Rows)
                     .ThenInclude(t => t.Cells)
                     .Where(t=>t.DatabaseId==id)
                     .ToListAsync();

            var database = await FindById(id);
            var finalDatabase = new Database()
            {
                Id = database.Id,
                Name = database.Name,
                Tables = tables
            };
            return finalDatabase;

            // return await _context.Databases.Include(t => t.Tables)
            //     .ThenInclude(t => t.Attributes)
            //     .ThenInclude(t => t.Cells)
            //     .Where(t => t.Id == id)
            //     .FirstAsync();

        }

        public bool DatabaseExist(int id)
        {
            return _context.Databases.Any(d => d.Id == id);
        }
    }
}