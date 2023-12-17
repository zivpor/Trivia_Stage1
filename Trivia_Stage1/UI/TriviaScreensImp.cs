using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Trivia_Stage1.Models;

namespace Trivia_Stage1.UI
{
    public class TriviaScreensImp : ITriviaScreens
    {

        //Place here any state you would like to keep during the app life time
        //For example, player login details...
        private TriviaContext Db = new TriviaContext();
        Player p;
        Question q;
        //Implememnt interface here
        public bool ShowLogin()//נועה
        {
            bool ok = false;
            while (!ok)
            {
                Console.WriteLine("Please enter your name");
                string UserName = Console.ReadLine();
                Console.WriteLine("Please enter your email");
                string email = Console.ReadLine();
                Console.WriteLine("Please enter a password");
                string password = Console.ReadLine();

                try
                {
                    this.p = Db.Login(UserName, password, email);
                    if (p != null)
                    {
                        return true;

                    }
                    else
                    {
                        Console.WriteLine("enter again");
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    Console.WriteLine("there is a problem...");
                }

            }
            return ok;
        }
        public bool ShowSignUp()//זיו
        {

            //Logout user if anyone is logged in!
            //A reference to the logged in user should be stored as a member variable
            //in this class! Example:
            //this.currentyPLayer == null

            //Loop through inputs until a user/player is created or 
            //user choose to go back to menu
            char c = ' ';
            while (c != 'B' && c != 'b' /*&& this.currentyPLayer == null*/)
            {
                //Clear screen
                ClearScreenAndSetTitle("Signup");

                Console.Write("Please Type your email: ");
                string email = Console.ReadLine();
                while (!IsEmailValid(email))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Bad Email Format! Please try again:");
                    Console.ResetColor();
                    email = Console.ReadLine();
                }

                Console.Write("Please Type your password: ");
                string password = Console.ReadLine();
                while (!IsPasswordValid(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("password must be at least 4 characters! Please try again: ");
                    Console.ResetColor();
                    password = Console.ReadLine();
                }

                Console.Write("Please Type your Name: ");
                string name = Console.ReadLine();
                while (!IsNameValid(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("name must be at least 3 characters! Please try again: ");
                    Console.ResetColor();
                    name = Console.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Connecting to Server...");
                Console.ResetColor();
                //Create instance of Business Logic and call the signup method
                // *For example:
                try
                {
                    TriviaContext db = new TriviaContext();
                    this.p = db.AddSignUp(email, name, password);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to signup! Email may already exist in DB!");
                    Console.ResetColor();
                }



                //Provide a proper message for example:
                Console.WriteLine("Press (B)ack to go back or any other key to signup again...");
                //Get another input from user
                c = Console.ReadKey(true).KeyChar;
            }
            //return true if signup suceeded!
            return (false);
        }

        public void ShowAddQuestion()//שי
        {
            foreach (Player p in Db.Players)
            {
                if (p.Points >= 100)
                {
                    Console.WriteLine("good job! now you have 100 points and you can add questions");
                    Console.WriteLine("please enter the subject");
                    string subject = Console.ReadLine();
                    Console.WriteLine("please enter your question");
                    string question = Console.ReadLine();
                    Console.WriteLine("please enter right answer");
                    string Ranswer = Console.ReadLine();
                    Console.WriteLine("please enter wrong answer");
                    string Wanswer = Console.ReadLine();
                    Console.WriteLine("please enter another wrong answer");
                    string Wanswer2 = Console.ReadLine();
                    Console.WriteLine("please enter another wrong answer");
                    string Wanswer3 = Console.ReadLine();
                }
                else { Console.WriteLine("if you want to add questions, go play and get more points!! X)"); }
            }
        }

        public void ShowPendingQuestions()//נועה
        {
            Console.WriteLine("Pending question");
            char c;
            c = '5';
            foreach (Question q in Db.Questions)
            {
                if (q.StatusId == 1)
                {
                    Console.WriteLine(q.Ranswer);
                    Console.WriteLine(q.Wanswer1);
                    Console.WriteLine(q.Wanswer2);
                    Console.WriteLine(q.Wanswer3);
                    Console.WriteLine("Press 1 to approve, Press 2 to reject, Press 3 to skip");
                    while (c == '5')
                    {
                        c = Console.ReadKey().KeyChar;
                        if (c == 1)
                        {
                            q.StatusId = 2;
                        }
                        if (c == 2)
                        {
                            q.StatusId = 3;
                        }
                        else
                            c = '5';
                    }
                }
            }
        }
        public void ShowGame()//זיו
        {
            bool exist = false;
            string answer = "";
            char e = ' ';
            foreach (Question q in Db.Questions)
            {
                while (!exist)
                {
                    Console.WriteLine("trivia questions:");
                    //print question and answers
                    Db.QuestoinsAndAnswers(q);
                    Console.WriteLine("what is your final answer?");
                    answer = Console.ReadLine();
                    if (answer == q.Ranswer)
                    {
                        this.p.Points += 10;
                        Console.WriteLine("you nailed it!!");
                    }
                    else
                    {
                        Console.WriteLine("maybe next time:(");
                    }
                }
                Console.WriteLine("press e if you want to exit");
                e = Console.ReadKey().KeyChar;
                if (e == 'e')
                {
                    exist = true;
                }
            }
        }
        public void ShowProfile()//שי
        {
            char c = ' ';
            while (c != 'B' && c != 'b')
            {
                Console.WriteLine($"Email:{p.Email}");
                Console.WriteLine($"Name:{p.Name}");
                Console.WriteLine($"Password:{p.Password}");
                Console.WriteLine($"Rank:{p.Rank}");
                Console.WriteLine($"Score:{p.Points}");
                Console.WriteLine("   ");

                char ch;
                Console.WriteLine("if you want to update anything enter U");
                Console.WriteLine("if you dont want to change anything enter N");
                ch = char.Parse(Console.ReadLine());
                bool playerUpdate = false;

                if (ch == 'U' || ch == 'u')
                {
                    int num = 0;
                    while (num != 1 && num != 2 && num != 3)
                    {
                        Console.WriteLine("Enter 1 if you want to change email");
                        Console.WriteLine("Enter 2 if you want to change name");
                        Console.WriteLine("Enter 3 if you want to change password");
                        num = int.Parse(Console.ReadLine());
                    }
                    if (num == 1)
                    {
                        string UpdatedEmail;
                        Console.WriteLine("enter new email");
                        UpdatedEmail = Console.ReadLine();
                        while (!IsEmailValid(UpdatedEmail))
                        {
                            Console.Write("Bad Email Format! Please try again");
                            UpdatedEmail = Console.ReadLine();
                        }
                        p.Email = UpdatedEmail;
                        playerUpdate = true;

                    }
                    else if (num == 2)
                    {
                        string updatedName;
                        Console.WriteLine("enter new name");
                        updatedName = Console.ReadLine();
                        while (!IsNameValid(updatedName))
                        {
                            Console.Write("name must have at least 3 letter");
                            updatedName = Console.ReadLine();
                        }
                        p.Name = updatedName;
                        playerUpdate = true;
                    }
                    else if (num == 3)
                    {
                        string updatedPass;
                        Console.WriteLine("enter new Password");
                        updatedPass = Console.ReadLine();
                        while (!IsPasswordValid(updatedPass))
                        {
                            Console.Write("Password must have at least 4 letters/numbers,try again");
                            updatedPass = Console.ReadLine();
                        }
                        p.Password = updatedPass;
                        playerUpdate = true;
                    }

                    if (playerUpdate == true)
                    {
                        try
                        {

                            Db.Update(p);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("update player failed");
                            Console.WriteLine("Press any key");
                            Console.ReadKey(true);
                            return;
                        }

                    }
                    Console.WriteLine("Press B to go back to the menu");
                    Console.WriteLine("enter any other key to continue updating");
                    c = Console.ReadKey(true).KeyChar;
                }

            }
        }


        //Private helper methods down here...
        private void ClearScreenAndSetTitle(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{title,65}");
            Console.WriteLine();
            Console.ResetColor();
        }

        private bool IsEmailValid(string emailAddress)
        {
            //regex is string based pattern to validate a text that follows a certain rules
            // see https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference

            var pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            var regex = new Regex(pattern);
            return regex.IsMatch(emailAddress);

            //another option is using .net System.Net.Mail library which has an EmailAddress class that stores email
            //we can use it to validate the structure of the email:
            // https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress?view=net-7.0
            /*
             * try
             * {
             *     //try to create MailAddress objcect from the email address string
             *      var email=new MailAddress(emailAddress);
             *      //if success
             *      return true;
             * }
             *      //if it throws a formatExcpetion then the string is not email format.
             * catch (Exception ex)
             * {
             * return false;
             * }
             */

        }



        private bool IsPasswordValid(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 3;
        }

        private bool IsNameValid(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 3;
        }
    }
}
