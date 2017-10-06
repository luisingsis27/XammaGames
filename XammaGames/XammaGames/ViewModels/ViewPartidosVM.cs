using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace XammaGames
{
	public class ViewPartidosVM:BaseViewModel
	{
		public event MasterViewVM.ChangeViewMasterEventHandler ChangeViewMasterEvent;
		string idJuego;
		Page _pagePartidos;
		public ViewPartidosVM(string idjuegonuevo,Page pagePartidos)
		{
			_pagePartidos = pagePartidos;
			idJuego = idjuegonuevo;
			btnAddPartido = new Command(ActionAgregarPartidos);
		}
		void ActionAgregarPartidos()
		{
			_pagePartidos.Navigation.PushModalAsync(new AddPartidos());
			//Application.Current.MainPage = new AddGames();
		}

		public async Task<ObservableCollection<ViewPartidosVM>> CargarPartidos()
		{
            var resp = await Conexion.Instance.ObtenerPartidos(idJuego);

            return resp;
		}

		#region Propiedades

		protected Command _AddPartido;

		public Command btnAddPartido
		{
			get { return _AddPartido; }
			set
			{
				_AddPartido = value;
				OnPropertyChanged(nameof(btnAddPartido));
			}
		}



		protected string _IdPartido;

		public string IdPartido
		{
			get { return _IdPartido; }
			set
			{
				_IdPartido = value;
				OnPropertyChanged(nameof(IdPartido));

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

		protected string _NameJuego;

		public string NameJuego
		{
			get { return _NameJuego; }
			set
			{
				_NameJuego = value;
				OnPropertyChanged(nameof(NameJuego));

			}
		}
		protected string _IdUsuario1;
		public string IdUsuario1
		{
			get { return _IdUsuario1; }
			set
			{
				_IdUsuario1 = value;
				OnPropertyChanged(nameof(IdUsuario1));

			}
		}

		protected string _Score1;

		public string Score1
		{
			get { return _Score1; }
			set
			{
				_Score1 = value;
				OnPropertyChanged(nameof(Score1));

			}
		}

		protected string _Usuario1;

		public string Usuario1
		{
			get { return _Usuario1; }
			set
			{
				_Usuario1 = value;
				OnPropertyChanged(nameof(Usuario1));

			}
		}

		protected string _IdUsuario2;
		public string IdUsuario2
		{
			get { return _IdUsuario2; }
			set
			{
				_IdUsuario2 = value;
				OnPropertyChanged(nameof(IdUsuario2));

			}
		}
		protected string _Score2;

		public string Score2
		{
			get { return _Score2; }
			set
			{
				_Score2 = value;
				OnPropertyChanged(nameof(Score2));

			}
		}

		protected string _Usuario2;

		public string Usuario2
		{
			get { return _Usuario2; }
			set
			{
				_Usuario2 = value;
				OnPropertyChanged(nameof(Usuario2));

			}
		}

		protected Color _Color1;

		public Color Color1
		{
			get { return _Color1; }
			set
			{
				_Color1 = value;
				//OnPropertyChanged(nameof(Color));

			}
		}
		protected Color _Color2;

		public Color Color2
		{
			get { return _Color2; }
			set
			{
				_Color2 = value;
				//OnPropertyChanged(nameof(Color));

			}
		}
		#endregion

	}
	public class PartidosListVM
	{
		public ObservableCollection<ViewPartidosVM> results { get; set; }
	}
}

