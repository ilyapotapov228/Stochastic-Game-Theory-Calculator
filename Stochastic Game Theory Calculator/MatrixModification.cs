using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stochastic_Game_Theory_Calculator.Models;

namespace Stochastic_Game_Theory_Calculator
{
    public partial class MatrixModification : Form
    {
        public Matrix currentMatrix = new Matrix();

        public void recieveMatrix(Matrix matrix)
        {
            currentMatrix = matrix;
        }

        public MatrixModification()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MatrixModification_Load(object sender, EventArgs e)
        {
            MatrixBlueprint.RowCount = currentMatrix.rows + 2;
            MatrixBlueprint.ColumnCount = currentMatrix.cols + 2;

            MatrixBlueprint.ColumnHeadersVisible = false;
            MatrixBlueprint.RowHeadersVisible = false;
            MatrixBlueprint.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            MatrixBlueprint.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MatrixBlueprint.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int r = 0; r < currentMatrix.rows; r++)
            {
                for (int c = 0; c < currentMatrix.cols; c++)
                {
                    MatrixBlueprint[c+2, r+2].Value = currentMatrix.payoffs[r, c];
                }
            }
            MatrixBlueprint.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            MatrixBlueprint.RowTemplate.Height = 40;
            MatrixBlueprint[MatrixBlueprint.RowCount / 2, 0].Value = currentMatrix.Players[0];
            MatrixBlueprint[0, MatrixBlueprint.ColumnCount / 2].Value = currentMatrix.Players[1];
            MatrixBlueprint[0, 0].Value = currentMatrix.MatrixID;

            for (int c = 0; c < currentMatrix.cols; c++)
            {
                MatrixBlueprint[c + 2, 1].Value = currentMatrix.ColStrategies[c];
            }

            for (int r = 0; r < currentMatrix.rows; r++)
            {
                MatrixBlueprint[1, r + 2].Value = currentMatrix.RowStrategies[r];
            }
        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < currentMatrix.rows; r++)
            {
                for (int c = 0; c < currentMatrix.cols; c++)
                {
                    currentMatrix.payoffs[r, c] = MatrixBlueprint[c + 2, r + 2].Value.ToString();
                }
            }

            for (int c = 0; c < currentMatrix.cols; c++)
            {
                currentMatrix.ColStrategies[c] = MatrixBlueprint[c + 2, 1].Value.ToString();    
            }

            for (int r = 0; r < currentMatrix.rows; r++)
            {
                currentMatrix.RowStrategies[r] = MatrixBlueprint[1, r + 2].Value.ToString();
            }
            currentMatrix.Players[0] = MatrixBlueprint[MatrixBlueprint.RowCount / 2, 0].Value.ToString();
            currentMatrix.Players[1] = MatrixBlueprint[0, MatrixBlueprint.ColumnCount / 2].Value.ToString();
        }

        public void DisplayMatrix(Matrix matrix)
        {
            currentMatrix = matrix;
            MatrixBlueprint.RowCount = currentMatrix.rows + 2;
            MatrixBlueprint.ColumnCount = currentMatrix.cols + 2;

            MatrixBlueprint.ColumnHeadersVisible = false;
            MatrixBlueprint.RowHeadersVisible = false;
            MatrixBlueprint.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            MatrixBlueprint.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MatrixBlueprint.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int r = 0; r < currentMatrix.rows; r++)
            {
                for (int c = 0; c < currentMatrix.cols; c++)
                {
                    MatrixBlueprint[c + 2, r + 2].Value = currentMatrix.payoffs[r, c];
                }
            }
            MatrixBlueprint.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            MatrixBlueprint.RowTemplate.Height = 40;
            MatrixBlueprint[MatrixBlueprint.RowCount / 2, 0].Value = currentMatrix.Players[0];
            MatrixBlueprint[0, MatrixBlueprint.ColumnCount / 2].Value = currentMatrix.Players[1];
            MatrixBlueprint[0, 0].Value = currentMatrix.MatrixID;

            for (int c = 0; c < currentMatrix.cols; c++)
            {
                MatrixBlueprint[c + 2, 1].Value = currentMatrix.ColStrategies[c];
            }

            for (int r = 0; r < currentMatrix.rows; r++)
            {
                MatrixBlueprint[1, r + 2].Value = currentMatrix.RowStrategies[r];
            }
        }

    }
}
