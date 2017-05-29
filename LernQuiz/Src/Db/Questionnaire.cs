using System;
using System.Collections.Generic;

namespace LernQuiz.Db
{
    public class Questionnaire
    {
		public List<Question> questions { get; set;}

        public Questionnaire(List<Question> questions)
        {
            this.questions = questions;
        }
    }
}
