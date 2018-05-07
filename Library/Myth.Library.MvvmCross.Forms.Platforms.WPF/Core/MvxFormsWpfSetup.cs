using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using MvvmCross;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Presenters;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.Plugin;
using MvvmCross.ViewModels;
using Myth.Library.MvvmCross.Forms.Platforms.WPF.Presenters;
using Myth.Library.MvvmCross.Forms.Platforms.WPF.Views;
using Xamarin.Forms;

namespace Myth.Library.MvvmCross.Forms.Platforms.WPF.Core {
    public abstract class MvxFormsWpfSetup : MvxWpfSetup, IMvxFormsSetup {
        private List<Assembly> _viewAssemblies;
        private Application _formsApplication;
        
        public override IEnumerable<Assembly> GetViewAssemblies()
        {
            return _viewAssemblies ?? (_viewAssemblies = new List<Assembly>(base.GetViewAssemblies()));
        }

        protected override void InitializeIoC() {
            base.InitializeIoC();
            Xamarin.Forms.Forms.Init();
            Mvx.RegisterSingleton<IMvxFormsSetup>(this);
        }

        protected override void InitializeApp(IMvxPluginManager pluginManager, IMvxApplication app) {
            base.InitializeApp(pluginManager, app);
            _viewAssemblies.AddRange(GetViewModelAssemblies());

            MvxFormsWindow formsWindow = (MvxFormsWindow)System.Windows.Application.Current.MainWindow;
            formsWindow.LoadApplication(FormsApplication);
        }

        public virtual Application FormsApplication {
            get {
                if (_formsApplication == null) {
                    _formsApplication = CreateFormsApplication();
                    Application.Current = _formsApplication;
                }
                return _formsApplication;
            }
        }

        protected abstract Application CreateFormsApplication();

        protected virtual IMvxFormsPagePresenter CreateFormsPagePresenter(IMvxFormsViewPresenter viewPresenter) {
            var formsPagePresenter = new MvxFormsPagePresenter(viewPresenter);
            Mvx.RegisterSingleton(formsPagePresenter);
            return formsPagePresenter;
        }


        protected override IMvxWpfViewPresenter CreateViewPresenter(ContentControl root) {
            var presenter = new MvxFormsWpfViewPresenter(root, FormsApplication);
            Mvx.RegisterSingleton<IMvxFormsViewPresenter>(presenter);
            presenter.FormsPagePresenter = CreateFormsPagePresenter(presenter);
            return presenter;
        }

        //protected override void InitializeBindingBuilder() {
        //    MvxBindingBuilder bindingBuilder = CreateBindingBuilder();

        //    RegisterBindingBuilderCallbacks();
        //    bindingBuilder.DoRegistration();
        //}

        //protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry) {
        //    MvxFormsSetupHelper.FillTargetFactories(registry);
        //    base.FillTargetFactories(registry);
        //}

        //protected override void FillBindingNames(Binding.BindingContext.IMvxBindingNameRegistry registry) {
        //    MvxFormsSetupHelper.FillBindingNames(registry);
        //    base.FillBindingNames(registry);
        //}

        //protected override MvxBindingBuilder CreateBindingBuilder() => new MvxFormsAndroidBindingBuilder();

        protected override IMvxNameMapping CreateViewToViewModelNaming() {
            return new MvxPostfixAwareViewToViewModelNameMapping("View", "Page");
        }
    }


    public class MvxFormsWpfSetup<TApplication, TFormsApplication> : MvxFormsWpfSetup
        where TApplication : IMvxApplication, new()
        where TFormsApplication : Application, new() {
        public override IEnumerable<Assembly> GetViewAssemblies() {
            return new List<Assembly>(base.GetViewAssemblies().Union(new[] { typeof(TFormsApplication).GetTypeInfo().Assembly }));
        }

        public override IEnumerable<Assembly> GetViewModelAssemblies() {
            return new[] { typeof(TApplication).GetTypeInfo().Assembly };
        }

        protected override Application CreateFormsApplication() => new TFormsApplication();

        protected override IMvxApplication CreateApp() => Mvx.IocConstruct<TApplication>();
    }
}
