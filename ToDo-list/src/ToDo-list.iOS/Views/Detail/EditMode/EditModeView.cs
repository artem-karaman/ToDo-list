using System.Drawing;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
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
        private UITextField _pickerTextField;
        private MvxPickerViewModel _mvxPickerModel;

        private UIPickerView _pickerView;
        private UIToolbar _toolBar;

        public EditModeView()
        {
            CreateToolbarForPickerView();
            CreateUI();
            CreateLayout();
            CreateBindings();
        }

        private void CreateUI()
        {

            _titleText = new UITextField()
            {
                Placeholder = "Enter task title",
                
            };

            _titleText.Layer.BorderWidth = 1;
            _titleText.Layer.BorderColor = UIColor.Gray.CGColor;


            _titleLabel = new UILabel
            {
                Text = "Task name: ",
                TextColor = UIColor.Gray
            };

            _descriptionTextView = new UITextView();
            _descriptionTextView.Layer.BorderWidth = 1;
            _descriptionTextView.Layer.BorderColor = UIColor.Gray.CGColor;

            _descriptionLabel = new UILabel
            {
                Text = "Task description: ",
                TextColor = UIColor.Gray
            };

            _pickerView = new UIPickerView();
            _pickerTextField = new UITextField();

            _mvxPickerModel = new MvxPickerViewModel(_pickerView);
            _pickerView.Model = _mvxPickerModel;

            _pickerTextField.InputView = _pickerView;
            _pickerTextField.InputAccessoryView = _toolBar;

            _currentStatusLabel = new UILabel
            {
                Text = "Current task status: ",
                TextColor = UIColor.Gray
            };

            AddSubviews(
                _titleLabel, 
                _titleText,
                _descriptionLabel,
                _descriptionTextView,
                _currentStatusLabel,
                _pickerTextField);
        }

        private void CreateToolbarForPickerView()
        {
            _toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            UIBarButtonItem flexibleSpaceLeft = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null);
            UIBarButtonItem doneButton = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, this, new ObjCRuntime.Selector("DoneAction"));
            UIBarButtonItem[] items = { flexibleSpaceLeft, doneButton };
            _toolBar.SetItems(items, false);
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

                _pickerTextField.Below(_currentStatusLabel, 5),
                _pickerTextField.WithSameLeft(_currentStatusLabel),
                _pickerTextField.WithSameRight(_currentStatusLabel),
                _pickerTextField.Height().EqualTo(20)

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

                bindingSet
                    .Bind(_mvxPickerModel)
                    .For(v => v.ItemsSource)
                    .To(vm => vm.Statuses);

                bindingSet
                    .Bind(_mvxPickerModel)
                    .For(v => v.SelectedChangedCommand)
                    .To(vm => vm.StatusChangedCommand);

                bindingSet
                    .Bind(_pickerTextField)
                    .To(vm => vm.Status);

                bindingSet
                    .Bind(_descriptionTextView)
                    .To(vm => vm.Description);

                bindingSet.Apply();

            });
        }

        [Export("DoneAction")]
        private void DoneAction()
        {
            _pickerTextField.ResignFirstResponder();
        }
    }
}