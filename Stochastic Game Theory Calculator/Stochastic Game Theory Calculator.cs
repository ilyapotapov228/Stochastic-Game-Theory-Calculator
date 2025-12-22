using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stochastic_Game_Theory_Calculator.Models;

namespace Stochastic_Game_Theory_Calculator
{
    public partial class mainWindow : Form
    {
        private float zoomDelta = 0.6f;
        private PointF zoomFoc = new PointF(0, 0);
        private Models.Matrix currentMatrix;
        private Graph currentGraph;
        private int currentSimulations;
        public Models.Matrix[] savedMaticies;
        public int matrixID = 0;
        private int graphID = 0;
        private Graph[] savedGraphs;
        public Font text_font = new Font("Times New Roman", 11, FontStyle.Regular);

        public mainWindow()
        {
            InitializeComponent();
            Canvas.MouseWheel += Canvas_MouseWheel;
        }

        class Algorithms
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            savedMaticies = new Models.Matrix[100];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MatrixInitialise_Click(object sender, EventArgs e)
        {
            currentMatrix = new Models.Matrix();
            currentMatrix = currentMatrix.defaultMatrix();
            currentMatrix.setMatrixID(matrixID);
            currentMatrix.X = 100;
            currentMatrix.Y = 70;
            MatrixModification MM = new MatrixModification();
            MM.recieveMatrix(currentMatrix);
            MM.ShowDialog();
            if (MM.isSaved)
            {
                savedMaticies[currentMatrix.MatrixID] = MM.currentMatrix;
                matrixID++;
                Canvas.Invalidate();
            }
        }
        private void tutorialButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=rA57mAI6cKc");
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
       
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(zoomFoc.X, zoomFoc.Y);
            e.Graphics.ScaleTransform(zoomDelta, zoomDelta);

            foreach (var matrix in savedMaticies)
            {
                if (matrix != null)
                {
                    DrawMatrix(e.Graphics, matrix);
                }
            }
        }

        private void DrawMatrix(Graphics g, Models.Matrix matrix)
        {

            float cellH = 60;
            float cellW = 100;
            float longestCol = 0;

            foreach (string s in matrix.ColStrategies)
            {
                SizeF size = g.MeasureString(s, text_font);
                if (size.Width > longestCol)
                {
                    longestCol = size.Width;
                }
            }

            cellW = Math.Max(cellH, longestCol + 20);

            float gridW = matrix.cols * cellW;
            float gridH = matrix.rows * cellH;

            RectangleF currentGrid = new RectangleF(matrix.X + cellW, matrix.Y + cellH, gridW, gridH);
            g.FillRectangle(Brushes.White, currentGrid);
            g.DrawRectangle(Pens.Black, currentGrid.X, currentGrid.Y, currentGrid.Width, currentGrid.Height);

            using (Pen gridPen = new Pen(Color.Black, 1))
            using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(matrix.Players[0], text_font, Brushes.Black, new PointF(matrix.X - 35, matrix.Y + cellH + (gridH / 2)), format);
                g.DrawString(matrix.Players[1], text_font, Brushes.Black, new PointF(matrix.X + (gridW/2)+80, matrix.Y - 15));

                for (int r = 0; r < matrix.rows; r++)
                {
                    float rowYcord = matrix.Y + cellH + (r * cellH);
                    RectangleF rowStrats = new RectangleF(matrix.X, rowYcord, cellW, cellH);
                    g.DrawString(matrix.RowStrategies[r], text_font, Brushes.Black, rowStrats, format);

                    for (int c = 0; c < matrix.cols; c++)
                    {
                        float colXcrd = matrix.X + cellW + (c * cellW);

                        if (r == 0)
                        {
                            RectangleF colHeaderRect = new RectangleF(colXcrd, matrix.Y, cellW, cellH);
                            g.DrawString(matrix.ColStrategies[c], text_font, Brushes.Black, colHeaderRect, format);
                        }
                        g.DrawRectangle(gridPen, colXcrd, rowYcord, cellW, cellH);

                        RectangleF cellPic = new RectangleF(colXcrd, rowYcord, cellW, cellH);
                        g.DrawString(matrix.payoffs[r, c], text_font, Brushes.Black, cellPic, format);
                    }
                }
            }
        }

        private void Canvas_MouseWheel(object sender, MouseEventArgs e)
        {

            float canvX = (e.X - zoomFoc.X) / zoomDelta;
            float cnavY = (e.Y - zoomFoc.Y) / zoomDelta;

            if(e.Delta > 0)
            {
                zoomDelta = zoomDelta * 1.1f;
            }
            else
            {
                zoomDelta = zoomDelta * 0.9f;
            }

            if (zoomDelta < 0.5f)
            {
                zoomDelta = 0.5f;
            }
            if (zoomDelta > 4.0f)
            {
                zoomDelta = 4.0f;
            }

            zoomFoc.X = e.X - (canvX * zoomDelta);
            zoomFoc.Y = e.Y - (cnavY * zoomDelta);

            Canvas.Invalidate();
        }

        private void SimulationInitialise_Click(object sender, EventArgs e)
        {
            StochasticModification SM = new StochasticModification();
            SM.ShowDialog();
            currentSimulations = SM.itterations;
        }
    }
}