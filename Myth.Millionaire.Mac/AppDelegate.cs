using AppKit;
using Foundation;
using MvvmCross.Platforms.Mac.Core;

namespace Myth.Millionaire.Mac
{
    [Register("AppDelegate")]
	public class AppDelegate : MvxApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
