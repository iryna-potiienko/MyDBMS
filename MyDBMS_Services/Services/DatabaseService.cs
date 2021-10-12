using System.Collections.Generic;
using System.Threading.Tasks;
using MyDBMS.Models;
using MyDBMS.Repositories;

namespace DBMSServices.Services
{
    public class DatabaseService
    {
        //private readonly ChapterMapper _chapterMapper;

        private readonly DatabaseRepository _databaseRepository;

        public DatabaseService(DatabaseRepository databaseRepository)
        {
            //_chapterMapper = chapterMapper;
            _databaseRepository = databaseRepository;
        }
        
        public Task<Database> Create(Database database)
        {
            //var chapter = _chapterMapper.MapToChapter(database);
            
            return _databaseRepository.Create(database);
            //return _chapterMapper.MapToChapterDto(createdChapter.Result);
        }

        public Task<List<Database>> GetAll()
        {
            return _databaseRepository.FindAll();
        }

        public Task<Database> Get(int id)
        {
            var database = _databaseRepository.FindById(id);
            return database;
        }

        public async Task<bool> Edit(int id, Database database)
        {
            var db = await _databaseRepository.FindById(id);
            
            if (db == null)
            {
                return true;
            }

            db.Name = database.Name;

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
    }
}