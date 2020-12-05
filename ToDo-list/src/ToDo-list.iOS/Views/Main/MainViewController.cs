using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using ToDo_list.Core.ViewModels.Main;
using UIKit;

namespace ToDo_list.iOS.Views.Main
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class MainViewController : MvxTableViewController<MainViewModel>
    {
        private UIBarButtonItem _testButton;
        private MvxStandardTableViewSource _tableViewSource;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "ToDo-list";

            _tableViewSource = new MvxStandardTableViewSource(TableView);
            
            TableView.Source = _tableViewSource;

            CreateBindings();
        }

        private void CreateBindings()
        {
            var bindingSet = CreateBindingSet();

            bindingSet
                .Bind(_tableViewSource)
                .To(vm => vm.TaskNames);
            
            bindingSet
                .Bind(_tableViewSource)
                .For(t => t.SelectionChangedCommand)
                .To(vm => vm.NavigateToChildCommand);

            bindingSet.Apply();
        }
    }
}
