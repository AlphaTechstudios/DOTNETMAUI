using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{

		public BaseViewModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChnaged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
		{
			if(EqualityComparer<T>.Default.Equals(property, value))
			{
				return false;
			}
			property = value;
			RaisePropertyChnaged(propertyName);
			return true;
		}
    }
}

