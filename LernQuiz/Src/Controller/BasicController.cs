using System;

using LernQuiz.View;
using LernQuiz.View.Panels;
using LernQuiz.Model;

namespace LernQuiz.Controller
{
	public abstract class BasicController
	{
		protected BasicModel bModel;

		// delegate callback, changes the visable panel
		public delegate void SetNextPanel(String panelName, String[] parames);
		public SetNextPanel setPanel;

		public BasicController (QuizForm qForm, String[] parames)
		{
			InitModel (parames);
			// delegate to qForm.UpdatePanel()
			setPanel = new SetNextPanel (qForm.updatePanel);
		}

		public BasicModel GetModel() {
			return bModel;
		}

		protected abstract void InitModel(String[] parames);
	}
}

