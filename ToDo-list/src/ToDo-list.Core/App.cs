using MvvmCross.ViewModels;
using ToDo_list.Core.ViewModels.Main;

namespace ToDo_list.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainViewModel>();
        }
    }
}
