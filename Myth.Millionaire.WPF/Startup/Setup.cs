using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Myth.Millionaire.WPF {
    public class Setup : MvxWpfSetup {
        protected override IMvxApplication CreateApp() {
            return new Core.App();
        }
    }
}