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

		public static PictureBox CreatePictureBox(String ResourceId, int Width, int Height, int X, int Y) {
			Stream imgStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream( "LernQuiz.Resources." + ResourceId );

			// create image from stream
			Image image = Image.FromStream (imgStream);

			// setup picturebox
			PictureBox pictureBox = new PictureBox ();
			pictureBox.Image = image;
			pictureBox.Location = new Point (X, Y);
			pictureBox.Width = Width;
			pictureBox.Height = Height;
			pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

			return pictureBox;
		}

		public static Button CreateButton(String Text, int Width, int Height, int X, int Y) {
			Button button = new Button ();
			button.Text = Text;
			button.Width = Width;
			button.Height = Height;
			button.Location = new Point (X, Y);

			return button;
		}

		public static Label CreateLabel(String Text, int Size, int Width, int Height, int X, int Y) {
			Label label = new Label ();
			label.Text = Text;

			label.Font = new Font (label.Font.FontFamily, Size);
			label.Width = Width;
			label.Height = Height;
			label.Location = new Point (X, Y);

			return label;
		}

		public static CheckBox CreateCheckBox(int X, int Y, bool Checked) {
			CheckBox checkBox = new CheckBox ();
			checkBox.Location = new Point (X, Y);
			checkBox.Width = 20;
			checkBox.Height = 20;
			checkBox.Checked = Checked;
			return checkBox;
		}

		public static TextBox CreateTextBox(String Text, bool Multiline, int Width, int Height, int X, int Y) {
			TextBox textBox = new TextBox ();
			textBox.Text = Text;
			textBox.Width = Width;
			textBox.Height = Height;
			textBox.Location = new Point (X, Y);
			textBox.Multiline = Multiline;

			return textBox;
		}

		public static ListBox CreateListBox(List<String> elements, int Width, int Height, int X, int Y) {
			ListBox listBox = new ListBox ();
			listBox.Width = Width;
			listBox.Height = Height;
			listBox.Location = new Point (X, Y);
			listBox.Items.AddRange (elements.ToArray());

			return listBox;
		}

		public static ComboBox CreateComboBox(List<String> elements, String SelectedItem, int Width, int Height, int X, int Y) {

			ComboBox comboBox = new ComboBox ();
			comboBox.Width = Width;
			comboBox.Height = Height;
			comboBox.Location = new Point (X, Y);
			comboBox.Items.AddRange (elements.ToArray());
			comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

			comboBox.SelectedIndex = comboBox.FindStringExact (SelectedItem);
			if (comboBox.Text == "") {
				comboBox.SelectedIndex = 0;
			}

			return comboBox;
		}

		public static ProgressBar CreateProgressBar(int Progress,int Width, int Height, int X, int Y) {
			ProgressBar progressBar = new ProgressBar ();
			progressBar.Width = Width;
			progressBar.Height = Height;
			progressBar.Location = new Point (X, Y);
			progressBar.Value = Progress;
			return progressBar;
		}
	}
}

