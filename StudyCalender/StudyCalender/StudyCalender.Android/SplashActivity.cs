using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;

namespace StudyCalender.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/IconCalender" ,MainLauncher = true, Theme ="@style/Theme.Splash",
             NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.splashLayout);
                StartActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        
    }
}