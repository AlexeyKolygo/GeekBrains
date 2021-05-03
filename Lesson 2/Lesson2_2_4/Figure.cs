using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2_2_4
{
    class Figure
    {
        protected List<Point> plist;
        public void Draw()
        {
            foreach (Point p in plist)
            { p.Drow(); }
        }
    }
}