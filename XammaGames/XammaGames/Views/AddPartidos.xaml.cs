using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XammaGames
{
	public partial class AddPartidos : ContentPage
	{
		AddPartidosVM addPartidosVM;
		public AddPartidos()
		{
			InitializeComponent();
			addPartidosVM = new AddPartidosVM();
			BindingContext = addPartidosVM;
		}
	}
}

