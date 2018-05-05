using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MvvmCross.Forms.Core;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace Myth.Millionaire.Forms.WPF.Startup {
    public class Setup : MvxWpfSetup, IMvxFormsSetup {
        protected override IMvxApplication CreateApp() {
            return new Myth.Millionaire.Core.Startup.App();
        }

        public Application FormsApplication { get; } = new Myth.Millionaire.Forms.Desktop.Startup.App();

        public override IEnumerable<Assembly> GetViewAssemblies() {
            var assemblies = base.GetViewAssemblies();
           return  assemblies.Union(new[] { FormsApplication.GetType().Assembly });
        }
    }
}