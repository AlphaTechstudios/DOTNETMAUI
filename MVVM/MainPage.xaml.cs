using MVVM.ViewModels;

namespace MVVM;

public partial class MainPage : ContentPage
{
	
	public MainPage(MainPageViewModel mainPageViewModel)
	{
		InitializeComponent();
		BindingContext = mainPageViewModel;
	}

}


