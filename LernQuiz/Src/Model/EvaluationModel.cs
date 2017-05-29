using System;
using System.Collections.Generic;

namespace LernQuiz.Model
{
	public class EvaluationModel : BasicModel
	{
		List<String[]> wrongResults;
		bool passed;

		public String panelLabel = "Auswertung";
		public String successText = "Herzlichen Glückwunsch, Sie haben bestanden!";
		public String failText = "Leider haben Sie nicht bestanden :(";
		public String listWrongAnswers = "Falsch beantwortete Fragen:";
		public String backToStartButton = "Zurück zum Hauptprogramm";

		public EvaluationModel (List<String[]> wrongResults, bool passed) {
			this.wrongResults = wrongResults;
			this.passed = passed;
		}

		public List<String> GetQuestionsOfWrongAnswers() {
			List<String> wrongAnsweredQuestions = new List<String> ();
			wrongAnsweredQuestions.Add (listWrongAnswers);

			foreach(String[] wrongAnsweredQuestion in wrongResults) {
				wrongAnsweredQuestions.Add(wrongAnsweredQuestion[0]);
			}

			return wrongAnsweredQuestions;
		}

		public String GetWrongAnswer(int index) {
			return wrongResults [index] [1];
		}

		public String GetRightAnswer(int index) {
			return wrongResults [index] [2];
		}

		public String GetEvaluationText() {
			return (30 - wrongResults.Count) + "/30 Fragen richtig beantwortet";
		}

		public String GetResultText() {
			if (passed) {
				return successText;
			}

			return failText;
		}
	}
}

