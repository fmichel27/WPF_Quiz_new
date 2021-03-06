﻿using System;
using System.Windows.Forms;

using LernQuiz.View;
using LernQuiz.View.Panels;
using LernQuiz.Controller;
using LernQuiz.Model;

namespace LernQuiz
{
	public class ConfigurationController : BasicController
	{
		public ConfigurationController (QuizForm qForm, String[] parames) : base (qForm, parames)
		{
		}

		protected override void InitModel(String[] parames) {
			bModel = new ConfigurationModel();
		}

		public void deleteHistory() {
			new History().delete();
		}

		public bool saveConfig(String programName, String percentToPass) {
			try{
				int percentToPassInt = int.Parse(percentToPass);
				if (percentToPassInt > 100 || percentToPassInt < 0) {
					AlertIllegalNumber() ;
					return false;
				}
			} catch (Exception e) {
				AlertIllegalNumber();
				return false;
			} 

			Settings settings = new Settings ();
			settings.SetValue (settings.PROGRAM_NAME, programName);
			settings.SetValue (settings.PERCENT_TO_PASS, percentToPass);

			return true;
		}

		private void AlertIllegalNumber() {
			MessageBox.Show ("Nur Nummern von 0 bis 100 sind gültig!", "Ungültige Nummer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}
}

