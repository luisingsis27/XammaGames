using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XammaGames
{
	public partial class MasterMenu : MasterDetailPage
	{
		public MasterMenu()
		{
			UserDialogs.Instance.HideLoading();
			InitializeComponent();
		}
	}
}

