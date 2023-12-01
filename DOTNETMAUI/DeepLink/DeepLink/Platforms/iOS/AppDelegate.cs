using Foundation;
using UIKit;

namespace DeepLink;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool OpenUrl(UIApplication application, NSUrl url, NSDictionary options)
    {
        Microsoft.Maui.Controls.Application.Current.SendOnAppLinkRequestReceived(url.AbsoluteUrl);
        return true;
    }
} 


