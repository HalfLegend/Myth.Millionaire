using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.ViewModels;
using Myth.Millionaire.Core.Startup;

namespace Myth.Millionaire.WPF.Startup {
    public class Setup : MvxWpfSetup {
        protected override IMvxApplication CreateApp() {
            return new App();
        }
    }
}