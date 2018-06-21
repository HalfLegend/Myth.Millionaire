using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Myth.Millionaire.Forms.UI.Pages.CreditMasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditMasterDetailPageMaster
    {
        public ListView ListView;

        public CreditMasterDetailPageMaster()
        {
            InitializeComponent();
        }
    }
}