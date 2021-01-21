using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stemadvies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage(List<UserAnswer> answers)
        {
            InitializeComponent();
            GetResult(answers);
        }

        private async void NavigateBack(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void GetResult(List<UserAnswer> userAnswers)
        {
            List<UserScore> userScores = new List<UserScore>();
            int highestScore = 0;

            foreach (var UserAnswer in userAnswers)
            {
                if (UserAnswer.answer == "True")
                {
                    foreach (var party in UserAnswer.parties)
                    {
                        if (party.eens == 1)
                        {
                            if (userScores.Exists(x => x.party_name == party.partij_naam))
                            {
                                userScores.Find(x => x.party_name == party.partij_naam).score_total++;
                            }
                            else
                            {
                                userScores.Add(new UserScore { party_name = party.partij_naam, party_logo = party.partij_logo, score_total = 1 });
                            }
                        }
                        else if (party.eens == 0)
                        {
                            if (userScores.Exists(x => x.party_name == party.partij_naam))
                            {
                                userScores.Find(x => x.party_name == party.partij_naam).score_total--;
                            }
                            else
                            {
                                userScores.Add(new UserScore { party_name = party.partij_naam, party_logo = party.partij_logo, score_total = -1 });
                            }
                        }
                    }
                }
                else if (UserAnswer.answer == "False")
                {
                    foreach (var party in UserAnswer.parties)
                    {
                        if (party.eens == 1)
                        {
                            if (userScores.Exists(x => x.party_name == party.partij_naam))
                            {
                                userScores.Find(x => x.party_name == party.partij_naam).score_total--;
                            }
                            else
                            {
                                userScores.Add(new UserScore { party_name = party.partij_naam, party_logo = party.partij_logo, score_total = -1 });
                            }
                        }
                        else if (party.eens == 0)
                        {
                            if (userScores.Exists(x => x.party_name == party.partij_naam))
                            {
                                userScores.Find(x => x.party_name == party.partij_naam).score_total++;
                            }
                            else
                            {
                                userScores.Add(new UserScore { party_name = party.partij_naam, party_logo = party.partij_logo, score_total = 1 });
                            }
                        }
                    }
                }
            }

            foreach (var partyScore in userScores)
            {
                if (partyScore.score_total > highestScore)
                {
                    highestScore = partyScore.score_total;
                }
            }

            resultLayout.ItemsSource = userScores.FindAll(x => x.score_total == highestScore);
        }
    }
}