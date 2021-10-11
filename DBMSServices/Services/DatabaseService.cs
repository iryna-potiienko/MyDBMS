using System.Collections.Generic;
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
        
        public Database CreateDatabase(Database database)
        {
            //var chapter = _chapterMapper.MapToChapter(database);

            var createdDatabase = _databaseRepository.Create(database);
            return createdDatabase.Result;
            //return _chapterMapper.MapToChapterDto(createdChapter.Result);
        }

        public List<Database> GetAll()
        {
            return _databaseRepository.FindAll()
                .Result;
            //.ConvertAll(input => _chapterMapper.MapToChapterDto(input));
        }

        public Database GetDatabase(int id)
        {
            var chapter = _databaseRepository.FindById(id);
            return chapter;
            //return chapter != null ? _chapterMapper.MapToChapterDto(chapter) : null;
        }

        public bool UpdateDatabase(int id, Database database)
        {
            var db = _databaseRepository.FindById(id);
            
            if (db == null)
            {
                return true;
            }

            db.Name = database.Name;

            _databaseRepository.Update(db);
            return false;
        }

        public bool DeleteDatabase(int id)
        {
            var database = _databaseRepository.FindById(id);
            
            if (database == null)
            {
                return true;
            }
            
            _databaseRepository.Delete(database);
            return false;
        }
    }
}