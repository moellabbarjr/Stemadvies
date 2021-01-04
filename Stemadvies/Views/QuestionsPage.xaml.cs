using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stemadvies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionsPage : ContentPage
    {
        public QuestionsPage()
        {
            InitializeComponent();
        }

        private async void NavigateButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ResultsPage()));
        }

        private async void PreviousButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ResultsPage()));
        }

        private async void NextButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ResultsPage()));
        }
    }
}