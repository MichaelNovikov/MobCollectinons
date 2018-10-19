using CoreGraphics;
using Foundation;
using PCL;
using PCL.Presenter;
using System;
using System.Collections.Generic;
using UIKit;

namespace AppiOS
{
    public partial class ViewController : UIViewController
    {
        Delegate _delegate;
        Presenter _presenter;
        List<FriendVM> _list;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _collectionView.RegisterNibForCell(ViewCell.Nib, ViewCell.Key);

            _presenter = new Presenter(new Repository(new JsonGetter()));
            _list = _presenter.GetFriendVM();

            _delegate = new Delegate(this);
           
            _collectionView.WeakDataSource = new DataSource(_list);
            _collectionView.WeakDelegate = _delegate;
            _collectionView.CollectionViewLayout = new LeftAlignedCollectionViewFlowLayout();

            //_collectionView.ReloadData();
            //_collectionView.ReloadItems(new NSIndexPath[] { NSIndexPath.FromRowSection(0, 0) });
        }
    }
}
