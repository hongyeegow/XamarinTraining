﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTraining.Services;

namespace XamarinTraining
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IFoursquare, Foursquare>();
            MainPage = new NavigationPage(new MainPage());
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
