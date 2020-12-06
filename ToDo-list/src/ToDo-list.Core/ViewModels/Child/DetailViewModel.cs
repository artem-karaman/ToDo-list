using System;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ToDo_list.Core.Models;

namespace ToDo_list.Core.ViewModels.Child
{
    public class DetailViewModel : MvxNavigationViewModel<TaskModel>
    {
        private TaskModel _model;

        public DetailViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) 
            : base(logProvider, navigationService)
        {
        }

        public override void Prepare(TaskModel model)
        {
            _ = model ?? throw new ArgumentNullException(nameof(model));

            _model = model;
        }

        public TaskModel Model => _model;
    }
}
