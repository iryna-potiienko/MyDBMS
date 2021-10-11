using System;
using MyDBMS.Contexts;
using MyDBMS.Models;
using MyDBMS.Repositories;

namespace MyDBMS
{
    class Program
    {
        static void Main(string[] args)
        {
            // using (MyDatabaseContext db = new MyDatabaseContext())
            // {
            //     Database dabase1 = new Database() { Name = "Database1" };
            //     Database dabase2 = new Database() { Name = "Database2" };
            //
            //     db.Databases.Add(dabase1);
            //     db.Databases.Add(dabase2);
            //     db.SaveChanges();
            //     Console.WriteLine("Объекты успешно сохранены");
            //
            //     var databases = db.Databases.ToList();
            //     Console.WriteLine("Список объектов:");
            //     foreach (Database u in databases)
            //     {
            //         Console.WriteLine($"{u.Id}.{u.Name}");
            //     }
            // }
            // Console.Read();
            
            using (MyDBMSContextDbContext db = new MyDBMSContextDbContext())
            {
                DatabaseRepository _databaseRepository = new DatabaseRepository(db);

                var databases = _databaseRepository.FindAll().Result;
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