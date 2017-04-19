using System;
using PU_Application.ViewModel;
using Xamarin.Forms;

namespace PU_Application.View
{
	public partial class MazeMapPage : ContentPage
	{
		public MazeMapPage(WebViewViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
			Browser.Source = viewModel.MazeUrl();
		}

		private void BackClicked(object sender, EventArgs e)
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

		private void ForwardClicked(object sender, EventArgs e)
		{
			if (Browser.CanGoForward)
			{
				Browser.GoForward();
			}
		}
	}
}