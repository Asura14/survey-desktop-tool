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
        public Survey survey { get; set; }
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
                //CONTINUE TO QUESTIONS
                QuestionForm questionForm = new QuestionForm(survey);
                questionForm.Show();
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
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Text = "Novo Inquérito";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            //Label
            this.lblTitle.Location=  new System.Drawing.Point(12, 9);
            this.lblTitle.Size = new System.Drawing.Size(50, 25);
            //Button next -> For question page
            this.buttonNext.BackColor = Color.LightGray;
            this.buttonNext.Text = "Adicionar";
            this.buttonNext.Location = new System.Drawing.Point(320, 300);
            this.buttonNext.Size = new System.Drawing.Size(100, 50);
            //Button end -> 
            this.btnDone.BackColor = Color.LightGray;
            this.btnDone.Text = "Fim";
            this.btnDone.Location = new System.Drawing.Point(450, 300);
            this.btnDone.Size = new System.Drawing.Size(100, 50);
            this.btnDone.Click += new EventHandler(doneClick);
            // Text Box
            this.txtBox.Text = "Texto";
            this.txtBox.Location = new System.Drawing.Point(80, 25);
            this.txtBox.Size = new System.Drawing.Size(425, 25);

            this.Controls.Add(btnDone);
        }
    }
}
