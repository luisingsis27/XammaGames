using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XammaGames
{
	public partial class ViewPartidos : ContentPage
	{
		public ViewPartidos()
		{
			InitializeComponent();
			List<string> adds = new List<string>();
			for (var i = 0; i < 20; i++)
			{
				adds.Add(i.ToString());

			}
			listViewPartidos.ItemsSource = adds;
		}
	}
}

