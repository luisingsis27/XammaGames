using System;
using System.ComponentModel;

namespace XammaGames
{
	public class BaseViewModel:INotifyPropertyChanged
	{
		public BaseViewModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

