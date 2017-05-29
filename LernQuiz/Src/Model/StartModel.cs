using System;
using System.Collections.Generic;
using LernQuiz;
using LernQuiz.Db;

namespace LernQuiz.Model
{
	public class StartModel : BasicModel
	{
		public static String defaultQuestionnaireBoxText = "Fragebogen auswählen:";
		public String companyAddressLabel = "Segelschule OSZ IMT GmbH\nMarine Weg 5b\n54321 Berlin";
		public String startButtonLabel = "loslegen";
		public String configurationLabel = "Konfiguration einstellen";
		public String historyLabel = "Historie";

		public StartModel ()
		{
		}
			
		public List<String> GetFrageboegen() {
			IEstablishQuestionnaires inlandMotorFactory = new InlandMotorFactory ();
			List<String> frageboegen = new List<String> ();
			frageboegen.Add (defaultQuestionnaireBoxText);
			frageboegen.AddRange(inlandMotorFactory.GetFragebogenIds ());

			return frageboegen;
		}

		public String GetProgramLabel() {
			return settings.GetValue (settings.PROGRAM_NAME);
		}

		public List<String> GetHistory() {
			History history = new History ();

			return history.getHistory();
		}


	}
}
