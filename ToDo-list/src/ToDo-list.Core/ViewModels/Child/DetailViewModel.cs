using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace ToDo_list.Core.ViewModels.Child
{
    public class DetailViewModel : MvxNavigationViewModel
    {
        public DetailViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) 
            : base(logProvider, navigationService)
        {
        }
    }
}
