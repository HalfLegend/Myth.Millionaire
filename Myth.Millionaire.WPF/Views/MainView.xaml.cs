
using MvvmCross.Platforms.Wpf.Views;
using Myth.Millionaire.ViewModels;

namespace Myth.Millionaire.WPF.Views {

    public partial class MainView : MvxWpfView<MainViewModel> {
        public MainView() {
            InitializeComponent();
        }
    }
}
