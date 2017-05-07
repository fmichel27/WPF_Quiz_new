using System;
using System.Collections.Generic;

namespace LernQuiz.Model
{
	public class EvaluationModel : BasicModel
	{
		List<String[]> wrongResults;
		bool passed;

		public String PanelLabel = "Auswertung";
		public String SuccessText = "Herzlichen Glückwunsch, Sie haben bestanden!";
		public String FailText = "Leider haben Sie nicht bestanden :(";
		public String ListWrongAnswers = "Falsch beantwortete Fragen:";
		public String BackToStartButton = "Zurück zum Hauptprogramm";

		public EvaluationModel (List<String[]> wrongResults, bool passed) {
			this.wrongResults = wrongResults;
			this.passed = passed;
		}

		public List<String> getQuestionsOfWrongAnswers() {
			List<String> wrongAnsweredQuestions = new List<String> ();
			wrongAnsweredQuestions.Add (ListWrongAnswers);

			foreach(String[] wrongAnsweredQuestion in wrongResults) {
				wrongAnsweredQuestions.Add(wrongAnsweredQuestion[0]);
			}

			return wrongAnsweredQuestions;
		}

		public String getWrongAnswer(int index) {
			return wrongResults [index] [1];
		}

		public String getRightAnswer(int index) {
			return wrongResults [index] [2];
		}

		public String getEvaluationText() {
			return (30 - wrongResults.Count) + "/30 Fragen richtig beantwortet";
		}

		public String getResultText() {
			if (passed) {
				return SuccessText;
			}

			return FailText;
		}
	}
}

