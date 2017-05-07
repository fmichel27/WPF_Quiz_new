using System;

using LernQuiz.Db;
using LernQuiz.View;

using System.Collections.Generic;

namespace LernQuiz
{
	public class QuizMain
	{
		public QuizMain ()
		{
		}

		public static void Main(String[] args) {
			QuizForm quizForm = new QuizForm ();
			quizForm.ShowDialog ();
		}
	}
}

