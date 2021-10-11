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
            using (MyDBMSContext db = new MyDBMSContext())
            {
                DatabaseRepository _databaseRepository = new DatabaseRepository(db);
                DatabaseService _databaseService = new DatabaseService(_databaseRepository);

                //_databaseService.Delete(5);
                var databases = _databaseService.GetAll();
                Console.WriteLine("Список объектов:");
                foreach (Database u in databases)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
                
                TableRepository _tableRepository = new TableRepository(db);
                TableService _tableService = new TableService(_tableRepository);

                var table = new Table {Name = "Table2", DatabaseId = 1};
                _tableService.Create(table);
                
                var tables = _tableService.GetAll();
                Console.WriteLine("\nСписок объектов:");
                foreach (Table u in tables)
                {
                    Console.WriteLine($"{u.Id}. {u.Name}, DatabaseId = {u.DatabaseId}");
                }

            }
        }
    }
}