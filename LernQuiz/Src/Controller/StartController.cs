using System;

using LernQuiz.Controller;
using LernQuiz.View;
using LernQuiz.View.Panels;
using LernQuiz.Model;

namespace LernQuiz
{
	public class StartController : BasicController
	{
		public StartController (QuizForm qForm, String[] parames) : base (qForm, parames)
		{
		}

		public void SetConfigurationPanel() {
			//setPanel("configuration");
		}

		protected override void InitModel(String[] parames) {
			bModel = new StartModel();
		}
	}
}

