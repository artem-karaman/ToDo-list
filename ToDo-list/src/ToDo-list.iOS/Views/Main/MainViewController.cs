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
        private UIBarButtonItem _addTaskButton;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PrepareUI();

            ViewModel.LoadTasksCommandAsync.ExecuteAsync();

            CreateBindings();
        }

        private void PrepareUI()
        {
            Title = "ToDo-list";

            _tableViewSource = new MvxStandardTableViewSource(TableView, "TitleText Name");
            TableView.Source = _tableViewSource;
            TableView.TableFooterView = new UIView();

            _addTaskButton = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            
            NavigationItem.RightBarButtonItem = _addTaskButton;
        }

        private void CreateBindings()
        {
            var bindingSet = CreateBindingSet();

            bindingSet
                .Bind(_tableViewSource)
                .To(vm => vm.Tasks);
            
            bindingSet
                .Bind(_tableViewSource)
                .For(t => t.SelectionChangedCommand)
                .To(vm => vm.NavigateToDetailViewModelCommandAsync);

            bindingSet
                .Bind(_addTaskButton)
                .To(vm => vm.NavigateToCreateTaskCommandAsync);

            bindingSet.Apply();
        }
    }
}
