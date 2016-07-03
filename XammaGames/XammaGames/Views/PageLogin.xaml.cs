using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XammaGames.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLogin : ContentPage
    {
		PageLoginVM pageLoginVM;
        public PageLogin()
        {
            InitializeComponent();
			pageLoginVM = new PageLoginVM(this);
			BindingContext = pageLoginVM;


        }


    }
}
