using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_2_2
    //Contents:
    //Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.
    //Запросить у пользователя порядковый номер текущего месяца и вывести его название.
    //Определить, является ли введённое пользователем число чётным
    //(*) Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».
    //(*) Расписание офисов через битовые маски не успел сделать, но там по сути та же логика была бы, что и при проверке месяца, см Вариант 3

{
    class Program
    {
        [Flags]
        public enum Month
        { 
            Январь, //0
            Февраль, //1...
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь,    
        }
     
        static void Main(string[] args)
        {

        Start: 
            int check;
            int even = 2;//для Варианта 1
            string IsEven;//Для Варианта 1
            bool flag = false;//для Варианта 2
            
            Console.WriteLine("Please input the NUMBER of current Month");
                string m_number = Console.ReadLine();
                while (!Int32.TryParse(m_number, out check)) { Console.WriteLine("Будь мужиком!Введи НОМЕР месяца"); m_number = Console.ReadLine(); };
                int switcher = Convert.ToInt32(m_number);

            //Вариант 1.Можно было просто прописать каждый случай, например так:
            //if ((switcher % even) == 0) { IsEven = "Четное"; } else { IsEven = "Нечетное"; }
            //if (switcher >= 1 && switcher <= 12)
            //{
            //    if (switcher == 1) { Console.WriteLine($"Январь, {IsEven}"); }
            //    if (switcher == 2) { Console.WriteLine($"{Month.Февраль},{IsEven}"); }
            //    if (switcher == 3) { Console.WriteLine(Month.Март); }//дальще было лень....
            //    if (switcher == 4) { Console.WriteLine(Month.Апрель); }
            //    if (switcher == 5) { Console.WriteLine("Май"); }
            //    if (switcher == 6) { Console.WriteLine("Июнь"); }
            //    if (switcher == 7) { Console.WriteLine("Июль"); }
            //    if (switcher == 8) { Console.WriteLine("Август"); }
            //    if (switcher == 9) { Console.WriteLine("Сентябрь"); }
            //    if (switcher == 10) { Console.WriteLine("Октябрь"); }
            //    if (switcher == 11) { Console.WriteLine(Month.Ноябрь); }
            //    if (switcher == 12) { Console.WriteLine("Декабрь"); }
            //}
            //else { Console.WriteLine("Нет такого месяца"); }


            //Вариант 2. Можно получить массив из перечислений и циклом проверить что ввел пользователь+добавить проверку, если введено несуществующее число для месяца
            //var trick = Enum.GetNames(typeof(Month));

            //for (int i = 1; i <= trick.Length; i++)
            //{
            //    if (switcher == i)
            //    {
            //        if ((switcher % even) == 0) { IsEven = "Четное"; } else { IsEven = "Нечетное"; }
            //        Console.WriteLine($"Ваш месяц: {trick[switcher - 1]}, введенное число - {IsEven}");
            //        flag = true;
            //    };

            //};
            //if (!flag) { Console.WriteLine("Нет такого месяца"); }

            //Вариант 3. Еще я попробовал метод. И решил объединить все задания в 1 проект...Нет, не проект!ПРОЕКТИЩЕ!!!
            string MonthName = GetMonth(switcher);
            int MonthMask= 0; 
            if (switcher == 10) { MonthMask = 0b010111; }//Октябрь
            if (switcher == 11) { MonthMask = 0b011010; }//Ноябрь
            if (switcher == 12) { MonthMask = 0b110000; }//Декабрь

            bool IsWinter = Program.IsWinter(MonthMask);
            
            string e;
            if (Program.IsEven(switcher)) { e = "четный"; } else { e = "нечетный"; };
            Console.WriteLine($"Название месяца:  { MonthName} и еще он {e}");
            Console.WriteLine("Хотите проверить узнать, а была ли дождливая зима? Y/N");
            var repeat = Console.ReadLine();
            if (repeat.Equals("Y") || repeat.Equals("y")) goto Stage2; else goto Start;

            Stage2:
            
            decimal itemptchk;
            Console.WriteLine("Please input min temperature");
            string min_temp = Console.ReadLine();
            while (!Decimal.TryParse(min_temp, out itemptchk)) { Console.WriteLine("Only numbers are available, Please try again"); min_temp = Console.ReadLine(); };
            decimal min_tmp_converted = Convert.ToDecimal(min_temp);

            Console.WriteLine("Please input max temperature");
            string max_temp = Console.ReadLine();
            while (!Decimal.TryParse(max_temp, out itemptchk)) { Console.WriteLine("Only numbers are available, Please try again"); min_temp = Console.ReadLine(); };
            decimal max_tmp_converted = Convert.ToDecimal(max_temp);
            // Можно было написать что-то вроде 'decimal avg = (min_tmp_converted + max_tmp_converted) / 2;'
            //но я решил погуглить, какие еще решения могут быть и наткнулся на расчет среднего через массив.Мне кажется, так более универсально, т.к. среднее значение не будет зависеть от количество введнных данных
            var avg_array = new decimal[] { min_tmp_converted, max_tmp_converted };
            decimal avg = Queryable.Average(avg_array.AsQueryable());
            //
            int WinterMask = 0b_000111;
            int WinterReq = 0b_000001 | 0b_000010 | 0b_000100;
          
            bool iswinter = WinterReq == WinterMask;
            Console.WriteLine($"The average temperature is:  {avg} ");
            if (IsWinter&&avg>0) { Console.WriteLine("Дождливая зима"); }
            Console.ReadLine();


        }
        static bool IsEven(int switcher)
        {
            if ((switcher % 2) == 0) { return true; } else { return false; }
        }
        static string GetMonth(int switcher)
        {
            var Month = Enum.GetNames(typeof(Month));
            string fail="Oh no!Oh no!Oh nonononono";
            for (int i = 1; i <= Month.Length; i++)
            {
                if (switcher == i)
                {
                    string result = Month[switcher - 1];           
                    return result;
                }
            }
            return fail;
        }

        static bool IsWinter(int MonthMask)
        {
            int WinterMask = 0b010111;
            int WinterReq = WinterMask & MonthMask;

            if (WinterReq == WinterMask) { return true; }
            return false;
        }



    }
}
