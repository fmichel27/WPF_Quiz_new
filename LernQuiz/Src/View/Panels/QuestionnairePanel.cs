using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using LernQuiz.Db;
using LernQuiz.View;
using LernQuiz.Model;

namespace LernQuiz.View.Panels
{
	public class QuestionnairePanel : BasicPanel
	{
		// global, because we use them on different locations
		CheckBox Antwort1, Antwort2, Antwort3, Antwort4;
		ProgressBar Progress;
		Panel FrageBogen;
		Button ForwardButton;
		String[] EvaluationParams = new String[31];

		int questionIndex = 0;

		QuestionnaireController QController;

		public QuestionnairePanel (QuizForm QForm, String[] Params) : base (QForm) {
			// Last index tells the EvaluationController which
			String questionnaireIndex = Params [0];
			EvaluationParams [30] = questionnaireIndex;
			BController = new QuestionnaireController (QForm, Params);
			InitView (BController.GetModel ());
			QController= (QuestionnaireController)BController;
		}

		protected override void InitView(BasicModel BModel) {
			QuestionnaireModel questionnaireModel = (QuestionnaireModel)BModel;
			List<Control> elements = new List <Control> ();

			Label FormLabel = FormElementFactory.CreateLabel (questionnaireModel.GetProgramLabel(), 18, 1000, 30, 10, 10);
			elements.Add (FormLabel);

			Label QuestionnaireLabel = FormElementFactory.CreateLabel (questionnaireModel.GetQuestionnaireLabel(), 15, 800, 30, 10, 80);
			elements.Add (QuestionnaireLabel);

			FrageBogen = CreateFragebogenFrage(790,300,10,125, questionnaireModel.GetQuestions()[0]);
			elements.Add(FrageBogen);

			Button BackButton = FormElementFactory.CreateButton (questionnaireModel.back, 150, 50, 0, 430);
			BackButton.Click += (s, e) => {
				GoBack ();
			};
			elements.Add (BackButton);

			Progress = FormElementFactory.CreateProgressBar (0, 490, 30, 155, 440);
			elements.Add (Progress);

			ForwardButton = FormElementFactory.CreateButton (questionnaireModel.forward, 150, 50, 650, 430);
			ForwardButton.Click += (s, e) => {
				GoForward ();
			};
			elements.Add (ForwardButton);

			Controls.AddRange(elements.ToArray());
		}

		private Panel CreateFragebogenFrage(int Width, int Height, int X, int Y, Question question) {
			Panel FrageBogenFrage = new Panel ();
			List<Control> Elements = new List<Control> ();

		

			FrageBogenFrage.Width = Width;
			FrageBogenFrage.Height = Height;
			FrageBogenFrage.Location = new Point (X, Y);
			FrageBogenFrage.BackColor = Color.White;

			Label FrageLabel = FormElementFactory.CreateLabel(question.questionText,12, 650,50,20,20);
			Elements.Add (FrageLabel);

			Antwort1 = FormElementFactory.CreateCheckBox (80, 100, false);
			Elements.Add (Antwort1);

			Antwort2 = FormElementFactory.CreateCheckBox (80, 140, false);
			Elements.Add (Antwort2);

			Antwort3 = FormElementFactory.CreateCheckBox (80, 180, false);
			Elements.Add (Antwort3);

			Antwort4 = FormElementFactory.CreateCheckBox (80, 220, false);
			Elements.Add (Antwort4);

			Antwort1.Click += (s, e) => {
				Antwort2.Checked = Antwort3.Checked = Antwort4.Checked = false;
				SaveAnswer(1);
			};
			Antwort2.Click += (s, e) => {
				Antwort1.Checked = Antwort3.Checked = Antwort4.Checked = false;
				SaveAnswer(2);
			};
			Antwort3.Click += (s, e) => {
				Antwort1.Checked = Antwort2.Checked = Antwort4.Checked = false;
				SaveAnswer(3);
			};
			Antwort4.Click += (s, e) => {
				Antwort1.Checked = Antwort2.Checked = Antwort3.Checked = false;
				SaveAnswer(4);
			};

			Label Antwort1Label = FormElementFactory.CreateLabel (question.answers [0].answerText, 10, 400, 30, 120, 100);
			Elements.Add (Antwort1Label);

			Label Antwort2Label = FormElementFactory.CreateLabel (question.answers [1].answerText, 10, 400, 30, 120, 140);
			Elements.Add (Antwort2Label);

			Label Antwort3Label = FormElementFactory.CreateLabel (question.answers [2].answerText, 10, 400, 30, 120, 180);
			Elements.Add (Antwort3Label);

			Label Antwort4Label = FormElementFactory.CreateLabel (question.answers [3].answerText, 10, 400, 30, 120, 220);
			Elements.Add (Antwort4Label);

			try {
			PictureBox p = FormElementFactory.CreatePictureBox (question.picture, 110, 110, 580, 120);
			Elements.Add (p);
			} catch (Exception e) {
				// picture not found
			}
			
			FrageBogenFrage.Controls.AddRange (Elements.ToArray());

			return FrageBogenFrage;
		}

		private void GoBack() {
			if ((questionIndex > 0)) {
				questionIndex--;
				Progress.Value = (int)(100f / 30f * (float)questionIndex);
				Controls.Remove (FrageBogen);
				FrageBogen = CreateFragebogenFrage(790,300,10,125,((QuestionnaireModel) QController.GetModel()).GetQuestions()[questionIndex]);
				Controls.Add (FrageBogen);

				UpdateButtonSelection ();
			}
		}

		private void GoForward() {
			if (questionIndex < 29 && (Antwort1.Checked || Antwort2.Checked || Antwort3.Checked || Antwort4.Checked)) {
				questionIndex++;
				Progress.Value = (int)(100f / 30f * (float)questionIndex) ;

				Controls.Remove (FrageBogen);
				FrageBogen = CreateFragebogenFrage (790,300,10,125, ((QuestionnaireModel)QController.GetModel ()).GetQuestions () [questionIndex]);
				Controls.Add (FrageBogen);

				UpdateButtonSelection ();

			} else if ((Antwort1.Checked || Antwort2.Checked || Antwort3.Checked || Antwort4.Checked)) {
				ForwardButton.Enabled = false;
				QController.setPanel ("evaluation", EvaluationParams);
			}
		}

		private void SaveAnswer(int answerIndex) {
			EvaluationParams [questionIndex] = answerIndex.ToString();
		}

		private void UpdateButtonSelection() {
			switch (EvaluationParams[questionIndex]) {
				case "1":
				Antwort1.Checked = true;
				break;
				case "2":
				Antwort2.Checked = true;
				break;
				case "3":
				Antwort3.Checked = true;
				break;
				case "4":
				Antwort4.Checked = true;
				break;
			}
		}
	}
}
