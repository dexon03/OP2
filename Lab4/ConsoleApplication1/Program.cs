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
            Console.Write("Введіть дату в форматі DD.MM.YYYY або DD.MM: ");
            for (int i = 0; i < 2; i++)
            {
                string line = Console.ReadLine();
                dates.Add(Data.Parse(line));
            }

        }
    }
}