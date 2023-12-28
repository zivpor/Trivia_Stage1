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
            return this.Players.Where(p => p.Name == username && p.Email == email && p.Password == password).Include(p => p.RankNavigation).Include(p => p.RankNavigation).FirstOrDefault();
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
        public void AddQuestion(string playerEmail, int subjectID, string subject, string text, string Ranswer, string Wanswer1, string Wanswer2, string Wanswer3)
        {
            Question q = new Question() 
            { 
                CreatedBy = playerEmail,
                Subject = subject,
                Text = text,
                Ranswer = Ranswer,
                Wanswer1 = Wanswer1,
                Wanswer2 = Wanswer2,
                Wanswer3 = Wanswer3,
                StatusId = 3,
                SubjectId = subjectID,

            };
            this.Questions.Add(q);
            SaveChanges();
        }

        public void Profile(Player player)
        { 
            Update(player);
            SaveChanges();
        }

        public void ApproveQuestion(Question question)
        {
            Update(question);
            SaveChanges();
        }
        public Question RandomQusetion() 
        {
            List<Question> q = new List<Question>();
            q = this.Questions.ToList();
            Random random = new Random();
            int place = random.Next(0, q.Count);
            return q[place];
        }

        public Question Approved(Question question)
        {
            if (question.StatusId == 1 )
            {
                return question;
            }
            return null; 
        }

    }
}
