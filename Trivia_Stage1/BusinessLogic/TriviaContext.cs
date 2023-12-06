using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Stage1.Models
{
    public partial class TriviaContext
    {
        public Player Login(string username, string password, string email)
        {
            return this.Players.Where(p=>p.Name == username && p.Email == email && p.Password == password).FirstOrDefault();
        }
        public Question GetQuestion(int i)
        {
            return this.Questions.Where(x => x.QuestionId == i).FirstOrDefault();
        }
        public string GetRightAnswer(int i)
        {
            return this.Questions.Where(x => x.QuestionId == i).FirstOrDefault().Ranswer;
        }
        public string GetAnswer1(int i)
        {
            return this.Questions.Where(x => x.QuestionId == i).FirstOrDefault().Wanswer1;
        }
        public string GetAnswer2(int i)
        {
            return this.Questions.Where(x => x.QuestionId == i).FirstOrDefault().Wanswer2;
        }
        public string GetAnswer3(int i)
        {
            return this.Questions.Where(x => x.QuestionId == i).FirstOrDefault().Wanswer3;
        }
        public int? GetPoints(string i)
        {
            return this.Players.Where(x => x.Email == i).FirstOrDefault().Points;
        }
        public void SetPoints(int points,string i)
        {
            this.Players.Where(x => x.Email == i).FirstOrDefault().Points = points;
        }
    }
}
