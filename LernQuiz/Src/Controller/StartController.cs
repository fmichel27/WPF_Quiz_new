using System;

using LernQuiz.Controller;
using LernQuiz.View;
using LernQuiz.View.Panels;
using LernQuiz.Model;

namespace LernQuiz
{
	public class StartController : BasicController
	{
		public StartController (QuizForm QForm, String[] Params) : base (QForm, Params)
		{
		}

		public void SetConfigurationPanel() {
			//SetPanel("configuration");
		}

		protected override void InitModel(String[] Params) {
			BModel = new StartModel();
		}
	}
}

