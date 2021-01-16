namespace Dots_and_boxes
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelHumanScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelComputerScore = new System.Windows.Forms.Label();
            this.Winerlabel = new System.Windows.Forms.Label();
            this.PlayAgainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(400, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your score:";
            // 
            // labelHumanScore
            // 
            this.labelHumanScore.AutoSize = true;
            this.labelHumanScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHumanScore.ForeColor = System.Drawing.Color.Blue;
            this.labelHumanScore.Location = new System.Drawing.Point(400, 75);
            this.labelHumanScore.Name = "labelHumanScore";
            this.labelHumanScore.Size = new System.Drawing.Size(0, 20);
            this.labelHumanScore.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(400, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Computer\'s score:";
            // 
            // labelComputerScore
            // 
            this.labelComputerScore.AutoSize = true;
            this.labelComputerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComputerScore.ForeColor = System.Drawing.Color.Red;
            this.labelComputerScore.Location = new System.Drawing.Point(400, 135);
            this.labelComputerScore.Name = "labelComputerScore";
            this.labelComputerScore.Size = new System.Drawing.Size(0, 20);
            this.labelComputerScore.TabIndex = 3;
            // 
            // Winerlabel
            // 
            this.Winerlabel.AutoSize = true;
            this.Winerlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Winerlabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.Winerlabel.Location = new System.Drawing.Point(400, 188);
            this.Winerlabel.Name = "Winerlabel";
            this.Winerlabel.Size = new System.Drawing.Size(0, 29);
            this.Winerlabel.TabIndex = 4;
            // 
            // PlayAgainButton
            // 
            this.PlayAgainButton.BackColor = System.Drawing.Color.OrangeRed;
            this.PlayAgainButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayAgainButton.Location = new System.Drawing.Point(382, 257);
            this.PlayAgainButton.Name = "PlayAgainButton";
            this.PlayAgainButton.Size = new System.Drawing.Size(118, 39);
            this.PlayAgainButton.TabIndex = 5;
            this.PlayAgainButton.Text = "Play Again";
            this.PlayAgainButton.UseVisualStyleBackColor = false;
            this.PlayAgainButton.Visible = false;
            this.PlayAgainButton.Click += new System.EventHandler(this.PlayAgainButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.PlayAgainButton);
            this.Controls.Add(this.Winerlabel);
            this.Controls.Add(this.labelComputerScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelHumanScore);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Dots and boxes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHumanScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelComputerScore;
        private System.Windows.Forms.Label Winerlabel;
        private System.Windows.Forms.Button PlayAgainButton;
    }
}

