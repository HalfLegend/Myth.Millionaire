using MvvmCross.IoC;
using Myth.Millionaire.Core.ViewModels;

namespace Myth.Millionaire.Core.Startup {
    public class App : MvvmCross.ViewModels.MvxApplication {
        public override void Initialize() {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<MainViewModel>();
        }
    }
}