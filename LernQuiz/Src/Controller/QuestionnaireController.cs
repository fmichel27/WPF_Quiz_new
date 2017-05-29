using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using LernQuiz.View;
using LernQuiz.View.Panels;
using LernQuiz.Controller;
using LernQuiz.Model;
using LernQuiz.Db;

namespace LernQuiz
{
	public class QuestionnaireController : BasicController
	{
		private String questionnaireIndex;

		public QuestionnaireController (QuizForm qForm, String[] parames) : base (qForm, parames)
		{
			this.questionnaireIndex = questionnaireIndex;
		}

		protected override void InitModel(String[] parames) {
			string index = parames [0];
			bModel = new QuestionnaireModel (index);
		}
	}
}

