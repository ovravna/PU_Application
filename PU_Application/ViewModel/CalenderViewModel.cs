﻿using PU_Application.Helpers;
using PU_Application.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PU_Application.Data;
using PU_Application.Droid.Data;
using Xamarin.Forms;


namespace PU_Application.ViewModel
{
	public class CalenderViewModel : ViewModelBase
	{
		public ObservableRangeCollection<Item> Items { get;}
		public IEnumerable<Item> Monday { get; }
		public IEnumerable<Item> Tuesday { get; }
		public IEnumerable<Item> Wednesday { get; }
		public IEnumerable<Item> Thursday { get; }
		public IEnumerable<Item> Friday { get; set; }
		public IEnumerable<Item> Saturday { get; }
		public IEnumerable<Item> Sunday { get; }
		public Action<ItemDetailViewModel> OnNavigateToDetails { get; set; }
		public CalenderViewModel()
		{
			Title = "Calender";
			Items = EventParser.Parse();
			int i = 0;

		    Monday = Items.Where(n => n.Date.DayOfWeek == DayOfWeek.Monday);
		    Tuesday = Items.Where(n => n.Date.DayOfWeek == DayOfWeek.Tuesday);
		    Wednesday = Items.Where(n => n.Date.DayOfWeek == DayOfWeek.Wednesday);
		    Thursday = Items.Where(n => n.Date.DayOfWeek == DayOfWeek.Thursday);
		    Friday = Items.Where(n => n.Date.DayOfWeek == DayOfWeek.Friday);
		    Saturday = Items.Where(n => n.Date.DayOfWeek == DayOfWeek.Saturday);
		    Sunday = Items.Where(n => n.Date.DayOfWeek == DayOfWeek.Sunday);


		    GoToDetailsCommand = new Command<string>(ExecuteGoToDetailsCommand);
		}

		public Command LoadItemsCommand { get; }

		async void ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			try
			{
				Items.Clear();
				var items = await StoreManager.ItemStore.GetItemsAsync(true);
				var i = 0;
				Items.ReplaceRange(items);
//				foreach (Item item in Items)
//				{
//					if (item.Day.Equals("mandag"))
//						Monday.Add(item);
//					if (item.Day.Equals("tirsdag"))
//						Tuesday.Add(item);
//					if (item.Day.Equals("onsdag"))
//						Wednesday.Add(item);
//					if (item.Day.Equals("torsdag"))
//						Thursday.Add(item);
//					if (item.Day == "fredag")
////						Friday.Add(item);
//					if (item.Day.Equals("lørdag"))
//						Saturday.Add(item);
//					if (item.Day.Equals("søndag"))
//						Sunday.Add(item);
//					if (i > 5)
//						break;
//				}
			}
			catch (Exception ex)
			{
				//Handle exception here
				Debug.WriteLine(ex);
				MessagingCenter.Send(new MessagingCenterAlert
				{
					Title = "Error",
					Message = "Unable to load items.",
					Cancel = "OK"
				}, "message");
			}
			finally
			{
				IsBusy = false;
			}
		}


		public Command<string> GoToDetailsCommand { get; }
		ItemDetailViewModel detailsViewModel;
		void ExecuteGoToDetailsCommand(string id)
		{
			if (IsBusy)
				return;

			var selectedItem = Items.FirstOrDefault(i => i.Id == id);

			detailsViewModel = new ItemDetailViewModel(selectedItem);
			detailsViewModel.OnFinished += OnFinished;

			OnNavigateToDetails(detailsViewModel);
		}

		void OnFinished(Item item)
		{
			detailsViewModel.OnFinished -= OnFinished;
		}

	}
}
