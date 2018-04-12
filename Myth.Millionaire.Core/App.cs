using MvvmCross.IoC;

namespace Myth.Millionaire.Core {
    public class App : MvvmCross.ViewModels.MvxApplication {
        public override void Initialize() {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<ViewModels.MainViewModel>();
        }
    }
}