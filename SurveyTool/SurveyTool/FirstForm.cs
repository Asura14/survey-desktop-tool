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
        private Button btnDel = new Button();
        private Button btnNext = new Button();
        private CheckBox chkBox = new CheckBox();
        private Label lblTitle = new Label();
        private ComboBox comboBox = new ComboBox();

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

                textBoxIntro.Dispose();
                textBoxOutro.Dispose();
                textBoxTitle.Dispose();
                labelIntro.Dispose();
                labelOutro.Dispose();
                labelTitle.Dispose();
                buttonNext.Dispose();
                //Add
                newQuestion();

            } else
            {
                MessageBox.Show("Preencha os campos em falta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void newQuestion()
        {
            int size = survey.Questions.Count;
            string newTitle = "Question " + size + ". Title and Type";
            lblTitle.Text = newTitle;
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtBox);
            this.Controls.Add(btnDel);
            this.Controls.Add(btnNext);

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
            //Button Next
            this.btnNext.BackColor = Color.LightGray;
            this.btnNext.Text = "Add";
            this.btnNext.Location = new System.Drawing.Point(620, 340);
            this.btnNext.Size = new System.Drawing.Size(150, 50);
            //Button next -> For first page
            this.buttonNext.BackColor = Color.LightGray;
            this.buttonNext.Text = "Add";
            this.buttonNext.Location = new System.Drawing.Point(620, 340);
            this.buttonNext.Size = new System.Drawing.Size(150, 50);
            //Button Stop
            this.btnDel.BackColor = Color.LightGray;
            this.btnDel.Text = "End";
            this.btnDel.Location = new System.Drawing.Point(450, 340);
            this.btnDel.Size = new System.Drawing.Size(150, 50);
            // Text Box
            this.txtBox.Text = "Text";
            this.txtBox.Location = new System.Drawing.Point(80, 25);
            this.txtBox.Size = new System.Drawing.Size(425, 25);
            //Combo Box
            this.comboBox.Location = new System.Drawing.Point(55, 160);
            this.comboBox.Size = new System.Drawing.Size(65, 15);

        }

    }
}
