using System;
using System.Linq;

namespace Lesson_4
{

    class Program
    {


        public enum Season
        {
            Winter,
            Spring,
            Summer,
            Autumn,
            NoSuchSeason,
        }

        public enum Month { January, February, March, April, May, June, July, August, September, October, November, December }
        static void Main(string[] args)
            

        {
            while (true)
            {
                Console.WriteLine(@"
____________________________________________________________________________________________________
Contents
1 - Задание 1 Написать метод GetFullName(string firstName, string lastName, string patronymic)
2 - Задание 2 Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке
3 - Задание 3. Метод по определению времени года.
4* - Задание 4. Числа Фибоначчи

ESC - Завершить
Please input the task number:
_____________________________________________________________________________________________________
                ");

                ConsoleKeyInfo ch;
                ch = Console.ReadKey();
                Console.WriteLine();
                switch (ch.Key)
                {

                    case ConsoleKey.D1://Задание 1 
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        GetFullName("Эдуард", "Бэкингем", "Васильевич");
                        GetFullName("Самуил", "Конор", "Яковлевич");
                        GetFullName("Иван", "Иванов", "Иванович");
                        GetFullName("Петр", "Петров", "Петрович");
                        GetFullName("Семен", "Горбунков", "Семеныч");
                        break;
                    case ConsoleKey.D2://Задание 2 
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Console.WriteLine("Введите несколько целых чисел, разделяя их пробелом");
                        string req = Console.ReadLine();
                        GetSumInteger(req);

                        break;
                    case ConsoleKey.D3: //Задание 3. 
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Console.WriteLine("Input month number");
                        var stringMonth = Console.ReadLine();
                        if (!int.TryParse(stringMonth, out var month)
                            || (month < 1 || month > 12))
                        {
                            Console.WriteLine("Invalid month.");
                            return;
                        }
                        var season = GetSeason((Month)month - 1);
                        Console.WriteLine(season.ToString());

                        break;
                    case ConsoleKey.D4: //Задание 4. 
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        Console.WriteLine("Please input sequence  to get Fibonacchi  number");
                        int fib = Int32.Parse(Console.ReadLine());
                        Fibonacci(fib);
                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine("TThank you!");
                        return;
                }
            }
            
        }

        static void GetFullName(string firstName, string lastName, string patronymic)
        {
            if (firstName.Contains("Эдуард") & lastName.Contains("Бэкингем"))
            {
                Console.WriteLine("- Имя, сестра!");
                Console.WriteLine($"- {firstName}  { patronymic} { lastName}");
            }
            if (firstName.Contains("Самуил") & lastName.Contains("Конор"))
            { 
                Console.WriteLine("- Ты Сара Конор?");
                Console.WriteLine($"- Нет, я {firstName} { patronymic} { lastName}");
            }
            
            
                Console.WriteLine($"Имя: {firstName} { patronymic} { lastName}");
            
        }

        static void GetSumInteger(string result)
        {
            int sum = 0;
            string[] res = result.Split(' ');
           foreach(var b in res)
            {
                bool IsInt = int.TryParse(b, out _);
                if (IsInt) { sum = sum + Convert.ToInt32(b); }

            }

             Console.WriteLine($"Нажмиии на кнопку, получишь результат:{sum}");
        }

        static void Fibonacci(int x)
        {
            if (x == 0) Console.WriteLine(0);

            int prevseq = 0;
            int nextseq = 1;
            for (int i = 1; i < x; i++)
            {
                int sum = prevseq + nextseq;
                prevseq = nextseq;
                nextseq = sum;
            }
            Console.WriteLine(nextseq);
        }

        static Season GetSeason(Month month)
        {
            
            var monthSeasons = GetMothSeasonsFromSettings();

            foreach (var monthSeason in monthSeasons)
            {
                if (monthSeason.Month == month)
                    return monthSeason.Season;
               
            }
            return Season.NoSuchSeason;//пришлось добавить, потому что не знаю как по-другому можно вернуть.Но учитывая, что перед заходом в метод проверяем, что введено число от 1 до 12 сюда приходить вообще никогда не должны
            
            //Начал с такого, но как-то не оч понравилось((
            //return month switch
            //{
            //    >= 0 and < 3 => Season.Winter,
            //    >= 3 and < 6 => Season.Spring,
            //    >= 6 and < 9 => Season.Summer,
            //    _ => Season.Summer
            //};
        }

        public static MonthSeason[] GetMothSeasonsFromSettings()
        {
            return new[]
            {
                new MonthSeason {Month = Month.January, Season = Season.Winter},
                new MonthSeason {Month = Month.February, Season = Season.Winter},
                new MonthSeason {Month = Month.March, Season = Season.Spring},
                new MonthSeason {Month = Month.April, Season = Season.Spring},
                new MonthSeason {Month = Month.May, Season = Season.Spring},
                new MonthSeason {Month = Month.June, Season = Season.Summer},
                new MonthSeason {Month = Month.July, Season = Season.Summer},
                new MonthSeason {Month = Month.August, Season = Season.Summer},
                new MonthSeason {Month = Month.September, Season = Season.Autumn},
                new MonthSeason {Month = Month.October, Season = Season.Autumn},
                new MonthSeason {Month = Month.November, Season = Season.Autumn},
                new MonthSeason {Month = Month.December, Season = Season.Winter},
            };
        }
        public sealed class MonthSeason
        {
            public Month Month { get; set; }
            public Season Season { get; set; }
        }
    }



}
  





    

