using System;
using System.Collections.Generic;
using LernQuiz;
using LernQuiz.Db;

namespace LernQuiz.Model
{
	public class StartModel : BasicModel
	{
		public static String DefaultQuestionnaireBoxText = "Fragebogen auswählen:";
		public String CompanyAddressLabel = "Segelschule OSZ IMT GmbH\nMarine Weg 5b\n54321 Berlin";
		public String StartButtonLabel = "loslegen";
		public String ConfigurationLabel = "Konfiguration einstellen";
		public String HistoryLabel = "Historie";

		public StartModel ()
		{
		}
			
		public List<String> getFrageboegen() {
			IEstablishQuestionnaires inlandMotorFactory = new InlandMotorFactory ();
			List<String> frageboegen = new List<String> ();
			frageboegen.Add (DefaultQuestionnaireBoxText);
			frageboegen.AddRange(inlandMotorFactory.GetFragebogenIds ());

			return frageboegen;
		}

		public String getProgramLabel() {
			return settings.GetValue (settings.PROGRAM_NAME);
		}

		public List<String> getHistory() {
			History history = new History ();

			return history.getHistory();
		}


	}
}
