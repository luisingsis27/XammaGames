using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using Plugin.Connectivity;
using Xamarin.Forms;
using XammaGames.Views;

namespace XammaGames
{
	public class RegistrarUsuarioVM:BaseViewModel
	{
		
		public RegistrarUsuarioVM()
		{
			

			btnGuardarUsuario =  new Command(GuardarUsuarioBoton);
		}

	
		async void GuardarUsuarioBoton()
		{
			if (!string.IsNullOrWhiteSpace(Usuario) || !string.IsNullOrWhiteSpace(Password))
			{

				if (await CrossConnectivity.Current.IsRemoteReachable("www.google.com"))
				{
				
					UserDialogs.Instance.ShowLoading("Guardando", MaskType.Gradient);
					if (!await Conexion.Instance.VerificarUsuario(Usuario))
					{
						IdUsuario = (await Conexion.Instance.ObtenerIdUsuario()).ToString();
						bool seGuardo = await Conexion.Instance.GuardarUsurio(IdUsuario, Usuario, Password);

						if (seGuardo)
						{
							Application.Current.MainPage = new PageLogin();
						}
						else
						{
							UserDialogs.Instance.ShowError("No se pudo guardar", 1000);
						}
					}
					else
					{

						UserDialogs.Instance.ShowError("Este usuario ya existe", 1000);
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


		protected Command _GuardarUsuario;

		public Command btnGuardarUsuario
		{
			get { return _GuardarUsuario; }
			set
			{
				_GuardarUsuario = value;
				OnPropertyChanged(nameof(btnGuardarUsuario));
			}
		}
		protected string _IdUsuario;

		public string IdUsuario
		{
			get { return _IdUsuario; }
			set
			{
				_IdUsuario = value;
				OnPropertyChanged(nameof(IdUsuario));

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

	public class RegistrarUsuarioListVM
	{
		public ObservableCollection<RegistrarUsuarioVM> results { get; set; }
	}



}

