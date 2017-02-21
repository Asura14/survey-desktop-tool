using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;

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
            this.FormClosing += formClosingEvent;
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
            this.BackColor = Color.FromArgb(250, 250, 250);
            this.ForeColor = Color.Black;
            this.Text = "Nova | Pergunta " + (questions.Count + 1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(500, 300);
            //Label - Titulo da pergunta
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Size = new System.Drawing.Size(70, 25);
            this.lblTitle.ForeColor = Color.FromArgb(87, Color.Black);
            this.lblTitle.Font = new Font("Roboto", this.lblTitle.Font.Size);
            this.lblTitle.Text = "Pergunta";
            // Text Box - Title
            this.txtboxTitle.Location = new System.Drawing.Point(80, 10);
            this.txtboxTitle.Size = new System.Drawing.Size(400, 25);
            this.txtboxTitle.ReadOnly = false;
            //Label - Tipo de pergunta
            this.lblType.Location = new System.Drawing.Point(10, 50);
            this.lblType.Size = new System.Drawing.Size(70, 50);
            this.lblType.Text = "Tipo de Pergunta";
            this.lblType.ForeColor = Color.FromArgb(87, Color.Black);
            this.lblType.Font = new Font("Roboto", this.lblType.Font.Size);
            // ComboBox - Types
            this.cbType.Items.Clear();
            this.cbType.Items.Insert(0, "oneof");
            this.cbType.Items.Insert(1, "atleast");
            this.cbType.Items.Insert(2, "dropdown");
            this.cbType.Items.Insert(3, "fillstring");
            this.cbType.Items.Insert(4, "fillint");
            this.cbType.Location = new System.Drawing.Point(80, 50);
            this.cbType.Size = new System.Drawing.Size(100, 25);
            this.cbType.Sorted = true;
            this.cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            //Button - Next
            this.btnAdd.Text = "Adicionar Pergunta";
            this.btnAdd.Location = new System.Drawing.Point(160, 200);
            this.btnAdd.Size = new System.Drawing.Size(150, 50);
            this.btnAdd.Font = new Font("Roboto", this.lblTitle.Font.Size);
            //Button - End
            this.btnDone.Text = "Finalizar";
            this.btnDone.Location = new System.Drawing.Point(320, 200);
            this.btnDone.Size = new System.Drawing.Size(150, 50);
            this.btnDone.Font = new Font("Roboto", this.lblTitle.Font.Size);
            //Button - Add Answer
            this.btnAnswer.Image = Properties.Resources.add;
            this.btnAnswer.Location = new System.Drawing.Point(80, 90);
            this.btnAnswer.Size = new System.Drawing.Size(30, 30);
            this.btnAnswer.Font = new Font("Roboto", this.lblTitle.Font.Size);
            //Add Controls to form
            this.Controls.Add(txtboxTitle);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblType);
            this.Controls.Add(cbType);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnDone);
            this.Controls.Add(btnAnswer);
        }

        void addClick(object sender, EventArgs e)
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
                    this.addingAnswers = false;
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
            saveJSONFile();
            DialogResult dialog = MessageBox.Show(questions.Count + " Perguntas adicionadas", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                Application.Exit();
            }
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
                    this.txtAnswerTitle.Text = "";
                    this.txtAnswerJump.Value = 0;
                    return;
                } else
                {
                    MessageBox.Show("Preencha os todos os campos da resposta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            if (title.Length > 0 && type.Length > 0)
            {
                //Labels
                this.lblAnswerTitle.Text = "Resposta";
                this.lblAnswerJump.Text = "Saltar para";
                this.lblAnswerTitle.Location = new System.Drawing.Point(10, 100);
                this.lblAnswerTitle.Size = new System.Drawing.Size(70, 25);
                this.lblAnswerJump.Location = new System.Drawing.Point(10, 130);
                this.lblAnswerJump.Size = new System.Drawing.Size(70, 25);
                this.lblAnswerJump.Font = new Font("Roboto", this.lblType.Font.Size);
                this.lblAnswerTitle.Font = new Font("Roboto", this.lblType.Font.Size);
                this.lblAnswerTitle.ForeColor = Color.FromArgb(87, Color.Black);
                this.lblAnswerJump.ForeColor = Color.FromArgb(87, Color.Black);
                //TextBoxes
                this.txtAnswerTitle.Location = new System.Drawing.Point(80, 100);
                this.txtAnswerTitle.Size = new System.Drawing.Size(400, 25);
                this.txtAnswerJump.Location = new System.Drawing.Point(80, 130);
                this.txtAnswerJump.Size = new System.Drawing.Size(50, 25);
                this.txtAnswerJump.Minimum = -1;
                //Button
                this.btnAnswer.Location = new System.Drawing.Point(80, 170);
                //Add Controls to form
                this.Controls.Add(txtAnswerTitle);
                this.Controls.Add(txtAnswerJump);
                this.Controls.Add(lblAnswerTitle);
                this.Controls.Add(lblAnswerJump);
                //Update variables
                this.txtboxTitle.ReadOnly = true;
                this.addingAnswers = true;
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

        private void formClosingEvent(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Deseja sair? ", "Informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                return;
            } else
            {
                e.Cancel = true;
            }
        }
    }
}