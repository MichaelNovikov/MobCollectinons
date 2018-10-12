using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using PCL.Presenter;

namespace AppDroid
{
    class RecyclerViewAdapter : RecyclerView.Adapter
    {
        List<FriendVM> _friends;

        public RecyclerViewAdapter(List<FriendVM> friends)
        {
            _friends = friends;
        }
        public override int ItemCount
        {
            get
            {
                return _friends?.Count ?? 0;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row, parent, false);
            return new RecyclerViewHolder(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = _friends[position];
            var view = holder as RecyclerViewHolder;
            view.SetData(item);
        }
    }
}