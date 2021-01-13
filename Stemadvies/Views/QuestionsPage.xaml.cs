using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;

namespace Stemadvies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionsPage : ContentPage
    {
        int questionIndex = 0;

        public QuestionsPage()
        {
            InitializeComponent();
            GetQuestion();
        }

        public async void GetQuestion()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://192.168.2.13/?table=vraag");
            var question = JsonConvert.DeserializeObject<List <Question> > (response);
            titleText.Text = $"Vraag {questionIndex + 1} van de {question.Count}";
            questionText.Text = question[questionIndex].vraag;
        }

        private async void NavigateButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ResultsPage()));
        }

        private void PreviousButton(object sender, EventArgs e)
        {
            questionIndex--;
            GetQuestion();
        }

        private void NextButton(object sender, EventArgs e)
        {
            questionIndex++;
            GetQuestion();
        }
    }
}