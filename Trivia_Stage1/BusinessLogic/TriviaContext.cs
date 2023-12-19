using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Stage1.Models
{
    public partial class TriviaContext
    {
        const int PLAYER_MANAGER = 3;
        const int PLAYER_MASTER = 2;
        const int PLAYER_TIRON = 1;
        public Player Login(string username, string email, string password)
        {
            return this.Players.Where(p => p.Name == username && p.Email == email && p.Password == password).FirstOrDefault();
        }
        public void QuestoinsAndAnswers(Question question)
        {
            Console.WriteLine(question.Text);
            Console.WriteLine(question.Wanswer1);
            Console.WriteLine(question.Wanswer2);
            Console.WriteLine(question.Wanswer3);
            Console.WriteLine(question.Ranswer);
        }
        public Player AddSignUp(string email, string name, string password)
        {
            Player p1 = new Player
            {
                Name = name,
                Email = email,
                Password = password,
                Points = 0,
                Rank = PLAYER_TIRON,
            };
            try
            {
                this.Players.Add(p1);
                SaveChanges();
                return p1;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
      

    }
}
