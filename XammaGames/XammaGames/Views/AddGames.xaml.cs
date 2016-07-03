using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XammaGames
{
	public partial class AddGames : ContentPage
	{
		AddGamesVM addGamesVM;
		public AddGames()
		{
			InitializeComponent();
			addGamesVM = new AddGamesVM();
			BindingContext = addGamesVM;
		}
	}
}

