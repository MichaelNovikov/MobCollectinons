
using Android.App;
using Android.Content;
using Android.OS;

namespace AppDroid
{
    [Activity(Label = "Activity")]
    public class DetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail);

            Bundle bundle = Intent.Extras;
            var str = bundle?.GetString("tag");

            CustomViewDetail viewDetail = this.FindViewById<CustomViewDetail>(Resource.Id.customViewDetail);
            viewDetail.SetData(str);
        }
    }
}