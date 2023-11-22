using System;
using System.Windows.Input;

namespace MVVM.ViewModels
{
	public class MainPageViewModel: BaseViewModel
	{
		private int count;
		public int Count
		{
			get => count;
			set => SetProperty(ref count, value);
		}

		public ICommand OnClickCommand { get; private set; }

		public MainPageViewModel()
		{
			OnClickCommand = new Command(execute:()=> OnCounterClicked());
		}

        void OnCounterClicked()
        {
            Count++;
        }
    }
}

