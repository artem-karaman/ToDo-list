using System;
using System.Globalization;
using MvvmCross.Converters;
using ToDo_list.Core.Models;

namespace ToDo_list.Core.Converters
{
    public class ReadModeToBoolValueConverter : MvxValueConverter<Mode, bool>
    {
        protected override bool Convert(Mode value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == Mode.Read;
        }
    }
}
