using MvvmCross.Core;
using Myth.Library.MvvmCross.Forms.Platforms.WPF.Core;

namespace Myth.Millionaire.Forms.WPFv0.Startup {
    /// <summary>
    /// FormsApp.xaml 的交互逻辑
    /// </summary>
    public partial class App {
        protected override void RegisterSetup() {
            this.RegisterSetupType<MvxFormsWpfSetup<Core.Startup.App, UI.Startup.FormsApp>>();
            /*
            Timer timer = new Timer();
            timer.Interval = 5000;
            Dispatcher dispatcher = this.Dispatcher;

            int times = 0;
            Page lastPage = new MainPage();
            timer.Elapsed += (sender, e) => {
                dispatcher.Invoke(() => {


                    MvxFormsWindow window = (MvxFormsWindow)this.MainWindow;

                    Page tempPage = (Page)window.StartupPage;
                    window.StartupPage = lastPage;
                    if (times == 3) {
                        timer.Stop();
                        ICollection<string> result = lastPage.CompareProperties(tempPage);
                        foreach (string s in result) {
                           System.Console.WriteLine(s);
                        }
                        return;
                    }
                    lastPage = tempPage;



                    times++;
                    //NavigationPage p = (NavigationPage)window.StartupPage;
                    //p.Navigation.PushAsync(new MainPage());
                    //var a = Application.Current.MainPage;

                    //Application.Current.MainPage = new MainPage();
                    //System.Windows.Application wpfApplication = System.Windows.Application.Current;
                    //MvxFormsWindow window = (MvxFormsWindow)System.Windows.Application.Current.MainWindow;
                    //window.Content = Application.Current.MainPage;
                });



                //Application.Current.MainPage = new NavigationPage(new MainPage());

            };
             timer.Start();
             */
        }
    }
}
