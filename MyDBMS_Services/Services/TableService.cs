using System.Collections.Generic;
using System.Threading.Tasks;
using MyDBMS.Models;
using MyDBMS.Repositories;

namespace DBMSServices.Services
{
    public class TableService
    {
        private readonly TableRepository _tableRepository;

        public TableService(TableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }
        
        public Task<Table> Create(Table table)
        {
            return _tableRepository.Create(table);
        }

        public Task<List<Table>> GetAll()
        {
            return _tableRepository.FindAll();
        }

        public Task<Table> Get(int id)
        {
            return _tableRepository.FindById(id);
        }

        public async Task<bool> Edit(int id, Table table)
        {
            var oldTable = await _tableRepository.FindById(id);
            
            if (oldTable == null)
            {
                return true;
            }

            oldTable.Name = table.Name;
            oldTable.DatabaseId = table.DatabaseId;

            _tableRepository.Update(oldTable);
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var table = await _tableRepository.FindById(id);
            
            if (table == null)
            {
                return false;
            }
            
            _tableRepository.Delete(table);
            return true;
        }
    }
}