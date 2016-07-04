using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XammaGames
{
	public partial class DetailMenu : ContentPage
	{
		DetailMenuVM detailtMenuVM;
		public DetailMenu()
		{
			InitializeComponent();
			detailtMenuVM = new DetailMenuVM();
			BindingContext = detailtMenuVM;

		}
	}
}

