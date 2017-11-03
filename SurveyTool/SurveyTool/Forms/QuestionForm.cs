using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;

namespace SurveyTool
{
    public partial class QuestionForm : Form
    {
        private Survey survey;
        private List<Question> questions = new List<Question>();
        private List<Answer> answers = new List<Answer>();
        private Label lblType = new Label();
        private Label lblTitle = new Label();
        private Label lblAnswerTitle = new Label();
        private Label lblAnswerJumpTo = new Label();
        private TextBox txtboxTitle = new TextBox();
        private TextBox txtAnswerTitle = new TextBox();
        private NumericUpDown txtAnswerJump = new NumericUpDown();
        private ComboBox cbType = new ComboBox();
        private Button btnAdd = new Button();
        private Button btnDone = new Button();
        private Button btnAnswer = new Button();
        private string title, type;
        private bool addingAnswers = false;

        /// <summary>
        ///  Form where the user fills the question and answer fields.
        /// </summary>
        public QuestionForm(Survey survey)
        {
            this.survey = survey;
            InitializeComponent();
            InitializeControls();
            InitializeOnClicks();
            FormClosing += Form1_Closing;
            HelpButtonClicked += QuestionForm_HelpButtonClicked;
        }

        /// <summary>
        ///  Help button opens a pdf file that serves as a user guide.
        /// </summary>
        private void QuestionForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Manual.pdf");
            String openPDFFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Manual.pdf";
            File.WriteAllBytes(openPDFFile, Properties.Resources.Manual);
            System.Diagnostics.Process.Start(openPDFFile);
            e.Cancel = true;
        }

        /// <summary>
        ///  Adds eventHandlers to each button.
        /// </summary>
        private void InitializeOnClicks()
        {
            btnAnswer.Click += new EventHandler(NewAnswerClick);
            btnAdd.Click += new EventHandler(AddClick);
            btnDone.Click += new EventHandler(DoneClick);
        }

