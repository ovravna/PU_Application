using System;
using PU_Application.Helpers;
using PU_Application.Model;

namespace PU_Application.ViewModel
{
    public class WebViewViewModel : ViewModelBase
    {
        public Item Item { get; set; }
        public Action<Item> OnFinished { get; set; }
        public ObservableRangeCollection<Item> Items { get; }
        public WebViewViewModel(Item item)
        {
            Title = item.Text;
            Item = item;
            Items = Droid.Data.IcalParser.Parse();
        }

        public string MazeUrl()
        {
            return Item.MazeUrl;
        }
    }
}