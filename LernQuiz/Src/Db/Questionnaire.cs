using System;
using System.Collections.Generic;

namespace LernQuiz.Db
{
    public class Questionnaire
    {
		public List<Question> Questions { get; set;}

        public Questionnaire(List<Question> Questions)
        {
            this.Questions = Questions;
        }
    }
}
