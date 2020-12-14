using AndroidX.RecyclerView.Widget;
using MvvmCross.DroidX.RecyclerView;
using ToDo_list.Core.Models;
using ToDo_list.Core.ViewModels.Main;

namespace ToDo_list.Droid.Helpers
{
    public class ItemTouchHelperSimpleCallback : ItemTouchHelper.SimpleCallback
    {
        private readonly MainViewModel _mainViewModel;
        public ItemTouchHelperSimpleCallback(MainViewModel viewModel) : base(0, ItemTouchHelper.Left)
        {
            _mainViewModel = viewModel;
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            var holder = (MvxRecyclerViewHolder)viewHolder;
            var item = (TaskModel)holder.DataContext;
            _mainViewModel.DeleteTaskAsyncCommand.Execute(item);
        }
    }
}