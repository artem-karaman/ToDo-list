using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using ToDo_list.Core.ViewModels.Main;

namespace ToDo_list.iOS.Views.Main
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class MainViewController : MvxViewController<MainViewModel>
    {
    }
}
