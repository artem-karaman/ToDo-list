using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo_list.Core.Models;

namespace ToDo_list.Core.Services
{
	public class MockDataStore : IDataStore<TaskModel>
	{
		private List<TaskModel> _tasks;

		public MockDataStore()
		{
			_tasks = new List<TaskModel>();
			_tasks.AddRange(
				new List<TaskModel>()
				{
					new TaskModel
					{
						Id = Guid.NewGuid().ToString(),
						Name = "This is the first ToDo task" ,
						Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
									  "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
									  " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris" +
									  " nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
									  "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
									  " Excepteur sint occaecat cupidatat non proident, " +
									  "sunt in culpa qui officia deserunt mollit anim id est laborum.",
						CreatedDate = DateTime.Now,
						Status = Status.Opened
					},
					new TaskModel
					{
						Id = Guid.NewGuid().ToString(),
						Name = "This is the second ToDo task" ,
						Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
									  "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
									  " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris" +
									  " nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
									  "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
									  " Excepteur sint occaecat cupidatat non proident, " +
									  "sunt in culpa qui officia deserunt mollit anim id est laborum.",
						CreatedDate = DateTime.Now + TimeSpan.FromDays(2),
						Status = Status.Completed
					},
					new TaskModel
					{
						Id = Guid.NewGuid().ToString(),
						Name = "This is the third ToDo task" ,
						Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
									  "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
									  " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris" +
									  " nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
									  "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
									  " Excepteur sint occaecat cupidatat non proident, " +
									  "sunt in culpa qui officia deserunt mollit anim id est laborum.",
						CreatedDate = DateTime.Now + TimeSpan.FromDays(1),
						Status = Status.InProgress
					}
				});
		}

		public async Task<bool> AddItemAsync(TaskModel item)
		{
			_tasks.Add(item);

            return await Task.FromResult(true);
        }

		public async Task<bool> UpdateItemAsync(TaskModel item)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == item.Id);
            _tasks.Remove(task);
			_tasks.Add(item);

            return await Task.FromResult(true);
        }

		public async Task<bool> DeleteItemAsync(TaskModel item)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == item.Id);
            _tasks.Remove(task);

            return await Task.FromResult(true);
        }

		public async Task<TaskModel> GetItemAsync(string id) 
            => await Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));

        public async Task<IEnumerable<TaskModel>> GetItemsAsync(bool forceRefresh = false)
            => await Task.FromResult(_tasks);
    }
}
