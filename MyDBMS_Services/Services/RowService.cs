using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDBMS.Models;
using MyDBMS.Repositories;

namespace DBMSServices.Services
{
    public class RowService
    {
        private readonly RowRepository _rowRepository;
        private readonly CellService _cellService;

        public RowService(RowRepository rowRepository, CellService cellService)
        {
            _rowRepository = rowRepository;
            _cellService = cellService;
        }

        public Task<Row> Create(Row row)
        {
            var createdRow = _rowRepository.Create(row);
            return createdRow;
        }

        public Task<List<Row>> GetAll()
        {
            return _rowRepository.FindAll();
        }

        public Task<Row> Get(int id)
        {
            var row = _rowRepository.FindById(id);
            return row;
        }

        public async Task<bool> Edit(int id, Row attribute)
        {
            var oldRow = await _rowRepository.FindById(id);

            if (oldRow == null)
            {
                return true;
            }

            oldRow.TableId = attribute.TableId;

            _rowRepository.Update(oldRow);
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var row = await _rowRepository.FindById(id);

            if (row == null)
            {
                return false;
            }

            _rowRepository.Delete(row);
            return true;
        }

        public async Task<Row> GetAllRow(int id)
        {
            var row = await Get(id);
            row.Cells = _cellService.GetByRowId(id);
            return row;
        }
        
        public Row GetAllRow(out Row row, int id)
        {
            row = Get(id).Result;
            row.Cells = _cellService.GetByRowId(id);
            return row;
        }

        public async Task<List<Row>> GetByTableId(int tableId)
        {
            var rows = await _rowRepository.FindByTableId(tableId);

            var res = rows.Select(row => GetAllRow(row.Id).Result).ToList();
            return res;
        }
        
    }
}