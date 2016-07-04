using System;
using Xamarin.Forms;

namespace XammaGames
{
	public class MasterViewVM
	{
		public delegate void ChangeViewMasterEventHandler(Page page);

		MasterDetailPage MenuMaster;
		public MasterViewVM(MasterDetailPage menuMaster)
		{
			MenuMaster = menuMaster;
			CambiarDetail(new ViewJuegos());
			//ViewPartidosVM view = new ViewPartidosVM();
			//view.ChangeViewMasterEvent += CambiarDetail(
		}

		void CambiarDetail(Page page)
		{
			
			MenuMaster.Detail=new NavigationPage(page);
		}


	}
}

