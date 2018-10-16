using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using Com.Google.Android.Flexbox;
using PCL;
using PCL.Presenter;
using System;
using System.Collections.Generic;

namespace AppDroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Presenter _presenter;
        List<FriendVM> _list;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _presenter = new Presenter(new Repository(new JsonGetter()));
            _list = _presenter.GetFriendVM();

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.my_recycler_view);

            FlexboxLayoutManager flexboxLayoutManager = new FlexboxLayoutManager(this);
            flexboxLayoutManager.FlexDirection = 1;
            flexboxLayoutManager.JustifyContent = 1;

            recyclerView.SetLayoutManager(flexboxLayoutManager);

            // recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            var adapter = new RecyclerViewAdapter(_list);
            recyclerView.SetAdapter(adapter);
        }

        private void Item_Click(object sender, EventArgs e)
        {
            TextView textView = sender as TextView;

            textView.SetTextColor(Android.Graphics.Color.Red);
        }
    }
}