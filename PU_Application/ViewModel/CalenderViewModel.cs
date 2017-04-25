using PU_Application.Helpers;
using PU_Application.Model;
using System;
using System.Linq;
using PU_Application.Data;
using Xamarin.Forms;

namespace PU_Application.ViewModel
{
	public class CalenderViewModel : ViewModelBase
	{
		private ItemDetailViewModel _detailsViewModel;

		public ObservableRangeCollection<Item> Items { get;}
		public ObservableRangeCollection<Item> Monday { get; }
		public ObservableRangeCollection<Item> Tuesday { get; }
		public ObservableRangeCollection<Item> Wednesday { get; }
		public ObservableRangeCollection<Item> Thursday { get; }
		public ObservableRangeCollection<Item> Friday { get; }
		public ObservableRangeCollection<Item> Saturday { get; }
		public ObservableRangeCollection<Item> Sunday { get; }
		public Action<ItemDetailViewModel> OnNavigateToDetails { get; set; }

		public CalenderViewModel()
		{
			Title = "Calender";
			Items = EventParser.Parse(Settings.Username);
			GoToDetailsCommand = new Command<string>(ExecuteGoToDetailsCommand);
		}

		public Command<string> GoToDetailsCommand { get; }
		
		void ExecuteGoToDetailsCommand(string id)
		{
			if (IsBusy)
				return;

			var selectedItem = Items.FirstOrDefault(i => i.Id == id);

			_detailsViewModel = new ItemDetailViewModel(selectedItem);
			_detailsViewModel.OnFinished += OnFinished;

			OnNavigateToDetails(_detailsViewModel);
		}

		void OnFinished(Item item)
		{
			_detailsViewModel.OnFinished -= OnFinished;
		}
	}
}