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
        Survey survey = new Survey();

        //Controls
        private TextBox txtBox = new TextBox();
        private Button btnNext = new Button();
        private Label lblTitle = new Label();

        public FirstForm()
        {
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
                QuestionForm questionForm = new QuestionForm();
                questionForm.Show();                

            } else
            {
                MessageBox.Show("Preencha os campos em falta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
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
            //Button next -> For first page
            this.buttonNext.BackColor = Color.LightGray;
            this.buttonNext.Text = "Adicionar";
            this.buttonNext.Location = new System.Drawing.Point(620, 340);
            this.buttonNext.Size = new System.Drawing.Size(150, 50);
            // Text Box
            this.txtBox.Text = "Texto";
            this.txtBox.Location = new System.Drawing.Point(80, 25);
            this.txtBox.Size = new System.Drawing.Size(425, 25);

        }

    }
}
