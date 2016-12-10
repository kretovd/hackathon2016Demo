﻿using Feedback.UI.Core.Views.Places;
using Xamarin.Forms;

namespace Feedback.UI.Core
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            ServiceLocator.Initialize();
            MainPage = new NavigationPage(new PlacesPage());
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