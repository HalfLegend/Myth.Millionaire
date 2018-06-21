using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;

namespace Myth.Millionaire.Core.ViewModels.CreditMasterDetail
{
    public class CreditMasterDetailViewModel : MvxViewModel
    {
        private string _text = "Hello MvvmCross in master";
        public string Text2
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}
