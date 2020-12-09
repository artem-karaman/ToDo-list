using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using MvvmCross.DroidX.RecyclerView;
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

            var toolbarView = FindViewById(Resource.Id.layout_toolbar);
            var toolbar = (AndroidX.AppCompat.Widget.Toolbar)toolbarView?.FindViewById(Resource.Id.toolbar);

            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.main_recycler_view);
            recyclerView?.AddItemDecoration(new DividerItemDecoration(recyclerView.Context, DividerItemDecoration.Vertical));

            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "ToDo-list";

            ViewModel.LoadTasksCommandAsync.ExecuteAsync();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.MenuInflater.Inflate(Resource.Menu.add, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.addTask:
                    ViewModel.NavigateToCreateTaskCommandAsync.ExecuteAsync();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}
