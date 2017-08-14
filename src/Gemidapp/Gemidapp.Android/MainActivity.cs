using Android.App;
using Android.Content.PM;
using Android.OS;
using Gemidapp.Droid.Services;
using PerpetualEngine.Storage;

namespace Gemidapp.Droid
{
    [Activity(Label = "GemidaoXam.Android", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            SimpleStorage.SetContext(ApplicationContext);
            ContactService.SetContext(ApplicationContext);

            LoadApplication(new App());
        }
    }
}