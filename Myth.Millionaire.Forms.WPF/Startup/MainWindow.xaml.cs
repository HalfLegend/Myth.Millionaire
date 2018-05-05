using System.Windows;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace Myth.Millionaire.Forms.WPF.Startup {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once InheritdocConsiderUsage
    public partial class MainWindow {
        public MainWindow() {
            Xamarin.Forms.Forms.Init();
            LoadApplication(new Desktop.Startup.App());
            InitializeComponent();
        }
    }
}
