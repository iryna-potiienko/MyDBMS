using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDBMS.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DBMSServices.Services
{
    public class ReadSaveDatabaseInFileService
    {
        private readonly DatabaseService _databaseService;

        private JsonSerializerOptions _jsonSerializerOptionsoptions;
        
        public ReadSaveDatabaseInFileService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            _jsonSerializerOptionsoptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

        }
        
        public async Task<Database> ReadDatabaseFromDisk(string filename)
        {
            //var fileContent = string.Empty;
            var filePath = string.Empty;

            string json;
            Database database = null;

            // using (OpenFileDialog openFileDialog = new OpenFileDialog())
            // {
            //     // openFileDialog.InitialDirectory = "c:\\";
            //     // openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //     // openFileDialog.FilterIndex = 2;
            //     // openFileDialog.RestoreDirectory = true;
            //
            //     if (openFileDialog.ShowDialog() != DialogResult.OK) return null;
                //Get the path of specified file
             //   filePath = openFileDialog.FileName;

                json = await File.ReadAllTextAsync(filename);
                    
                database = JsonConvert.DeserializeObject<Database>(json, 
                    new JsonSerializerSettings()
                    {

                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                    });
                    
                if (_databaseService.DatabaseExist(database.Id))
                {
                    await _databaseService.Delete(database.Id);
                }

                var createdDatabase = await _databaseService.Create(database);
            //}

            return createdDatabase;
            //var json = await File.ReadAllTextAsync(filename);
        }

        public async Task<bool> SaveDatabaseOnDisk(int databaseId)
        {
            try
            {
                Database database = await _databaseService.GetFullDatabase(databaseId);
                var filename = database.Name + ".json";
                var json = JsonConvert.SerializeObject(database, Formatting.Indented,
                    new JsonSerializerSettings()
                    {

                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                    });
                await File.WriteAllTextAsync(filename, json);
                return true;

                // сохранение данных
                // using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                // {
                //     await JsonSerializer.SerializeAsync<Database>(fs, database, _jsonSerializerOptionsoptions);
                //     return true;
                // }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}