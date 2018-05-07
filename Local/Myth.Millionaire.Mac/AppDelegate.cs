using System;
using AppKit;
using Foundation;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Core;
using MvvmCross.Platforms.Mac.Core;
using MvvmCross.ViewModels;

namespace Myth.Millionaire.Mac
{
    [Register("AppDelegate")]
	public class AppDelegate : MvxApplicationDelegate
    {
		public override void DidFinishLaunching(NSNotification notification)
		{
			MvxMacSetupSingleton.EnsureSingletonAvailable((IMvxApplicationDelegate)this, MainWindow).EnsureInitialized();
			IMvxAppStart mvxAppStart = Mvx.Resolve<IMvxAppStart>();
            if (mvxAppStart.IsStarted)
                return;
			mvxAppStart.Start(this.GetAppStartHint(notification));
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
