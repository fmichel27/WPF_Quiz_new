using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using LernQuiz.View;
using LernQuiz.Model;

namespace LernQuiz.View.Panels
{
	public class ConfigurationPanel : BasicPanel
	{
		public ConfigurationPanel (QuizForm QForm, String[] Params) : base (QForm) {
			BController = new ConfigurationController (QForm, Params);
			InitView (BController.GetModel());
		}

		protected override void InitView(BasicModel BModel) {
			ConfigurationModel configurationModel = (ConfigurationModel)BModel;
			List<Control> elements = new List <Control> ();

			Label PanelLabel = FormElementFactory.CreateLabel (configurationModel.panelLabel, 18, 1000, 40, 10, 10);
			elements.Add (PanelLabel);

			Label ProgramNameLabel = FormElementFactory.CreateLabel (configurationModel.setProgramNameLabel, 10, 300, 40, 100, 100);
			elements.Add (ProgramNameLabel);

			TextBox SetProgramNameBox = FormElementFactory.CreateTextBox (configurationModel.GetProgramLabel(), false, 300, 40, 400, 100);
			elements.Add (SetProgramNameBox);

			Label PercentToPassLabel = FormElementFactory.CreateLabel (configurationModel.setPercentToPassLabel, 10, 300, 40, 100, 180);
			elements.Add (PercentToPassLabel);

			TextBox PercentToPassBox = FormElementFactory.CreateTextBox (configurationModel.GetPercentToPass(), false, 300, 40, 400, 180);
			elements.Add (PercentToPassBox);

			Label DeleteHistoryLabel = FormElementFactory.CreateLabel (configurationModel.deleteHistoryLabel, 10, 200, 40, 100, 260);
			elements.Add (DeleteHistoryLabel);

			Button DeleteHistoryButton = FormElementFactory.CreateButton(configurationModel.deleteHistoryButtonLabel, 300, 40, 400, 260);
			DeleteHistoryButton.Click += (s, e) => {((ConfigurationController)BController).deleteHistory();};
			elements.Add (DeleteHistoryButton);
			///
			Button SaveAndBackButton = FormElementFactory.CreateButton(configurationModel.saveAndBackButtonLabel, 600, 40, 100, 340);
			SaveAndBackButton.Click += (s, e) => {
				if (((ConfigurationController)BController).saveConfig(SetProgramNameBox.Text, PercentToPassBox.Text)) {
					BController.setPanel("start", null);
				}
			};
			elements.Add (SaveAndBackButton);

			PictureBox DeveloperLogo = FormElementFactory.CreatePictureBox ("ApplicationImages.DeveloperABC.png", 200, 80, 10, 460);
			elements.Add (DeveloperLogo);

			Label TeamLabel = FormElementFactory.CreateLabel (configurationModel.teamLabel, 8, 200, 80, 210, 480);
			elements.Add (TeamLabel);


			Label CompanyAddressLabel = FormElementFactory.CreateLabel (configurationModel.companyAddressLabel, 8, 200, 80, 280, 560);
			elements.Add (CompanyAddressLabel);

			PictureBox CompanyLogo = FormElementFactory.CreatePictureBox ("ApplicationImages.SegelschuleOSZIMT.png", 300, 200, 450, 430);
			elements.Add (CompanyLogo);



			Controls.AddRange (elements.ToArray());
		}
	}
}

