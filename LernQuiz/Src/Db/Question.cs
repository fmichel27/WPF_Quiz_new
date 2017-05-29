using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LernQuiz.Db
{
    public class Question
    {
		public int QuestionNumber { get;set;}
		public string QuestionText { get;set;}
		public string Picture { get;set;}
		public List<Answer> Answers { get;set;}

        public Question(int QuestionNumber, String QuestionText, List<Answer> Answers)
        {
            this.QuestionNumber = QuestionNumber;
           
            string replacement = "";
            Regex rgx = new Regex("\\{.*\\}");
            string result = rgx.Replace(QuestionText, replacement);
            this.QuestionText = result;
            this.Answers = Answers;
			this.Picture = "QuestionsImages." + QuestionNumber + ".gif";
        }
    }
}
