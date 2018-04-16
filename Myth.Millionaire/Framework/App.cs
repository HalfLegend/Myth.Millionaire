using MvvmCross.IoC;
using Myth.Millionaire.ViewModels;

namespace Myth.Millionaire.Framework {
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