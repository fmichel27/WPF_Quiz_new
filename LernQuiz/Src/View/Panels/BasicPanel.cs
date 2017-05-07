using System;
using System.Windows.Forms;
using System.Drawing;

using LernQuiz.View;
using LernQuiz.Model;
using LernQuiz.Controller;

namespace LernQuiz.View.Panels
{
	public abstract class BasicPanel : Panel
	{
		protected BasicController BController;

		public BasicPanel (QuizForm QForm)
		{
			this.Height = QForm.Height;
			this.Width = QForm.Width;
			Location = new Point (0, 0);
		}

		protected abstract void InitView (BasicModel BModel);
	}
}
