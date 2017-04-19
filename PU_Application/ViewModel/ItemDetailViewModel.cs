using PU_Application.Helpers;
using PU_Application.Model;
using System;
using Xamarin.Forms;

namespace PU_Application.ViewModel
{
	public class ItemDetailViewModel : ViewModelBase
	{
        private WebViewViewModel _webViewViewModel;
        private int _quantity = 1;

		public Action<Item> OnFinished { get; set; }
		public Action<WebViewViewModel> OnNavigateToWebView { get; set; }
		public Item Item { get; set; }
		public ObservableRangeCollection<Item> Items { get; }

		public ItemDetailViewModel(Item item)
		{
			Title = item.Text;
			Item = item;
			Items = Droid.Data.IcalParser.Parse();

			GoToMazeMapCommand = new Command<string>(ExecuteGoToMazeMapCommand);
		}

		public int Quantity
		{
			get => _quantity;
			set => SetProperty(ref _quantity, value);
		}

		public Command<string> GoToMazeMapCommand { get; }

		void ExecuteGoToMazeMapCommand(string id)
		{
			if (IsBusy)
				return;


			if (Item == null)
				return;

			_webViewViewModel = new WebViewViewModel(Item);
			_webViewViewModel.OnFinished += OnFinished;

			OnNavigateToWebView(_webViewViewModel);
		}
	}
}
