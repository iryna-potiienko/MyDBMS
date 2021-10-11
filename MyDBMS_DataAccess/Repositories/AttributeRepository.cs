using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDBMS.Contexts;
using MyDBMS.Models;

namespace MyDBMS.Repositories
{
    public class AttributeRepository
    {
        private readonly MyDBMSContext _context;

        public AttributeRepository(MyDBMSContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        
        public async Task<Attribute> Create(Attribute attribute)
        {
            var table = await _context.Tables.FindAsync(attribute.TableId);

            if (table == null)
            {
                return null;
            }

            _context.Attributes.Add(attribute);
            await _context.SaveChangesAsync();

            return attribute;
        }

        public Task<List<Attribute>> FindAll()
        {
            return _context.Attributes.ToListAsync();
        }
        
        public Attribute FindById(int id)
        {
            return _context.Attributes.Find(id);
        }

        public void Update(Attribute attribute)
        {
            _context.Attributes.Update(attribute);
            _context.SaveChanges();
        }

        public void Delete(Attribute attribute)
        {
            _context.Attributes.Remove(attribute);
            _context.SaveChanges();
        }
    }
}