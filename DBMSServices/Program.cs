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
            using (MyDBMSContextDbContext db = new MyDBMSContextDbContext())
            {
                DatabaseRepository _databaseRepository = new DatabaseRepository(db);

                DatabaseService _databaseService = new DatabaseService(_databaseRepository);
                var databases = _databaseService.GetAll();
                Console.WriteLine("Список объектов:");
                foreach (Database u in databases)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
            }

            Console.Read();
        }
    }
}