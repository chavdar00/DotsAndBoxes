using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dots_and_boxes
{
    class Human: Player
    {       public new Color Color = Color.Blue;
            public new bool Turn = true;
            public new int Score;
        public override void OnTurn(MyRectangle selected, List<MyRectangle> rectangles)
        {
                if (selected != null && selected.isClicked == false)
                {
                    rectangles
                      .Where(r => r == selected)
                      .FirstOrDefault().isClicked = true;
                    selected.Color = Color;
                    Turn = false;                   
                }
            
        }

    }
}
