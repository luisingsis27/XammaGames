using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace XammaGames
{
	public class AddGamesVM:BaseViewModel
	{
        Page pageAddGames;
        public AddGamesVM(Page pageAddGames)
		{
			this.pageAddGames = pageAddGames;
            //NavigationPage.SetHasNavigationBar(pageAddGames, false);
			btnGuardarJuego = new Command(ActionGuardarJuego);
            btnCancelar = new Command(ActionCerrar);
		}

		async void ActionGuardarJuego()
		{
			
			if (!string.IsNullOrWhiteSpace(Nombre))
			{
				if (await CrossConnectivity.Current.IsRemoteReachable("www.google.com"))
				{
					UserDialogs.Instance.ShowLoading("Guardando", MaskType.Gradient);
					IdJuego = (await Conexion.Instance.ObtenerIdJuegos()).ToString();
					bool seGuardo=  await Conexion.Instance.GuardarJuego(IdJuego, Nombre);
					if (seGuardo)
					{
						
						Application.Current.MainPage = new MasterMenu(DetailMenuVM.UsuarioGlobal);
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

        async void ActionCerrar()
        {
            try
            {
               await pageAddGames.Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
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
		protected Command _Cancelar;

		public Command btnCancelar
		{
			get { return _Cancelar; }
			set
			{
				_Cancelar = value;
                OnPropertyChanged(nameof(btnCancelar));
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

