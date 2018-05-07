using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Views;
using Myth.Millionaire.Core.Startup;

namespace Myth.Millionaire.WPF.Startup {
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class WpfApp {
        protected override void RegisterSetup() {
            this.RegisterSetupType<MvxWpfSetup<App>>();
        }
    }
}
