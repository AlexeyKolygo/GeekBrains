using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2_2_4
{
    class Frame
    {
        List<Figure> flist;
        public int delNamePos = 26;
        public int delPricePos = 36;
        public int delTaxPos = 46;
        public int delQuantPos = 56;
        public int delAdultPos = 87;
        public Frame(int mapWidth, int mapHeight)
        {
            flist = new List<Figure>();
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine Leftline = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine Rightline = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');
            VerticalLine DelimetrName = new VerticalLine(4, mapHeight - 1, delNamePos, '|');
            VerticalLine DelimetrPrice = new VerticalLine(4, mapHeight - 1, delPricePos, '|');
            VerticalLine DelimetrTax = new VerticalLine(4, mapHeight - 1, delTaxPos, '|');
            VerticalLine DelimetrQuant = new VerticalLine(4, mapHeight - 1, delQuantPos, '|');


            flist.Add(upLine);
            flist.Add(downLine);
            flist.Add(Leftline);
            flist.Add(Rightline);
            flist.Add(DelimetrName);
            flist.Add(DelimetrPrice);
            flist.Add(DelimetrTax);
            flist.Add(DelimetrQuant);

        }
  

        public void Draw()
        {
            foreach (var frame in flist)
            { frame.Draw(); }
        }
    }
}
