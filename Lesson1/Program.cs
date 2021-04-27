using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What's your name? ");
            string name = Console.ReadLine();
            Console.WriteLine($"Привет, имя пользователя {name}, а вот имя Вашего компьютера {Environment.UserName}, сегодня {DateTime.Today.ToString("dd/MM/yyyy")}");
            Console.WriteLine("А еще я тут поэкспериментировал и....");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Немного потренировался....не судите строго, это допотопный калькулятор (где я также демонстрирую свой великолепный английский, хахахах)");
            Console.WriteLine("Поехали!");
        Start:
            Console.WriteLine("Please input param1");
            var param1 = Console.ReadLine();
            decimal value;
            while (!Decimal.TryParse(param1, out value)) { Console.WriteLine("Only numbers are availbale! Try again"); goto Start; };
        Start2:
            Console.WriteLine("Please input param2");
            var param2 = Console.ReadLine();
            while (!Decimal.TryParse(param2, out value)) { Console.WriteLine("Only numbers are availbale! Try again"); goto Start2; };

        OpsChoose:
            Console.WriteLine("'sum' - will summarize parameters(param1+param2)");
            Console.WriteLine("'dif' - will subtract the first parameter from the second(param1-param2)");
            Console.WriteLine("'mul' - will multiply parametrs (param1*param2)");
            Console.WriteLine("'div' - will divide parametrs (param1/param2)");
            Console.WriteLine("Please choose operation from above");
            var ops = Console.ReadLine();

            decimal sum = Decimal.Parse(param1) + Decimal.Parse(param2);
            decimal dif = Decimal.Parse(param1) - Decimal.Parse(param2);
            decimal div = Decimal.Parse(param1) / Decimal.Parse(param2);
            decimal mul = Decimal.Parse(param1) * Decimal.Parse(param2);

            if (ops.Equals("sum")) { Console.WriteLine($"param1 + param2 = " + sum); goto Finish; }
            if (ops.Equals("dif")) { Console.WriteLine($"param1 - param2 = " + dif); goto Finish; }
            if (ops.Equals("mul")) { Console.WriteLine($"param1 * param2 = " + mul); goto Finish; }
            if (ops.Equals("div")) { Console.WriteLine($"param1 / param2 = " + div); goto Finish; }

            else
                Console.WriteLine("Error! Please try again");
            goto OpsChoose;
        Finish:
            Console.WriteLine("Thank you for using this crap. Please don't laugh about the code, I'm still learning ;)");
            Console.WriteLine("Type Y if you wanna go again");
            var repeat = Console.ReadLine();
            if (repeat.Equals("Y") || repeat.Equals("y")) goto Start; else goto Finish;

        }
    }
}
