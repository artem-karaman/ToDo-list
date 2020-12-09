using Android.Views;
using System;
using System.Globalization;
using MvvmCross.Converters;
using ToDo_list.Core.Models;

namespace ToDo_list.Droid.Converters
{
    public class ReadModeVisibilityValueConverter : MvxValueConverter<Mode, ViewStates>
    {
        protected override ViewStates Convert(Mode value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == Mode.Read ? ViewStates.Visible : ViewStates.Gone;
        }
    }
}