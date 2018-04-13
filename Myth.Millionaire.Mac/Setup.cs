using System;
using AppKit;
using MvvmCross.Platforms.Mac.Core;
using MvvmCross.ViewModels;

namespace Myth.Millionaire.Mac
{
	public class Setup : MvxMacSetup
    {
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}
