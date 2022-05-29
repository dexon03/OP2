using System;
using System.Collections.Generic;
using static Lab5.Functions;

namespace Lab5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Скільки об'єктів TDate1 бажаєте створити: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Скільки об'єктів TDate2 бажаєте створити: ");
            int m = int.Parse(Console.ReadLine());
            List<TDate1> listOfDate1 = new List<TDate1>();
            Input1(listOfDate1,n);
            Console.WriteLine();
            List<TDate2> listOfDate2 = new List<TDate2>();
            Input2(listOfDate2,m);
            Console.WriteLine();
            string oldestDate = OldestDate(listOfDate1, listOfDate2);
            Console.WriteLine("Самя пізня дата: " + oldestDate);
            Console.WriteLine();
            Console.WriteLine("Введіть проміжок дат в одному з двох форматів");
            Console.Write("Початок: ");
            string begin;
            while (true)
            {
                begin = Console.ReadLine();
                if(isValid1(begin) || isValid2(begin)) break;
                Console.Write("Ви ввели в неправильному форматі, спробуйте ще раз: ");
            }
            Console.Write("Кінець: ");
            string end;
            while (true)
            {
                end = Console.ReadLine();
                if (isValid1(end) || isValid2(end)) break;
                Console.Write("Ви ввели в неправильному форматі, спробуйте ще раз: ");
            }
            List<string> resultList = ListDatesBetween(listOfDate1, listOfDate2, begin, end);
            Console.WriteLine("Результат:");
            if (resultList.Count == 0)
            {
                Console.WriteLine("Немає дат з цього проміжку");
            }
            else
            {
                for (int i = 0; i < resultList.Count; i++)
                {
                    Console.WriteLine($"Дата {i+1}: {resultList[i]}");
                }
            }
            
        }
    }
}