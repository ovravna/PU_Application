using PU_Application.Helpers;

namespace PU_Application.ViewModel
{
    public class ViewModelBase : ObservableObject
    {
        private bool _isBusy = false;
        private string _title = string.Empty;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}