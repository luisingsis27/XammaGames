using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XammaGames
{
	public partial class ViewJuegos : ContentPage
	{
		ViewJuegosVM viewJuegosVM;

		public ViewJuegos()
		{
			InitializeComponent();
			viewJuegosVM = new  ViewJuegosVM(this);
			this.BindingContext = viewJuegosVM;
			cargarListView();

		}
		public async void cargarListView()
		{ 
			Conexion conect = new Conexion();
			var slistJuegos =  await conect.ObtenerJuegos(); 
			//var slistJuegos = await conect.ObtenerJuegos(); 
			listViewJuegos.ItemsSource = slistJuegos;
		}
	}
}

