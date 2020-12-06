using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using SafeTraveling;

namespace Twinkle.Scripts.Main
{
    class quiz : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.quiz, container, false);

            TextView tv1 = v.FindViewById<TextView>(Resource.Id.textView1);
            TextView tv2 = v.FindViewById<TextView>(Resource.Id.textView2);
            Spinner sp1 = v.FindViewById<Spinner>(Resource.Id.spinner1);
            Spinner sp2 = v.FindViewById<Spinner>(Resource.Id.spinner2);
            ImageView iv1 = v.FindViewById<ImageView>(Resource.Id.imageView1);

            SetTypeface.Normal.SetTypeFace(Context, tv1);
            SetTypeface.Normal.SetTypeFace(Context, tv2);

            List<string> hours = new List<string>() { "01", "02", "02", "03", "04", "05", "06", "07", "08", "09" };
            hours.AddRange(Enumerable.Range(10,15).Select(s=>s.ToString()));
            
            ArrayAdapter aa = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, hours);
            aa.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            sp1.Adapter = aa;
            sp2.Adapter = aa;

            iv1.Click += (object sender, EventArgs e) =>
            {
                ((main_container)Activity).setViewPager(1);
            };

            return v;
        }
    }
}