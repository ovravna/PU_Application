using PU_Application.Model;
using PU_Application.ViewModel;

using Xamarin.Forms;

namespace PU_Application.View
{
    public partial class MyItemsPage : ContentPage
    {
        MyItemsViewModel viewModel;
        public MyItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MyItemsViewModel();

            viewModel.OnNavigateToDetails = async (detailsViewModel) =>
            {
                await Navigation.PushAsync(new MyItemsDetailPage(detailsViewModel));
            };

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as MyItem;
            if (item == null)
                return;

            viewModel.EditCommand.Execute(item.Id);

            // Manually deselect item
            ListViewItems.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Items.Count == 0 || MyItemsViewModel.IsDirty)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
