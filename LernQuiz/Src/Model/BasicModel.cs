using System;

namespace LernQuiz.Model
{
	public abstract class BasicModel
	{
		protected Settings settings;
		public BasicModel ()
		{
			settings = new Settings ();
		}
	}
}

