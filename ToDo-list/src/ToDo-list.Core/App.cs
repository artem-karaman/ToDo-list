using MvvmCross;
using MvvmCross.ViewModels;
using ToDo_list.Core.Models;
using ToDo_list.Core.Services;
using ToDo_list.Core.ViewModels.Main;

namespace ToDo_list.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterDependencies();

            RegisterAppStart<MainViewModel>();
        }

        private static void RegisterDependencies()
        {
            Mvx.IoCProvider.RegisterSingleton<IDataStore<TaskModel>>(() => new MockDataStore());
        }
    }
}
