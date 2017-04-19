//#define FlyoutNavigation

using PU_Application.Helpers;
using PU_Application.Interfaces;
using PU_Application.View;

#if AZURE
using Microsoft.Identity.Client;
#endif
using System.Collections.Generic;
using Xamarin.Forms;

namespace PU_Application
{
    public partial class App : Application
    {
        public App()
        {
            // Loads all reasources from App.xaml
            InitializeComponent();
        }

        protected override void OnStart()
        {
            MainPage = new RootMasterDetailPage();

            MessagingCenter.Subscribe<MessagingCenterAlert>(this, "message", async info =>
            {
                var task = Current?.MainPage?.DisplayAlert(info.Title, info.Message, info.Cancel);

                if (task == null)
                    return;

                await task;
                info.OnCompleted?.Invoke();
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
 
