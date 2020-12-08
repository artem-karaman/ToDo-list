using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ToDo_list.Core.Models;
using ToDo_list.Core.Services;

namespace ToDo_list.Core.ViewModels.Details
{
    public class DetailViewModel : MvxNavigationViewModel<TaskViewModel>
    {
        private readonly IDataStore<TaskModel> _dataStore;
        private TaskViewModel _model;

        public DetailViewModel(
            IMvxLogProvider logProvider, 
            IMvxNavigationService navigationService,
            IDataStore<TaskModel> dataStore) 
            : base(logProvider, navigationService)
        {
            _dataStore = dataStore;

            SaveTaskCommand = new MvxAsyncCommand(SaveTaskCommandExecute);
            UpdateTaskCommand = new MvxAsyncCommand(UpdateTaskCommandExecute);
        }

        public override void Prepare(TaskViewModel model)
        {
            _model = model;
        }

        public TaskViewModel Model => _model;
        public IMvxAsyncCommand SaveTaskCommand { get; }
        public IMvxAsyncCommand UpdateTaskCommand { get; }

        private async Task SaveTaskCommandExecute()
        {
            if (await _dataStore.AddItemAsync(_model.TaskModel))
            {
                await NavigationService.Close(this);
            }
        }

        private async Task UpdateTaskCommandExecute()
        {
            if (await _dataStore.UpdateItemAsync(Model.TaskModel))
            {
                await NavigationService.Close(this);
            }
        }
    }
}
