using PU_Application.Helpers;
using PU_Application.Model;
using System;
using System.Diagnostics;
using System.Linq;
using PU_Application.Data;
using Xamarin.Forms;

namespace PU_Application.ViewModel
{
    public class BrowseItemsViewModel : ViewModelBase
    {
        private ItemDetailViewModel _detailsViewModel;

        public ObservableRangeCollection<Item> Items { get;}
        public Action<ItemDetailViewModel> OnNavigateToDetails { get; set; }
        public BrowseItemsViewModel()
        {
            Title = "Events";
            Items = EventParser.Parse();
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