using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using LernQuiz.View;
using LernQuiz.Model;

namespace LernQuiz.View.Panels
{
	public class EvaluationPanel : BasicPanel
	{
		public EvaluationPanel (QuizForm QForm, String[] Params) : base (QForm) {
			BController = new EvaluationController (QForm, Params);
			InitView (BController.GetModel ());
		}

		protected override void InitView(BasicModel BModel) {
			EvaluationModel EModel = (EvaluationModel)BModel;
			List<Control> elements = new List <Control> ();

			Label PanelLabel = FormElementFactory.CreateLabel (EModel.panelLabel, 18, 1000, 40, 10, 10);
			elements.Add (PanelLabel);

			Label ResultText = FormElementFactory.CreateLabel (EModel.GetResultText(), 15, 650, 40, 10, 80);
			elements.Add (ResultText);

			TextBox ShowWrongQuestionsBox = FormElementFactory.CreateTextBox ("", true, 800, 200, 10, 180);
			elements.Add (ShowWrongQuestionsBox);

			ComboBox WrongAnswersBox = FormElementFactory.CreateComboBox (EModel.GetQuestionsOfWrongAnswers (), EModel.listWrongAnswers,800, 30, 10, 150);
			WrongAnswersBox.SelectedIndexChanged += (s, e) => {
				Console.WriteLine(WrongAnswersBox.SelectedIndex);
				if (WrongAnswersBox.SelectedIndex > 0) {
					ShowWrongQuestionsBox.Text = "Falsch: " + EModel.GetWrongAnswer(WrongAnswersBox.SelectedIndex-1) + 
						"\nRichtig: " + EModel.GetRightAnswer(WrongAnswersBox.SelectedIndex-1);
				} else {
					ShowWrongQuestionsBox.Text = "";
				}

			};
			elements.Add (WrongAnswersBox);


			Label EvaluationText = FormElementFactory.CreateLabel (EModel.GetEvaluationText(), 15, 800, 40, 10, 400);
			elements.Add (EvaluationText);

			Button StartButton = FormElementFactory.CreateButton (EModel.backToStartButton, 800, 50, 10, 450);
			// OnClick trigger callback function, which changes the panel to configuration
			StartButton.Click += (s, e) => {BController.setPanel ("start", null);};
			elements.Add (StartButton); 

			Controls.AddRange (elements.ToArray());
		}
	}
}

