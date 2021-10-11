using System.Collections.Generic;
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
        
        public Database FindById(int id)
        {
            return _context.Databases.Find(id);
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
    }
}