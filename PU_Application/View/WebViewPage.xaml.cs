using System;
using System.Collections.Generic;
using PU_Application.Model;
using PU_Application.ViewModel;

using Xamarin.Forms;

namespace PU_Application.View
{
	public partial class WebViewPage : ContentPage
	{

		WebViewViewModel viewModel;
		public WebViewPage(WebViewViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = this.viewModel = viewModel;
			Browser.Source = viewModel.MazeUrl();
			//Browser.Source = "https://use.mazemap.com/?v=1&campusid=1&left=10.3800201&right=10.4280424&top=63.4249667&bottom=63.4100644";
		}

		private void backClicked(object sender, EventArgs e)
		{
			// Check to see if there is anywhere to go back to
			if (Browser.CanGoBack)
			{
				Browser.GoBack();
			}
			else
			{ // If not, leave the view
				Navigation.PopAsync();
			}
		}

		private void forwardClicked(object sender, EventArgs e)
		{
			if (Browser.CanGoForward)
			{
				Browser.GoForward();
			}
		}
	}
}



