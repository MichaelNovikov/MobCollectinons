
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using PCL.Presenter;
using System;

namespace AppDroid
{
    public class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        private TextView _textView;
        private View _view;

        public RecyclerViewHolder(View item) : base(item)
        {
            _view = item;
            _textView = item.FindViewById<TextView>(Resource.Id.text_view_id1);
        }

        public void SetData(FriendVM friends)
        {
            _textView.Text = $"Name: {friends?.FirstName} {friends?.LastName}";

            Random rnd = new Random();
            var color = Color.Argb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256));
            _view.SetBackgroundColor(color);
        }
    }
}