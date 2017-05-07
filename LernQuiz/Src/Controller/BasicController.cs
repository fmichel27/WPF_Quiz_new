using System;

using LernQuiz.View;
using LernQuiz.View.Panels;
using LernQuiz.Model;

namespace LernQuiz.Controller
{
	public abstract class BasicController
	{
		protected BasicModel BModel;

		// delegate callback, changes the visable panel
		public delegate void SetNextPanel(String PanelName, String[] Params);
		public SetNextPanel SetPanel;

		public BasicController (QuizForm QForm, String[] Params)
		{
			InitModel (Params);
			// delegate to QForm.UpdatePanel()
			SetPanel = new SetNextPanel (QForm.updatePanel);
		}

		public BasicModel GetModel() {
			return BModel;
		}

		protected abstract void InitModel(String[] Params);
	}
}

