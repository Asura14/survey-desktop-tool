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
                //Questions Start
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
            this.ForeColor = Color.Black;
            this.Text = "Novo Inquérito";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            //Label
            this.lblTitle.Location=  new System.Drawing.Point(12, 9);
            this.lblTitle.Size = new System.Drawing.Size(50, 25);
            this.labelTitle.ForeColor = Color.FromArgb(87, Color.Black);
            this.labelIntro.ForeColor = Color.FromArgb(87, Color.Black);
            this.labelOutro.ForeColor = Color.FromArgb(87, Color.Black);
            this.labelTitle.Font = new Font("Roboto", this.labelTitle.Font.Size);
            this.labelIntro.Font = new Font("Roboto", this.labelTitle.Font.Size);
            this.labelOutro.Font = new Font("Roboto", this.labelTitle.Font.Size);
            //Button next -> For question page
            this.buttonNext.BackColor = Color.LightGray;
            this.buttonNext.Text = "Começar";
            this.buttonNext.Location = new System.Drawing.Point(320, 300);
            this.buttonNext.Size = new System.Drawing.Size(100, 50);
            this.buttonNext.Font = new Font("Roboto", this.lblTitle.Font.Size);
            //Button end
            this.btnDone.BackColor = Color.LightGray;
            this.btnDone.Text = "Sair";
            this.btnDone.Location = new System.Drawing.Point(450, 300);
            this.btnDone.Size = new System.Drawing.Size(100, 50);
            this.btnDone.Click += new EventHandler(doneClick);
            this.btnDone.Font = new Font("Roboto", this.lblTitle.Font.Size);
            //Text Box
            this.txtBox.Text = "Texto";
            this.txtBox.Location = new System.Drawing.Point(80, 25);
            this.txtBox.Size = new System.Drawing.Size(425, 25);
            //Update variables
            this.Controls.Add(btnDone);
        }
    }
}
