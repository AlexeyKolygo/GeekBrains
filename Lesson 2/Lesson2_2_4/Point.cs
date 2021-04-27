using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2_2_4
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;

        }

        public void Drow()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);

        }
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }
        
        public void Clear()
        {
            sym = ' ';
            Drow();
        }
        
    }
}
