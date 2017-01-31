using PU_Application.Model;
using PU_Application.ViewModel;

using Xamarin.Forms;

namespace PU_Application.View
{
    public partial class DetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public DetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

            this.viewModel.OnFinished += OnFinished;
        }

        async void OnFinished(Item item)
        {
            viewModel.OnFinished -= OnFinished;
            await Navigation.PopAsync();
        }
    }
}
