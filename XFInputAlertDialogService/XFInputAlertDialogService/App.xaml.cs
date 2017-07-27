using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using XFInputAlertDialogService.Interfaces;
using XFInputAlertDialogService.Services;

namespace XFInputAlertDialogService
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            
            NavigationService.NavigateAsync($"{nameof(Views.MainPage)}");
        }

        protected override void RegisterTypes()
        {
            // pages registration
            Container.RegisterTypeForNavigation<Views.MainPage>();

            // services registration
            Container.RegisterType<IInputAlertDialogService, InputAlertDialogService>();
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
