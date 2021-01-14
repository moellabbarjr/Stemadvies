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
            var response = await httpClient.GetStringAsync("http://535497.student4a8.ao-ica.nl/");
            var question = JsonConvert.DeserializeObject<List <Question> > (response);
            int maxIndex = question.Count - 1;

            // Check of de index niet onder de nul komt en niet boven de maximale index
            questionIndex = (questionIndex < 0) ? 0 : questionIndex;
            questionIndex = (questionIndex > maxIndex) ? maxIndex : questionIndex;

            // Enable en disable buttons op basis van de index
            previousButton.IsEnabled = (questionIndex <= 0) ? false : true;
            nextButton.IsEnabled = (questionIndex >= maxIndex) ? false : true;

            titleText.Text = $"Vraag {questionIndex + 1} van de {question.Count}";
            questionText.Text = question[questionIndex].vraag;

            answerButtons.Children.Clear();
            foreach (var answer in question[questionIndex].antwoorden)
            {
                answerButtons.Children.Add(new RadioButton { Text = answer.antwoord, GroupName = answer.vraag_id.ToString() });
            }
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