using DeepLink.Views;

namespace DeepLink;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute($"{nameof(NewPage1)}/productdetails", typeof(NewPage1));
	}
}

