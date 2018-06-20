using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;

namespace Myth.Library.MvvmCross.Forms.Platforms.WPF.Presenters {
    class MvxFormsWpfViePresenter : MvxFormsPagePresenter {
        public MvxFormsWpfViePresenter(IMvxFormsViewPresenter platformPresenter) : base(platformPresenter) { }

        public override void ReplacePageRoot(Page existingPage, Page page, MvxPagePresentationAttribute attribute) {
            if (existingPage == this.FormsApplication.MainPage) {
                FormsApplication.MainPage = page;
            }
        }

    }
}
