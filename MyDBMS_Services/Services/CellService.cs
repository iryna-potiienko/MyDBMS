using System.Collections.Generic;
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

        public Cell Create(Cell cell)
        {
            var createdCell = _cellRepository.Create(cell);
            return createdCell.Result;
        }

        public List<Cell> GetAll()
        {
            return _cellRepository.FindAll()
                .Result;
        }

        public Cell Get(int id)
        {
            var attribute = _cellRepository.FindById(id);
            return attribute;
        }

        public bool Edit(int id, Cell attribute)
        {
            var oldCell = _cellRepository.FindById(id);

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

        public bool Delete(int id)
        {
            var cell = _cellRepository.FindById(id);

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