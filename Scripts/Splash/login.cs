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

namespace Twinkle.Scripts.Splash
{
    class login : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.login, container, false);

            ImageView fb_signUp = v.FindViewById<ImageView>(Resource.Id.imageView2);
            ImageView b = v.FindViewById<ImageView>(Resource.Id.imageView1);
            TextView tv1 = v.FindViewById<TextView>(Resource.Id.textView1);
            SetTypeface.Italic.SetTypeFace(Context, tv1);

            b.Click += (object sender, EventArgs e)=>
            {
                StartActivity(new Intent(this.Context,typeof(main_container)));
            };

            fb_signUp.Click += (object sender, EventArgs e) => {
                facebookLogin fbl = new facebookLogin(Context);

                fbl.AuthCompleteEvent += (s, args) =>
                {
                    UserSignUpData usud = fbl.GetUserData();

                    if (usud != null)
                    {
                        string userID = usud.first_name+" "+usud.last_name +" "+ usud.birthday+" " +usud.gender;
                        Toast.MakeText(Context,userID,ToastLength.Short).Show();

                        StartActivity(new Intent(this.Context, typeof(main_container)));
                    }
                    else
                        Toast.MakeText(Context, "sign up error", ToastLength.Short).Show();
                };
            };

            return v;
        }
    }
}