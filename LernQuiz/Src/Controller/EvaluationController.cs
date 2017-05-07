using System;
using System.Collections.Generic;

using LernQuiz;
using LernQuiz.View;
using LernQuiz.View.Panels;
using LernQuiz.Controller;
using LernQuiz.Model;
using LernQuiz.Db;

namespace LernQuiz
{
	public class EvaluationController : BasicController
	{
		List<String[]> wrongResults = new List<String[]> ();
		bool passed;
		String questionnaireIndex;

		public EvaluationController (QuizForm QForm, String[] Params) : base (QForm, Params)
		{
			SaveToHistory ();
		}

		protected override void InitModel(String[] Params) {
			Evaluate (Params);
			Console.WriteLine ("Wrong" + wrongResults.Count);
			BModel = new EvaluationModel(wrongResults, passed);
		}

		private void Evaluate(String[] Params) {
			Settings settings = new Settings ();
			questionnaireIndex = Params [30];
			int PercentToPass =  int.Parse(settings.GetValue(settings.PERCENT_TO_PASS));
			Question[] questions = new InlandMotorFactory ().GetFragebogen (questionnaireIndex).Questions.ToArray();

			for(int i = 0; i < questions.Length; i++) {
				if (!questions [i].Answers[int.Parse(Params [i]) - 1].RightAnswer ) {
					String CorrectAnswer = "";
					foreach (Answer possibleAnswer in questions[i].Answers) {
						if (possibleAnswer.RightAnswer) {
							CorrectAnswer = possibleAnswer.AnswerText;
							break;
						}
					}
					wrongResults.Add (new String[] {
						questions [i].QuestionText,
						questions [i].Answers [int.Parse (Params [i]) -1 ].AnswerText, 
						CorrectAnswer
					});
				}
			}

			passed = ((float) (wrongResults.Count)) / 30f > ((float) PercentToPass) / 100f;
		}

		private void SaveToHistory() {
			History history = new History ();
			if (passed) {
				history.addQuiz ("Sportbootführerschein Binnen - (Fragebogen " + questionnaireIndex + ") bestanden");
			} else {
				history.addQuiz ("Sportbootführerschein Binnen - (Fragebogen " + questionnaireIndex + ") nicht bestanden");
			}
		}
	}
}

