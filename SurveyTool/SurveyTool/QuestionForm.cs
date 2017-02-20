using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SurveyTool
{
    public partial class QuestionForm : Form
    {
        private Survey survey;
        private List<Question> questions = new List<Question>();
        private Label lblType = new Label();
        private Label lblTitle = new Label();
        private TextBox txtboxTitle = new TextBox();
        private ComboBox cbType = new ComboBox();
        private Button btnAdd = new Button();
        private Button btnDone = new Button();
        private Button btnAnswer = new Button();
        private string title, type;
        private List<Answer> answers = new List<Answer>();
        private bool addingAnswers = false;
        private Label lblAnswerTitle = new Label();
        private Label lblAnswerJump = new Label();
        private TextBox txtAnswerTitle = new TextBox();
        private NumericUpDown txtAnswerJump = new NumericUpDown();

        public QuestionForm(Survey survey)
        {
            this.survey = survey;
            InitializeComponent();
            initializeControls();
            initializeOnClicks();
        }
        private void initializeOnClicks()
        {
            this.btnAnswer.Click += new EventHandler(newAnswerClick);
            this.btnAdd.Click += new EventHandler(addClick);
            this.btnDone.Click += new EventHandler(doneClick);
        }

        private void initializeControls()
        {
            //Resources
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Text = "Nova: Pergunta " + (questions.Count + 1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(500, 300);
            //Label - Titulo da pergunta
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Size = new System.Drawing.Size(50, 25);
            this.lblTitle.Text = "Pergunta";
            // Text Box - Title
            this.txtboxTitle.Location = new System.Drawing.Point(80, 10);
            this.txtboxTitle.Size = new System.Drawing.Size(400, 25);
            this.txtboxTitle.ReadOnly = false;
            //Label - Tipo de pergunta
            this.lblType.Location = new System.Drawing.Point(10, 50);
            this.lblType.Size = new System.Drawing.Size(50, 50);
            this.lblType.Text = "Tipo de Pergunta";
            // ComboBox - Types
            cbType.Items.Clear();
            cbType.Items.Insert(0, "oneof");
            cbType.Items.Insert(1, "atleast");
            cbType.Items.Insert(2, "dropdown");
            cbType.Items.Insert(3, "fillstring");
            cbType.Items.Insert(4, "fillint");
            this.cbType.Location = new System.Drawing.Point(80, 50);
            this.cbType.Size = new System.Drawing.Size(100, 25);
            this.cbType.Sorted = true;
            this.cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            //Button - Next
            this.btnAdd.Text = "Próxima Pergunta";
            this.btnAdd.Location = new System.Drawing.Point(160, 200);
            this.btnAdd.Size = new System.Drawing.Size(150, 50);
            //Button - End
            this.btnDone.Text = "Finalizar";
            this.btnDone.Location = new System.Drawing.Point(320, 200);
            this.btnDone.Size = new System.Drawing.Size(150, 50);
            //Button - Add Answer
            this.btnAnswer.Text = "+";
            this.btnAnswer.Location = new System.Drawing.Point(80, 90);
            this.btnAnswer.Size = new System.Drawing.Size(30, 30);
            //Add Controls to form
            this.Controls.Add(txtboxTitle);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblType);
            this.Controls.Add(cbType);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnDone);
            this.Controls.Add(btnAnswer);
        }

        protected void addClick(object sender, EventArgs e)
        {
            this.title = txtboxTitle.Text;
            this.type = cbType.Text;

            if (title.Length > 0 && type.Length > 0)
            {
                if(answers.Count > 0)
                {
                    Question question = new Question(questions.Count + 1, title, type);
                    for(int i = 0; i < answers.Count; i++)
                    {
                        question.Answers.Add(answers[i]);
                    }
                    Console.WriteLine("Question added: " + question.Title + ", " + question.Type + ": " + answers.Count);
                    questions.Add(question);
                    //Restart question
                    addingAnswers = false;
                    this.answers.Clear();
                    this.Controls.Clear();
                    initializeControls();
                } else
                {
                    MessageBox.Show("Adicione pelo menos uma resposta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos em falta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        protected void doneClick(object sender, EventArgs e)
        {
            Console.WriteLine("Total Questions" + questions.Count);
            survey.Questions = questions;
            MessageBox.Show("Perguntas adicionadas", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            saveJSONFile();
            this.Close();
        }

        protected void newAnswerClick(object sender, EventArgs e)
        {
            this.title = txtboxTitle.Text;
            this.type = cbType.Text;
            if(addingAnswers)
            {
                if (txtAnswerTitle.Text.Length > 0 && txtAnswerJump.Value >= -1)
                {
                    Answer newAnswer = new Answer();
                    newAnswer.Title = txtAnswerTitle.Text;
                    newAnswer.Jump = Convert.ToInt32(txtAnswerJump.Value);
                    Console.WriteLine("Answer added: " + newAnswer.Title + " - " + newAnswer.Jump);
                    answers.Add(newAnswer);
                    MessageBox.Show("Resposta adicionada", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAnswerTitle.Text = "";
                    txtAnswerJump.Value = 0;
                    return;
                } else
                {
                    MessageBox.Show("Preencha os todos os campos da resposta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            if (title.Length > 0 && type.Length > 0)
            {
                lblAnswerTitle.Text = "Resposta";
                lblAnswerJump.Text = "Saltar para";
                lblAnswerTitle.Location = new System.Drawing.Point(10, 100);
                lblAnswerTitle.Size = new System.Drawing.Size(50, 25);
                lblAnswerJump.Location = new System.Drawing.Point(10, 130);
                lblAnswerJump.Size = new System.Drawing.Size(50, 25);
                txtAnswerTitle.Location = new System.Drawing.Point(80, 100);
                txtAnswerTitle.Size = new System.Drawing.Size(400, 25);
                txtAnswerJump.Location = new System.Drawing.Point(80, 130);
                txtAnswerJump.Size = new System.Drawing.Size(50, 25);
                txtAnswerJump.Minimum = -1;
                this.btnAnswer.Location = new System.Drawing.Point(80, 170);

                this.Controls.Add(txtAnswerTitle);
                this.Controls.Add(txtAnswerJump);
                this.Controls.Add(lblAnswerTitle);
                this.Controls.Add(lblAnswerJump);

                this.txtboxTitle.ReadOnly = true;
                addingAnswers = true;
                return;
            }
            else
            {
                MessageBox.Show("Preencha a pergunta e o tipo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void saveJSONFile()
        {
            string json = JsonConvert.SerializeObject(survey);
            System.IO.File.WriteAllText(@"D:\path.json", json);

        }
    }
}
