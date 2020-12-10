using System;
using System.Globalization;
using MvvmCross.Converters;
using ToDo_list.Core.Models;

namespace ToDo_list.Core.Converters
{
    public class IntToStatusValueConverter  : MvxValueConverter<int, Status>
    {
        protected override Status Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
            Status result = Status.Opened;

            switch (value)
            {
                case 0:
                    result = Status.Opened;
                    break;
                case 1:
                    result = Status.InProgress;
                    break;
                case 2:
                    result = Status.Completed;
                    break;
            }

            return result;
        }
    }
}
