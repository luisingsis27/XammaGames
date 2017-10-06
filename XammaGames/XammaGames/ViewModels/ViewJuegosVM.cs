using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace XammaGames
{
	public class ViewJuegosVM:BaseViewModel
	{
		Page nuevoJuego;
		public event MasterViewVM.ChangeViewMasterEventHandler ChangeViewMasterEvent;

		#region Constructores
		public ViewJuegosVM(Page NuevoJuego)
		{
			nuevoJuego = NuevoJuego;
			btnAddGame = new Command(ActionAgregarJuegos);

		}

		#endregion

		#region Metodos
		public  ObservableCollection<ViewJuegosVM> cargarJuegos()
		{

			//ObservableCollection<ViewJuegosVM> Results = new ObservableCollection<ViewJuegosVM>();
			var Results =  Conexion.Instance.ObtenerJuegos();
			return Results.Result;
		}
		void ActionAgregarJuegos()
		{
            //Application.Current.MainPage = new AddGames();

            nuevoJuego.Navigation.PushModalAsync(new NavigationPage(new AddGames())
            {
                BarBackgroundColor = Color.FromHex("#56427F")
            });
           


		}
		public void ActionVerPartidos(string idjuego)
		{
			//ChangeViewMasterEvent?.Invoke(new ViewPartidos());
			//Application.Current.MainPage = new NavigationPage (new ViewPartidos(idjuego));

			nuevoJuego.Navigation.PushModalAsync(new NavigationPage(new ViewPartidos(idjuego))
			{
				BarBackgroundColor = Color.FromHex("#56427F")
			});
		}
		#endregion

		#region Propiedades
		//protected ObservableCollection<ViewJuegosVM> _Results;
		//public ObservableCollection<ViewJuegosVM> Results
		//{
		//	get { return _Results; }
		//	set
		//	{
		//		_Results = value;
		//		OnPropertyChanged(nameof(Results));

		//	}

		//}

		protected Command _AddGame;

		public Command btnAddGame
		{
			get { return _AddGame; }
			set
			{
				_AddGame = value;
				OnPropertyChanged(nameof(btnAddGame));
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
		#endregion

	}

	public class JuegosListVM
	{
		public ObservableCollection<ViewJuegosVM> results { get; set; }
	}
}

