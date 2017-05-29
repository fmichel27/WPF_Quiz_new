using System;
using System.Collections.Generic;
using LernQuiz;
using LernQuiz.Db;

namespace LernQuiz.Model
{
	public class QuestionnaireModel : BasicModel
	{
		private Questionnaire questionnaire;
		private String questionnaireIndex;
		
		public QuestionnaireModel (string questionnaireIndex)
		{

			this.questionnaireIndex = questionnaireIndex;
            questionnaire = new InlandMotorFactory().GetFragebogen (this.questionnaireIndex);
		}

		public String GetProgramLabel() {
			return settings.GetValue (settings.PROGRAM_NAME);
		}

		public String GetQuestionnaireLabel() {
			return "Prüfungsbogen Nummer " + questionnaireIndex;
		}

		public String back = "<-- Zurück";

		public String forward = "Weiter -->";

		public List<Question>  GetQuestions() {
			return questionnaire.questions;
		}
	}
}

