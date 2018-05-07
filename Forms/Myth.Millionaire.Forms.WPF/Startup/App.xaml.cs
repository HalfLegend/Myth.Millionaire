using System.Timers;
using System.Windows;
using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Core;
using Myth.Library.MvvmCross.Forms.Platforms.WPF.Core;
using Myth.Millionaire.Forms.UI.Startup;

namespace Myth.Millionaire.Forms.WPF.Startup {
    /// <summary>
    /// FormsApp.xaml 的交互逻辑
    /// </summary>
    public partial class App {
        protected override void RegisterSetup() {
            this.RegisterSetupType<MvxFormsWpfSetup<Core.Startup.App, UI.Startup.FormsApp>>();
            Timer timer = new Timer();
            timer.Elapsed += (sender, e) =>
            {
            };
        }
    }
}
