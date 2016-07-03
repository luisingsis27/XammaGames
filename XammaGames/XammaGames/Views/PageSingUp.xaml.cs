using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XammaGames
{
	public partial class PageSingUp : ContentPage
	{
		RegistrarUsuarioVM registrarUsuarioVM;
		public PageSingUp()
		{
			
			InitializeComponent();

			registrarUsuarioVM = new RegistrarUsuarioVM();
			BindingContext = registrarUsuarioVM;
		}
	}
}

