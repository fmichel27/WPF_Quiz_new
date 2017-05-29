using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LernQuiz.Db
{
    public class Question
    {
		public int questionNumber { get;set;}
		public string questionText { get;set;}
		public string picture { get;set;}
		public List<Answer> answers { get;set;}

        public Question(int questionNumber, String questionText, List<Answer> answers)
        {
            this.questionNumber = questionNumber;
           
            Regex rgx = new Regex("\\{.*\\}");
            this.questionText = rgx.Replace(questionText, "");
            this.answers = answers;
			this.picture = "QuestionsImages." + questionNumber + ".gif";
        }
    }
}
