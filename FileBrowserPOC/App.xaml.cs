using System;
using Xamarin.Forms;
using FileBrowserPOC.View;
using Xamarin.Forms.Xaml;

namespace FileBrowserPOC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FileBrowserPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
