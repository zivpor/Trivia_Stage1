using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Trivia_Stage1.UI
{
    class LoginMenu:Menu
    {
        public LoginMenu() : base($"Login / Signup")
        {
            //Build items in login menu!
            AddItem("Login", new LoginScreen());
            AddItem("Sign Up", new SignupScreen());
        }

        
    }
}
