using Android.App;
using Android.Content.PM;
using Android.OS;

namespace OpenPDF;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
    {
        if (permissions.ToList().Where(x => x == "WRITE_MEDIA_STORAGE") != null)
        {
            var grants = new Permission[] { Permission.Granted };
            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grants);
            base.OnRequestPermissionsResult(requestCode, permissions, grants);

        }
        else
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
