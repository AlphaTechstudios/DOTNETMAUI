using Android.App;
using Android.Content.PM;
using Android.OS;
using Java.Net;

namespace DeepLink;

[Activity(Theme = "@style/Maui.SplashTheme", Exported =true, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(new[] {Android.Content.Intent.ActionView},
    DataScheme ="https",
    DataHost ="yourdomain.com",
    DataPathPrefix ="/",
    AutoVerify =true,
    Categories = new[] { Android.Content.Intent.ActionView, Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable})]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        var url = Intent?.DataString;
        if (!string.IsNullOrEmpty(url))
        {
            Microsoft.Maui.Controls.Application.Current.SendOnAppLinkRequestReceived(new Uri(url))
;        }
    }
}

