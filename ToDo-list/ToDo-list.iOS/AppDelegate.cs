using Foundation;
using MvvmCross.Platforms.Ios.Core;
using ToDo_list.Core;

namespace ToDo_list.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
