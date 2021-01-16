using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Dots_and_boxes
{
   public class MyRectangle
    {
        public Point Position { get; set; }
        public Color Color { get; set; }
        public bool isClicked = false;
        public  int _x, _y, _width, _height;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {               
                    _width = value;
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {              
                    _height = value;
            }
        }
        public  bool Contains(Point point)
        {
            return Position.X-2 < point.X && (Position.X + Width +4) > point.X &&
                Position.Y-2 < point.Y && (Position.Y + Height +4) > point.Y;
        }
        
        public MyRectangle(int x,int y,int width,int height)
        {
            _x = x;
            _y = y;
            Width = width;
            Height = height;
            Color = Color.DarkGray;
        }


        public void Draw(Graphics g)
        {
            using(var myPen = new Pen(Color,5))
            {              
                g.DrawRectangle(myPen, Position.X, Position.Y, _width, _height);
            }            
        }   
        
    }
}
