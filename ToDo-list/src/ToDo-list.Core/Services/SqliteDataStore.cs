using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using ToDo_list.Core.Models;

namespace ToDo_list.Core.Services
{
    public class SqliteDataStore : IDataStore<TaskModel>
    {
        readonly SQLiteAsyncConnection _database;

        public SqliteDataStore(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TaskModel>().Wait();
        }

        public async Task<bool> AddItemAsync(TaskModel item)
        {
            await _database.InsertAsync(item);

           return await Task.FromResult(true);

        }

        public async Task<bool> UpdateItemAsync(TaskModel item)
        {
            await _database.UpdateAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(TaskModel item)
        {
            await _database.DeleteAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<TaskModel> GetItemAsync(string id)
        {
            return await _database.Table<TaskModel>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TaskModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await _database.Table<TaskModel>().ToListAsync();
        }
    }
}
