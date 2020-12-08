using System;
using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using ToDo_list.Core.ViewModels.Main;
using ToDo_list.iOS.Views.Main.TableView.Source;
using UIKit;

namespace ToDo_list.iOS.Views.Main
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class MainViewController : MvxTableViewController<MainViewModel>
    {
        private MvxDeleteRowStandardTableViewSource _tableViewSource;
        private UIBarButtonItem _addTaskButton;
        private UIBarButtonItem _editRowsButton;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PrepareUi();
            PrepareNavigationUi();

            ViewModel.LoadTasksCommandAsync.ExecuteAsync();

            CreateBindings();
            SubscribeToEvents();
        }

        protected override void Dispose(bool disposing)
        {
            UnsubscribeFromEvents();

            base.Dispose(disposing);
        }

        private void PrepareUi()
        {
            Title = "ToDo-list";

            _tableViewSource = new MvxDeleteRowStandardTableViewSource(
                TableView, 
                UITableViewCellStyle.Subtitle,
                new NSString("CustomCell"), 
                "TitleText Name;DetailText Status");

            TableView.Source = _tableViewSource;
            TableView.TableFooterView = new UIView();
        }

        private void PrepareNavigationUi()
        {
            _addTaskButton = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            _editRowsButton = new UIBarButtonItem { Title = "Edit Rows" };

            NavigationItem.RightBarButtonItem = _addTaskButton;
            NavigationItem.LeftBarButtonItem = _editRowsButton;
        }

        private void EditRowsButtonClicked(object sender, EventArgs e)
        {
            TableView.Editing = !TableView.Editing;
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

            bindingSet
                .Bind(_tableViewSource)
                .For(s => s.RemoveRowCommand)
                .To(vm => vm.DeleteTaskAsyncCommand);

            bindingSet.Apply();
        }

        private void SubscribeToEvents()
        {
            _editRowsButton.Clicked += EditRowsButtonClicked;
        }

        private void UnsubscribeFromEvents()
        {
            _editRowsButton.Clicked -= EditRowsButtonClicked;
        }
    }
}
