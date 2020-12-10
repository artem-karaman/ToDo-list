using System;
using System.Globalization;
using MvvmCross.Converters;

namespace ToDo_list.Core.Converters
{
    public class DateToStringValueConverter : MvxValueConverter<DateTimeOffset, string>
    {
        protected override string Convert(DateTimeOffset value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString("d");
        }
    }
}
