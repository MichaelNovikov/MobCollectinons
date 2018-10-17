using System;
using System.Collections.Generic;
using AppiOS;
using Foundation;
using PCL.Presenter;
using UIKit;

namespace AppiOS
{
    public class DataSource : UICollectionViewDataSource
    {
        public List<FriendVM> _friends;

        public DataSource(List<FriendVM> friends)
        {
            _friends = friends;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {

            var cell = collectionView.DequeueReusableCell(ViewCell.Key, indexPath) as ViewCell;
            cell.SetData(_friends[indexPath.Row]);


            cell.ContentView.Layer.BackgroundColor = (UIColor.LightGray).CGColor;
            cell.ContentView.Layer.BorderWidth = 2;
            cell.ContentView.Layer.CornerRadius = 8;
            return cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return _friends?.Count ?? 0;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1; //base.NumberOfSections(collectionView);
        }
    }
}
