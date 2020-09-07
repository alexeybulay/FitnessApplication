using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Graphics;
using Android.Views;
using FFImageLoading.Forms.Platform;

namespace App3.Droid
{
    [Activity(Label = "App3", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Rg.Plugins.Popup.Popup.Init(this, savedInstanceState); // инициализация плагина pop-up
            CachedImageRenderer.Init(true);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            Window.SetNavigationBarColor(Color.Teal);
            Window.SetStatusBarColor(Color.Teal);
        }
    }
}