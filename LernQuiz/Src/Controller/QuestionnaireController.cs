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
		private String QuestionnaireIndex;

		public QuestionnaireController (QuizForm QForm, String[] Params) : base (QForm, Params)
		{
			this.QuestionnaireIndex = QuestionnaireIndex;
		}

		protected override void InitModel(String[] Params) {
			string Index = Params [0];
			BModel = new QuestionnaireModel (Index);
		}
	}
}

