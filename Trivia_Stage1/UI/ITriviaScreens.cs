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
        bool ShowSignup();

        void ShowPendingQuestions();
        void ShowGame();
        void ShowProfile();

    }
}
