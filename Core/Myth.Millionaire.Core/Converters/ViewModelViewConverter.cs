using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace Myth.Millionaire.Core.Converters
{
    class ViewModelViewConverter : MvxValueConverter<Type, IMvxView> {
        private static readonly IMvxViewsContainer ViewsContainer = Mvx.Resolve<IMvxViewsContainer>();
        protected override IMvxView Convert(Type viewModelType, Type targetType, object parameter, CultureInfo culture) {
            Type viewType = ViewsContainer.GetViewType(viewModelType);
            return viewType != null ? (IMvxView)Activator.CreateInstance(viewType) : null;
        }
    }
}

