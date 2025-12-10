namespace Stochastic_Game_Theory_Calculator
{
    partial class Form1
    {
  
        private System.ComponentModel.IContainer components = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ModelSelection = new System.Windows.Forms.Label();
            this.MatrixInitialise = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox1.Location = new System.Drawing.Point(436, 107);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1632, 1324);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ModelSelection
            // 
            this.ModelSelection.AutoSize = true;
            this.ModelSelection.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelSelection.Location = new System.Drawing.Point(29, 54);
            this.ModelSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModelSelection.Name = "ModelSelection";
            this.ModelSelection.Size = new System.Drawing.Size(268, 42);
            this.ModelSelection.TabIndex = 2;
            this.ModelSelection.Text = "Model Selection";
            // 
            // MatrixInitialise
            // 
            this.MatrixInitialise.Location = new System.Drawing.Point(36, 185);
            this.MatrixInitialise.Name = "MatrixInitialise";
            this.MatrixInitialise.Size = new System.Drawing.Size(214, 84);
            this.MatrixInitialise.TabIndex = 3;
            this.MatrixInitialise.Text = "Normal Form";
            this.MatrixInitialise.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2197, 1350);
            this.Controls.Add(this.MatrixInitialise);
            this.Controls.Add(this.ModelSelection);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Stochastic Game Theory Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ModelSelection;
        private System.Windows.Forms.Button MatrixInitialise;
    }
}

