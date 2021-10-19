using System.Collections.Generic;
using System.Linq;
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
            // var table = await _context.Tables.FindAsync(attribute.TableId);
            //
            // if (table == null)
            // {
            //     return null;
            // }

            if (!TableExist(attribute.TableId))
            {
                return null;
            }
            // var type = await _context.Types.Where(a => a.Name == attribute.TypeName).FirstOrDefaultAsync();
            //
            // if (type == null)
            // {
            //     return null;
            // }

            var type = await TypeExist(attribute.TypeName);
            //attribute.Table = table;
            if (type == null)
            {
                return null;
            }

            attribute.Type = type;
            _context.Attributes.Add(attribute);
            await _context.SaveChangesAsync();

            return attribute;
        }

        public Task<List<Attribute>> FindAll()
        {
            return _context.Attributes.ToListAsync();
        }
        
        public async Task<Attribute> FindById(int id)
        {
            return await _context.Attributes.FindAsync(id);
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

        public List<Attribute> GetByTableId(int tableId)
        {
            return _context.Attributes.Where(a => a.TableId == tableId).ToList();
        }

        public bool TableExist(int tableId)
        {
            var table = _context.Tables.Find(tableId);

            return table != null;
        }

        public async Task<Type> TypeExist(string typeName)
        {
            var type = await _context.Types.Where(a => a.Name == typeName).FirstAsync();

            return type;
        }
    }
}