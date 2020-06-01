namespace IndGraphCykl
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.run = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.graphMatrix = new System.Windows.Forms.RichTextBox();
            this.cykleNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(344, 343);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(120, 50);
            this.run.TabIndex = 0;
            this.run.Text = "Выполнить";
            this.run.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.Run_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Матрица смежности графа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество простых циклов графа:";
            // 
            // graphMatrix
            // 
            this.graphMatrix.Location = new System.Drawing.Point(76, 112);
            this.graphMatrix.Name = "graphMatrix";
            this.graphMatrix.Size = new System.Drawing.Size(219, 199);
            this.graphMatrix.TabIndex = 4;
            this.graphMatrix.Text = "";
            // 
            // cykleNumber
            // 
            this.cykleNumber.Location = new System.Drawing.Point(538, 175);
            this.cykleNumber.Name = "cykleNumber";
            this.cykleNumber.Size = new System.Drawing.Size(100, 20);
            this.cykleNumber.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cykleNumber);
            this.Controls.Add(this.graphMatrix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.run);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox graphMatrix;
        private System.Windows.Forms.TextBox cykleNumber;
    }
}

