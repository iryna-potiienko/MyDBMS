using System.Collections.Generic;
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
        
        public Table Create(Table table)
        {
            var createdTable = _tableRepository.Create(table);
            return createdTable.Result;
        }

        public List<Table> GetAll()
        {
            return _tableRepository.FindAll()
                .Result;
        }

        public Table Get(int id)
        {
            var table = _tableRepository.FindById(id);
            return table;
        }

        public bool Edit(int id, Table table)
        {
            var oldTable = _tableRepository.FindById(id);
            
            if (oldTable == null)
            {
                return true;
            }

            oldTable.Name = table.Name;
            oldTable.DatabaseId = table.DatabaseId;

            _tableRepository.Update(oldTable);
            return false;
        }

        public bool Delete(int id)
        {
            var table = _tableRepository.FindById(id);
            
            if (table == null)
            {
                return false;
            }
            
            _tableRepository.Delete(table);
            return true;
        }

        public void TableDifference()
        {
            
        }
    }
}