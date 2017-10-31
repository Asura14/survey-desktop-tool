using System;
using System.Drawing;
using System.Windows.Forms;

namespace SurveyTool
{
    public partial class FirstForm : Form
    {
        private Survey survey;
        //Controls
        private TextBox txtBox = new TextBox();
        private Button btnNext = new Button();
        private Button btnDone = new Button();
        private Label lblTitle = new Label();

        /// <summary>
        ///  Form where the user fills surveys information (before the questions/answers).
        /// </summary>
        public FirstForm()
        {
            survey = new Survey();
            InitializeComponent();
            InitializeControls();
        }

        /// <summary>
        ///  Saves user input (if filled) and starts the next form.
        /// </summary>
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text;
            string intro = textBoxIntro.Text;
            string outro = textBoxOutro.Text;
            if (title.Length > 0 && intro.Length > 0 && outro.Length > 0)
            {
                survey.Title = title;
                survey.Intro = intro;
                survey.Outro = outro;
                QuestionForm questionForm = new QuestionForm(survey);
                questionForm.Show();
                Hide();
            } else
            {
                MessageBox.Show("Preencha os campos em falta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        ///  Closes the application.
        /// </summary>
        private void DoneClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///  Initializes the form and it's elements/controls.
        /// </summary>
        private void InitializeControls()
        {
            BackColor = Color.FromArgb(250,250,250);
            ForeColor = Color.FromArgb(100, 34, 34, 34);
            Text = "Novo Inquérito";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            //Labels
            lblTitle.Location=  new Point(12, 9);
            lblTitle.Size = new Size(50, 25);
            labelOutro.Font = new Font("Roboto", 12, FontStyle.Regular);
            labelIntro.Font = new Font("Roboto", 12, FontStyle.Regular);
            labelTitle.Font = new Font("Roboto", 12, FontStyle.Regular);
            //Button next -> For question page
            buttonNext.Text = "CONTINUAR";
            buttonNext.Location = new Point(320, 300);
            buttonNext.Size = new Size(120, 50);
            buttonNext.Font = new Font("Roboto", 11, FontStyle.Regular);
            buttonNext.FlatStyle = FlatStyle.Flat;
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.BackColor = Color.FromArgb(0, 255, 255, 255);
            buttonNext.ForeColor = Color.FromArgb(100, 20, 103, 255);
            //Button end
            btnDone.Text = "SAIR";
            btnDone.Location = new Point(450, 300);
            btnDone.Size = new Size(120, 50);
            btnDone.Click += new EventHandler(DoneClick);
            btnDone.Font = new Font("Roboto", 11, FontStyle.Regular);
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.FlatAppearance.BorderSize = 0;
            btnDone.BackColor = Color.FromArgb(0, 255, 255, 255);
            btnDone.ForeColor = Color.FromArgb(100, 0, 103, 255);
            //Text Boxes
            textBoxTitle.Font = new Font("Roboto", 12, FontStyle.Regular);
            textBoxIntro.Font = new Font("Roboto", 12, FontStyle.Regular);
            textBoxOutro.Font = new Font("Roboto", 12, FontStyle.Regular);
            //Update variables
            Controls.Add(btnDone);
        }
    }
}
