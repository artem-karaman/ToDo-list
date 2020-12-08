using System;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using ToDo_list.Core.Models;

namespace ToDo_list.Core.ViewModels.Details
{
    public class TaskViewModel : MvxViewModel
    {
        private readonly TaskModel _taskModel;
        private readonly Mode _mode;

        public TaskViewModel(TaskModel taskModel, Mode mode)
        {
            _taskModel = taskModel;
            _mode = mode;

            SetSelectedStatus = new MvxCommand<Status>(SelectedStatusCommandExecute);
        }

        private void SelectedStatusCommandExecute(Status model)
        {
            Status = model;
        }

        public Mode Mode => _mode;

        public string Name
        {
            get => _taskModel.Name;
            set
            {
                _taskModel.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public string Description
        {
            get => _taskModel.Description;
            set
            {
                _taskModel.Description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public string[] Statuses => Enum.GetNames(typeof(Status));


        public Status Status
        {
            get => _taskModel.Status;
            set
            {
                _taskModel.Status = value;
                RaisePropertyChanged(() => Status);
            }
        }

        public DateTime CreatedDate => _taskModel.CreatedDate;

        public IMvxCommand<Status> SetSelectedStatus { get; }

    }
}
