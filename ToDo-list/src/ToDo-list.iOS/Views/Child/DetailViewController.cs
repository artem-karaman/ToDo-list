using Cirrious.FluentLayouts.Touch;
using MvvmCross.Platforms.Ios.Views;
using ToDo_list.Core.ViewModels.Child;
using UIKit;

namespace ToDo_list.iOS.Views.Child
{
    public class DetailViewController : MvxViewController<DetailViewModel>
    {
        private UILabel _titleLabel;
        private UILabel _descriptionLabel;
        private UILabel _createdDateLabel;
        private UILabel _currentStatusLabel;

        private UILabel _titleLabelName;
        private UILabel _descriptionLabelName;
        private UILabel _createdDateLabelName;
        private UILabel _currentStatusLabelName;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "ToDo-list.Details";

            View.BackgroundColor = UIColor.White;

            CreateUI();
            CreateLayout();
            
            CreateBindings();
        }

        private void CreateUI()
        {
            _titleLabel = new UILabel
            {
                Lines = 0
            };

            _titleLabelName = new UILabel
            {
                Text = "Task name: " ,
                TextColor = UIColor.Gray
            };

            _descriptionLabel = new UILabel
            {
                Lines = 0
            };

            _descriptionLabelName = new UILabel
            {
                Text = "Task description: ",
                TextColor = UIColor.Gray
            };

            _createdDateLabel = new UILabel();
            _createdDateLabelName = new UILabel
            {
                Text = "Created date: ",
                TextColor = UIColor.Gray
            };

            _currentStatusLabel = new UILabel();
            _currentStatusLabelName = new UILabel
            {
                Text = "Current task status: ",
                TextColor = UIColor.Gray
            };

            View.AddSubviews(
                _titleLabel,
                _descriptionLabel,
                _createdDateLabel,
                _currentStatusLabel,
                _titleLabelName,
                _descriptionLabelName,
                _createdDateLabelName,
                _currentStatusLabelName);
        }

        private void CreateLayout()
        {
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _titleLabelName.AtTopOfSafeArea(View, 40),
                _titleLabelName.AtLeftOf(View, 20),
                _titleLabelName.AtRightOf(View, 20),
                _titleLabelName.Height().EqualTo(20),

                _titleLabel.Below(_titleLabelName, 5),
                _titleLabel.AtLeftOf(View,20),
                _titleLabel.AtRightOf(View, 20),
                _titleLabel.Height().GreaterThanOrEqualTo(20),

                _descriptionLabelName.Below(_titleLabel, 25),
                _descriptionLabelName.WithSameLeft(_titleLabel),
                _descriptionLabelName.WithSameRight(_titleLabel),
                _descriptionLabelName.Height().GreaterThanOrEqualTo(20),

                _descriptionLabel.Below(_descriptionLabelName, 5),
                _descriptionLabel.WithSameLeft(_titleLabel),
                _descriptionLabel.WithSameRight(_titleLabel),
                _descriptionLabel.Height().GreaterThanOrEqualTo(100),

                _createdDateLabel.AtBottomOfSafeArea(View, 20),
                _createdDateLabel.WithSameLeft(_descriptionLabel),
                _createdDateLabel.Width().GreaterThanOrEqualTo(50),
                _createdDateLabel.Height().GreaterThanOrEqualTo(20),

                _createdDateLabelName.Above(_createdDateLabel, 5),
                _createdDateLabelName.WithSameLeft(_descriptionLabel),
                _createdDateLabelName.Width().GreaterThanOrEqualTo(50),
                _createdDateLabelName.Height().GreaterThanOrEqualTo(20),

                _currentStatusLabel.WithSameBottom(_createdDateLabel),
                _currentStatusLabel.WithSameRight(_descriptionLabel),
                _currentStatusLabel.Width().GreaterThanOrEqualTo(50),
                _currentStatusLabel.Height().GreaterThanOrEqualTo(20),

                _currentStatusLabelName.Above(_currentStatusLabel, 5),
                _currentStatusLabelName.WithSameRight(_descriptionLabel),
                _currentStatusLabelName.Width().GreaterThanOrEqualTo(50),
                _currentStatusLabelName.Height().GreaterThanOrEqualTo(20));
        }

        private void CreateBindings()
        {
            var bindingSet = CreateBindingSet();

            bindingSet
                .Bind(_titleLabel)
                .To(vm => vm.Model.Name);

            bindingSet
                .Bind(_descriptionLabel)
                .To(vm => vm.Model.Description);

            bindingSet
                .Bind(_createdDateLabel)
                .To(vm => vm.Model.CreatedDate);

            bindingSet
                .Bind(_currentStatusLabel)
                .To(vm => vm.Model.Status);
            
            bindingSet.Apply();
        }
    }
}
