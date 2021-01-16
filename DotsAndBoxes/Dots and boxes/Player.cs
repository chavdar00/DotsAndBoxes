using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Dots_and_boxes
{
    public class Player
    {
        public Color Color { get; set; }
        public virtual void OnTurn(MyRectangle element, List<MyRectangle> rectangles)
        {

        }
        public bool Turn { get; set; }
        public int Score;
    }
}
