﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Stemadvies.Services;
using Stemadvies.Views;

namespace Stemadvies
{
    public partial class App : Application
    {

        public App()
        {
            Device.SetFlags(new string[] { "RadioButton_Experimental" });

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
