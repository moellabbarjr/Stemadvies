using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stemadvies.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void NavigateButton(object sender, EventArgs e)
        {
            await DisplayAlert("ok", "ok", "ok");
            //await Navigation.PushModalAsync(new NavigationPage(new ResultsPage()));
        }
    }
}