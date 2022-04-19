using System;
using System.Collections.Generic;
using static ConsoleApplication1.Functions;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Data> dates = new List<Data>();
            
            for (int i = 0; i <= 2; i++)
            {
                Console.Write("Введіть дату в форматі DD.MM.YYYY або DD.MM: ");
                string line;
                while (true)
                {
                    line = Console.ReadLine();
                    if (isValid(line)) break;
                    Console.Write("Ви ввели дату в неправильному форматі, спробуйте ще раз: ");
                }
                dates.Add(Data.Parse(line));
            }

            ++dates[0];
            Console.WriteLine("Дата D1 збільшена на 1 місяць:");
            dates[0].Print();
            --dates[1];
            Console.WriteLine("Дата D2 збільшена на 1 день:");
            dates[1].Print();
            if (dates[0] > dates[1])
            {
                Console.WriteLine("D1 більше пізня");
            }else Console.WriteLine("D2 більш пізня");

            Console.WriteLine("Для D3 до кінця року залишилось " + Data.RemainedUntilEndOfTheYear(dates[2]) + "днів");

        }
    }
}