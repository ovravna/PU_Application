using PU_Application.Helpers;
using PU_Application.Model;
using System;
using System.Linq;
using PU_Application.Data;
using Xamarin.Forms;

namespace PU_Application.ViewModel
{
    public class BrowseItemsViewModel : ViewModelBase
    {
        private ItemDetailViewModel _detailsViewModel;
        private EventItemViewModel _selectedItem;

        public BrowseItemsViewModel()
        {
            Title = "Events";
            Items = new ObservableRangeCollection<EventItemViewModel>(EventParser.Parse().Select(e => new EventItemViewModel(e)));
            GoToDetailsCommand = new Command<string>(ExecuteGoToDetailsCommand);
        }

        public ObservableRangeCollection<EventItemViewModel> Items { get; }
        public Action<ItemDetailViewModel> OnNavigateToDetails { get; set; }
        public Command<string> GoToDetailsCommand { get; }

        public EventItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != null) _selectedItem.IsSelected = false;
                SetProperty(ref _selectedItem, value);
                if(value != null) value.IsSelected = true;
            }
        }

        private void ExecuteGoToDetailsCommand(string id)
        {
            if (IsBusy)
                return;

            var selectedItem = Items.FirstOrDefault(i => i.Item.Id == id);

            _detailsViewModel = new ItemDetailViewModel(selectedItem.Item);
            _detailsViewModel.OnFinished += OnFinished;

            OnNavigateToDetails(_detailsViewModel);
        }

        private void OnFinished(Item item)
        {
            _detailsViewModel.OnFinished -= OnFinished;
        }
    }

    public class EventItemViewModel : ObservableObject
    {
        private bool _isSelected;

        public EventItemViewModel(Item item)
        {
            Item = item;
        }

        public Item Item { get; }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}