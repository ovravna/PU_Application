using PU_Application.Helpers;
using PU_Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PU_Application.ViewModel
{
	public class ItemDetailViewModel : ViewModelBase
	{
		public Action<Item> OnFinished { get; set; }
		public Action<WebViewViewModel> OnNavigateToWebView { get; set; }
		public Item Item { get; set; }
		public ObservableRangeCollection<Item> Items { get; }
		public ItemDetailViewModel(Item item)
		{
			Title = item.Text;
			Item = item;
			Items = Droid.Data.IcalParser.Parse();
			SaveCommand = new Command(async () => await ExecuteSaveCommand());
			GoToMazeMapCommand = new Command<string>(ExecuteGoToMazeMapCommand);


		}

		int quantity = 1;
		public int Quantity
		{
			get { return quantity; }
			set { SetProperty(ref quantity, value); }
		}

		public Command<string> GoToMazeMapCommand { get; }
		WebViewViewModel webViewViewModel;
		void ExecuteGoToMazeMapCommand(string id)
		{
			if (IsBusy)
				return;


			if (Item == null)
				return;

			webViewViewModel = new WebViewViewModel(Item);
			webViewViewModel.OnFinished += OnFinished;

			OnNavigateToWebView(webViewViewModel);
		}

		public Command SaveCommand { get; }

		async Task ExecuteSaveCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			var newItem = new MyItem
			{
				Text = Item.Text,
				Description = Item.Description,
				Quantity = Quantity
			};

			try
			{
				if (!Settings.IsLoggedIn)
				{
					if (!await LoginViewModel.TryLoginAsync(StoreManager))
						return;
				}

				await StoreManager.MyItemStore.InsertAsync(newItem);
				MyItemsViewModel.IsDirty = true;

				IsBusy = false;
				OnFinished?.Invoke(Item);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
