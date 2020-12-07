using System;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ToDo_list.Core.Models;
using ToDo_list.Core.ViewModels.Details;

namespace ToDo_list.Core.ViewModels.Child
{
    public class DetailViewModel : MvxNavigationViewModel<TaskViewModel>
    {
        private TaskViewModel _model;

        public DetailViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) 
            : base(logProvider, navigationService)
        {
        }

        public override void Prepare(TaskViewModel model)
        {
            _model = model;
        }

        public TaskViewModel Model => _model;
    }
}
