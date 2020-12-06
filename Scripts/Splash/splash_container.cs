using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Twinkle.Scripts;
using Android.Support.V4.View;
using Twinkle.Scripts.Splash;
using Android.App;
using Java.IO;
using Com.Tbruyelle.Rxpermissions2;

namespace Twinkle
{
    [Activity(MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private pagerAdapter mPagerAdapter;
        private ViewPager viewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            Window.SetFlags(Android.Views.WindowManagerFlags.Fullscreen, Android.Views.WindowManagerFlags.Fullscreen);

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.splash_container);

            SupportActionBar.Hide();

            viewPager = FindViewById<ViewPager>(Resource.Id.container);
            mPagerAdapter = new pagerAdapter(SupportFragmentManager);
            
            mPagerAdapter.addFragment(new splash());
            mPagerAdapter.addFragment(new login());

            viewPager.BeginFakeDrag();
            viewPager.Adapter = mPagerAdapter;

            setViewPager(0);
            Handler handler = new Handler();
            handler.PostDelayed(()=> setViewPager(1),3000);
        }

        public void setViewPager(int index)
        {
            viewPager.SetCurrentItem(index, false);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}