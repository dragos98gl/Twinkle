using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Twinkle.Scripts.Main;

namespace Twinkle.Scripts
{
    [Activity(Label = "main")]
    public class main_container : AppCompatActivity
    {
        private pagerAdapter mPagerAdapter;
        private ViewPager viewPager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            Window.SetFlags(Android.Views.WindowManagerFlags.Fullscreen, Android.Views.WindowManagerFlags.Fullscreen);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.main_container);

            SupportActionBar.Hide(); viewPager = FindViewById<ViewPager>(Resource.Id.container);
            mPagerAdapter = new pagerAdapter(SupportFragmentManager);

            mPagerAdapter.addFragment(new quiz());
            mPagerAdapter.addFragment(new main());
            mPagerAdapter.addFragment(new sleepplayer());

            viewPager.BeginFakeDrag();
            viewPager.Adapter = mPagerAdapter;
            
            setViewPager(0);
        }

        public void setViewPager(int index)
        {
            viewPager.SetCurrentItem(index, false);
        }
    }
}