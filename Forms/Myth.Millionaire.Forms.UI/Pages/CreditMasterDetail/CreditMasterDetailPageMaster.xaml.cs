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
            Button button = ConfigButton;


            new Animation {
                { 0, 0.5, new Animation (v => button.BackgroundColor = new Color(255,0,0, v), 0, 1) },
                { 0.5, 1, new Animation (v => button.BackgroundColor = new Color(255,0,0, v), 1, 0) },
            }.Commit(button, "ChildAnimations", 16, 4000, null, null, () => true);
        }
    }
}