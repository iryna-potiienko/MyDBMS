using System.Threading.Tasks;
using MyDBMS.Dtos;
using MyDBMS.Models;

namespace DBMSServices.Mappers
{
    public class DatabaseMapper
    {
        public Database MapToDatabase(DatabaseDto dto)
        {
            var database = new Database()
            {
                Id = dto.Id,
                Name = dto.Name
            };

            return database;
        }

        public DatabaseDto MapToDatabaseDto(Database database)
        {
            var databaseDto = new DatabaseDto()
            {
                Id = database.Id,
                Name = database.Name
            };

            return databaseDto;
        }
        public Database MapFromDatabasePostDto(string databaseName)
        {
            var database = new Database()
            {
                Name = databaseName
            };

            return database;
        }
    }
}