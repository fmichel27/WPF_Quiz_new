using System;
using System.IO;
using System.Collections.Generic;

namespace LernQuiz
{
	class LogErrorsInFile : ICanLogErrors
	{
		public void LogWarning(String warning)
		{
			TextWriter textWriter = new StreamWriter("warnings.txt");
			textWriter.WriteLine(warning);
			textWriter.Close();
		}

		public void LogError(String error)
		{
			TextWriter textWriter = new StreamWriter("errors.txt");
			textWriter.WriteLine(error);
			textWriter.Close();
		}
	}
}