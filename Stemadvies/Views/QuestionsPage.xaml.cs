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
        List<UserAnswer> userAnswers = new List<UserAnswer>();
        List<Answer> currentAnswer = new List<Answer>();

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
            if (questionIndex >= maxIndex)
            {
                nextButton.IsEnabled = false;
                resultButton.IsEnabled = true;
            }

            titleText.Text = $"Vraag {questionIndex + 1} van de {question.Count}";
            questionText.Text = question[questionIndex].vraag;

            foreach(RadioButton radioButton in answerButtons.Children)
            {
                radioButton.GroupName = question[questionIndex].vraag_id.ToString();
            }

            currentAnswer = question[questionIndex].antwoorden;

            SetRadioButtons(question[questionIndex].vraag_id);
        }

        private async void NavigateButton(object sender, EventArgs e)
        {
            UpdateScore();
            await Navigation.PushModalAsync(new NavigationPage(new ResultsPage(userAnswers)));
        }

        private void PreviousButton(object sender, EventArgs e)
        {
            UpdateScore();
            questionIndex--;
            GetQuestion();
        }

        private void NextButton(object sender, EventArgs e)
        {
            UpdateScore();
            questionIndex++;
            GetQuestion();
        }

        private void UpdateScore()
        {
            int? questionId = null;
            string answer = "";
            foreach(RadioButton radioButton in answerButtons.Children)
            {
                if (radioButton.IsChecked)
                {
                    questionId = int.Parse(radioButton.GroupName);
                    answer = radioButton.ClassId;
                }
            }

            if (userAnswers.Exists(x => x.question_id == questionId))
            {
                userAnswers.Find(x => x.question_id == questionId).answer = answer;
            } else
            {
                userAnswers.Add(new UserAnswer() { question_id = questionId, answer = answer , parties = currentAnswer});
            }
        }

        private void SetRadioButtons(int questionId)
        {
            if (userAnswers.Exists(x => x.question_id == questionId))
            {
                foreach(RadioButton radioButton in answerButtons.Children)
                {
                    if (userAnswers.Find(x => x.question_id == questionId).answer == radioButton.ClassId)
                    {
                        radioButton.IsChecked = true;
                    }
                }
            } 
            else
            {
                RadioButton first = (RadioButton)answerButtons.Children.FirstOrDefault();
                first.IsChecked = true;
            }
        }
    }
}