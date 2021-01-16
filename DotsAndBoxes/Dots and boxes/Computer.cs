using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Dots_and_boxes
{
    class Computer : Player
    {
        public new Color Color = Color.Red;
        public new bool Turn = false;
        public static MyRectangle Move(List<MyRectangle> rectangles)
        {
            List<MyRectangle> AllExeptTwoSides = NotClicked(rectangles).Except(TwoSides(rectangles)).ToList();
            if (ThreeSides(rectangles).Any())
                return CloseSquare(rectangles);
            else if (AllExeptTwoSides.Any())
                return PickRandomRectangle(AllExeptTwoSides);
            else
                return PickRandomRectangle(rectangles);
        }
        public static List<MyRectangle> NotClicked(List<MyRectangle> rectangles)
        {
            List<MyRectangle> notClicked = rectangles
                .Where(r => r.isClicked == false)
                .ToList();
            return notClicked;
        }
        public static MyRectangle PickRandomRectangle(List<MyRectangle> rectangles)
        {
            Random random = new Random();
            var notClicked = NotClicked(rectangles);
            return notClicked[random.Next(notClicked.Count - 1)];
        }
        public static List<MyRectangle> GetSidesCount(List<MyRectangle> rectangles, int a, int b)
        {
            List<MyRectangle> Sides = new List<MyRectangle>();
            var notClicked = NotClicked(rectangles);

            foreach (var r in notClicked)
            {
                int br1, br2;
                var neighbors = Board.GetNeighbors(r);
                Board.ReturnCounters(neighbors, r, out br1, out br2);
                if (br1 == a || br2 == b)
                {
                    Sides.Add(r);
                }
            }
            return Sides;
        }
        public static List<MyRectangle> ThreeSides(List<MyRectangle> rectangles)
        {
            int a = 3, b = 3;
            List<MyRectangle> threeSides = GetSidesCount(rectangles, a, b);

            return threeSides;
        }

        public static List<MyRectangle> TwoSides(List<MyRectangle> rectangles)
        {
            int a = 2, b = 2;
            List<MyRectangle> twoSides = GetSidesCount(rectangles, a, b);

            return twoSides;
        }
        public static MyRectangle CloseSquare(List<MyRectangle> rectangles)
        {
            Random random = new Random();
            var threeSides = ThreeSides(rectangles);

            return threeSides[random.Next(threeSides.Count - 1)];
        }

    }
}
