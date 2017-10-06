using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XammaGames
{
	public partial class MasterMenu : MasterDetailPage
    {

		MasterViewVM masterViewVM;
		DetailMenuVM detail;
		public MasterMenu(string Usuario)
		{
			UserDialogs.Instance.HideLoading();
			InitializeComponent();
			masterViewVM = new MasterViewVM(this);
			BindingContext = masterViewVM;
			detail = new DetailMenuVM(Usuario);
			detailMenu.BindingContext = detail;
		}
	}
}

