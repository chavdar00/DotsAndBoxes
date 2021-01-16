using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dots_and_boxes
{
    public partial class Form1 : Form
    {
        static Human human = new Human();
        static Computer computer = new Computer();
        Board b = new Board();
        static MyRectangle selected = null;
        List<MyRectangle> rect = new List<MyRectangle>();
        public static List<MyRectangle> rectangles = new List<MyRectangle>();
        static bool flag = false;
        bool gameover = false;
        public static Point point = new Point(0, 0);
        public static Point point2 = new Point(0, 0);
        public static bool allneighbors = false;
        static Color sqcolor = Color.Empty;
        public Form1() => InitializeComponent();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            labelComputerScore.Text = computer.Score.ToString();
            labelHumanScore.Text = human.Score.ToString();
            labelComputerScore.Refresh();
            labelHumanScore.Refresh();
            label1.Refresh();
            label3.Refresh();
            Winerlabel.Refresh();
            PlayAgainButton.Refresh();
            Graphics graphics = e.Graphics;
            foreach (var r in rectangles)
            {
                r.Draw(graphics);
            }

            b.DrawCircles(graphics);
            b.DrawSquare(graphics, flag, point, rect, sqcolor);

            if (allneighbors)
            {
                b.DrawSquare(graphics, flag, point2, rect, sqcolor);
                allneighbors = false;
            }
            flag = false;
            if (computer.Turn && !gameover)
            {
                Cmove();
            }
            if (Computer.NotClicked(rectangles).Count == 0) gameover = true;    
            
            Invalidate();
            if (gameover)
            {
                if (computer.Score > human.Score)
                {
                    Winerlabel.ForeColor = Color.Red;
                    Winerlabel.Text = "COMPUTER WINS!";
                }
                else if (computer.Score < human.Score)
                {
                    Winerlabel.ForeColor = Color.Blue;
                    Winerlabel.Text = "YOU WIN!";
                }
                else Winerlabel.Text = "YOU ARE TIED!";
                PlayAgainButton.Visible = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rectangles = b.GetArray();
        }
        private void Cmove()
        {
            if (!gameover)
                selected = Computer.Move(rectangles);

            if (selected != null && selected.isClicked == false)
            {
                rectangles.Where(r => r == selected)
                   .FirstOrDefault().isClicked = true;
                selected.Color = computer.Color;
                var selectedNeighbors = Board.GetNeighbors(selected);

                int br1 = 0, br2 = 0, minx, miny;
                if (selectedNeighbors
                  .Where(r => r.isClicked)
                  .ToList().Count == 6)
                {
                    allneighbors = true;
                    if (selected.Width > 1)
                        point2 = new Point(selected.Position.X, selected.Position.Y - 50);
                    else
                        point2 = new Point(selected.Position.X, selected.Position.Y);

                }
                foreach (var r in selectedNeighbors)
                {

                    if (r.isClicked && selected != null)
                    {

                        if (selected.Width > 1)
                        {
                            if (r.Position.Y < selected.Position.Y)
                                br1++;
                            else
                                br2++;
                        }
                        else
                            if (r.Position.X < selected.Position.X)
                            br1++;
                        else
                            br2++;

                    }

                    if (br1 == 3 || br2 == 3)
                    {
                        minx = Math.Min(r.Position.X, selected.Position.X);
                        miny = Math.Min(r.Position.Y, selected.Position.Y);
                        flag = true;
                        point = new Point(minx, miny);
                        // MessageBox.Show(br1.ToString() + " "+ br2.ToString());
                        if (human.Turn)
                            sqcolor = human.Color;
                        else
                            sqcolor = computer.Color;
                        br1 = 0;
                        br2 = 0;

                    }
                }
                if (flag)
                {
                    human.Turn = false;
                    computer.Turn = true;
                    computer.Score++;
                    if (allneighbors) computer.Score++;
                }
                else
                {
                    human.Turn = true;
                    computer.Turn = false;
                }
                selected = null;
            }
            Invalidate();
        }
        void RestartGame()
        {
            foreach(var r in rectangles)
            {
                r.isClicked = false;
                r.Color = Color.Gray;
            }
            
            human.Score = 0;
            computer.Score = 0;
            Winerlabel.Text = "";
            gameover = false;
            rect.Clear();
            PlayAgainButton.Visible = false;
            Invalidate();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (human.Turn)
                {
                    selected = rectangles
                      .Where(r => r.Contains(e.Location))
                      .FirstOrDefault();

                    if (selected != null && selected.isClicked == false)
                    {
                        rectangles
                          .Where(r => r == selected)
                          .FirstOrDefault().isClicked = true;
                        selected.Color = human.Color;

                        var selectedNeighbors = Board.GetNeighbors(selected);
                        int br1 = 0, br2 = 0, minx, miny;
                        if (selectedNeighbors
                          .Where(r => r.isClicked)
                          .ToList().Count == 6)
                        {
                            allneighbors = true;
                            if (selected.Width > 1)
                                point2 = new Point(selected.Position.X, selected.Position.Y - 50);
                            else
                                point2 = new Point(selected.Position.X, selected.Position.Y);

                        }
                        foreach (var r in selectedNeighbors)
                        {

                            if (r.isClicked && selected != null)
                            {

                                if (selected.Width > 1)
                                {
                                    if (r.Position.Y < selected.Position.Y)
                                        br1++;
                                    else
                                        br2++;
                                }
                                else
                                    if (r.Position.X < selected.Position.X)
                                    br1++;
                                else
                                    br2++;

                            }

                            if (br1 == 3 || br2 == 3)
                            {
                                minx = Math.Min(r.Position.X, selected.Position.X);
                                miny = Math.Min(r.Position.Y, selected.Position.Y);
                                flag = true;
                                point = new Point(minx, miny);
                                if (human.Turn)
                                    sqcolor = human.Color;
                                else
                                    sqcolor = computer.Color;
                                br1 = 0;
                                br2 = 0;

                            }
                        }

                        if (flag)
                        {
                            human.Turn = true;
                            computer.Turn = false;
                            human.Score++;
                            if (allneighbors) human.Score++;
                        }
                        else
                        {
                            human.Turn = false;
                            computer.Turn = true;
                        }
                        selected = null;
                    }
                }
            }
            Invalidate();
        }

        private void PlayAgainButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
