using System;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XammaGames;
using XammaGames.iOS.Renders;

[assembly: ExportRenderer(typeof(AddGames), typeof(BackNavigationRender))]
namespace XammaGames.iOS.Renders
{
	public class BackNavigationRender : PageRenderer
	{
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			// Create the material drop shadow
			NavigationController.NavigationBar.Layer.ShadowColor = UIColor.Black.CGColor;
			NavigationController.NavigationBar.Layer.ShadowOffset = new CGSize(0, 0);
			NavigationController.NavigationBar.Layer.ShadowRadius = 10;
			NavigationController.NavigationBar.Layer.ShadowOpacity = 1;

			// Create the back arrow icon image
			//var arrowImage = UIImage.FromBundle("Icons/ic_arrow_back_white.png");
			//NavigationController.NavigationBar.BackIndicatorImage = arrowImage;
			//NavigationController.NavigationBar.BackIndicatorTransitionMaskImage = arrowImage;

            UIBarButtonItem back = new UIBarButtonItem(UIBarButtonSystemItem.Action, null);
            //NavigationItem.LeftBarButtonItem = back;
            NavigationItem.BackBarButtonItem = back;
			// Set the back button title to empty since Material Design doesn't use it.
			if (NavigationItem?.BackBarButtonItem != null)
				NavigationItem.BackBarButtonItem.Title = "hola render ";
			if (NavigationController.NavigationBar.BackItem != null)
			{
				NavigationController.NavigationBar.BackItem.Title = " ";
				//NavigationController.NavigationBar.BackItem.BackBarButtonItem.Image = arrowImage;
			}
        }

      	
    }
}
