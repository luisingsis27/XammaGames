using System;
using Xamarin.Forms;
using XammaGames.Views;

namespace XammaGames
{
	public class DetailMenuVM:BaseViewModel
	{
		public DetailMenuVM(string user)
		{
			btnSalir = new Command(ActionSalir);
			Usuario = user;
		}
		public DetailMenuVM()
		{
			btnSalir = new Command(ActionSalir);

		}
		void ActionSalir()
		{

			Application.Current.MainPage = new PageLogin();
		}
		protected Command _LogOut;

		public Command btnSalir
		{
			get { return _LogOut; }
			set
			{
				_LogOut = value;
				OnPropertyChanged(nameof(btnSalir));
			}
		}
		protected string _Usuario;

		public string Usuario
		{
			get { return _Usuario; }
			set
			{
				_Usuario = value;
				OnPropertyChanged(nameof(Usuario));

			}
		}

	}
}

