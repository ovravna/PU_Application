using PU_Application.Model;
using PU_Application.ViewModel;
using Xamarin.Forms;

namespace PU_Application.View
{
	public partial class DetailPage : ContentPage
	{
	    private readonly ItemDetailViewModel _viewModel;

		public DetailPage(ItemDetailViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = _viewModel = viewModel;

			viewModel.OnNavigateToWebView = async webViewViewModel =>
			{
				await Navigation.PushAsync(new MazeMapPage(webViewViewModel));
			};
			_viewModel.OnFinished += OnFinished;
		}

		private async void OnFinished(Item item)
		{
			_viewModel.OnFinished -= OnFinished;
			await Navigation.PopAsync();
		}
	}
}