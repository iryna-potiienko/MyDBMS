using System.Collections.Generic;
using System.Threading.Tasks;
using DBMSServices.Mappers;
using MyDBMS.Dtos;
using MyDBMS.Models;
using MyDBMS.Repositories;

namespace DBMSServices.Services
{
    public class DatabaseService
    {
        private readonly DatabaseMapper _databaseMapper;

        private readonly DatabaseRepository _databaseRepository;

        public DatabaseService(DatabaseRepository databaseRepository, DatabaseMapper databaseMapper)
        {
            _databaseMapper = databaseMapper;
            _databaseRepository = databaseRepository;
        }
        
        public async Task<DatabaseDto> Create(string databaseName)
        {
            //var database = _databaseMapper.MapToDatabase(databaseDto);
            
            var database = _databaseMapper.MapFromDatabasePostDto(databaseName);
            var createdDatabase = await _databaseRepository.Create(database);
            return _databaseMapper.MapToDatabaseDto(createdDatabase);
        }
        
        public async Task<Database> Create(Database database)
        {
            //var database = _databaseMapper.MapToDatabase(databaseDto);
            
            var createdDatabase = await _databaseRepository.Create(database);
            return createdDatabase;
            //return _databaseMapper.MapToDatabaseDto(createdDatabase);
        }

        public async Task<List<DatabaseDto>> GetAll()
        {
            return _databaseRepository.FindAll()
                .Result
                .ConvertAll(input => _databaseMapper.MapToDatabaseDto(input));
        }

        public async Task<DatabaseDto> Get(int id)
        {
            var database = await _databaseRepository.FindById(id);
            return database != null ? _databaseMapper.MapToDatabaseDto(database) : null;
        }

        public async Task<bool> Edit(int id, DatabaseDto databaseDto)
        {
            var db = await _databaseRepository.FindById(id);
            
            if (db == null)
            {
                return true;
            }

            db.Name = databaseDto.Name;

            _databaseRepository.Update(db);
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var database = await _databaseRepository.FindById(id);
            
            if (database == null)
            {
                return false;
            }
            
            _databaseRepository.Delete(database);
            return true;
        }

        public Task<Database> GetFullDatabase(int id)
        {
            return _databaseRepository.GetFullDatabase(id);
        }

        public bool DatabaseExist(int id)
        {
            return _databaseRepository.DatabaseExist(id);
        }
    }
}