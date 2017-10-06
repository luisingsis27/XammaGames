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
			BindingContext = viewPartidosVM;
            viewPartidosVM.CargarPartidos()
            .ContinueWith((x)=>
            {
                if (x?.Result != null)
                {
                    Device.BeginInvokeOnMainThread(()=> {
                        listViewPartidos.ItemsSource = x.Result;
                    });
                }
            });
		}
	}
}

