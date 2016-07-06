using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace XammaGames
{
	public partial class ViewJuegos : ContentPage
	{
		ViewJuegosVM viewJuegosVM;

		public ViewJuegos()
		{
			InitializeComponent();
			viewJuegosVM = new ViewJuegosVM(this);
			this.BindingContext = viewJuegosVM;
			listViewJuegos.ItemsSource = viewJuegosVM.cargarJuegos();

			listViewJuegos.ItemTapped += (sender, e) =>
			{
				
				(BindingContext as ViewJuegosVM).ActionVerPartidos((((ListView)sender).SelectedItem as ViewJuegosVM).IdJuego);
			};

		}


	
	}
}

