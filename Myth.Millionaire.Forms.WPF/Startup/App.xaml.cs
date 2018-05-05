using System.Windows;
using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Core;
using Myth.Library.MvvmCross.Forms.Platforms.WPF.Core;

namespace Myth.Millionaire.Forms.WPF.Startup {
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App {
        protected override void RegisterSetup() {
            this.RegisterSetupType<MvxFormsWpfSetup<Core.Startup.App, Desktop.Startup.App>>();
        }
    }
}
