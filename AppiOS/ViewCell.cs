using System;

using Foundation;
using PCL.Presenter;
using UIKit;

namespace AppiOS
{
    public partial class ViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("ViewCell");
        public static readonly UINib Nib;

        static ViewCell()
        {
            Nib = UINib.FromName("ViewCell", NSBundle.MainBundle);

        }

        protected ViewCell(IntPtr handle) : base(handle)
        {

        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

        }

        public void SetData(FriendVM friends)
        {
            _lblText.Text = $"{friends?.FirstName} {friends?.LastName}";
        }

    }
}
