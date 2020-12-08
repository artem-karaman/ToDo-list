using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Base;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Views;
using ToDo_list.Core.Converters;
using ToDo_list.Core.Models;
using ToDo_list.Core.ViewModels.Details;
using ToDo_list.iOS.Views.Detail.EditMode;
using ToDo_list.iOS.Views.Detail.ReadMode;
using UIKit;

namespace ToDo_list.iOS.Views.Child
{
    public class DetailViewController : MvxViewController<DetailViewModel>
    {
        private ReadModeView _readModeView;
        private EditModeView _editModeView;

        private UIButton _addTaskButton;
        private UIButton _updateTaskButton;
        private UIBarButtonItem _editButton;

        private UIBarButtonItem _emptyButton;

        private Mode _currentMode;
        public Mode CurrentMode
        {
            get => _currentMode;
            set
            {
                _currentMode = value;

                PrepareCurrentModeButton();
            }
        }

        private void PrepareCurrentModeButton()
        {
            switch (_currentMode)
            {
                case Mode.Add:
                    NavigationItem.RightBarButtonItem = _emptyButton;
                    break;
                case Mode.Edit:
                    NavigationItem.RightBarButtonItem = _emptyButton;
                    break;
                case Mode.Read:
                    NavigationItem.RightBarButtonItem = _editButton;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            CreateUI();
            CreateLayout();
            CreateBindings();
            SubscribeToEvents();
        }

        protected override void Dispose(bool disposing)
        {
            UnsubscribeFromEvents();

            base.Dispose(disposing);
        }

        private void CreateUI()
        {
            _readModeView = new ReadModeView();
            _editModeView = new EditModeView();

            _emptyButton = new UIBarButtonItem();

            _editButton = new UIBarButtonItem(UIBarButtonSystemItem.Edit);

            _addTaskButton = new UIButton(UIButtonType.RoundedRect);
            _addTaskButton.SetTitle("AddTask", UIControlState.Normal);

            _updateTaskButton = new UIButton(UIButtonType.RoundedRect);
            _updateTaskButton.SetTitle("Update task", UIControlState.Normal);

            _editModeView.AddSubviews(_addTaskButton, _updateTaskButton);

            View.AddSubviews(_readModeView, _editModeView);
        }

        private void CreateLayout()
        {
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            _editModeView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _readModeView.AtTopOfSafeArea(View),
                _readModeView.AtLeftOf(View),
                _readModeView.AtRightOf(View),
                _readModeView.AtBottomOfSafeArea(View),

                _editModeView.AtTopOfSafeArea(View),
                _editModeView.AtLeftOf(View),
                _editModeView.AtRightOf(View),
                _editModeView.AtBottomOfSafeArea(View));

            _editModeView.AddConstraints(
                _addTaskButton.AtBottomOf(_editModeView, 200),
                _addTaskButton.AtLeftOf(_editModeView, 50),
                _addTaskButton.AtRightOf(_editModeView, 50),
                _addTaskButton.Height().EqualTo(50),

                _updateTaskButton.AtBottomOf(_editModeView, 200),
                _updateTaskButton.AtLeftOf(_editModeView, 50),
                _updateTaskButton.AtRightOf(_editModeView, 50),
                _updateTaskButton.Height().EqualTo(50));
        }

        private void CreateBindings()
        {
            var bindingSet = CreateBindingSet();

            bindingSet
                .Bind(this)
                .For("Title")
                .To(vm => vm.Model.Name);

            bindingSet
                .Bind(_readModeView)
                .For(v => v.DataContext)
                .To(vm => vm.Model);

            bindingSet
                .Bind(_editModeView)
                .For(v => v.DataContext)
                .To(vm => vm.Model);

            bindingSet
                .Bind(_readModeView)
                .For(v => v.BindVisible())
                .To(vm => vm.Model.Mode)
                .WithConversion<ReadModeToBoolConverter>();

            bindingSet
                .Bind(_editModeView)
                .For(v => v.BindVisible())
                .To(vm => vm.Model.Mode)
                .WithConversion<EditModeToBoolConversion>();

            bindingSet
                .Bind(_addTaskButton)
                .For(v => v.BindVisible())
                .To(vm => vm.Model.Mode)
                .WithConversion<AddModeToBoolValueConverter>();

            bindingSet
                .Bind(_addTaskButton)
                .To(vm => vm.SaveTaskCommand);

            bindingSet
                .Bind(_updateTaskButton)
                .For(v => v.Hidden)
                .To(vm => vm.Model.Mode)
                .WithConversion<AddModeToBoolValueConverter>();

            bindingSet
                .Bind(this)
                .For(v => v.CurrentMode)
                .To(vm => vm.Model.Mode);

            bindingSet
                .Bind(_updateTaskButton)
                .To(vm => vm.UpdateTaskCommand);
            
            bindingSet.Apply();
        }

        private void SubscribeToEvents()
        {
            _editButton.Clicked += EditButtonClicked;
        }

        private void UnsubscribeFromEvents()
        {
            _editButton.Clicked -= EditButtonClicked;
        }

        private void EditButtonClicked(object sender, EventArgs e)
        {
            ViewModel.Model.ChangeMode(Mode.Edit);
        }
    }
}
