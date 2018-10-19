// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppiOS
{
    [Register ("CustomViewDetail")]
    partial class CustomViewDetail
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _customLabelText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView _customTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _customViewText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootFrame { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_customLabelText != null) {
                _customLabelText.Dispose ();
                _customLabelText = null;
            }

            if (_customTextView != null) {
                _customTextView.Dispose ();
                _customTextView = null;
            }

            if (_customViewText != null) {
                _customViewText.Dispose ();
                _customViewText = null;
            }

            if (_rootFrame != null) {
                _rootFrame.Dispose ();
                _rootFrame = null;
            }
        }
    }
}