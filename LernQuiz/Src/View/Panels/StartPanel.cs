using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using LernQuiz.View;
using LernQuiz.Model;


namespace LernQuiz.View.Panels
{
	public class StartPanel : BasicPanel
	{
		public StartPanel (QuizForm QForm, String[] Params) : base (QForm) {
			BController = new StartController (QForm, Params);
			InitView (BController.GetModel ());
		}
			
		protected override void InitView(BasicModel BModel) {
			StartModel startModel = (StartModel)BModel;
			List<Control> elements = new List <Control> ();

			Label ProgramNameLabel = FormElementFactory.CreateLabel (startModel.GetProgramLabel(), 18, 700, 40, 10, 10);
			elements.Add (ProgramNameLabel);

			Label CompanyAddressLabel = FormElementFactory.CreateLabel (startModel.companyAddressLabel, 10, 200, 100, 700, 50);
			elements.Add (CompanyAddressLabel);

			PictureBox CompanyLogoPicture = FormElementFactory.CreatePictureBox ("ApplicationImages.SegelschuleOSZIMT.png", 50, 80, 900, 50);
			elements.Add (CompanyLogoPicture);

			Label HistoryLabel = FormElementFactory.CreateLabel (startModel.historyLabel, 15, 200, 40, 400, 140);
			elements.Add (HistoryLabel);

			ListBox HistoryBox = FormElementFactory.CreateListBox (startModel.GetHistory (), 570, 200, 400, 180);
			elements.Add (HistoryBox);

			ComboBox QuestionnaireBox = FormElementFactory.CreateComboBox (startModel.GetFrageboegen (), StartModel.defaultQuestionnaireBoxText, 200, 100, 100, 180);
			elements.Add (QuestionnaireBox);

			Button StartButton = FormElementFactory.CreateButton (startModel.startButtonLabel, 100, 50, 50, 280);
			// OnClick trigger callback function, which changes the panel to configuration
			StartButton.Click += (s, e) => {
				if (QuestionnaireBox.Text == StartModel.defaultQuestionnaireBoxText) {
					MessageBox.Show("Bitte wähle einen Fragebogen aus", "Kein Fragebogen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				BController.setPanel ("questionnaire", new String[]{QuestionnaireBox.Text});
			};
			elements.Add (StartButton);

			Button ConfigurationButton = FormElementFactory.CreateButton (startModel.configurationLabel, 100, 50, 250, 280);
			// OnClick trigger callback function, which changes the panel to configuration
			ConfigurationButton.Click += (s, e) => {BController.setPanel ("configuration", null);};
			elements.Add (ConfigurationButton); 



			Controls.AddRange(elements.ToArray());
		}
	}
}

