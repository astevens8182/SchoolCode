namespace Homework1
{
    partial class Form1
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.rtxtReport = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(718, 12);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // rtxtReport
            // 
            this.rtxtReport.Location = new System.Drawing.Point(12, 12);
            this.rtxtReport.Name = "rtxtReport";
            this.rtxtReport.Size = new System.Drawing.Size(700, 385);
            this.rtxtReport.TabIndex = 2;
            this.rtxtReport.Text = "";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(718, 41);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 428);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rtxtReport);
            this.Controls.Add(this.btnCalculate);
            this.Name = "Form1";
            this.Text = "Employee Pay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.RichTextBox rtxtReport;
        private System.Windows.Forms.Button btnExit;
    }
}

