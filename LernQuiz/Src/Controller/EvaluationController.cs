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

		public EvaluationController (QuizForm qForm, String[] parames) : base (qForm, parames)
		{
			SaveToHistory ();
		}

		protected override void InitModel(String[] parames) {
			Evaluate (parames);
			Console.WriteLine ("Wrong" + wrongResults.Count);
			bModel = new EvaluationModel(wrongResults, passed);
		}

		private void Evaluate(String[] parames) {
			Settings settings = new Settings ();
			questionnaireIndex = parames [30];
			int PercentToPass =  int.Parse(settings.GetValue(settings.PERCENT_TO_PASS));
			Question[] questions = new InlandMotorFactory ().GetFragebogen (questionnaireIndex).questions.ToArray();

			for(int i = 0; i < questions.Length; i++) {
				if (!questions [i].answers[int.Parse(parames [i]) - 1].rightAnswer ) {
					String correctAnswer = "";
					foreach (Answer possibleAnswer in questions[i].answers) {
						if (possibleAnswer.rightAnswer) {
							correctAnswer = possibleAnswer.answerText;
							break;
						}
					}
					wrongResults.Add (new String[] {
						questions [i].questionText,
						questions [i].answers [int.Parse (parames [i]) -1 ].answerText, 
						correctAnswer
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

