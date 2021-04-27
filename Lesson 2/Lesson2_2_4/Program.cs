using System;
using System.Collections.Generic;

namespace Lesson2_2_4
{
    class Program
    {


        static void Main(string[] args)
        {
            int xZeroPosition = 2;
            int yZeroPostion = 0;
            int xUltimatePosition = 85;

            int delNamePos = 26;
            int delPricePos = 36;
            int delTaxPos = 46;
            int delQuantPos = 56;
            int delAdultPos = 87;

        string company = "ООО Рога и Копыта";
            Goods gl = new Goods();
            int q = qSymbols(company);
            int c_position = cposition(xUltimatePosition, q);
            //Console.SetBufferSize(80, 25);
            Frame flist = new Frame(xUltimatePosition, 25);
            flist.Draw();
            Console.SetCursorPosition(c_position, yZeroPostion);
            Console.WriteLine(company);
            Console.SetCursorPosition(xZeroPosition, ++yZeroPostion);
            Console.WriteLine("Спасибо, что выбрали нас!");
            Console.SetCursorPosition(xZeroPosition, ++yZeroPostion);
            Console.WriteLine($"СПИСОК ВАШИХ ВОНЮЧИХ ПОКУПОК НА СЕГОДНЯ({System.DateTime.Now})");
            Console.SetCursorPosition(xZeroPosition, ++yZeroPostion);
            Console.WriteLine("Название");
            Console.SetCursorPosition(delNamePos, yZeroPostion);
            Console.WriteLine("Цена");
            Console.SetCursorPosition(delPricePos, yZeroPostion);
            Console.WriteLine("Налог");
            Console.SetCursorPosition(delTaxPos, yZeroPostion);
            Console.WriteLine("Количество");
            Console.SetCursorPosition(delQuantPos, yZeroPostion);
            Console.WriteLine("Наличие паспорта");
            Console.SetCursorPosition(delAdultPos, yZeroPostion);

            gl.goodlist("Сигареты'Друг'", 200, 1, xZeroPosition, ++yZeroPostion);
            gl.goodlist("Сметана 'Кумир молодежи'", 58.6, 1, xZeroPosition, ++yZeroPostion);
            gl.goodlist("Напиток 'Вкусная Пепси'", 124, 1, xZeroPosition, ++yZeroPostion);

            Console.SetCursorPosition(0, 24);
        }

        static int qSymbols(string x)
        {
            int result = x.Length;
            return result;
        }

        static int cposition(int xUltimatePosition, int StringLenght)
        {
            return (xUltimatePosition - StringLenght )/ 2;
        }
    }
}
