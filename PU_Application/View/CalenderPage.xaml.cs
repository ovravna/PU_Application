using System;
using System.Collections.Generic;
using PU_Application.ViewModel;
using PU_Application.Model;

using Xamarin.Forms;

namespace PU_Application.View
{
	public partial class CalenderPage : ContentPage
	{
		CalenderViewModel viewModel;
		public CalenderPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new CalenderViewModel();
			viewModel.OnNavigateToDetails = async (detailsViewModel) =>
			{
				await Navigation.PushAsync(new DetailPage(detailsViewModel));
			};

		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			viewModel.GoToDetailsCommand.Execute(item.Id);

			// Manually deselect item
			ListViewItems.SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}

	}
}
