using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XammaGames
{
	public partial class ViewPartidos : ContentPage
	{
		ViewPartidosVM viewPartidosVM;
		public ViewPartidos(string idJuegos)
		{
			InitializeComponent();
			viewPartidosVM = new ViewPartidosVM(idJuegos,this);
			this.BindingContext = viewPartidosVM;
			listViewPartidos.ItemsSource = viewPartidosVM.cargarPartidos();


		}
	}
}

