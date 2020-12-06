    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Android.App;
    using Android.Content;
    using Android.Graphics;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Org.Json;
    using Xamarin.Auth;

namespace Twinkle.Scripts.Splash
{
    class facebookLogin
    {
        public EventHandler AuthCompleteEvent;
        private Account acc;
        const string FaceBookAppId = "1686673194912443";
        private UserSignUpData userData = null;

        public facebookLogin(Context context)
        {
            OAuth2Authenticator auth = new OAuth2Authenticator(FaceBookAppId, "user_friends+user_status+public_profile+user_friends+email+user_birthday+user_events+user_hometown+user_likes+user_location+user_photos+user_posts+user_tagged_places+user_videos+pages_show_list", new Uri("https://m.facebook.com/dialog/oauth/"), new Uri("https://www.facebook.com/connect/login_success.html"));
            context.StartActivity(auth.GetUI(context));
            auth.Completed += (object s, AuthenticatorCompletedEventArgs ev) =>
            {
                string w = ev.Account.Serialize();
                acc = Account.Deserialize(w);
                var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me/picture?fields=height=800,width=800"), null, acc);
                Bitmap profilePic = null;
                request.GetResponseAsync().ContinueWith(t =>
                {
                    if (t.IsFaulted)
                        Console.WriteLine("Error: " + t.Exception.InnerException.Message);
                    else
                    {
                        var Response = t.Result.GetResponseStream();
                        profilePic = BitmapFactory.DecodeStream(Response);
                    }
                });

                request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=gender,first_name,middle_name,last_name,birthday,name"), null, acc);

                request.GetResponseAsync().ContinueWith(t =>
                {
                    if (t.IsFaulted)
                        Console.WriteLine("Error: " + t.Exception.InnerException.Message);
                    else
                    {
                        var Response = t.Result.GetResponseText();
                        JSONObject oj = new JSONObject(Response);
                        string gender = oj.GetString("gender");
                        string first_name = oj.GetString("first_name");
                        string last_name = oj.GetString("last_name");
                        string birthday = oj.GetString("birthday");
                        string name = oj.GetString("name");

                        userData = new UserSignUpData(profilePic, gender, first_name, last_name, birthday, name);
                        AuthCompleteEvent.Invoke(this, EventArgs.Empty);
                    }
                });
            };
        }

        public UserSignUpData GetUserData()
        {
            return userData;
        }
    }

    class UserSignUpData
    {
        public Bitmap profilePic;
        public string gender;
        public string first_name;
        public string last_name;
        public string birthday;
        public string name;

        public UserSignUpData(Bitmap profilePic, string gender, string first_name, string last_name, string birthday, string name)
        {
            this.profilePic = profilePic;
            this.gender = gender;
            this.first_name = first_name;
            this.last_name = last_name;
            this.birthday = birthday;
            this.name = name;
        }
    }
}