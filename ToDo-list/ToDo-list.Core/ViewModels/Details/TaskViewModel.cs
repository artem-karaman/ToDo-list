using System;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using ToDo_list.Core.Models;

namespace ToDo_list.Core.ViewModels.Details
{
    public class TaskViewModel : MvxViewModel
    {
        private readonly TaskModel _taskModel;
        private Mode _mode;

        public TaskViewModel(TaskModel taskModel, Mode mode)
        {
            _taskModel = taskModel;
            _mode = mode;

            StatusChangedCommand = new MvxCommand<Status>(StatusChangedCommandExecute);
        }

        public TaskModel TaskModel => _taskModel;

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
            get => (Status)_taskModel.Status;
            private set
            {
                _taskModel.Status = (int)value;
                RaisePropertyChanged(() => Status);
            }
        }

        public DateTimeOffset CreatedDate => _taskModel.CreatedDate;
        public IMvxCommand<Status> StatusChangedCommand { get; }

        public void ChangeMode(Mode mode)
        {
            _mode = mode;

            RaisePropertyChanged(() => Mode);
        }

        private void StatusChangedCommandExecute(Status status) => Status = status;
    }
}
