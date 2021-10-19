using System;
using DBMSServices.Services;
using MyDBMS.Contexts;
using MyDBMS.Models;
using MyDBMS.Repositories;

namespace DBMSServices
{
    class Program
    {
        static void Main(string[] args)
        {
            // using (MyDBMSContext db = new MyDBMSContext())
            // {
            //     DatabaseRepository _databaseRepository = new DatabaseRepository(db);
            //     DatabaseService _databaseService = new DatabaseService(_databaseRepository);
            //
            //     //var database1 = new Database {Name = "Database2"};
            //     //_databaseService.Create(database1);
            //     //_databaseService.Delete(5);
            //     var databases = _databaseService.GetAll();
            //     Console.WriteLine("Список объектов:");
            //     foreach (Database u in databases.Result)
            //     {
            //         Console.WriteLine($"{u.Id}.{u.Name}");
            //     }
            //     
            //     TableRepository _tableRepository = new TableRepository(db);
            //     TableService _tableService = new TableService(_tableRepository);
            //     
            //     var _attributeRepository = new AttributeRepository(db);
            //     var _attributeService = new AttributeService(_attributeRepository);
            //     var _rowRepository = new RowRepository(db);
            //
            //     var _cellRepository = new CellRepository(db);
            //     var _cellService = new CellService(_cellRepository);
            //     
            //     var _rowService = new RowService(_rowRepository, _cellService);
            //
            //     var table = new Table {Name = "Table2", DatabaseId = 1};
            //     _tableService.Create(table);
            //     
            //     var tables = _tableService.GetAll();
            //     Console.WriteLine("\nСписок объектов:");
            //     foreach (Table u in tables.Result)
            //     {
            //         Console.WriteLine($"{u.Id}. {u.Name}, DatabaseId = {u.DatabaseId}");
            //     }
            //
            //     var _tablesDifferenceService =
            //         new TablesDifferenceService(_attributeService, _rowService);
            //
            //     _tablesDifferenceService.TableDifference(1, 2);
                // var rows = _tableService.GetAll();
                // Console.WriteLine("\nСписок объектов:");
                // foreach (Table u in tables)
                // {
                //     Console.WriteLine($"{u.Id}. {u.Name}, DatabaseId = {u.DatabaseId}");
                // }
            //}
        }
    }
}