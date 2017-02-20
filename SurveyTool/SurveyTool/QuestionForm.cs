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
    public partial class QuestionForm : Form
    {
        Question question { get; set; }
        private Label lblType = new Label();
        private Label lblTitle = new Label();
        private TextBox txtboxTitle = new TextBox();
        private ComboBox cbType = new ComboBox();
        private Button btnAdd = new Button();
        private Button btnDone = new Button();

        public QuestionForm()
        {
            InitializeComponent();
            initializeControls();
        }

        private void initializeControls()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Text = "Nova pergunta";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(500, 300);
            //Label - Titulo da pergunta
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Size = new System.Drawing.Size(50, 25);
            this.lblTitle.Text = "Pergunta";
            // Text Box
            this.txtboxTitle.Location = new System.Drawing.Point(80, 10);
            this.txtboxTitle.Size = new System.Drawing.Size(400, 25);
            //Label - Tipo de pergunta
            this.lblType.Location = new System.Drawing.Point(10, 50);
            this.lblType.Size = new System.Drawing.Size(50, 50);
            this.lblType.Text = "Tipo de Pergunta";
            // ComboBox - Types
            cbType.Items.Insert(0, "oneof");
            cbType.Items.Insert(1, "atleast");
            cbType.Items.Insert(2, "dropdown");
            cbType.Items.Insert(3, "fillstring");
            cbType.Items.Insert(4, "fillint");
            this.cbType.Location = new System.Drawing.Point(80, 50);
            this.cbType.Size = new System.Drawing.Size(100, 25);
            this.cbType.Sorted = true;
            this.cbType.SelectedValue = this.cbType.Items[0];
            //Button
            this.btnAdd.Click += new EventHandler(addClick);
            this.btnAdd.Text = "Adicionar Respostas";
            this.btnAdd.Location = new System.Drawing.Point(160, 200);
            this.btnAdd.Size = new System.Drawing.Size(150, 50);
            //Button
            this.btnDone.Click += new EventHandler(doneClick);
            this.btnDone.Text = "Finalizar Pergunta";
            this.btnDone.Location = new System.Drawing.Point(320, 200);
            this.btnDone.Size = new System.Drawing.Size(150, 50);

            this.Controls.Add(txtboxTitle);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblType);
            this.Controls.Add(cbType);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnDone);
        }

        protected void addClick(object sender, EventArgs e)
        {
            // TODO
        }

        protected void doneClick(object sender, EventArgs e)
        {
            // TODO
        }

    }
}
