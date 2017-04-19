using PU_Application.ViewModel;
using PU_Application.Model;
using Xamarin.Forms;

namespace PU_Application.View
{
	public partial class CalenderPage : ContentPage
	{
	    private readonly CalenderViewModel _viewModel;

		public CalenderPage()
		{
			InitializeComponent();
			BindingContext = _viewModel = new CalenderViewModel();
			_viewModel.OnNavigateToDetails = async detailsViewModel =>
			{
				await Navigation.PushAsync(new DetailPage(detailsViewModel));
			};
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			_viewModel.GoToDetailsCommand.Execute(item.Id);

			// Manually deselect item
			ListViewItems.SelectedItem = null;
		}
	}
}