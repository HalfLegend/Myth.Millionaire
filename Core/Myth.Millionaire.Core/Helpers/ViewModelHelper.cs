using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace Myth.Millionaire.Core.Helpers
{
    public static class ViewModelHelper
    {
        public static void EnsureViewModel<TViewModel>(IMvxView<TViewModel> mvxView) where TViewModel:class ,IMvxViewModel {
            if (mvxView.ViewModel == null) {
                try {
                    mvxView.ViewModel = Mvx.IoCConstruct<TViewModel>();
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
