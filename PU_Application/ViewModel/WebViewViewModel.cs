using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.OS;
using Android.Util;
using PU_Application.Helpers;
using PU_Application.Model;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

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
		public String MazeUrl()
		{
            Android.Util.Log.WriteLine(LogPriority.Debug, "URL", Item.MazeUrl);
			return Item.MazeUrl;
		}

}
}

