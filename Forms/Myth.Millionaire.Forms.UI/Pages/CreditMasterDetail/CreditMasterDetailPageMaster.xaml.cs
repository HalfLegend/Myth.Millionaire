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
    public partial class CreditMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public CreditMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new CreditMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class CreditMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<CreditMasterDetailPageMenuItem> MenuItems { get; set; }
            
            public CreditMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<CreditMasterDetailPageMenuItem>(new[]
                {
                    new CreditMasterDetailPageMenuItem { Id = 0, Title = "Page 1" },
                    new CreditMasterDetailPageMenuItem { Id = 1, Title = "Page 2" },
                    new CreditMasterDetailPageMenuItem { Id = 2, Title = "Page 3" },
                    new CreditMasterDetailPageMenuItem { Id = 3, Title = "Page 4" },
                    new CreditMasterDetailPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}