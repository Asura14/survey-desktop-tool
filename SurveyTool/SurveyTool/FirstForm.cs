using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public FirstForm()
        {
            survey = new Survey();
            InitializeComponent();
            initializeControls();
        }

        private void buttonNext_Click(object sender, EventArgs e)
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
                this.Hide();
            } else
            {
                MessageBox.Show("Preencha os campos em falta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void doneClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void initializeControls()
        {
            this.BackColor = Color.FromArgb(250,250,250);
            this.ForeColor = Color.FromArgb(100, 34, 34, 34);
            this.Text = "Novo Inquérito";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            //Labels
            this.lblTitle.Location=  new System.Drawing.Point(12, 9);
            this.lblTitle.Size = new System.Drawing.Size(50, 25);
            this.labelOutro.Font = new Font("Roboto", 12, FontStyle.Regular);
            this.labelIntro.Font = new Font("Roboto", 12, FontStyle.Regular);
            this.labelTitle.Font = new Font("Roboto", 12, FontStyle.Regular);
            //Button next -> For question page
            this.buttonNext.Text = "CONTINUAR";
            this.buttonNext.Location = new System.Drawing.Point(320, 300);
            this.buttonNext.Size = new System.Drawing.Size(120, 50);
            this.buttonNext.Font = new Font("Roboto", 11, FontStyle.Regular);
            this.buttonNext.TabStop = false;
            this.buttonNext.FlatStyle = FlatStyle.Flat;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.BackColor = Color.FromArgb(0, 255, 255, 255);
            this.buttonNext.ForeColor = Color.FromArgb(100, 20, 103, 255);
            //Button end
            this.btnDone.Text = "SAIR";
            this.btnDone.Location = new System.Drawing.Point(450, 300);
            this.btnDone.Size = new System.Drawing.Size(120, 50);
            this.btnDone.Click += new EventHandler(doneClick);
            this.btnDone.Font = new Font("Roboto", 11, FontStyle.Regular);
            this.btnDone.TabStop = false;
            this.btnDone.FlatStyle = FlatStyle.Flat;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.BackColor = Color.FromArgb(0, 255, 255, 255);
            this.btnDone.ForeColor = Color.FromArgb(100, 0, 103, 255);
            //Text Boxes
            this.textBoxTitle.Font = new Font("Roboto", 12, FontStyle.Regular);
            this.textBoxIntro.Font = new Font("Roboto", 12, FontStyle.Regular);
            this.textBoxOutro.Font = new Font("Roboto", 12, FontStyle.Regular);
            //Update variables
            this.Controls.Add(btnDone);
        }
    }
}
