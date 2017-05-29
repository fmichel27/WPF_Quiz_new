using System;

namespace LernQuiz.Model
{
	public class ConfigurationModel : BasicModel
	{
		public String panelLabel = "Konfiguration";
		public String setProgramNameLabel = "Name des Programs:";
		public String setPercentToPassLabel = "Prüfungsbogen bestanden mit .. Prozent:";
		public String deleteHistoryLabel = "Historie löschen";
		public String deleteHistoryButtonLabel = "löschen";
		public String saveAndBackButtonLabel = "Speichern und zurück zum Quiz.";
		public String teamLabel = "Datenbank Spezialist: Daniel Bernardino Schneider\nFrontend Spezialist: David Alexander Dieckow\nBackend Spezialist: Florian Michel";
		public String companyAddressLabel = "Segelschule OSZ IMT GmbH\nMarine Weg 5b\n54321 Berlin";

		public ConfigurationModel ()
		{
		}

		public String GetProgramLabel() {
			return settings.GetValue (settings.PROGRAM_NAME);
		}

		public String GetPercentToPass() {
			return settings.GetValue (settings.PERCENT_TO_PASS);
		}
	}
}

