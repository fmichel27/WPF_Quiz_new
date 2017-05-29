using System;
using System.IO;
using System.Collections.Generic;

namespace LernQuiz
{
	public abstract class DictionaryIO
	{
		protected String fileName;
		protected Dictionary<string,string> dictionary;

		public DictionaryIO (String fileName)
		{
			this.fileName = fileName;
		}

		protected bool LoadFromFile() {
			dictionary = new Dictionary<string, string>();

			try {
				if (!File.Exists(fileName)) {
					return false;
				}

				StreamReader textReader = System.IO.File.OpenText(fileName);
				string line;
				while ((line = textReader.ReadLine()) != null)
				{
					string[] parts = line.Split('=');
					string key = parts[0];
					string value = parts[1];

					dictionary.Add (key, value);
					// use it
				}
				textReader.Close();

			} catch(IOException e) {
				new LogErrorsInFile ().LogError (e.Message);
				Console.WriteLine (e.Message);
			}

			return true;
		}

		protected void SaveToFile() {
			try {
				StreamWriter textWriter = new StreamWriter(fileName, false);
				foreach (String key in dictionary.Keys) {
					textWriter.WriteLine(key + "=" + dictionary[key]); 
				}

				textWriter.Close();

			} catch(Exception e) {
				new LogErrorsInFile ().LogError (e.Message);
				Console.WriteLine (e.Message);
			}
		}
	}
}

