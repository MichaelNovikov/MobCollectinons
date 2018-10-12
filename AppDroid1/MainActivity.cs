using Android.App;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using PCL.Presenter;
using Android.Support.V7.Widget;
using Com.Google.Android.Flexbox;

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

            _presenter = new Presenter();
            _list = _presenter.GetViewModel();

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.my_recycler_view);

            FlexboxLayoutManager flexboxLayoutManager = new FlexboxLayoutManager(this);

            recyclerView.SetLayoutManager(flexboxLayoutManager);

         // recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            var adapter = new RecyclerViewAdapter(_list);
            recyclerView.SetAdapter(adapter);
        }
    }
}