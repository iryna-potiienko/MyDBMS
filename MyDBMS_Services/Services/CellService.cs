using System.Collections.Generic;
using System.Threading.Tasks;
using MyDBMS.Models;
using MyDBMS.Repositories;

namespace DBMSServices.Services
{
    public class CellService
    {
        private readonly CellRepository _cellRepository;

        public CellService(CellRepository cellRepository)
        {
            _cellRepository = cellRepository;
        }

        public Task<Cell> Create(Cell cell)
        {
            var createdCell =  _cellRepository.Create(cell);
            return createdCell;
        }

        public async Task<List<Cell>> GetAll()
        {
            return await _cellRepository.FindAll();
        }

        public Task<Cell> Get(int id)
        {
            var cell = _cellRepository.FindById(id);
            return cell;
        }

        public async Task<bool> Edit(int id, Cell attribute)
        {
            var oldCell = await _cellRepository.FindById(id);

            if (oldCell == null)
            {
                return true;
            }

            oldCell.Data = attribute.Data;
            oldCell.AttributeId = attribute.AttributeId;
            oldCell.RowId = attribute.RowId;
            

            _cellRepository.Update(oldCell);
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var cell = await _cellRepository.FindById(id);

            if (cell == null)
            {
                return false;
            }

            _cellRepository.Delete(cell);
            return true;
        }

        public List<Cell> GetByRowId(int rowId)
        {
            return _cellRepository.GetByRowId(rowId);
        }
    }
}