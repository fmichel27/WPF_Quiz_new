using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using LernQuiz.View.Panels;
using LernQuiz.Controller;

namespace LernQuiz.View
{
	public class QuizForm : Form
	{
		private BasicPanel CurrentBasicPanel;

		public QuizForm ()
		{
			Text = "LernQuiz";
			updatePanel ("start", null);
		}
			

		public void updatePanel(String PanelName, String[] Params) {
			BasicPanel NextPanel;
			switch (PanelName) {
			case "start":
				SetSize (1000, 470);
				NextPanel = new StartPanel (this, Params);
				break;
			case "configuration":
				SetSize (800, 700);
				NextPanel = new ConfigurationPanel (this, Params);
				break;
			case "questionnaire":
				SetSize (820, 520);
				NextPanel = new QuestionnairePanel (this, Params);
				break;
			case "evaluation":
				SetSize (830, 540);
				NextPanel = new EvaluationPanel (this, Params);
				break;
			default:
				new LogErrorsInFile ().LogError ("Couldnt load panel: \"" + PanelName + "\"");
				return;
			}

			this.Controls.Add (NextPanel);
			this.Controls.Remove (CurrentBasicPanel);
			this.CurrentBasicPanel = NextPanel;
		}

		private void SetSize(int Width, int Height) {
			MinimumSize = new Size (Width, Height);
			MaximumSize = new Size (Width, Height);
		}
	}
}
