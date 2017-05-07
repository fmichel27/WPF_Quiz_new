using System;

namespace LernQuiz.Model
{
	public class ConfigurationModel : BasicModel
	{
		public String PanelLabel = "Konfiguration";
		public String SetProgramNameLabel = "Name des Programs:";
		public String SetPercentToPassLabel = "Prüfungsbogen bestanden mit .. Prozent:";
		public String DeleteHistoryLabel = "Historie löschen";
		public String DeleteHistoryButtonLabel = "löschen";
		public String SaveAndBackButtonLabel = "Speichern und zurück zum Quiz.";
		public String TeamLabel = "Datenbank Spezialist: Daniel Bernardino Schneider\nFrontend Spezialist: David Alexander Dieckow\nBackend Spezialist: Florian Michel";
		public String CompanyAddressLabel = "Segelschule OSZ IMT GmbH\nMarine Weg 5b\n54321 Berlin";

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

