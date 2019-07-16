using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using XLabs.Ioc;

namespace MrcheTrekking.Droid
{
    [Activity(Label = "MrcheTrekking", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            if (!Resolver.IsSet)
            {
                Resolver.SetResolver(new SimpleContainer().GetResolver());
            }

            LoadApplication(new App());

        }

    }
}