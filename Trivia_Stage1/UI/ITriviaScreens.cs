using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Stage1.UI
{
    public interface ITriviaScreens
    {
        bool ShowLogin();
        bool ShowSignUp();
        void ShowAddQuestion();
        void ShowPendingQuestions();
        void ShowGame();
        void ShowProfile();

    }
}
