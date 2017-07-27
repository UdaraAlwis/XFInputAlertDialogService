using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Unity;
using Xamarin.Forms;

namespace XFInputAlertDialogService
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            
            NavigationService.NavigateAsync($"{nameof(MainPage)}");
        }

        protected override void RegisterTypes()
        {

        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
