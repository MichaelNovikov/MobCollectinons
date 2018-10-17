using Foundation;
using System;
using UIKit;

namespace AppiOS
{
    public partial class ViewTwoController : UIViewController
    {
        public string textData;
        public ViewTwoController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _LabelText.Text = textData;

        }
    }
}