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

namespace Twinkle.Scripts
{
    public class pagerAdapter : FragmentStatePagerAdapter
    {
        private List<Fragment> fragmentList = new List<Fragment>();

        public pagerAdapter(FragmentManager fm) : base(fm)
        {

        }

        public void addFragment(Fragment fragment)
        {
            fragmentList.Add(fragment);
        }

        public override int Count => fragmentList.Count;

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return fragmentList[position];
        }
    }
}