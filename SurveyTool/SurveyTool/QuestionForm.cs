﻿using System;
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
        private Label lblAnswerJump = new Label();
        private TextBox txtboxTitle = new TextBox();
        private TextBox txtAnswerTitle = new TextBox();
        private NumericUpDown txtAnswerJump = new NumericUpDown();
        private ComboBox cbType = new ComboBox();
        private Button btnAdd = new Button();
        private Button btnDone = new Button();
        private Button btnAnswer = new Button();
        private string title, type;
        private bool addingAnswers = false;

        public QuestionForm(Survey survey)
        {
            this.survey = survey;
            InitializeComponent();
            initializeControls();
            initializeOnClicks();
            this.FormClosing += Form1_Closing;
            this.HelpButtonClicked += QuestionForm_HelpButtonClicked;
        }

        private void QuestionForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Manual.pdf");
            String openPDFFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Manual.pdf";
            System.IO.File.WriteAllBytes(openPDFFile, global::SurveyTool.Properties.Resources.Manual);
            System.Diagnostics.Process.Start(openPDFFile);
            Console.WriteLine("Help Buton pressed");
            e.Cancel = true;
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
            this.ForeColor = Color.FromArgb(100, 34, 34, 34);
            this.Text = "Nova | Pergunta " + (questions.Count + 1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(500, 300);
            //Label - Titulo da pergunta
            this.lblTitle.Location = new System.Drawing.Point(10, 13);
            this.lblTitle.Size = new System.Drawing.Size(70, 25);
            this.lblTitle.Text = "Pergunta";
            this.lblTitle.Font = new Font("Roboto", 9, FontStyle.Regular);
            // Text Box - Title
            this.txtboxTitle.Location = new System.Drawing.Point(80, 10);
            this.txtboxTitle.Size = new System.Drawing.Size(400, 25);
            this.txtboxTitle.ReadOnly = false;
            this.txtboxTitle.Text = String.Empty;
            this.txtboxTitle.Font = new Font("Roboto", 9, FontStyle.Regular);
            //Label - Tipo de pergunta
            this.lblType.Location = new System.Drawing.Point(10, 50);
            this.lblType.Size = new System.Drawing.Size(70, 50);
            this.lblType.Text = "Tipo de Pergunta";
            this.lblType.Font = new Font("Roboto", 9, FontStyle.Regular);
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
            this.cbType.FlatStyle = FlatStyle.Popup;
            this.cbType.Enabled = true;
            //Button - Next
            this.btnAdd.Text = "ADICIONAR PERGUNTA";
            this.btnAdd.Location = new System.Drawing.Point(230, 200);
            this.btnAdd.Size = new System.Drawing.Size(120, 50);
            this.btnAdd.Font = new Font("Roboto", 11, FontStyle.Regular);
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.BackColor = Color.FromArgb(0, 255, 255, 255);
            this.btnAdd.ForeColor = Color.FromArgb(100, 20, 103, 255);
            //Button - End
            this.btnDone.Text = "FINALIZAR";
            this.btnDone.Location = new System.Drawing.Point(350, 200);
            this.btnDone.Size = new System.Drawing.Size(120, 50);
            this.btnDone.Font = new Font("Roboto", 11, FontStyle.Regular);
            this.btnDone.FlatStyle = FlatStyle.Flat;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.BackColor = Color.FromArgb(0, 255, 255, 255);
            this.btnDone.ForeColor = Color.FromArgb(100, 20, 103, 255);
            //Button - Add Answer
            this.btnAnswer.Image = Properties.Resources.add;
            this.btnAnswer.ImageAlign = ContentAlignment.MiddleRight;
            this.btnAnswer.Location = new System.Drawing.Point(80, 90);
            this.btnAnswer.Size = new System.Drawing.Size(30, 30);
            this.btnAnswer.FlatStyle = FlatStyle.Flat;
            this.btnAnswer.FlatAppearance.BorderSize = 0;
            this.btnAnswer.BackColor = Color.FromArgb(100, 239, 239, 239);
            //Add Controls to form
            this.Controls.Add(txtboxTitle);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblType);
            this.Controls.Add(cbType);
            this.Controls.Add(btnAnswer);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnDone);
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
                    this.addingAnswers = false;
                    this.answers.Clear();
                    this.Controls.Clear();
                    initializeControls();
                } else
                {
                    MessageBox.Show("Adicione pelo menos uma resposta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            } else
            {
                MessageBox.Show("Preencha todos os campos em falta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        protected void doneClick(object sender, EventArgs e)
        {
            survey.Questions = questions;
            saveJSONFile();
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
                    if(this.type == "fillint" || this.type == "fillstring")
                    {
                        Question question = new Question(questions.Count + 1, title, type);
                        for (int i = 0; i < answers.Count; i++)
                        {
                            question.Answers.Add(answers[i]);
                        }
                        Console.WriteLine("Question added: " + question.Title + ", " + question.Type + ": " + answers.Count);
                        questions.Add(question);
                        this.addingAnswers = false;
                        this.answers.Clear();
                        this.Controls.Clear();
                        this.txtAnswerTitle.Text = "";
                        this.txtAnswerJump.Value = 0;
                        initializeControls();
                        return;
                    } else
                    {
                        MessageBox.Show("Resposta adicionada", "Informação", MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.txtAnswerTitle.Text = "";
                        this.txtAnswerJump.Value = 0;
                    }
                } else
                {
                    MessageBox.Show("Preencha os todos os campos da resposta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            } else if (title.Length > 0 && type.Length > 0)
            {
                //Labels
                this.lblAnswerTitle.Text = "Resposta";
                this.lblAnswerJump.Text = "Saltar para";
                this.lblAnswerTitle.Location = new System.Drawing.Point(10, 100);
                this.lblAnswerJump.Location = new System.Drawing.Point(10, 130);
                this.lblAnswerTitle.Size = new System.Drawing.Size(70, 50);
                this.lblAnswerJump.Size = new System.Drawing.Size(70, 25);
                this.lblAnswerJump.Font = new Font("Roboto", 9, FontStyle.Regular);
                this.lblAnswerTitle.Font = new Font("Roboto", 9, FontStyle.Regular);
                //TextBoxes
                this.txtAnswerTitle.Location = new System.Drawing.Point(80, 100);
                this.txtAnswerTitle.Size = new System.Drawing.Size(400, 25);
                this.txtAnswerJump.Location = new System.Drawing.Point(80, 130);
                this.txtAnswerJump.Size = new System.Drawing.Size(50, 25);
                this.txtAnswerJump.Minimum = -1;
                //Add Controls
                this.Controls.Add(txtAnswerTitle);
                this.Controls.Add(lblAnswerTitle);
                if (type == "oneof" || type == "dropdown")
                {
                    this.Controls.Add(txtAnswerJump);
                    this.Controls.Add(lblAnswerJump);
                    this.btnAnswer.Location = new System.Drawing.Point(80, 170);
                } else
                {
                    if(type == "fillint" || type == "fillstring")
                    {
                        this.lblAnswerTitle.Text = "Ajuda na Resposta";
                    }
                    this.btnAnswer.Location = new System.Drawing.Point(80, 130);
                }
                this.txtboxTitle.ReadOnly = true;
                this.cbType.Enabled = false;
                this.addingAnswers = true;
            } else
            {
                MessageBox.Show("Preencha a pergunta e o tipo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void saveJSONFile()
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SurveyTool");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\SurveyTool\" + survey.Title +".json";
            string json = JsonConvert.SerializeObject(survey);
            System.IO.File.WriteAllText(strPath, json);
            DialogResult dialog = MessageBox.Show(questions.Count + " Perguntas adicionadas", "Informação", MessageBoxButtons.OK, MessageBoxIcon.None);
            if (dialog == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(strPath);
                Application.Exit();
            }
        }
        
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialog = MessageBox.Show("Deseja sair? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                } else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}