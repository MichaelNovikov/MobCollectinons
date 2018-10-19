using Android.Content;
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
            _textView = item.FindViewById<TextView>(Resource.Id.text_view_id);
            _textView.Click += Item_Click;
        }

        public void SetData(FriendVM friend)
        {
            _textView.Text = friend.FirstLastName;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            TextView textView = sender as TextView;

            var context = _view.Context;
            Intent intent = new Intent(context ,typeof(DetailActivity));
            intent.PutExtra("tag", $"{textView.Text}");
            context.StartActivity(intent);
        }
    }
}