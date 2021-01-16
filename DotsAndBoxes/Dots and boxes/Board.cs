using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Dots_and_boxes
{
    public class Board
    {
        public static List<MyRectangle> rectangles = new List<MyRectangle>();    
        public Board() { }
        public List<MyRectangle> GetArray()
        {
            Point x = new Point(50, 50);
            Point y = new Point(50, 100);
            for (int i = 0; i < 5; i++)
            {
                y.Y = 100;
                x.Y = 50;
                for (int j = 0; j < 4; j++)
                {
                    MyRectangle rect = new MyRectangle(x.X, x.Y, 1, 50);
                    rect.Position = new Point(x.X, x.Y);
                    rect.Color = Color.Gray;
                    rectangles.Add(rect);
                    x.Y += 50;
                }
                x.X += 50;

            }
            y.Y = 50;
            x.Y = 50;

            for (int i = 0; i <= 4; i++)
            {
                x.X = 50;
                y.X = 100;
                for (int j = 0; j < 4; j++)
                {
                    MyRectangle rect2 = new MyRectangle(x.X, y.Y, 50, 1);
                    rect2.Position = new Point(x.X, y.Y);
                    rect2.Color = Color.Gray;
                    rectangles.Add(rect2);
                    x.X += 50;
                }
                y.Y += 50;

            }
            return rectangles;
        }

        public void DrawCircles(Graphics g)
        {
            int x = 46, y = 46;
            Rectangle rectangle;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    using (var pen = new Pen(Color.Gray, 8))
                    {
                        rectangle = new Rectangle(x, y, 8, 8);
                        g.DrawEllipse(pen, rectangle);
                        y += 50;
                    }

                }
                y = 46;
                x += 50;
            }
        }
        public void DrawSquare(Graphics g, bool flag, Point point, List<MyRectangle> rect, Color color)
        {
            if (flag)
            {
                MyRectangle rect2 = new MyRectangle(point.X +6, point.Y + 6, 40, 40);
                rect2.Position = point;
                rect2.Color = color;
                rect.Add(rect2);
            }         
            foreach (var r in rect)
            {
                using (var brush = new SolidBrush(r.Color))
                {
                    using (var pen = new Pen(Color.Gray, 1))
                    {
                        g.FillRectangle(brush, r.Position.X + 6, r.Position.Y +6, 40, 40);
                    }

                }
            }
        }
        public static MyRectangle AtVertical(int x, int y)
        {
            return rectangles.Where(r => r.Position.X == x && r.Position.Y == y).FirstOrDefault();
        }
        public static MyRectangle AtHorizontal(int x, int y)
        {
            return rectangles.Where(r => r.Position.X == x && r.Position.Y == y).LastOrDefault();
        }
        public static List<MyRectangle> GetNeighbors(MyRectangle rect)
        {
            int x = rect.Position.X, y = rect.Position.Y;
            List<MyRectangle> neighbors = new List<MyRectangle>();
            if (rect.Width == 50)
            {
                if (y > 50 && y < 250)
                {
                    neighbors.Add(AtVertical(x, y - 50));
                    neighbors.Add(AtVertical(x + 50, y - 50));
                    neighbors.Add(AtHorizontal(x, y - 50));
                    neighbors.Add(AtHorizontal(x, y + 50));
                    neighbors.Add(AtVertical(x + 50, y));
                    neighbors.Add(AtVertical(x, y));

                }
                if (y == 50)
                {
                    neighbors.Add(AtVertical(x, y));
                    neighbors.Add(AtVertical(x + 50, y));
                    neighbors.Add(AtHorizontal(x, y + 50));
                }
                if (y == 250)
                {
                    neighbors.Add(AtVertical(x, y - 50));
                    neighbors.Add(AtVertical(x + 50, y - 50));
                    neighbors.Add(AtHorizontal(x, y - 50));
                }
            }
            else
            {
                if (x > 50 && x < 250)
                {
                    neighbors.Add(AtHorizontal(x - 50, y));
                    neighbors.Add(AtHorizontal(x - 50, y + 50));
                    neighbors.Add(AtHorizontal(x, y));
                    neighbors.Add(AtHorizontal(x, y + 50));
                    neighbors.Add(AtVertical(x - 50, y));
                    neighbors.Add(AtVertical(x + 50, y));
                }
                if (x == 50)
                {
                    neighbors.Add(AtHorizontal(x, y));
                    neighbors.Add(AtHorizontal(x, y + 50));
                    neighbors.Add(AtVertical(x + 50, y));
                }
                if (x == 250)
                {
                    neighbors.Add(AtHorizontal(x - 50, y));
                    neighbors.Add(AtHorizontal(x - 50, y + 50));
                    neighbors.Add(AtVertical(x - 50, y));
                }
            }
           
            return neighbors;
        }
        public static void ReturnCounters(List<MyRectangle> neighbors, MyRectangle current, out int br1, out int br2)
        {
            br1 = 0;
            br2 = 0;
            if (neighbors
              .Where(r => r.isClicked)
              .ToList().Count == 6)
            {
                Form1.allneighbors = true;
                if (current.Width > 1)
                    Form1.point2 = new Point(current.Position.X, current.Position.Y - 50);
                else
                    Form1.point2 = new Point(current.Position.X, current.Position.Y);

            }
            foreach (var r in neighbors)
            {

                if (r.isClicked && current != null)
                {
                    if (current.Width > 1)
                    {
                        if (r.Position.Y < current.Position.Y)
                            br1++;
                        else
                            br2++;
                    }
                    else
                        if (r.Position.X < current.Position.X)
                        br1++;
                        else
                        br2++;
                }
            }
        }
    }
}
