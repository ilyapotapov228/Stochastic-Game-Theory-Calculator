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
        // Here I will initialise variables for all subroutines to make them easier to organise and find

        private Models.Matrix currentMatrix;
        public Models.Matrix[] savedMaticies;
        public int matrixID = 0;


        private Graph currentGraph;
        private Graph[] savedGraphs;
        private int graphID = 0;

        private int currentSimulations;

        public Font text_font = new Font("Times New Roman", 11, FontStyle.Regular);

        int inCellBuffer = 0;

        private float zoomDelta = 0.6f;
        private PointF zoomFocus = new PointF(0, 0);
        
        private int movingMatrixID = -1;
        private PointF selectPoint = new PointF(0, 0);
        private PointF startingPosition = new PointF(0, 0);
        private bool isDragged = false;
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
        // This subroutine will handle the initialisation of a new matrix
        private void MatrixInitialise_Click(object sender, EventArgs e)
        {
            currentMatrix = new Models.Matrix();
            currentMatrix = currentMatrix.defaultMatrix();
            currentMatrix.setMatrixID(matrixID);

            MatrixModification MM = new MatrixModification();
            MM.recieveMatrix(currentMatrix);
            MM.ShowDialog();

            if (MM.isSaved)
            {
                currentMatrix.X = 100;
                currentMatrix.Y = 70;
                bool positionVerified = false;

                using (Graphics g = this.CreateGraphics())
                {
                    //try different locaations until it is not taken
                    while (!positionVerified)
                    {
                        //assume true, and if not change back to false
                        positionVerified = true;


                        currentMatrix.hitbox = MatrixBounds(currentMatrix, g);


                        for (int i = 0; i < matrixID; i++)
                        {
                            if (matrixID == i)
                            {
                                continue;
                            }
                            else if (savedMaticies[i] != null)
                            {
                                if (currentMatrix.hitbox.IntersectsWith(savedMaticies[i].hitbox))
                                {
                                    positionVerified = false;
                                    currentMatrix.X += 20;
                                    currentMatrix.Y += 20;
                                    break;
                                }
                            }

                        }

                    }

                }

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
            if (isDragged && movingMatrixID > -1)
            {
                //get current world mouse position
                PointF worldMouseCoord = screenToWorldTranslate(e.Location);

                //new matrix position
                savedMaticies[movingMatrixID].X = worldMouseCoord.X - selectPoint.X;
                savedMaticies[movingMatrixID].Y = worldMouseCoord.Y - selectPoint.Y;

                Canvas.Invalidate();
            }
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragged && movingMatrixID > -1)
            {
                bool collision = false;

                using( Graphics g = this.CreateGraphics())
                {

                    //loop through coordinates of each existing matrix to ensure none intersect

                    Models.Matrix otherMatrix = new Models.Matrix();

                    for (int i = 0; i < matrixID; i++)
                    {
                        //avoid checking coordinates of the dragged matrix with it's old position
                        if(i == movingMatrixID) 
                        { 
                            continue; 
                        }
                        otherMatrix = savedMaticies[i];
                        otherMatrix.hitbox = MatrixBounds(savedMaticies[movingMatrixID], this.CreateGraphics());

                        if (otherMatrix != null)
                        {
                            //get the dymentions of the matrix that is being compared with
                            RectangleF otherMatrixHitBox = MatrixBounds(otherMatrix, g);
                            
                            if(otherMatrix.hitbox.IntersectsWith(otherMatrixHitBox))
                            {
                                collision = true;
                                break;
                            }
                        }

                    }

                    //if the collision happens, the matrix returns back to where it was before the movement

                    if (collision)
                    {
                        currentMatrix.X = startingPosition.X;
                        currentMatrix.Y = startingPosition.Y;
                        MessageBox.Show("Matrices cannot overlap");
                    }

                    isDragged = false;
                    movingMatrixID = -1;
                }
                Canvas.Invalidate();
            }
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            PointF worldMouseLocation = screenToWorldTranslate(e.Location);

            using (Graphics g = this.CreateGraphics())
            {

                for (int i = 0; i < matrixID; i++)
                {
                    Models.Matrix matrix = savedMaticies[i];
                    if (matrix != null)
                    {
                        matrix.hitbox = MatrixBounds(matrix, g);

                        if (matrix.hitbox.Contains(worldMouseLocation))
                        {
                            movingMatrixID = i;
                            isDragged = true;

                            selectPoint = new PointF(worldMouseLocation.X - matrix.X, worldMouseLocation.Y - matrix.Y);

                            startingPosition = new PointF(matrix.X, matrix.Y);

                            break;
                        }
                    }
                }
            }
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(zoomFocus.X, zoomFocus.Y);
            e.Graphics.ScaleTransform(zoomDelta, zoomDelta);

            foreach (var matrix in savedMaticies)
            {
                if (matrix != null)
                {
                    DrawMatrix(e.Graphics, matrix);
                }
            }
        }
        //this loop will compare each strategy length in columns and will save the longest one, this is neccesary as it columns in the matrix are the same and are determined by the longest strategy name
        private float LongestCol(Models.Matrix matrix, Graphics g)
        {
            float longestCol = 0;
            foreach (string s in matrix.ColStrategies)
            {
                SizeF size = g.MeasureString(s, text_font);
                if (size.Width > longestCol)
                {
                    longestCol = size.Width;
                }
            }
            return longestCol;

        }
        private void DrawMatrix(Graphics g, Models.Matrix matrix)
        {
            float cellHight = 60;
            float cellWidth = 100;

            cellWidth = Math.Max(cellHight, LongestCol(matrix,g) + inCellBuffer);

            float gridW = matrix.cols * cellWidth;
            float gridH = matrix.rows * cellHight;

            RectangleF currentGrid = new RectangleF(matrix.X + cellWidth, matrix.Y + cellHight, gridW, gridH);
            g.FillRectangle(Brushes.White, currentGrid);
            g.DrawRectangle(Pens.Black, currentGrid.X, currentGrid.Y, currentGrid.Width, currentGrid.Height);

            using (Pen gridPen = new Pen(Color.Black, 1))
            using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(matrix.Players[0], text_font, Brushes.Black, new PointF(matrix.X - 35, matrix.Y + cellHight + (gridH / 2)), format);
                g.DrawString(matrix.Players[1], text_font, Brushes.Black, new PointF(matrix.X + (gridW/2)+45, matrix.Y - 15));

                for (int r = 0; r < matrix.rows; r++)
                {
                    float rowYcord = matrix.Y + cellHight + (r * cellHight);
                    RectangleF rowStrats = new RectangleF(matrix.X, rowYcord, cellWidth, cellHight);
                    g.DrawString(matrix.RowStrategies[r], text_font, Brushes.Black, rowStrats, format);

                    for (int c = 0; c < matrix.cols; c++)
                    {
                        float colXcrd = matrix.X + cellWidth + (c * cellWidth);

                        if (r == 0)
                        {
                            RectangleF colHeaderRect = new RectangleF(colXcrd, matrix.Y, cellWidth, cellHight);
                            g.DrawString(matrix.ColStrategies[c], text_font, Brushes.Black, colHeaderRect, format);
                        }
                        g.DrawRectangle(gridPen, colXcrd, rowYcord, cellWidth, cellHight);

                        RectangleF cellPic = new RectangleF(colXcrd, rowYcord, cellWidth, cellHight);
                        g.DrawString(matrix.payoffs[r, c], text_font, Brushes.Black, cellPic, format);
                    }
                }
            }
        }

        private void Canvas_MouseWheel(object sender, MouseEventArgs e)
        {

            float canvX = (e.X - zoomFocus.X) / zoomDelta;
            float cnavY = (e.Y - zoomFocus.Y) / zoomDelta;

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

            zoomFocus.X = e.X - (canvX * zoomDelta);
            zoomFocus.Y = e.Y - (cnavY * zoomDelta);

            Canvas.Invalidate();
        }


        //this subroutine will convert screen coordinates to world coordinates which is nessecary for selecting objects on a canvas by clicking on them 
        private PointF screenToWorldTranslate(Point screenCoord)
        {
            float worldX = (screenCoord.X - zoomFocus.X) / zoomDelta;
            float worldY = (screenCoord.Y - zoomFocus.Y) / zoomDelta;
            return new PointF(worldX, worldY);
        }


        //this subroutine will find the bounds of the matrix which I will later use to prevent the user from stacking matrices on top of each other, decreasing the probability of confusion
        private RectangleF MatrixBounds(Models.Matrix matrix, Graphics g)
        {
            float cellHight = 60;

            float cellWidth = Math.Max(cellHight, LongestCol(matrix, g) + inCellBuffer);

            float totalWidth = (matrix.cols * cellWidth) + cellWidth;

            float totalHeight = (matrix.rows * cellHight) + cellHight;

            return new RectangleF(matrix.X, matrix.Y, totalWidth, totalHeight);
        }

        private void SimulationInitialise_Click(object sender, EventArgs e)
        {
            StochasticModification SM = new StochasticModification();
            SM.ShowDialog();
            currentSimulations = SM.itterations;
        }
    }
}