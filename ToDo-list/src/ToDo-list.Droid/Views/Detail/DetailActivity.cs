using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using ToDo_list.Core.Models;
using ToDo_list.Core.ViewModels.Details;

namespace ToDo_list.Droid.Views.Detail
{
    [MvxActivityPresentation]
    [Activity(
        Theme = "@style/AppTheme",
        LaunchMode = LaunchMode.SingleTop)]
    public class DetailActivity : MvxActivity<DetailViewModel>
    {
        private IMenu _menu;
        private MvxSpinner _spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_detail_view);

            var toolbarView = FindViewById(Resource.Id.layout_toolbar);
            var toolbar = (AndroidX.AppCompat.Widget.Toolbar)toolbarView?.FindViewById(Resource.Id.toolbar);

            var editView = FindViewById(Resource.Id.layout_edit_mode);
            _spinner = editView.FindViewById<MvxSpinner>(Resource.Id.spinner);

            if (_spinner != null)
            {
                _spinner.ItemSelected += SpinnerItemSelected;

                switch (ViewModel.Model.Status)
                {
                    case Status.Opened:
                        _spinner.SetSelection(0);
                        break;
                    case Status.InProgress:
                        _spinner.SetSelection(1);
                        break;
                    case Status.Completed:
                        _spinner.SetSelection(2);
                        break;
                }
            }

            toolbar.Title = ViewModel.Model.Name;

            SetSupportActionBar(toolbar);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.abc_ic_ab_back_material);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        private void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    ViewModel.Model.StatusChangedCommand.Execute(Status.Opened);
                    break;
                case 1:
                    ViewModel.Model.StatusChangedCommand.Execute(Status.InProgress);
                    break;
                case 2:
                    ViewModel.Model.StatusChangedCommand.Execute(Status.Completed);
                    break;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            _menu = menu;
            base.MenuInflater.Inflate(Resource.Menu.actions, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                        OnBackPressed();
                    break;

                case Resource.Id.updateTask:
                    SetEditView();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void SetEditView()
        {
            var updateTaskItem = _menu.FindItem(Resource.Id.updateTask);
            updateTaskItem?.SetVisible(false);
            ViewModel.Model.ChangeMode(Mode.Edit);
        }
    }
}