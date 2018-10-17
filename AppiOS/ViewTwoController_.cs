using Foundation;
using System;
using System.Text;
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
            _txtView.Text = TextCreate(textData);
        }

        private string TextCreate(string str)
        {
            var strB = new StringBuilder();

            for (int i = 0; i < 50; i++)
            {
                strB.Append(str + " ");
            }

            return strB.ToString();
        }
    }
}