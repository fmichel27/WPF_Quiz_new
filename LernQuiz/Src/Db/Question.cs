using System;
using System.Collections.Generic;

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
            this.QuestionText = QuestionText;
            this.Answers = Answers;
			this.Picture = "QuestionsImages." + QuestionNumber + ".gif";
        }
    }
}
