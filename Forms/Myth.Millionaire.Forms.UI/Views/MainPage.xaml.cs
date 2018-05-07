using MvvmCross.Forms.Views;
using Myth.Millionaire.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Myth.Millionaire.Forms.UI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MvxContentPage<MainViewModel> {
		public MainPage ()
		{
			InitializeComponent ();
		}
	}
}