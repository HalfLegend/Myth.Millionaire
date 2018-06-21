using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using Myth.Millionaire.Core.Helpers;
using Myth.Millionaire.Core.ViewModels.CreditMasterDetail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Myth.Millionaire.Forms.UI.Pages.CreditMasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditMasterDetailPage
    {
        public CreditMasterDetailPage()
        {
            InitializeComponent();
            ViewModelHelper.EnsureViewModel(this);
        }
    }
}