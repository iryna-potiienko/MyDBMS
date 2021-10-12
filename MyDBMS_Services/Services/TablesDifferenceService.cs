using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDBMS.Models;

namespace DBMSServices.Services
{
    public class TablesDifferenceService
    {
        private readonly AttributeService _attributeService;
        private readonly RowService _rowService;

        public TablesDifferenceService(AttributeService attributeService, RowService rowService)
        {
            _attributeService = attributeService;
            _rowService = rowService;
        }
        public async Task<List<Row>> TableDifference(int tableAId, int tableBId)
        {
            var attributesTableA = _attributeService.GetByTableId(tableAId);
            var attributesTableB = _attributeService.GetByTableId(tableBId);

            var similarAttributes = (
                from attributeA in attributesTableA
                from attributeB in attributesTableB
                where attributeA.Name == attributeB.Name
                select attributeA
            ).ToList();
            
            var rowsA = await _rowService.GetByTableId(tableAId);
            var rowsB = await _rowService.GetByTableId(tableBId);
            var resultRows = (
                from rowA in rowsA from cellA in rowA.Cells
                from rowB in rowsB from cellB in rowB.Cells
                from attr in similarAttributes
                where cellA.Attribute == attr
                where cellB.Attribute == attr
                where cellA.Data.Equals(cellB.Data)
                select rowA
            ).ToList();

            /*var cellsListA = new List<List<Cell>>();
            var cellsListB = new List<List<Cell>>();
            var resultCellsList=new List<List<Cell>>();
            foreach (var rowA in cellsListA)
            {
                foreach (var cellA in rowA)
                {
                    foreach (var rowB in cellsListB)
                    {
                        foreach (var cellB in rowB)
                        {
                            foreach (var attr in similarAttributes)
                            {
                                if (cellA.Attribute == attr)
                                {
                                    if (cellB.Attribute == attr)
                                    {
                                        if (cellA.Data.Equals(cellB.Data))
                                        {
                                            resultCellsList.Add(rowA);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }*/
            var res = rowsA.Except(resultRows).ToList();
            return res;
        }
    }
}