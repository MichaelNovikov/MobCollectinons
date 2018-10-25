using System;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AppDroid
{
    [Register("AppDroid.CustomView")]
    class CustomViewDetail : LinearLayout
    {
        TextView _textView1;
        TextView _textView2;

        public CustomViewDetail(Context context) : base(context)
        {
            InitView(context);
        }

        public CustomViewDetail(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            InitView(context);
        }

        public CustomViewDetail(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            InitView(context);
        }

        public CustomViewDetail(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            InitView(context);
        }

        protected CustomViewDetail(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        private void InitView(Context context)
        {
            LayoutInflater inflater = ((Activity)context).LayoutInflater;
            inflater.Inflate(Resource.Layout.custom_layout, this, true);
            _textView1 = FindViewById<TextView>(Resource.Id.detailText_view_id1);
            _textView2 = FindViewById<TextView>(Resource.Id.detailText_view_id2);
        }

        public void SetData(string str)
        {
            _textView1.Text = str;
            _textView2.Text = TextCreate(str);
        }

        private string TextCreate(string str)
        {
            var strB = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                strB.Append(str + " ");
            }
            return strB.ToString();
        }
    }
}