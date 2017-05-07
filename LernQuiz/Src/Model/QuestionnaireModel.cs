using System;
using System.Collections.Generic;
using LernQuiz;
using LernQuiz.Db;

namespace LernQuiz.Model
{
	public class QuestionnaireModel : BasicModel
	{
		private Questionnaire questionnaire;
		private String QuestionnaireIndex;
		
		public QuestionnaireModel (string questionnaireIndex)
		{

			this.QuestionnaireIndex = questionnaireIndex;
			questionnaire = new InlandMotorFactory().GetFragebogen (QuestionnaireIndex);
		}

		public String GetProgramLabel() {
			return settings.GetValue (settings.PROGRAM_NAME);
		}

		public String getQuestionnaireLabel() {
			return "Prüfungsbogen Nummer " + QuestionnaireIndex;
		}

		public String Back = "<-- Zurück";

		public String Forward = "Weiter -->";

		public List<Question>  getQuestions() {
			return questionnaire.Questions;
		}
	}
}

