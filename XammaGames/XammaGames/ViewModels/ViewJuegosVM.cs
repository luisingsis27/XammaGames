using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XammaGames
{
	public class ViewJuegosVM:BaseViewModel
	{
		Page nuevoJuego;
		public string SelectedItemText { get; private set; }
		public ICommand OutputAgeCommand { get; private set; }

		public ViewJuegosVM(Page NuevoJuego)
		{
			nuevoJuego = NuevoJuego;
			btnAddGame = new Command(ActionAgregarJuegos);
			OutputAgeCommand = new Command<ViewJuegosVM>(OutputAge);
		}

		void OutputAge(ViewJuegosVM viewJuegosVM)
		{
			SelectedItemText = "{0} is {1} years old";
			OnPropertyChanged("SelectedItemText");
		}
	

		void ActionAgregarJuegos()
		{
			nuevoJuego.Navigation.PushModalAsync(new AddGames());
			//Application.Current.MainPage = new AddGames();
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

