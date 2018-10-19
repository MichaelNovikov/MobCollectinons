using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using PCL.Presenter;
using UIKit;

namespace AppiOS
{
    public class Delegate : UICollectionViewDelegateFlowLayout
    {
        private UIViewController _controller;

        public Delegate(UIViewController controller)
        {
            _controller = controller;
        }

        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            var friend = ((DataSource)collectionView.WeakDataSource)._friends[indexPath.Row];
            CGSize size = new NSString(friend.FirstLastName + "   " ).GetSizeUsingAttributes(new UIStringAttributes(NSDictionary.FromObjectAndKey(UIFont.BoldSystemFontOfSize(15), UIStringAttributeKey.Font)));
            size.Width += 10;
            size.Height += 10;
            collectionView.SystemLayoutSizeFittingSize(size, 1.0f, 1.0f);
            

            return size;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            //base.ItemSelected(collectionView, indexPath);
            
            var friend = ((DataSource)collectionView.WeakDataSource)._friends[indexPath.Row];

            ViewTwoController viewTwo = _controller.Storyboard.InstantiateViewController("ViewTwo") as ViewTwoController;
            viewTwo.textData = friend.FirstLastName;
            _controller.NavigationController.PushViewController(viewTwo, true);
        }

        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            // Always allow for highlighting
            return true;
        }

        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {

        }

        public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {

        }
    }
}
