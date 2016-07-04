using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace XammaGames
{
	public class AddGamesVM:BaseViewModel
	{
		public AddGamesVM()
		{
			btnGuardarJuego = new Command(ActionGuardarJuego);
		}

		async void ActionGuardarJuego()
		{
			
			if (!string.IsNullOrWhiteSpace(Nombre))
			{
				if (await CrossConnectivity.Current.IsRemoteReachable("www.google.com"))
				{
					Conexion conec = new Conexion();
					UserDialogs.Instance.ShowLoading("Guardando", MaskType.Gradient);
					IdJuego = (await conec.ObtenerIdJuegos()).ToString();
					conec = new Conexion();
					bool seGuardo=  await conec.GuardarJuego(IdJuego, Nombre);
					if (seGuardo)
					{
						
						Application.Current.MainPage = new MasterMenu(Nombre);
					}
					else 
					{
						UserDialogs.Instance.ShowError("No se pudo guardar", 1000);
					}
				}
				else
				{ 
				UserDialogs.Instance.HideLoading();
					UserDialogs.Instance.ShowError("Verifique usuario o contraseña", 1000);
				}
			}
			else
			{ 
				UserDialogs.Instance.ShowError("Ingrese nombre del juego", 1000);
			}

		}
		protected Command _GuardarJuego;

		public Command btnGuardarJuego
		{
			get { return _GuardarJuego; }
			set
			{
				_GuardarJuego = value;
				OnPropertyChanged(nameof(btnGuardarJuego));
			}
		}

		protected string _IdJuego;

		public string IdJuego
		{
			get { return _IdJuego; }
			set
			{
				_IdJuego = value;
				OnPropertyChanged(nameof(IdJuego));

			}
		}

		protected string _Nombre;

		public string Nombre
		{
			get { return _Nombre; }
			set
			{
				_Nombre = value;
				OnPropertyChanged(nameof(Nombre));

			}
		}
	}
	public class AddJuegosListVM
	{
		public ObservableCollection<AddGamesVM> results { get; set; }
	}
}

