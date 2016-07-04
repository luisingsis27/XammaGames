using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace XammaGames
{
	public class PageLoginVM:BaseViewModel 
	{
		Page paageRegistro;

		public PageLoginVM(Page frompage)
		{
			paageRegistro = frompage;
			UserDialogs.Instance.HideLoading();
			btnLogin = new Command(ActionLogueo);
			btnRegistrate = new Command(ActionAgregarUsuario);

		}

		void ActionAgregarUsuario()
		{
			paageRegistro.Navigation.PushModalAsync(new PageSingUp());
		}

		async void ActionLogueo()
		{
			if (!string.IsNullOrWhiteSpace(Usuario) || !string.IsNullOrWhiteSpace(Password))
			{
				
				if (await CrossConnectivity.Current.IsRemoteReachable("www.google.com"))
				{
					Conexion conec = new Conexion();
					UserDialogs.Instance.ShowLoading("Cargando", MaskType.Gradient);
					List<Usuarios> listUsuario = await conec.login(Usuario.Trim(), Password.Trim());
					if (listUsuario.Count == 1)
					{
						Application.Current.MainPage = new MasterMenu(Usuario);
					}
					else
					{
						UserDialogs.Instance.HideLoading();
						UserDialogs.Instance.ShowError("Verifique usuario o contraseña", 1000);
					}
				}
				else { 
						UserDialogs.Instance.ShowError("Verifique su conexion a internet", 1000);
				}
			}
			else
			{
				UserDialogs.Instance.ShowError("Ingrese usuario y contraseña", 1000);
			}
		}

		protected Command _Registrarse;

		public Command btnRegistrate
		{
			get { return _Registrarse; }
			set
			{
				_Registrarse = value;
				OnPropertyChanged(nameof(btnRegistrate));
			}
		}

		protected Command _Logueo;

		public Command btnLogin
		{
			get { return _Logueo; }
			set
			{
				_Logueo = value;
				OnPropertyChanged(nameof(btnLogin));
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
		protected string _Password;

		public string Password
		{
			get { return _Password; }
			set
			{
				_Password = value;
				OnPropertyChanged(nameof(Password));

			}
		}
	}
}

