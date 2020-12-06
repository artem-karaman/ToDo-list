using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Views;
using ToDo_list.Core.ViewModels.Main;

namespace ToDo_list.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme",
        LaunchMode = LaunchMode.SingleInstance)]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main_view);
        }
    }
}
