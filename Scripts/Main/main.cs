using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SafeTraveling;

namespace Twinkle.Scripts.Main
{
    class main:Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.main, container, false);

            TextView tv1 = v.FindViewById<TextView>(Resource.Id.textView1);
            TextView tv2 = v.FindViewById<TextView>(Resource.Id.textView2);
            TextView tv3 = v.FindViewById<TextView>(Resource.Id.textView3);
            CheckBox c1 = v.FindViewById<CheckBox>(Resource.Id.checkBox1);
            CheckBox c2 = v.FindViewById<CheckBox>(Resource.Id.checkBox2);
            ImageView gotosleep = v.FindViewById<ImageView>(Resource.Id.imageView2);

            SetTypeface.Normal.SetTypeFace(Context, tv1);
            SetTypeface.Normal.SetTypeFace(Context, tv2);
            SetTypeface.Italic.SetTypeFace(Context, tv3);

            gotosleep.Click += (object sender, EventArgs e) => { 
                if (c1.Checked && c2.Checked)
                    ((main_container)Activity).setViewPager(2);
            };            

            return v;
        }
    }
}