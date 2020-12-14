using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ToDo_list.Core.Models;
using ToDo_list.Core.Services;
using ToDo_list.Core.ViewModels.Details;

namespace ToDo_list.Core.ViewModels.Main
{
    public class MainViewModel : MvxNavigationViewModel
    {
        private readonly IDataStore<TaskModel> _dataStore;

        public MainViewModel(
            IMvxLogProvider logProvider,
            IMvxNavigationService navigationService,
            IDataStore<TaskModel> dataStore)
            : base(logProvider, navigationService)
        {
            _dataStore = dataStore;

            Tasks = new ObservableCollection<TaskModel>();
            NavigateToDetailViewModelCommandAsync = new MvxAsyncCommand<TaskModel>(ShowDetailViewModelCommandExecute);
            NavigateToCreateTaskCommandAsync = new MvxAsyncCommand(ShowDetailViewModelToCrateTaskCommandExecute);
            LoadTasksCommandAsync = new MvxAsyncCommand(LoadTasksAsyncCommandExecute);
            DeleteTaskAsyncCommand = new MvxAsyncCommand<TaskModel>(DeleteTaskAsyncCommandExecute);
        }

        public ObservableCollection<TaskModel> Tasks { get; set; }
        public IMvxAsyncCommand<TaskModel> NavigateToDetailViewModelCommandAsync { get; }
        public IMvxAsyncCommand NavigateToCreateTaskCommandAsync { get; }
        public IMvxAsyncCommand LoadTasksCommandAsync { get; }
        public IMvxAsyncCommand<TaskModel> DeleteTaskAsyncCommand { get; } 

        private async Task LoadTasksAsyncCommandExecute()
        {
            var tasks = await _dataStore.GetItemsAsync();

            Tasks.Clear();

            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }
        }

        public override async void ViewAppeared()
        {
            await LoadTasksAsyncCommandExecute();
        }

        private async Task ShowDetailViewModelCommandExecute(TaskModel model)
        {
            await NavigationService.Navigate<DetailViewModel, TaskViewModel>(
                new TaskViewModel(model, Mode.Read));


        }

        void ReadDisc()
        {
            ReadDiscAsync();
        }

        private Task ReadDiscAsync()
        {
            Task t = new Task(StartNewAction);
            t.Start();
            return Task.CompletedTask;
        }

        private void StartNewAction()
        {
            
        }

        private async Task ShowDetailViewModelToCrateTaskCommandExecute()
        {
            var taskViewModel = new TaskViewModel(
                new TaskModel
                {
                    CreatedDate = DateTime.Now,
                    Description = string.Empty,
                    Id = Guid.NewGuid().ToString(),
                    Name = string.Empty,
                    Status = (int)Status.Opened
                }, Mode.Add);

            await NavigationService.Navigate<DetailViewModel, TaskViewModel>(taskViewModel);
        }
         
        private async Task DeleteTaskAsyncCommandExecute(TaskModel model)
        {
            if (await _dataStore.DeleteItemAsync(model))
            {
                await LoadTasksAsyncCommandExecute();
            }
        }
    }
}
