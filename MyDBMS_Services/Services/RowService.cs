using System.Collections.Generic;
using MyDBMS.Models;
using MyDBMS.Repositories;

namespace DBMSServices.Services
{
    public class RowService
    {
        private readonly RowRepository _rowRepository;

        public RowService(RowRepository rowRepository)
        {
            _rowRepository = rowRepository;
        }

        public Row Create(Row row)
        {
            var createdRow = _rowRepository.Create(row);
            return createdRow.Result;
        }

        public List<Row> GetAll()
        {
            return _rowRepository.FindAll()
                .Result;
        }

        public Row Get(int id)
        {
            var row = _rowRepository.FindById(id);
            return row;
        }

        public bool Edit(int id, Row attribute)
        {
            var oldRow = _rowRepository.FindById(id);

            if (oldRow == null)
            {
                return true;
            }

            oldRow.TableId = attribute.TableId;

            _rowRepository.Update(oldRow);
            return false;
        }

        public bool Delete(int id)
        {
            var row = _rowRepository.FindById(id);

            if (row == null)
            {
                return false;
            }

            _rowRepository.Delete(row);
            return true;
        }
    }
}