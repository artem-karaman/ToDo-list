using Cirrious.FluentLayouts.Touch;
using MvvmCross.Base;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Views;
using ToDo_list.Core.Converters;
using ToDo_list.Core.ViewModels.Child;
using ToDo_list.iOS.Views.Detail.EditMode;
using ToDo_list.iOS.Views.Detail.ReadMode;
using UIKit;

namespace ToDo_list.iOS.Views.Child
{
    public class DetailViewController : MvxViewController<DetailViewModel>
    {
        private ReadModeView _readModeView;
        private EditModeView _editModeView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            CreateUI();
            CreateLayout();
            
            CreateBindings();
        }

        private void CreateUI()
        {
            _readModeView = new ReadModeView();
            _editModeView = new EditModeView();

            View.AddSubviews(_readModeView, _editModeView);
        }

        private void CreateLayout()
        {
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _readModeView.AtTopOfSafeArea(View),
                _readModeView.AtLeftOf(View),
                _readModeView.AtRightOf(View),
                _readModeView.AtBottomOfSafeArea(View),

                _editModeView.AtTopOfSafeArea(View),
                _editModeView.AtLeftOf(View),
                _editModeView.AtRightOf(View),
                _editModeView.AtBottomOfSafeArea(View));
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

            bindingSet.Apply();
        }
    }
}
