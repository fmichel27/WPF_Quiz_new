using System;
using System.Collections.Generic;

namespace LernQuiz.Db
{
    public class Answer
    {
		public string answerText { get; set;}
		public bool chosenAnswer { get; set;}
		public bool rightAnswer { get; set;}

        public Answer(String answerText, bool rightAnswer)
        {
            this.answerText = answerText;
            this.chosenAnswer = false;
            this.rightAnswer = rightAnswer;
        }
    }
}
