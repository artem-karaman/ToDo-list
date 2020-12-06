using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ToDo_list.Core.Models;
using ToDo_list.Core.Services;
using ToDo_list.Core.ViewModels.Child;

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
			NavigateToChildCommandAsync = new MvxAsyncCommand(ShowChildCommandExecute);
			LoadTasksCommandAsync = new MvxAsyncCommand(LoadTasksAsyncCommandExecute);
        }

        public ObservableCollection<TaskModel> Tasks { get; set; }
		public IMvxAsyncCommand NavigateToChildCommandAsync { get; }
        public IMvxAsyncCommand LoadTasksCommandAsync { get; }

		private async Task LoadTasksAsyncCommandExecute()
		{
			var tasks = await _dataStore.GetItemsAsync();

			foreach (var task in tasks)
			{
                Tasks.Add(task);
			}
		}

        private async Task ShowChildCommandExecute() => await NavigationService.Navigate<DetailViewModel>();

	}
}
