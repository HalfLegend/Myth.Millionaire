using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MvvmCross.Base;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using Xamarin.Forms.Platform.WPF;
using MvxApplication = MvvmCross.Platforms.Wpf.Views.MvxApplication;

namespace Myth.Millionaire.Forms.WPF.Startup {
    public class MvxFormsWindow : FormsApplicationPage, IMvxWindow, IMvxWpfView, IDisposable {
        private IMvxViewModel _viewModel;

        public IMvxViewModel ViewModel {
            get => this._viewModel;
            set {
                this._viewModel = value;
                this.DataContext = (object)value;
            }
        }

        public string Identifier { get; set; }

        public MvxFormsWindow() {
            this.Unloaded += new RoutedEventHandler(this.MvxWindow_Unloaded);
            this.Loaded += new RoutedEventHandler(this.MvxWindow_Loaded);
            this.Initialized += new EventHandler(this.MvxWindow_Initialized);
        }

        private void MvxWindow_Initialized(object sender, EventArgs e) {
            if (this != System.Windows.Application.Current.MainWindow)
                return;
            (System.Windows.Application.Current as MvxApplication).ApplicationInitialized();
        }

        private void MvxWindow_Unloaded(object sender, RoutedEventArgs e) {
            IMvxViewModel viewModel1 = this.ViewModel;
            if (viewModel1 != null)
                viewModel1.ViewDisappearing();
            IMvxViewModel viewModel2 = this.ViewModel;
            if (viewModel2 == null)
                return;
            viewModel2.ViewDisappeared();
        }

        private void MvxWindow_Loaded(object sender, RoutedEventArgs e) {
            IMvxViewModel viewModel1 = this.ViewModel;
            if (viewModel1 != null)
                viewModel1.ViewAppearing();
            IMvxViewModel viewModel2 = this.ViewModel;
            if (viewModel2 == null)
                return;
            viewModel2.ViewAppeared();
        }

        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        ~MvxFormsWindow() {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposing)
                return;
            this.Unloaded -= new RoutedEventHandler(this.MvxWindow_Unloaded);
            this.Loaded -= new RoutedEventHandler(this.MvxWindow_Loaded);
        }
    }
}
