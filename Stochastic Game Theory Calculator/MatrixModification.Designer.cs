namespace Stochastic_Game_Theory_Calculator
{
    partial class MatrixModification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatrixModification));
            this.MatrixBlueprint = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveChanges = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixBlueprint)).BeginInit();
            this.SuspendLayout();
            // 
            // MatrixBlueprint
            // 
            this.MatrixBlueprint.AllowUserToOrderColumns = true;
            this.MatrixBlueprint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MatrixBlueprint.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MatrixBlueprint.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.MatrixBlueprint.ColumnHeadersHeight = 46;
            this.MatrixBlueprint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.MatrixBlueprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MatrixBlueprint.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.MatrixBlueprint.Location = new System.Drawing.Point(0, 0);
            this.MatrixBlueprint.Name = "MatrixBlueprint";
            this.MatrixBlueprint.RowHeadersWidth = 82;
            this.MatrixBlueprint.RowTemplate.Height = 33;
            this.MatrixBlueprint.Size = new System.Drawing.Size(964, 619);
            this.MatrixBlueprint.TabIndex = 0;
            this.MatrixBlueprint.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            // 
            // SaveChanges
            // 
            this.SaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SaveChanges.Location = new System.Drawing.Point(838, 565);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(114, 48);
            this.SaveChanges.TabIndex = 1;
            this.SaveChanges.Text = "Save";
            this.SaveChanges.UseVisualStyleBackColor = true;
            this.SaveChanges.Click += new System.EventHandler(this.SaveChanges_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(12, 572);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add Row";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point(133, 572);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete Row";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Location = new System.Drawing.Point(310, 572);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Add Column";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button4.Location = new System.Drawing.Point(463, 572);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "Delete Column";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MatrixModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 619);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SaveChanges);
            this.Controls.Add(this.MatrixBlueprint);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MatrixModification";
            this.Text = "Matrix Modification";
            this.Load += new System.EventHandler(this.MatrixModification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MatrixBlueprint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MatrixBlueprint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button SaveChanges;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}