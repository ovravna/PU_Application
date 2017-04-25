using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace PU_Application.View
{
	public partial class RootMasterPage : ContentPage
	{
		public ListView ListView => ListViewMenuItems;


		public RootMasterPage ()
		{
			InitializeComponent ();
			BindingContext = new MasterViewModel();
		}
	}

	class MasterMenuItem
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public Type TargetType { get; set; }
	}

	class MasterViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<MasterMenuItem> MenuItems { get; }
		public MasterViewModel()
		{
			MenuItems = new ObservableCollection<MasterMenuItem>(new[]
			{
					new MasterMenuItem { Id = 0, Title = "Events", TargetType = typeof(BrowseItemsPage) },
					new MasterMenuItem { Id = 1, Title = "Calender", TargetType = typeof(CalenderPage) },
					new MasterMenuItem { Id = 2, Title = "Settings", TargetType = typeof(SettingsPage) }
			});
		}

		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}