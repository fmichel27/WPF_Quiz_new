using System;
using System.Collections.Generic;

namespace LernQuiz.Db
{
    public class Answer
    {
		public string AnswerText { get; set;}
		public bool ChosenAnswer { get; set;}
		public bool RightAnswer { get; set;}

        public Answer(String AnswerText, bool RightAnswer)
        {
            this.AnswerText = AnswerText;
            this.ChosenAnswer = false;
            this.RightAnswer = RightAnswer;
        }
    }
}
