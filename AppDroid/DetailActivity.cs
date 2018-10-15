
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Text;

namespace AppDroid
{
    [Activity(Label = "Activity")]
    public class DetailActivity : Activity
    {
        ImageView _imageView;
        TextView _textView1;
        TextView _textView2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail);

            _imageView = FindViewById<ImageView>(Resource.Id.detailImage_view_id1);
            _textView1 = FindViewById<TextView>(Resource.Id.detailText_view_id1);
            _textView2 = FindViewById<TextView>(Resource.Id.detailText_view_id2);

            Bundle bundle = Intent.Extras;

            var str = bundle?.GetString("tag");
            _textView1.Text = str ?? "";

            _textView2.Text = TextCreate(str);
        }

        private string TextCreate(string str)
        {
            var strB = new StringBuilder();

            for (int i = 0; i < 1000; i++)
            {
                strB.Append(str + " ");
            }

            return strB.ToString();
        }
    }
}