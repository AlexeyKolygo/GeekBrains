using System;
using System.Collections.Generic;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)

        {
            while (true)
            {
                Console.WriteLine(@"
____________________________________________________________________________________________________
Contents
1 - Задание 1 Написать программу, выводящую элементы двумерного массива по диагонали.
2 - Задание 2 «Телефонный справочник».
3 - Задание 3. Написать программу, выводящую введенную пользователем строку в обратном порядке.
4* - Задание 4. Морской бой.
5* - Задание 5. Числа Фибоначчи
ESC - Завершить
Please input the task number:
_____________________________________________________________________________________________________
                ");

                ConsoleKeyInfo ch;
                ch = Console.ReadKey();
                Console.WriteLine();
                switch (ch.Key)
                {

                    case ConsoleKey.D1://Задание 1 Написать программу, выводящую элементы двумерного массива по диагонали.
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        Console.WriteLine("Please input array range");
                        string input = Console.ReadLine();
                        GetDiagon(Int32.Parse(input));
                        break;
                    case ConsoleKey.D2://Задание 2 «Телефонный справочник»
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Console.WriteLine("Please input PhoneBook size");
                        int x = Int32.Parse(Console.ReadLine());//Чтоб было как в задании, надо указать 5
                        PhoneBook(x);
                        break;
                    case ConsoleKey.D3: //Задание 3. Написать программу, выводящую введенную пользователем строку в обратном порядке
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Console.WriteLine("Please input string to inverse");
                        string inverse = Console.ReadLine();
                        Inverse(inverse);
                        break;
                    case ConsoleKey.D4: //Задание 4. Написать программу, выводящую введенную пользователем строку в обратном порядке
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        WarShipsGenerator(10, 10);
                        break;
                    case ConsoleKey.D5://Задание 5. Получить число фибоначчи
                    case ConsoleKey.NumPad5:
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

        static void GetDiagon(int x)
        {
            int y = x;
            int[,] arr = new int[x, y];
            Console.WriteLine("Output:");
            for (int i = 0; i < x; i++)
            {
                int x1 = 0; int y1 = 0; int inverse = x - i - 1;
                Console.WriteLine($"{ arr[x1, i] = i}{ arr[i, y1] = inverse}");
            }

        }
        static void PhoneBook(int n)
        {
            string[,] contacts = new string[n, 2];

            for (int i = 0; i < n; i++)
            {

                Console.WriteLine("Input contact name");
                string contactname = Console.ReadLine();
                Console.WriteLine("Input contact credentials(phone or email)");
                string contact = Console.ReadLine();
                contacts[i, 0] = contactname;
                contacts[i, 1] = contact;
            }
            int x;
            Console.WriteLine("Your contact list:");
            for (x = 0; x < n; x++) { Console.WriteLine($"Contact#:{x + 1} {contacts[x, 0]},{contacts[x, 1]}"); }
        }

        static void Inverse(string inverse)
        {
            int n = 1;
            int i = 0;

            List<char> inv = new List<char>(); // вариант 1 через класс листа
            char[] inv2 = new char[inverse.Length];// вариант 2 через массив

            foreach (char x in inverse)
            {

                char a = inverse[inverse.Length - n];
                char b = inverse[inverse.Length - i - 1];
                n++;
                i++;
                inv2[i - 1] = b;

                inv.Add(a);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Inversion with List class:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(inv.ToArray());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Inversion with array:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(inv2);


        }

        static void WarShipsGenerator(int x, int y)
        {
            string[,] field = new string[x, y];

            int c = field.Length - 1;
            string c1 = c.ToString();
            int _x = Int32.Parse((c1[c1.Length - 1]).ToString());
            int _y = Int32.Parse((c1[c1.Length - 2]).ToString());

            for (int i = 0; i < field.Length; i++)
            {
                if (_y < 0) { Console.WriteLine(); _x--; _y = y - 1; }


                char n = 'O';
                Random random = new Random();
                decimal r = random.Next(1, x);
                if (r >= x - 2) { n = 'X'; }

                Console.Write(field[_x, _y] = n.ToString());
                _y--;
            }

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
    }
}
