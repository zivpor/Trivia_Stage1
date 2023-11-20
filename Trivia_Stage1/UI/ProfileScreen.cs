using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Trivia_Stage1.UI
{
    class ProfileScreen:Screen
    {
        public ProfileScreen():base("Show Profile")
        {


        }

        public override void Show()
        {
            base.Show();
            Program.ui.Screens.ShowProfile();
        }
    }
}
