using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ToDo_list.Core.ViewModels.Child;

namespace ToDo_list.Core.ViewModels.Main
{
    public class MainViewModel : MvxNavigationViewModel
    {
        public MainViewModel(
            IMvxLogProvider logProvider,
            IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
        {
            NavigateToChildCommand = new MvxAsyncCommand(ShowChildCommand);
            
            TaskNames = new List<string>()
            {
                "First",
                "Second"
            };
        }

        public IMvxAsyncCommand NavigateToChildCommand { get; }
        public List<string> TaskNames { get; }

        private async Task ShowChildCommand() => await NavigationService.Navigate<DetailViewModel>();

    }
}