        /// <summary>
        ///  Initializes the form and it's elements.
        /// </summary>
        private void InitializeControls()
        {
            //Resources
            BackColor = Color.FromArgb(250, 250, 250);
            ForeColor = Color.FromArgb(100, 34, 34, 34);
            Text = "Nova | Pergunta " + (questions.Count + 1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(500, 300);
            //Label - Titulo da pergunta
            lblTitle.Location = new Point(10, 13);
            lblTitle.Size = new Size(70, 25);
            lblTitle.Text = "Pergunta";
            lblTitle.Font = new Font("Roboto", 9, FontStyle.Regular);
            // Text Box - Title
            txtboxTitle.Location = new Point(80, 10);
            txtboxTitle.Size = new Size(400, 25);
            txtboxTitle.ReadOnly = false;
            txtboxTitle.Text = String.Empty;
            txtboxTitle.Font = new Font("Roboto", 9, FontStyle.Regular);
            //Label - Tipo de pergunta
            lblType.Location = new Point(10, 50);
            lblType.Size = new Size(70, 50);
            lblType.Text = "Tipo de Pergunta";
            lblType.Font = new Font("Roboto", 9, FontStyle.Regular);
            // ComboBox - Types
            cbType.Items.Clear();
            cbType.Items.Insert(0, "oneof");
            cbType.Items.Insert(1, "atleast");
            cbType.Items.Insert(2, "dropdown");
            cbType.Items.Insert(3, "fillstring");
            cbType.Items.Insert(4, "fillint");
            cbType.Location = new Point(80, 50);
            cbType.Size = new Size(100, 25);
            cbType.Sorted = true;
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.FlatStyle = FlatStyle.Popup;
            cbType.Enabled = true;
            //Button - Next
            btnAdd.Text = "ADICIONAR PERGUNTA";
            btnAdd.Location = new Point(230, 200);
            btnAdd.Size = new Size(120, 50);
            btnAdd.Font = new Font("Roboto", 11, FontStyle.Regular);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.BackColor = Color.FromArgb(0, 255, 255, 255);
            btnAdd.ForeColor = Color.FromArgb(100, 20, 103, 255);
            //Button - End
            btnDone.Text = "FINALIZAR";
            btnDone.Location = new Point(350, 200);
            btnDone.Size = new Size(120, 50);
            btnDone.Font = new Font("Roboto", 11, FontStyle.Regular);
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.FlatAppearance.BorderSize = 0;
            btnDone.BackColor = Color.FromArgb(0, 255, 255, 255);
            btnDone.ForeColor = Color.FromArgb(100, 20, 103, 255);
            //Button - Add Answer
            btnAnswer.Image = Properties.Resources.add;
            btnAnswer.ImageAlign = ContentAlignment.MiddleRight;
            btnAnswer.Location = new Point(80, 90);
            btnAnswer.Size = new Size(30, 30);
            btnAnswer.FlatStyle = FlatStyle.Flat;
            btnAnswer.FlatAppearance.BorderSize = 0;
            btnAnswer.BackColor = Color.FromArgb(100, 239, 239, 239);
            //Add Controls to form
            Controls.Add(txtboxTitle);
            Controls.Add(lblTitle);
            Controls.Add(lblType);
            Controls.Add(cbType);
            Controls.Add(btnAnswer);
            Controls.Add(btnAdd);
            Controls.Add(btnDone);
        }

        /// <summary>
        ///  Adds a question to the survey, question fields as well as respective answers must be filled first.
        /// </summary>
        void AddClick(object sender, EventArgs e)
        {
            title = txtboxTitle.Text;
            type = cbType.Text;
            if (title.Length > 0 && type.Length > 0)
            {
                if (answers.Count > 0)
                {
                    Question question = new Question(questions.Count + 1, title, type);
                    for (int i = 0; i < answers.Count; i++)
                    {
                        question.Answers.Add(answers[i]);
                    }
                    questions.Add(question);
                    addingAnswers = false;
                    answers.Clear();
                    Controls.Clear();
                    InitializeControls();
                }
                else
                {
                    MessageBox.Show("Adicione pelo menos uma resposta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos em falta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        ///  When the finish button is clicked.
        ///  Closes application and opens file.
        /// </summary>
        protected void DoneClick(object sender, EventArgs e)
        {
            survey.Questions = questions;
            string strPath = SaveJSONFile();
            DialogResult dialog = MessageBox.Show(questions.Count + " Perguntas adicionadas", "Informação", MessageBoxButtons.OK, MessageBoxIcon.None);
            if (dialog == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(strPath);
                Application.Exit();
            }
        }

        /// <summary>
        ///  Shows answer fields, if they are hidden, otherwise, adds answer to survey.
        /// </summary>
        protected void NewAnswerClick(object sender, EventArgs e)
        {
            title = txtboxTitle.Text;
            type = cbType.Text;
            if (addingAnswers)
            {
                if (txtAnswerTitle.Text.Length > 0 && txtAnswerJump.Value >= -1)
                {
                    Answer newAnswer = new Answer
                    {
                        Title = txtAnswerTitle.Text,
                        Jump = Convert.ToInt32(txtAnswerJump.Value)
                    };
                    answers.Add(newAnswer);
                    if (type == "fillint" || type == "fillstring")
                    {
                        Question question = new Question(questions.Count + 1, title, type);
                        for (int i = 0; i < answers.Count; i++)
                        {
                            question.Answers.Add(answers[i]);
                        }
                        questions.Add(question);
                        addingAnswers = false;
                        answers.Clear();
                        Controls.Clear();
                        txtAnswerTitle.Text = "";
                        txtAnswerJump.Value = 0;
                        InitializeControls();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Resposta adicionada", "Informação", MessageBoxButtons.OK, MessageBoxIcon.None);
                        txtAnswerTitle.Text = "";
                        txtAnswerJump.Value = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Preencha os todos os campos da resposta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else if (title.Length > 0 && type.Length > 0)
            {
                //Labels
                lblAnswerTitle.Text = "Resposta";
                lblAnswerJumpTo.Text = "Saltar para";
                lblAnswerTitle.Location = new Point(10, 100);
                lblAnswerJumpTo.Location = new Point(10, 140);
                lblAnswerTitle.Size = new Size(80, 40);
                lblAnswerJumpTo.Size = new Size(80, 40);
                lblAnswerTitle.Font = new Font("Roboto", 9, FontStyle.Regular);
                lblAnswerJumpTo.Font = new Font("Roboto", 9, FontStyle.Regular);
                //TextBoxes
                txtAnswerTitle.Location = new Point(90, 100);
                txtAnswerJump.Location = new Point(90, 140);
                txtAnswerTitle.Size = new Size(390, 25);
                txtAnswerJump.Size = new Size(50, 25);
                txtAnswerJump.Minimum = -1;
                //Add Controls
                Controls.Add(txtAnswerTitle);
                Controls.Add(lblAnswerTitle);
                if (type == "oneof" || type == "dropdown")
                {
                    Controls.Add(lblAnswerJumpTo);
                    Controls.Add(txtAnswerJump);
                    btnAnswer.Location = new Point(80, 170);

                }
                else
                {
                    if (type == "fillint" || type == "fillstring")
                    {
                        lblAnswerTitle.Text = "Dica na Resposta";
                    }
                    btnAnswer.Location = new Point(80, 130);
                }
                txtboxTitle.ReadOnly = true;
                cbType.Enabled = false;
                addingAnswers = true;
            }
            else
            {
                MessageBox.Show("Preencha a pergunta e o tipo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        ///  Saves JSON file in the desktop in a folder "SurveyTool".
        ///  Shows Dialog informing the user that the file has been saved.
        ///  returns json file path.
        /// </summary>
        public string SaveJSONFile()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SurveyTool");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\SurveyTool\" + survey.Title + ".json";
            string json = JsonConvert.SerializeObject(survey);
            File.WriteAllText(strPath, json);
            return strPath;
        }

        /// <summary>
        ///  Shows Dialog warning user that the application will close.
        ///  If users accepts, closes the application.
        /// </summary>
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialog = MessageBox.Show("Sair sem guardar? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
