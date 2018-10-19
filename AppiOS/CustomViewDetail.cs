using Foundation;
using System;
using System.ComponentModel;
using System.Text;
using UIKit;

namespace AppiOS
{
    [DesignTimeVisible(true)]
    public partial class CustomViewDetail : UIView
    {
        public CustomViewDetail (IntPtr handle) : base (handle)
        {

        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            NSBundle.MainBundle.LoadNib("CustomViewDetail", this, null); //xib name!!!

            var frame = _rootFrame.Frame;
            frame.Width = Frame.Width;
            frame.Height = Frame.Height;
            _rootFrame.Frame = frame;

            AddSubview(_rootFrame);

        }
   
        public void setData(string str)
        {
            _customLabelText.Text = str;
            _customTextView.TextContainer.MaximumNumberOfLines = 3;
            _customTextView.Text = TextCreate(_customLabelText.Text);
        }

        private string TextCreate(string str)
        {
            var strB = new StringBuilder();

            for (int i = 0; i < 200; i++)
            {
                strB.Append(str + " ");
            }

            return strB.ToString();
        }

    }
}