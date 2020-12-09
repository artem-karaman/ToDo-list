using Android.Views;
using System;
using System.Globalization;
using MvvmCross.Converters;
using ToDo_list.Core.Models;

namespace ToDo_list.Droid.Converters
{
    public class AddModeVisibilityValueConverter : MvxValueConverter<Mode, ViewStates>
    {
        protected override ViewStates Convert(Mode value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == Mode.Add ? ViewStates.Visible : ViewStates.Gone;
        }
    }
}