using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using XLabs.Ioc;

namespace MrcheTrekking.Droid
{  
    [Activity(Label = "MrcheTrekking", Icon = "@drawable/logo", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //maps
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            if (!Resolver.IsSet)
            {
                Resolver.SetResolver(new SimpleContainer().GetResolver());
            }

            //check dei permessi della localizzazione
            base.OnStart();
            if (CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted && CheckSelfPermission(Manifest.Permission.AccessFineLocation) != (int)Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
            }

            LoadApplication(new App());

        }

    }
}