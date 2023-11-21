using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Trivia_Stage1.UI
{
    class MainMenu:Menu
    {
        public MainMenu() : base($"Main Menu")
        {
            //Build items in main menu!
            AddItem("Start Game", new GameScreen());
            AddItem("Add Question", new AddQuestionScreen());
            AddItem("Check Pending Questions", new CheckPendingQuestions());
            AddItem("Profile", new ProfileScreen());
        }

        
    }
}
