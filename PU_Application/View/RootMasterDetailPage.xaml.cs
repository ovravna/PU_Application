using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PU_Application.View
{
	public partial class RootMasterDetailPage : MasterDetailPage
	{
	    readonly Dictionary<int, Page> _storedPages;

		public RootMasterDetailPage ()
		{
			InitializeComponent ();
            _storedPages = new Dictionary<int, Page>();
            RootMasterPage.ListView.ItemSelected += ListView_ItemSelected;

            MasterBehavior = MasterBehavior.Popover;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterMenuItem;
            if (item == null)
                return;

            //Allow navigation drawer to close propertly
            IsPresented = false;
            await Task.Delay(230);

            if (_storedPages.ContainsKey(item.Id))
            {
                Detail = _storedPages[item.Id];
            }
            else
            {

                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;
                Page newPage = null;
                Detail = newPage = new NavigationPage(page)
                {
                    BarBackgroundColor = (Color)Application.Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
                _storedPages.Add(item.Id, newPage);
            }

            RootMasterPage.ListView.SelectedItem = null;
        }
    }
}