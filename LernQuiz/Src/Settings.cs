using System;
using System.Collections.Generic;


namespace LernQuiz
{
	public class Settings : DictionaryIO
	{
		public string PROGRAM_NAME = "programname";
		public string PERCENT_TO_PASS = "passedquizwith";

		public Settings () : base ("config.txt")
		{
			if (!LoadFromFile ()) {
				Console.WriteLine ("Config not read " + FileName);
				SetDefaultSettings ();
			}
		}

		public void SetValue(string key, string value) {
			if (dictionary.ContainsKey (key)) {
				dictionary.Remove (key);
			}
			dictionary.Add (key, value);
			SaveToFile ();
		}

		public string GetValue(string key) {
			if (dictionary.ContainsKey (key)) {
				return dictionary [key];
			} else {
				new LogErrorsInFile ().LogWarning ("Key: \"" + key + "\" not found in " + FileName);
				return "";
			}
		}
			
		private void SetDefaultSettings() {
			dictionary.Add (PROGRAM_NAME, "Sportbootführerschein Binnen (unter Antriebsmaschine)");
			dictionary.Add (PERCENT_TO_PASS, "95");
		}
	}
}