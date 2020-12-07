using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using ToDo_list.Core.ViewModels.Child;
using ToDo_list.Core.ViewModels.Details;
using UIKit;

namespace ToDo_list.iOS.Views.Detail.EditMode
{
    public class EditModeView : MvxView
    {
        private UILabel _titleLabel;
        private UILabel _descriptionLabel;
        private UILabel _currentStatusLabel;

        private UITextField _titleText;
        private UITextView _descriptionTextView;
        private UIPickerView _statusPickerView;
        private MvxPickerViewModel _mvxPickerModel;

        public EditModeView()
        {
            CreateUI();
            CreateLayout();

            CreateBindings();
        }

        private void CreateUI()
        {
            _titleText = new UITextField();

            _titleLabel = new UILabel
            {
                Text = "Task name: ",
                TextColor = UIColor.Gray
            };

            _descriptionTextView = new UITextView();

            _descriptionLabel = new UILabel
            {
                Text = "Task description: ",
                TextColor = UIColor.Gray
            };

            _statusPickerView = new UIPickerView();
            _mvxPickerModel = new MvxPickerViewModel(_statusPickerView);
            _statusPickerView.Model = _mvxPickerModel;

            _currentStatusLabel = new UILabel
            {
                Text = "Current task status: ",
                TextColor = UIColor.Gray
            };

            this.AddSubviews(
                _titleLabel, 
                _titleText,
                _descriptionLabel,
                _descriptionTextView,
                _currentStatusLabel,
                _statusPickerView);
        }

        private void CreateLayout()
        {
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                _titleLabel.AtTopOf(this, 40),
                _titleLabel.AtLeftOf(this, 20),
                _titleLabel.AtRightOf(this, 20),
                _titleLabel.Height().EqualTo(20),
                
                _titleText.Below(_titleLabel, 5),
                _titleText.WithSameLeft(_titleLabel),
                _titleText.WithSameRight(_titleLabel),
                _titleText.Height().EqualTo(20),
                
                _descriptionLabel.Below(_titleText, 10),
                _descriptionLabel.WithSameLeft(_titleLabel),
                _descriptionLabel.WithSameRight(_titleLabel),
                _descriptionLabel.Height().EqualTo(20) ,

                _descriptionTextView.Below(_descriptionLabel,5),
                _descriptionTextView.WithSameLeft(_titleLabel),
                _descriptionTextView.WithSameRight(_titleLabel),
                _descriptionTextView.Height().EqualTo(100),

                _currentStatusLabel.Below(_descriptionTextView, 10),
                _currentStatusLabel.WithSameLeft(_titleLabel),
                _currentStatusLabel.WithSameRight(_titleLabel),
                _currentStatusLabel.WithSameHeight(_titleLabel),

                _statusPickerView.AtBottomOfSafeArea(this),
                _statusPickerView.AtLeftOf(this),
                _statusPickerView.AtRightOf(this),
                _statusPickerView.Height().EqualTo(100)
            );
        }

        private void CreateBindings()
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<EditModeView, TaskViewModel>();

                bindingSet
                    .Bind(_titleText)
                    .To(vm => vm.Name);


                bindingSet.Apply();

            });
        }
    }
}