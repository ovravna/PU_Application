using PU_Application.Model;
using PU_Application.ViewModel;
using Xamarin.Forms;

namespace PU_Application.View
{
    public partial class BrowseItemsPage : ContentPage
    {
        private readonly BrowseItemsViewModel _viewModel;

        public BrowseItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BrowseItemsViewModel();
            _viewModel.OnNavigateToDetails = async (detailsViewModel) =>
            {
                await Navigation.PushAsync(new DetailPage(detailsViewModel));
            };
            
        }

        void OnItemSelected (object sender, SelectedItemChangedEventArgs args)
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