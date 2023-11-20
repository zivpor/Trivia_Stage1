using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia_Stage1.UI
{
    public class UIMain
    {
        //UI Main object is perfect for storing all UI state as it is initialized first and detroyed last.
        private Screen initialScreen;
        public UIMain(Screen initial, ITriviaScreens screens)
        {
            this.initialScreen = initial;
            Screens = screens;

        }
        public void ApplicationStart()
        {
            //Show Screen and start app!
            initialScreen.Show();
        }

        public ITriviaScreens Screens { get; private set; } 
    }
}
