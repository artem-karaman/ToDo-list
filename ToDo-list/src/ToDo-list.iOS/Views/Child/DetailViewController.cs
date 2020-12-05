using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using ToDo_list.Core.ViewModels.Child;
using UIKit;

namespace ToDo_list.iOS.Views.Child
{
    public class DetailViewController : MvxViewController<DetailViewModel>
    {
        MvxFluentBindingDescriptionSet<DetailViewController, DetailViewModel> _bindingSet;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "ToDo-list";

            View.BackgroundColor = UIColor.White;
        }
       
    }
}
