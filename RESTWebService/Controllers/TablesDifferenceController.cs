using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBMSServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDBMS.Models;

namespace RESTWebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TablesDifferenceController : ControllerBase
    {
        private readonly TablesDifferenceService _tablesDifferenceService;

        public TablesDifferenceController(TablesDifferenceService tablesDifferenceService)
        {
            _tablesDifferenceService = tablesDifferenceService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Row>>> GetRows(int tableAId,int tableBId)
        {
            return await _tablesDifferenceService.TableDifference(tableAId, tableBId);
            //return await _rowService.GetAll();
        }
    }
}
