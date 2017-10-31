namespace SurveyTool
{
    partial class FirstForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxIntro = new System.Windows.Forms.TextBox();
            this.labelIntro = new System.Windows.Forms.Label();
            this.textBoxOutro = new System.Windows.Forms.TextBox();
            this.labelOutro = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial Unicode MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(60, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Titulo";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(80, 10);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(425, 26);
            this.textBoxTitle.TabIndex = 1;
            // 
            // textBoxIntro
            // 
            this.textBoxIntro.AcceptsReturn = true;
            this.textBoxIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIntro.Location = new System.Drawing.Point(80, 62);
            this.textBoxIntro.Multiline = true;
            this.textBoxIntro.Name = "textBoxIntro";
            this.textBoxIntro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxIntro.Size = new System.Drawing.Size(425, 90);
            this.textBoxIntro.TabIndex = 3;
            // 
            // labelIntro
            // 
            this.labelIntro.AutoSize = true;
            this.labelIntro.Font = new System.Drawing.Font("Arial Unicode MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntro.Location = new System.Drawing.Point(12, 61);
            this.labelIntro.Name = "labelIntro";
            this.labelIntro.Size = new System.Drawing.Size(52, 26);
            this.labelIntro.TabIndex = 2;
            this.labelIntro.Text = "Intro";
            // 
            // textBoxOutro
            // 
            this.textBoxOutro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutro.Location = new System.Drawing.Point(80, 181);
            this.textBoxOutro.Multiline = true;
            this.textBoxOutro.Name = "textBoxOutro";
            this.textBoxOutro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutro.Size = new System.Drawing.Size(425, 90);
            this.textBoxOutro.TabIndex = 5;
            // 
            // labelOutro
            // 
            this.labelOutro.AutoSize = true;
            this.labelOutro.Font = new System.Drawing.Font("Arial Unicode MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOutro.Location = new System.Drawing.Point(12, 180);
            this.labelOutro.Name = "labelOutro";
            this.labelOutro.Size = new System.Drawing.Size(63, 26);
            this.labelOutro.TabIndex = 4;
            this.labelOutro.Text = "Outro";
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(650, 300);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(100, 50);
            this.buttonNext.TabIndex = 6;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // FirstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.ControlBox = false;
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textBoxOutro);
            this.Controls.Add(this.labelOutro);
            this.Controls.Add(this.textBoxIntro);
            this.Controls.Add(this.labelIntro);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FirstForm";
            this.Text = "New Survey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxIntro;
        private System.Windows.Forms.Label labelIntro;
        private System.Windows.Forms.TextBox textBoxOutro;
        private System.Windows.Forms.Label labelOutro;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxTitle;
    }
}

