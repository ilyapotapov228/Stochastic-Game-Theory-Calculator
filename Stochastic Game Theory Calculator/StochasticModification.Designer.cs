namespace Stochastic_Game_Theory_Calculator
{
    partial class StochasticModification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StochasticModification));
            this.itterationsLabel = new System.Windows.Forms.Label();
            this.SaveItterations = new System.Windows.Forms.Button();
            this.ittarations_input = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ittarations_input)).BeginInit();
            this.SuspendLayout();
            // 
            // itterationsLabel
            // 
            this.itterationsLabel.AutoSize = true;
            this.itterationsLabel.Location = new System.Drawing.Point(13, 30);
            this.itterationsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itterationsLabel.Name = "itterationsLabel";
            this.itterationsLabel.Size = new System.Drawing.Size(339, 42);
            this.itterationsLabel.TabIndex = 0;
            this.itterationsLabel.Text = "Number of itterations:";
            // 
            // SaveItterations
            // 
            this.SaveItterations.Location = new System.Drawing.Point(655, 22);
            this.SaveItterations.Name = "SaveItterations";
            this.SaveItterations.Size = new System.Drawing.Size(168, 59);
            this.SaveItterations.TabIndex = 1;
            this.SaveItterations.Text = "Save";
            this.SaveItterations.UseVisualStyleBackColor = true;
            this.SaveItterations.Click += new System.EventHandler(this.SaveItterations_Click);
            // 
            // ittarations_input
            // 
            this.ittarations_input.Location = new System.Drawing.Point(359, 28);
            this.ittarations_input.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ittarations_input.Name = "ittarations_input";
            this.ittarations_input.Size = new System.Drawing.Size(222, 50);
            this.ittarations_input.TabIndex = 3;
            this.ittarations_input.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.ittarations_input.ValueChanged += new System.EventHandler(this.ittarations_input_ValueChanged);
            // 
            // StochasticModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(21F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 93);
            this.Controls.Add(this.ittarations_input);
            this.Controls.Add(this.SaveItterations);
            this.Controls.Add(this.itterationsLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "StochasticModification";
            this.Text = "Stochastic Modification";
            ((System.ComponentModel.ISupportInitialize)(this.ittarations_input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itterationsLabel;
        private System.Windows.Forms.Button SaveItterations;
        private System.Windows.Forms.NumericUpDown ittarations_input;
    }
}