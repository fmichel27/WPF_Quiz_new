using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LernQuiz.View
{
	public class FormElementFactory
	{
		public FormElementFactory ()
		{
		}

		public static PictureBox CreatePictureBox(String resourceId, int width, int height, int x, int y) {
			Stream imgStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream( "LernQuiz.Resources." + resourceId );

			// create image from stream
			Image image = Image.FromStream (imgStream);

			// setup picturebox
			PictureBox pictureBox = new PictureBox ();
			pictureBox.Image = image;
			pictureBox.Location = new Point (x, y);
			pictureBox.Width = width;
			pictureBox.Height = height;
			pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

			return pictureBox;
		}

		public static Button CreateButton(String text, int width, int height, int x, int y) {
			Button button = new Button ();
			button.Text = text;
			button.Width = width;
			button.Height = height;
			button.Location = new Point (x, y);

			return button;
		}

		public static Label CreateLabel(String text, int size, int width, int height, int x, int y) {
			Label label = new Label ();
			label.Text = text;

			label.Font = new Font (label.Font.FontFamily, size);
			label.Width = width;
			label.Height = height;
			label.Location = new Point (x, y);

			return label;
		}

		public static CheckBox CreateCheckBox(int x, int y, bool checkeed) {
			CheckBox checkBox = new CheckBox ();
			checkBox.Location = new Point (x, y);
			checkBox.Width = 20;
			checkBox.Height = 20;
			checkBox.Checked = checkeed;
			return checkBox;
		}

		public static TextBox CreateTextBox(String text, bool multiline, int width, int height, int x, int y) {
			TextBox textBox = new TextBox ();
			textBox.Text = text;
			textBox.Width = width;
			textBox.Height = height;
			textBox.Location = new Point (x, y);
			textBox.Multiline = multiline;

			return textBox;
		}

		public static ListBox CreateListBox(List<String> elements, int width, int height, int x, int y) {
			ListBox listBox = new ListBox ();
			listBox.Width = width;
			listBox.Height = height;
			listBox.Location = new Point (x, y);
			listBox.Items.AddRange (elements.ToArray());

			return listBox;
		}

		public static ComboBox CreateComboBox(List<String> elements, String selectedItem, int width, int height, int x, int y) {

			ComboBox comboBox = new ComboBox ();
			comboBox.Width = width;
			comboBox.Height = height;
			comboBox.Location = new Point (x, y);
			comboBox.Items.AddRange (elements.ToArray());
			comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

			comboBox.SelectedIndex = comboBox.FindStringExact (selectedItem);
			if (comboBox.Text == "") {
				comboBox.SelectedIndex = 0;
			}

			return comboBox;
		}

		public static ProgressBar CreateProgressBar(int progress,int width, int height, int x, int y) {
			ProgressBar progressBar = new ProgressBar ();
			progressBar.Width = width;
			progressBar.Height = height;
			progressBar.Location = new Point (x, y);
			progressBar.Value = progress;
			return progressBar;
		}
	}
}

