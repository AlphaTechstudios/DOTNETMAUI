﻿
using DeepLink.Views;

namespace DeepLink;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }

    protected  override void OnAppLinkRequestReceived(Uri uri)
    {
        base.OnAppLinkRequestReceived(uri);

        if((uri.Host.ToLower() == "yourdomain" || uri.Host.ToLower() == "yourdomain.com") && uri.Segments != null && uri.Segments.Length == 3)
        {
            string action = uri.Segments.ElementAt(1).Replace("/", "");
            bool isActionParamsValid = long.TryParse(uri.Segments.ElementAt(2), out long productionId);
            if(action.ToLower() == "productdetails" && isActionParamsValid)
            {
                if(productionId > 0)
                {
                    // Navigate to your productdetails page
                    //Shell.Current.GoToAsync($"//{nameof(NewPage1)}/productionId/{productionId}");
                     Shell.Current.GoToAsync($"{nameof(NewPage1)}/productdetails");
                }
                else
                {
                    Shell.Current.GoToAsync($"{nameof(MainPage)}");
                }
            }


        }
    }
}
