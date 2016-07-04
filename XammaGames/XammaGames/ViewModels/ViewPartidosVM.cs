using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace XammaGames
{
	public class ViewPartidosVM:BaseViewModel
	{
		public event MasterViewVM.ChangeViewMasterEventHandler ChangeViewMasterEvent;
		string idJuego;
		public ViewPartidosVM(string idjuegonuevo)
		{
			idJuego = idjuegonuevo;
		}
		public ObservableCollection<ViewPartidosVM> cargarPartidos()
		{

			Conexion conect = new Conexion();
			//ObservableCollection<ViewJuegosVM> Results = new ObservableCollection<ViewJuegosVM>();
			var Results = conect.ObtenerPartidos();
			//foreach (var item in Results.Result)
			//{
			//	var nombreJuego = conect.ObtenerNombreJuego(item.IdJuego);
			//	item.NameJuego = nombreJuego.ToString();
			//	var usuario1 = conect.ObtenerNombreJugador(item.IdUsuario1);
			//	item.Usuario1 = usuario1.ToString();
			//	var usuario2 = conect.ObtenerNombreJugador(item.IdUsuario2);
			//	item.Usuario2 = usuario2.ToString();


			//}
			return new ObservableCollection<ViewPartidosVM>( Results.Result.Where(item => item.IdJuego == idJuego).ToList()); 
		}

		#region Propiedades
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
		#endregion

	}
	public class PartidosListVM
	{
		public ObservableCollection<ViewPartidosVM> results { get; set; }
	}
}

