// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AppiOS
{
    [Register ("ViewTwoController")]
    partial class ViewTwoController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _LabelText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_LabelText != null) {
                _LabelText.Dispose ();
                _LabelText = null;
            }
        }
    }
}