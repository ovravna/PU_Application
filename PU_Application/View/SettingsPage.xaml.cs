using PU_Application.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PU_Application.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();

		    BindingContext = new SettingsViewModel();
		}
	}
}