using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XammaGames
{
	public class ViewJuegosVM:BaseViewModel
	{
		Page nuevoJuego;
	
	

		public ViewJuegosVM(Page NuevoJuego)
		{
			nuevoJuego = NuevoJuego;
			btnAddGame = new Command(ActionAgregarJuegos);
			cargarJuegos();
		}
		public async void cargarJuegos()
		{
			Conexion conect = new Conexion();
			Results = await conect.ObtenerJuegos();
		}


		void ActionAgregarJuegos()
		{
			nuevoJuego.Navigation.PushModalAsync(new AddGames());
			//Application.Current.MainPage = new AddGames();
		}
		protected ObservableCollection<ViewJuegosVM> _Results;
		public ObservableCollection<ViewJuegosVM> Results
		{
			get { return _Results; }
			set
			{
				_Results = value;
				OnPropertyChanged(nameof(Results));

			}

		}

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


	}

	public class JuegosListVM
	{
		public ObservableCollection<ViewJuegosVM> results { get; set; }
	}
}

