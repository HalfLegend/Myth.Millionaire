using System;

using AppKit;
using Foundation;
using MvvmCross.Platforms.Mac;
using MvvmCross.Platforms.Mac.Core;
using MvvmCross.Platforms.Mac.Presenters;
using MvvmCross.Platforms.Mac.Views;
using Myth.Millionaire.Core.ViewModels;

namespace Myth.Millionaire.Mac
{
	[MvxFromStoryboard("Main")]
	public partial class ViewController : MvxViewController<MainViewModel> 
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
