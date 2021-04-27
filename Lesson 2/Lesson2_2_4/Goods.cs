using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;


namespace Lesson2_2_4
{
    class Goods 
    {
        public int delNamePos = 26;
        public int delPricePos = 36;
        public int delTaxPos = 46;
        public int delQuantPos = 56;
        public int delAdultPos = 87;

        public Goods()
        {
          
        }

        public bool Is18(string name)
        {
            if (name.Contains("Сигареты", StringComparison.OrdinalIgnoreCase)) { return true; }
            return false;
       
        
       }

        public void goodlist(string _name, double _amount, int _quantity,int xposition,int zposition)
        {
        
            double tax = _amount *0.2;
            bool is18 = Is18(_name);
            int DNamePos = delNamePos+1;
            int DAmPos = delPricePos+1;
            int DTaxPos = delTaxPos+1;
            int DQPos = delQuantPos + 1;
            Console.SetCursorPosition(xposition, zposition);
            Console.WriteLine(_name);
            Console.SetCursorPosition(DNamePos, zposition);
            Console.WriteLine(_amount);
            Console.SetCursorPosition(DAmPos, zposition);
            Console.WriteLine(tax);
            Console.SetCursorPosition(DTaxPos, zposition);
            Console.WriteLine(_quantity);
            Console.SetCursorPosition(DQPos, zposition);
            Console.WriteLine(is18);
           
        }

       
    }


    
}
