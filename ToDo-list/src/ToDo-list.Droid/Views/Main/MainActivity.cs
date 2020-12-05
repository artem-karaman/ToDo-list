using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Views;
using ToDo_list.Core.ViewModels.Main;

namespace ToDo_list.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main_container);
        }
    }
}
