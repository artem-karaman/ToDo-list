using System;
using System.Globalization;
using Android.Views;
using MvvmCross.Converters;
using ToDo_list.Core.Models;

namespace ToDo_list.Droid.Converters
{
    public class EditModeVisibilityValueConverter : MvxValueConverter<Mode, ViewStates>
    {
        protected override ViewStates Convert(Mode value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == Mode.Edit ? ViewStates.Visible : ViewStates.Gone;
        }
    }
}