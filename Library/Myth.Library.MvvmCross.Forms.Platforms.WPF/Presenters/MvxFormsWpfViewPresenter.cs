using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MvvmCross.Forms.Presenters;
using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
using Application = Xamarin.Forms.Application;

namespace Myth.Library.MvvmCross.Forms.Platforms.WPF.Presenters {
    class MvxFormsWpfViewPresenter : MvxWpfViewPresenter, IMvxFormsViewPresenter {
        public MvxFormsWpfViewPresenter(ContentControl contentControl, Application formsApplication) : base(contentControl) {
            FormsApplication = formsApplication ?? throw new ArgumentNullException(nameof(formsApplication), "MvxFormsApplication cannot be null");
        }

        public Application FormsApplication { get; set; }

        private IMvxFormsPagePresenter _formsPagePresenter;
        public virtual IMvxFormsPagePresenter FormsPagePresenter {
            get {
                if (_formsPagePresenter == null)
                    throw new ArgumentNullException(nameof(FormsPagePresenter), "IMvxFormsPagePresenter cannot be null. Set the value in CreateViewPresenter in the setup.");
                return _formsPagePresenter;
            }
            set { _formsPagePresenter = value; }
        }

        public override MvxBasePresentationAttribute CreatePresentationAttribute(Type viewModelType, Type viewType) {
            if (viewType.IsSubclassOf(typeof(Window))) {

                return new MvxWindowPresentationAttribute();
            }

            return new MvxContentPresentationAttribute();
        }

        public override void Show(MvxViewModelRequest request) {
            FormsPagePresenter.Show(request);
        }

        public override void RegisterAttributeTypes() {
            base.RegisterAttributeTypes();
            FormsPagePresenter.RegisterAttributeTypes();
        }

        public override void ChangePresentation(MvxPresentationHint hint) {
            FormsPagePresenter.ChangePresentation(hint);
            base.ChangePresentation(hint);
        }

        public override void Close(IMvxViewModel viewModel) {
            FormsPagePresenter.Close(viewModel);
        }

        public virtual bool ShowPlatformHost(Type hostViewModel = null) {
            // MvxFormsLog.Instance.Trace($"Showing of native host View in Forms is not supported.");
            return false;
        }

        public virtual bool ClosePlatformViews() {
            // MvxFormsLog.Instance.Trace($"Showing of native host View in Forms is not supported.");
            return false;
        }

        class InnerFormsPresenter {
            
        }
    }
}
