using System;
using System.IO;
using System.Collections.Generic;

namespace LernQuiz
{
	public class History : DictionaryIO
	{
		public static String NO_HISTORY = "Keine Historie";

		public History () : base ("history.txt")
		{
			LoadFromFile ();
		}

		public List<String> getHistory() {
			List<String> history = new List<String> ();

			// Keine Einträge in der Historie vorhanden
			if (dictionary.Keys.Count == 0) {
				history.Add (NO_HISTORY);

				return history;
			}
			
			foreach (String quiz in this.dictionary.Values) {
				history.Add (quiz);
			}

			return history;
		}

		public void addQuiz(String quiz) {
			dictionary.Add ((dictionary.Keys.Count + 1).ToString(), quiz);
			SaveToFile ();
		}

		public void delete() {
			if (File.Exists(FileName)) {
				File.Delete(FileName);
			}
		}
	}
}

