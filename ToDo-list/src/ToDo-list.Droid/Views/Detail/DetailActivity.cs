using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using ToDo_list.Core.ViewModels.Child;

namespace ToDo_list.Droid.Views.Detail
{
    [MvxActivityPresentation]
    [Activity(
        Theme = "@style/AppTheme",
        LaunchMode = LaunchMode.SingleTop)]
    public class DetailActivity : MvxActivity<DetailViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_detail_view);

            var toolbarView = FindViewById(Resource.Id.layout_toolbar);
            var toolbar = (AndroidX.AppCompat.Widget.Toolbar)toolbarView?.FindViewById(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.abc_ic_ab_back_material);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            SupportActionBar.Title = "ToDo-list.Details";
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                        OnBackPressed();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}